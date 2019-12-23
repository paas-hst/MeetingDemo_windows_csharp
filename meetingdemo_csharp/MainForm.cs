using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using fspclr;

namespace meetingdemo_csharp
{
    public partial class MainForm : CommonForm
    {
        //
        // Properties
        //

        // Currernt audio parameters 
        public int CurMicId { get; set; }   // Current used microphone
        public int CurSpkId { get; set; }   // Current used speaker
        public int SpkVolumn { get; set; }  // Current speaker volumn
        public int MicVolumn { get; set; }  // Current microphon volumn

        // Screen share parameters
        public ScreenShareQualityBiasClr ShareQosType { get; set; }
        public ScreenShareMode ShareMode { get; set; }
        public System.Drawing.Rectangle ShareRegion { get; set; }

        // Local record parameters
        public String RecordSavePath { get; set; }

        // Current video profile
        //public VideoProfileClr curVideoProfile { get; set; }    

        //
        // Types
        //

        private struct GroupUserInfo
        {
            public String userName;
            public bool broadcast_audio;
            public bool broadcast_video;
            public bool broadcast_screenshare;
        }

        private enum UserStateType
        {
            USER_STATE_AUDIO = 2,
            USER_STATE_VIDEO = 3,
            USER_STATE_SHARE = 4
        }

        private struct GroupMsg
        {
            public String senderUserId;
            public String content;
            public DateTime sendTime;
            public String toUserId; 
        }

        //
        // Member variables
        //

        // User list of the group
        private List<GroupUserInfo> groupUsers = new List<GroupUserInfo>();

        // Messages of the group
        private List<GroupMsg> groupMsgs = new List<GroupMsg>();

        // Manage all the video panels including the tab
        private VideoPanelMgr videoPanelMgr = null;

        // Toolbar button backgroud image control
        private bool micBtnClicked = false;
        private bool speakerBtnClicked = false;
        private bool camBtnClicked = false;
        private bool vncBtnClicked = false;
        private bool inviteBtnClicked = false;
        private bool settingBtnClicked = false;
        private bool recordBtnClicked = false;

        // Allowed to publish two local cameras 
        private System.Collections.Generic.HashSet<int> publishedCamSet = new HashSet<int>();

        // Override from CommonForm
        protected override void OnFormClosed()
        {
            CloseMainForm();

            SdkManager.Instance().OnlineForm.Show();
        }

        public MainForm()
        {
            InitializeComponent();

            this.HasMinBox = true;
            this.HasMaxBox = true;
            this.HasCloseBox = true;

            SdkManager.Instance().MainForm = this;

            // Default microphone and speaker
            CurMicId = CurSpkId = 0;
            SdkManager.Instance().SetCurrentMicrophone(CurMicId);
            SdkManager.Instance().SetCurrentSpeaker(CurSpkId);

            // Default volumn of microphone and speaker
            MicVolumn = SpkVolumn = 50;
            SdkManager.Instance().SetMicVolumn(MicVolumn);
            SdkManager.Instance().SetSpkVolumn(SpkVolumn);

            // Default to share desktop
            ShareMode = ScreenShareMode.SCREEN_SHARE_MODE_DESKTOP;
            ShareQosType = ScreenShareQualityBiasClr.CLR_SCREEN_SHARE_BIAS_QUALITY;
            ShareRegion = new Rectangle(0, 0, 0, 0);

            // Default record path
            RecordSavePath = "";

            videoPanelMgr = new VideoPanelMgr(this.tab_panel, this.video_panel);
        }

        #region "Initialization"
        private void InitUserListView()
        {
            this.users_datagridview.Columns.Add(new DataGridViewImageColumn());
            this.users_datagridview.Columns.Add(new DataGridViewTextBoxColumn());
            this.users_datagridview.Columns.Add(new DataGridViewImageColumn());
            this.users_datagridview.Columns.Add(new DataGridViewImageColumn());
            this.users_datagridview.Columns.Add(new DataGridViewImageColumn());

            this.users_datagridview.Columns[0].Width = 40;
            this.users_datagridview.Columns[1].Width = 100;
            this.users_datagridview.Columns[2].Width = 30;
            this.users_datagridview.Columns[3].Width = 30;
            this.users_datagridview.Columns[4].Width = 30;
        }

        private void InitUserCombobox()
        {
            this.users_combobox.Items.Add("所有人");

            this.users_combobox.SelectedIndex = users_combobox.Items.IndexOf("所有人");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            group_label.Text = String.Format("分组ID：{0}", SdkManager.Instance().GroupId);

            InitUserListView();

            InitUserCombobox();

            videoPanelMgr.SwitchToVideoPanel();
        }
        #endregion

        #region "Event handler"
        public void RemoteAudioEventHandler(String userId, RemoteAudioEventClr remoteAudioEvent)
        {
            if (remoteAudioEvent == RemoteAudioEventClr.CLR_REMOTE_AUDIO_EVENT_PUBLISHE_STARTED)
            {
                videoPanelMgr.AddRemoteAudio(userId);
                UpdateUserState(userId, UserStateType.USER_STATE_AUDIO, true);
            }
            else if (remoteAudioEvent == RemoteAudioEventClr.CLR_REMTOE_AUDIO_EVENT_PUBLISHE_STOPED)
            {
                videoPanelMgr.DelRemoteAudio(userId);
                UpdateUserState(userId, UserStateType.USER_STATE_AUDIO, false);
            }
        }

        public void RemoteVideoEventHandler(String userId, String videoId, RemoteVideoEventClr remoteVideoEvent)
        {
            if (remoteVideoEvent == RemoteVideoEventClr.CLR_REMOTE_VIDEO_EVENT_PUBLISHE_STARTED)
            {
                videoPanelMgr.AddRemoteVideo(userId, videoId);

                if (videoId == SdkManager.Instance().RESERVED_VIDEOID_SCREENSHARE)
                {
                    UpdateUserState(userId, UserStateType.USER_STATE_SHARE, true);
                }
                else
                {
                    UpdateUserState(userId, UserStateType.USER_STATE_VIDEO, true);
                }
            }
            else if (remoteVideoEvent == RemoteVideoEventClr.CLR_REMOTE_VIDEO_EVENT_PUBLISHE_STOPED)
            {
                videoPanelMgr.DelRemoteVideo(userId, videoId);

                if (videoId == SdkManager.Instance().RESERVED_VIDEOID_SCREENSHARE)
                {
                    UpdateUserState(userId, UserStateType.USER_STATE_SHARE, false);
                }
                else
                {
                    UpdateUserState(userId, UserStateType.USER_STATE_VIDEO, false);
                }
            }
        }

        public void GroupUserRefreshedHandler(List<String> userList)
        {
            foreach (String user in userList)
            {
                GroupUserInfo groupUser;
                groupUser.userName = user;
                groupUser.broadcast_audio = false;
                groupUser.broadcast_video = false;
                groupUser.broadcast_screenshare = false;

                groupUsers.Add(groupUser);
            }

            UpdateGroupUserList();
        }

        public void RemoteUserEventHandler(String remoteUserId, RemoteUserEventTypeClr eventType)
        {
            if (eventType == RemoteUserEventTypeClr.CLR_REMOTE_USER_EVENT_GROUP_JOINED)
            {
                GroupUserInfo groupUser;
                groupUser.userName = remoteUserId;
                groupUser.broadcast_audio = false;
                groupUser.broadcast_video = false;
                groupUser.broadcast_screenshare = false;

                groupUsers.Add(groupUser);
            }
            else // CLR_REMOTE_USER_EVENT_GROUP_LEAVED
            {
                foreach (GroupUserInfo user in groupUsers)
                {
                    if (user.userName == remoteUserId)
                    {
                        groupUsers.Remove(user);
                        break;
                    }
                }
            }

            UpdateGroupUserList();
        }

        public void UserMsgComeHandler(String senderUserId, int msgId, String msg)
        {
            GroupMsg message;
            message.senderUserId = senderUserId;
            message.content = msg;
            message.sendTime = System.DateTime.Now;
            message.toUserId = SdkManager.Instance().UserId;

            groupMsgs.Add(message);

            UpdateMsgTextbox();
        }

        public void GroupMsgComeHandler(String senderUserId, int msgId, String msg)
        {
            GroupMsg message;
            message.senderUserId = senderUserId;
            message.content = msg;
            message.sendTime = System.DateTime.Now;
            message.toUserId = "";

            groupMsgs.Add(message);

            UpdateMsgTextbox();
        }
        #endregion

        #region "Toolbar operations"
        private void toolbar_setting_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_setting_btn.BackgroundImage = Properties.Resources.setting_hover;
        }

        private void toolbar_setting_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!settingBtnClicked)
                toolbar_setting_btn.BackgroundImage = Properties.Resources.setting_normal;
            else
                toolbar_setting_btn.BackgroundImage = Properties.Resources.setting_pressed;
        }

        private void toolbar_invite_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!inviteBtnClicked)
                toolbar_invite_btn.BackgroundImage = Properties.Resources.invite_normal;
            else
                toolbar_invite_btn.BackgroundImage = Properties.Resources.invite_pressed;
        }

        private void toolbar_invite_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_invite_btn.BackgroundImage = Properties.Resources.invite_hover;
        }

        private void toolbar_vnc_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_vnc_btn.BackgroundImage = Properties.Resources.share_hover;
        }

        private void toolbar_vnc_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!vncBtnClicked)
                toolbar_vnc_btn.BackgroundImage = Properties.Resources.share_normal;
            else
                toolbar_vnc_btn.BackgroundImage = Properties.Resources.share_pressed;
        }

        private void toolbar_cam_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_cam_btn.BackgroundImage = Properties.Resources.cam_hover;
        }

        private void toolbar_cam_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!camBtnClicked)
                toolbar_cam_btn.BackgroundImage = Properties.Resources.cam_normal;
            else
                toolbar_cam_btn.BackgroundImage = Properties.Resources.cam_pressed;
        }

        private void toolbar_speaker_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_speaker_btn.BackgroundImage = Properties.Resources.spk_hover;
        }

        private void toolbar_speaker_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!speakerBtnClicked)
                toolbar_speaker_btn.BackgroundImage = Properties.Resources.spk_normal;
            else
                toolbar_speaker_btn.BackgroundImage = Properties.Resources.spk_pressed;
        }

        private void toolbar_mic_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_mic_btn.BackgroundImage = Properties.Resources.mic_hover;
        }

        private void toolbar_mic_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!micBtnClicked)
                toolbar_mic_btn.BackgroundImage = Properties.Resources.mic_normal;
            else
                toolbar_mic_btn.BackgroundImage = Properties.Resources.mic_pressed;
        }

        private void toolbar_mic_btn_Click(object sender, EventArgs e)
        {
            micBtnClicked = !micBtnClicked;

            toolbar_mic_btn.BackgroundImage = (micBtnClicked ? Properties.Resources.mic_pressed : Properties.Resources.mic_normal);

            if (micBtnClicked)
            {
                videoPanelMgr.StartPublishLocalMic();
                UpdateUserState(SdkManager.Instance().UserId, UserStateType.USER_STATE_AUDIO, true);
            }
            else
            {
                videoPanelMgr.StopPublishLocalMic();
                UpdateUserState(SdkManager.Instance().UserId, UserStateType.USER_STATE_AUDIO, false);
            }
        }

        private String GenerateRandomFilePath()
        {
            if (RecordSavePath.Length == 0)
            {
                return Environment.CurrentDirectory + "/" + (new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000)).ToString() + ".mp4";
            }
            else
            {
                return RecordSavePath + "/" + (new Random(Guid.NewGuid().GetHashCode()).Next(1, 1000)).ToString() + ".mp4";
            }
        }

        private void toolbar_record_btn_Click(object sender, EventArgs e)
        {
            recordBtnClicked = !recordBtnClicked;

            if (recordBtnClicked)
            {
                SdkManager.Instance().StartRecord(GenerateRandomFilePath());
            }
            else
            {
                SdkManager.Instance().StopRecord();
            }
        }

        private void toolbar_record_btn_MouseHover(object sender, EventArgs e)
        {
            toolbar_record_btn.BackgroundImage = Properties.Resources.record_hover;
        }

        private void toolbar_record_btn_MouseLeave(object sender, EventArgs e)
        {
            if (!recordBtnClicked)
                toolbar_record_btn.BackgroundImage = Properties.Resources.record_normal;
            else
                toolbar_record_btn.BackgroundImage = Properties.Resources.record_pressed;
        }

        private void toolbar_speaker_btn_Click(object sender, EventArgs e)
        {
            speakerBtnClicked = !speakerBtnClicked;

            toolbar_speaker_btn.BackgroundImage = (speakerBtnClicked ? Properties.Resources.spk_pressed : Properties.Resources.spk_normal);

            if (speakerBtnClicked)
            {
                SdkManager.Instance().SetSpkVolumn(100);
            }
            else
            {
                SdkManager.Instance().SetSpkVolumn(0);
            }
        }

        private void OnCameraMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int cameraId = int.Parse(e.ClickedItem.Name);

            if (publishedCamSet.Contains(cameraId))
            {
                publishedCamSet.Remove(cameraId);

                videoPanelMgr.StopPublishLocalCam(cameraId);

                if (publishedCamSet.Count == 0)
                {
                    camBtnClicked = false;
                    toolbar_cam_btn.BackgroundImage = Properties.Resources.cam_normal;

                    UpdateUserState(SdkManager.Instance().UserId, UserStateType.USER_STATE_VIDEO, false);
                }
            }
            else
            {
                // Allow to publish 2 cameras at most
                if (publishedCamSet.Count >= 2)
                {
                    MessageBox.Show("Allow to publish 2 cameras at most!");
                    return;
                }

                publishedCamSet.Add(cameraId);

                videoPanelMgr.StartPublishLocalCam(cameraId);

                camBtnClicked = true;
                toolbar_cam_btn.BackgroundImage = Properties.Resources.cam_pressed;

                UpdateUserState(SdkManager.Instance().UserId, UserStateType.USER_STATE_VIDEO, true);
            }
        }

        private void toolbar_cam_btn_Click(object sender, EventArgs e)
        {
            List<VideoDeviceInfo> cameras = SdkManager.Instance().GetLocalCameraList();
            if (cameras.Count == 0)
            {
                MessageBox.Show("No available camera!");
                return;
            }

            ContextMenuStrip camMenu = new ContextMenuStrip();
            foreach (VideoDeviceInfo info in cameras)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Name = info.cameraId.ToString();
                item.Image = publishedCamSet.Contains(info.cameraId) ? Properties.Resources.checkbox_sel : Properties.Resources.checkbox;
                item.Text = info.devName;

                camMenu.Items.Add(item);
            }
            camMenu.ItemClicked += OnCameraMenuItemClicked;

            Button camControl = (Button)sender;
            Point camScreenLocation = camControl.PointToScreen(new Point(0, 0));

            Point menuLocation = new Point();
            menuLocation.X = camScreenLocation.X - camMenu.Width / 2 + camControl.Width / 2;
            menuLocation.Y = camScreenLocation.Y - 5;

            camMenu.Show(menuLocation, ToolStripDropDownDirection.AboveRight);
        }

        private void toolbar_vnc_btn_Click(object sender, EventArgs e)
        {
            vncBtnClicked = !vncBtnClicked;

            if (vncBtnClicked)
            {
                StartScreenShare();
                toolbar_vnc_btn.BackgroundImage = Properties.Resources.share_pressed;

                UpdateUserState(SdkManager.Instance().UserId, UserStateType.USER_STATE_SHARE, true);
            }
            else
            {
                SdkManager.Instance().StopScreenshare();
                toolbar_vnc_btn.BackgroundImage = Properties.Resources.share_normal;

                UpdateUserState(SdkManager.Instance().UserId, UserStateType.USER_STATE_SHARE, false);
            }
        }

        private void toolbar_invite_btn_Click(object sender, EventArgs e)
        {
            inviteBtnClicked = !inviteBtnClicked;

            toolbar_invite_btn.BackgroundImage = (inviteBtnClicked ? Properties.Resources.invite_pressed : Properties.Resources.invite_normal);

            if (inviteBtnClicked)
            {
                SdkManager.Instance().OnlineForm.Popup();
            }
        }

        private void toolbar_setting_btn_Click(object sender, EventArgs e)
        {
            settingBtnClicked = true;

            toolbar_setting_btn.BackgroundImage = Properties.Resources.setting_pressed;

            SettingForm settingForm = new SettingForm();

            settingForm.ShowDialog();

            toolbar_setting_btn.BackgroundImage = Properties.Resources.setting_normal;

            settingBtnClicked = false;
        }
        #endregion

        private void UpdateUserState(String userId, UserStateType stateType, bool state)
        {
            int count = this.users_datagridview.Rows.Count;

            Trace.Assert(count > 0);

            for (int i = 0; i < count; i++)
            {
                if (this.users_datagridview.Rows[i].Tag.ToString() != userId)
                    continue;

                switch (stateType)
                {
                    case UserStateType.USER_STATE_AUDIO:
                        this.users_datagridview.Rows[i].Cells[(int)stateType].Value = state ? Properties.Resources.mic_enable : Properties.Resources.mic_disable;
                        break;

                    case UserStateType.USER_STATE_VIDEO:
                        this.users_datagridview.Rows[i].Cells[(int)stateType].Value = state ? Properties.Resources.cam_enable : Properties.Resources.cam_disable;
                        break;

                    case UserStateType.USER_STATE_SHARE:
                        this.users_datagridview.Rows[i].Cells[(int)stateType].Value = state ? Properties.Resources.share_enable : Properties.Resources.share_disable;
                        break;

                    default:
                        break;

                }
            }
        }

        private void UpdateMsgTextbox()
        {
            String text = "";

            foreach (GroupMsg msg in groupMsgs)
            {
                if (msg.senderUserId == SdkManager.Instance().UserId)
                {
                    text += msg.sendTime.ToString()
                        + " 我 对 "
                        + (msg.toUserId.Length != 0 ? msg.toUserId : "所有人")
                        + " 说："
                        + "\r\n"
                        //+ Encoding.UTF32.GetString(Encoding.UTF8.GetBytes(msg.content))
                        + msg.content
                        + "\r\n\r\n";
                }
                else if (msg.senderUserId == "")
                {
                    text += msg.sendTime.ToString()
                    + " 系统消息："
                    + "\r\n"
                    + msg.content
                    + "\r\n\r\n";
                }
                else
                {
                    text += msg.sendTime.ToString()
                    + " "
                    + msg.senderUserId
                    + " 对 "
                    + (msg.toUserId.Length != 0 ? "我" : "所有人")
                    + " 说："
                    + "\r\n"
                    + msg.content
                    + "\r\n\r\n";
                }
            }

            this.msg_textbox.Clear();
            this.msg_textbox.Text = text;
            this.msg_textbox.SelectionStart = this.msg_textbox.Text.Length;
            this.msg_textbox.ScrollToCaret();
        }

        private void UpdateGroupUserList()
        {
            this.users_datagridview.Rows.Clear();

            foreach (GroupUserInfo user in groupUsers)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.Tag = user.userName;
                row.Height = 30;

                DataGridViewImageCell userLabel = new DataGridViewImageCell();
                userLabel.Value = Properties.Resources.user_label;
                row.Cells.Add(userLabel);

                DataGridViewTextBoxCell userId = new DataGridViewTextBoxCell();
                if (user.userName == SdkManager.Instance().UserId)
                    userId.Value = user.userName + "（我）";
                else
                    userId.Value = user.userName;
                row.Cells.Add(userId);

                DataGridViewImageCell micLabel = new DataGridViewImageCell();
                micLabel.Value = user.broadcast_audio ? Properties.Resources.mic_enable : Properties.Resources.mic_disable;
                row.Cells.Add(micLabel);

                DataGridViewImageCell camLabel = new DataGridViewImageCell();
                camLabel.Value = user.broadcast_video ? Properties.Resources.cam_enable : Properties.Resources.cam_disable;
                row.Cells.Add(camLabel);

                DataGridViewImageCell shareLabel = new DataGridViewImageCell();
                shareLabel.Value = user.broadcast_screenshare ? Properties.Resources.share_enable : Properties.Resources.share_disable;
                row.Cells.Add(shareLabel);

                this.users_datagridview.Rows.Add(row);
            }

            this.users_datagridview.ClearSelection();

            this.users_combobox.Items.Clear();
            this.users_combobox.Items.Add("所有人");

            foreach (GroupUserInfo user in groupUsers)
            {
                if (user.userName != SdkManager.Instance().UserId)
                    this.users_combobox.Items.Add(user.userName);
            }

            this.users_combobox.SelectedIndex = users_combobox.Items.IndexOf("所有人");
        }

        private void send_msg_btn_Click(object sender, EventArgs e)
        {
            String msg = send_msg_textbox.Text;
            String selectedString = this.users_combobox.SelectedItem.ToString();

            if (msg.Length != 0)
            {
                if (this.users_combobox.SelectedIndex == 0)
                {
                    int msgId = 0;
                    SdkManager.Instance().SendGroupMsg(msg, ref msgId);

                    GroupMsg message;
                    message.senderUserId = SdkManager.Instance().UserId;
                    message.content = msg;
                    message.sendTime = System.DateTime.Now;
                    message.toUserId = "";

                    groupMsgs.Add(message);

                    UpdateMsgTextbox();
                }
                else
                {
                    int msgId = 0;
                    SdkManager.Instance().SendUserMsg(selectedString, msg, ref msgId);

                    GroupMsg message;
                    message.senderUserId = SdkManager.Instance().UserId;
                    message.content = msg;
                    message.sendTime = System.DateTime.Now;
                    message.toUserId = selectedString;

                    groupMsgs.Add(message);

                    UpdateMsgTextbox();
                }
            }

            this.send_msg_textbox.Clear();
        }

        public void OnInviteCompleted()
        {
            inviteBtnClicked = false;

            toolbar_invite_btn.BackgroundImage = Properties.Resources.invite_normal;
        }

        public void OnSendInviteMsg(String userId)
        {
            GroupMsg msg;
            msg.senderUserId = "";
            msg.sendTime = DateTime.Now;
            msg.toUserId = "";
            msg.content = String.Format("已向用户 {0} 发送邀请！", userId);

            groupMsgs.Add(msg);

            UpdateMsgTextbox();
        }

        public void CloseMainForm()
        {
            videoPanelMgr.Destroy();

            SdkManager.Instance().LeaveGroup();

            SdkManager.Instance().MainForm = null;

            Close();
        }

        public void StartScreenShare()
        {
            if (ShareMode == ScreenShareMode.SCREEN_SHARE_MODE_DESKTOP)
            {
                SdkManager.Instance().StartShareDesktop(ShareQosType);
            }
            else
            {
                SdkManager.Instance().StartShareRegion(ShareRegion, ShareQosType);
            }
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // Calc video panel width
            int videoPanelWidth = this.Width - this.main_right_panel.Width;

            // Toolbar positon and width
            this.toolbar_panel.Location = new Point(0, this.Height - this.toolbar_panel.Height);
            this.toolbar_panel.Width = videoPanelWidth;

            // Tab panel
            this.tab_panel.Width = videoPanelWidth;
            this.group_label.Location = new Point(this.tab_panel.Width - this.group_label.Width - 10, this.group_label.Location.Y);

            // Right panel
            this.main_right_panel.Location = new Point(videoPanelWidth, this.main_right_panel.Location.Y);
            this.main_right_panel.Height = this.Height - 36;

            this.left_right_split_label.Height = this.main_right_panel.Height;

            this.users_combobox.Location = new Point(this.users_combobox.Left, this.main_right_panel.Height - 40);
            this.send_msg_btn.Location = new Point(this.send_msg_btn.Left, this.main_right_panel.Height - 42);

            this.send_msg_split_label.Location = new Point(this.send_msg_split_label.Left, this.main_right_panel.Height - 52);
            this.send_msg_textbox.Location = new Point(this.send_msg_textbox.Left, this.main_right_panel.Height - 111);
            this.msg_split_label.Location = new Point(this.msg_split_label.Left, this.main_right_panel.Height - 115);

            this.msg_textbox.Location = new Point(this.msg_textbox.Left, this.main_right_panel.Height - 385);
            this.user_msg_split_label.Location = new Point(this.user_msg_split_label.Left, this.main_right_panel.Height - 389);

            // Video panel
            videoPanelMgr.OnPanelSizeChanged(new Size(this.Width - this.main_right_panel.Width, this.Height - 60 - this.toolbar_panel.Height));
        }
    }
}
