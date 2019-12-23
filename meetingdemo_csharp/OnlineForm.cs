using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using fspclr;

namespace meetingdemo_csharp
{
    public partial class OnlineForm : CommonForm
    {
        private struct OnlineUserInfo
        {
            public String userId;
            public bool isChecked;
        }

        private String curGroupId;
        private bool isPopup = false;

        private System.Windows.Forms.Timer refreshTimer = new Timer();

        private List<OnlineUserInfo> onlineUserList = new List<OnlineUserInfo>();

        public OnlineForm()
        {
            InitializeComponent();

            this.HasMinBox = true;
            this.HasCloseBox = true;

            this.TitleText = "在线";
        }

        protected override void OnFormClosed()
        {
            // Close timer
            refreshTimer.Enabled = false;
            refreshTimer.Stop();
            refreshTimer.Dispose();

            SdkManager.Instance().Logout();
            SdkManager.Instance().Destroy();
            System.Environment.Exit(0);
        }

        private void UpdateOnlineUserList()
        {
            this.online_listview.Items.Clear();
            foreach (OnlineUserInfo user in this.onlineUserList)
            {
                var item = new ListViewItem();

                item.ImageIndex = 0;
                item.Tag = user.userId;

                item.Text = "  " + user.userId;
                if (user.userId == SdkManager.Instance().UserId)
                {
                    item.Text += "（我）";
                    item.Checked = true;
                }
                else
                {
                    item.Checked = user.isChecked;
                }

                item.SubItems.Add("在线");

                this.online_listview.Items.Add(item);
            }
        }

        public void OnUserStateRefreshed(ErrCodeClr errCode, int requestId, List<UserInfoClr> userInfoList)
        {
            if (errCode != ErrCodeClr.CLR_ERR_OK)
                return;

            this.onlineUserList.Clear();
            foreach (UserInfoClr user in userInfoList)
            {
                OnlineUserInfo userInfo = new OnlineUserInfo();
                userInfo.userId = user.userId;
                userInfo.isChecked = false;

                for (int i = 0; i < this.online_listview.Items.Count; i++)
                {
                    if (this.online_listview.Items[i].Tag.ToString() == user.userId)
                    {
                        userInfo.isChecked = this.online_listview.Items[i].Checked;
                        break;
                    }
                }
                this.onlineUserList.Add(userInfo);
            }
            UpdateOnlineUserList();
        }

        public void OnUserStateChange(UserInfoClr userInfo)
        {
            // 上线
            if (userInfo.userState == UserStateTypeClr.CLR_USER_STATE_ONLINE)
            {
                // 这里不检查用户是否已经存在
                OnlineUserInfo onlineUser;
                onlineUser.userId = userInfo.userId;
                onlineUser.isChecked = false;
                this.onlineUserList.Add(onlineUser);
            }
            else // 下线
            {
                for (int i = 0; i < this.onlineUserList.Count; i++)
                {
                    if (this.onlineUserList[i].userId == userInfo.userId)
                    {
                        this.onlineUserList.Remove(this.onlineUserList[i]);
                        break;
                    }
                }
            }
            UpdateOnlineUserList();
        }

        private void SendInvitations(String groupId)
        {
            List<String> inviteList = new List<string>();

            int m = online_listview.CheckedItems.Count;
            for (int i = 0; i < m; i++)
            {
                if (online_listview.CheckedItems[i].Tag.ToString() != SdkManager.Instance().UserId)
                {
                    inviteList.Add(online_listview.CheckedItems[i].SubItems[0].Text.Trim());

                    if (isPopup)
                        SdkManager.Instance().MainForm.OnSendInviteMsg(online_listview.CheckedItems[i].Tag.ToString());
                }
            }

            if (inviteList.Count() > 0)
            {
                int inviteId = 0;
                SdkManager.Instance().Invite(inviteList, groupId, "", ref inviteId);
            }
        }

        public void Popup()
        {
            isPopup = true;

            this.group_textbox.Enabled = false;
            this.join_btn.Text = "邀请加入分组";

            this.HasCloseBox = false;
            this.HasMinBox = false;
            this.TitleText = "呼叫";

            this.Show();
        }

        private void RestoreOnlineFormState()
        {
            this.HasCloseBox = true;
            this.HasMinBox = true;
            this.TitleText = "在线";

            this.group_textbox.Enabled = true;
            this.join_btn.Text = "加入分组";

            isPopup = false;

            this.Hide();

            SdkManager.Instance().MainForm.OnInviteCompleted();
        }

        private void join_btn_Click(object sender, EventArgs e)
        {
            if (group_textbox.Text.Length <= 0)
            {
                MessageBox.Show("请输入Group ID！");
                return;
            }

            curGroupId = group_textbox.Text;

            SendInvitations(curGroupId);

            if (!isPopup)
            {
                SdkManager.Instance().JoinGroup(curGroupId);
            }
            else
            {
                RestoreOnlineFormState();
            }
        }

        public void JoinGroupResultHandler(CommonEventClr commonEvent, ErrCodeClr errCode)
        {
            if (errCode != ErrCodeClr.CLR_ERR_OK)
            {
                MessageBox.Show("加入分组失败!");
            }
            else
            {
                SdkManager.Instance().GroupId = curGroupId;

                this.Hide();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
        }

        private void InitOnlineUserListView()
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(36, 36);
            imgList.Images.Add("user", (System.Drawing.Image)Properties.Resources.user_label);

            online_listview.View = View.Details;
            online_listview.MultiSelect = true;
            online_listview.HeaderStyle = ColumnHeaderStyle.None;
            online_listview.Scrollable = true;
            online_listview.CheckBoxes = true;
            online_listview.FullRowSelect = true;
            online_listview.SmallImageList = imgList;

            online_listview.Columns.Add("User ID", 200, HorizontalAlignment.Left);
            online_listview.Columns.Add("User State", 40, HorizontalAlignment.Right);
        }

        private void OnlineForm_Load(object sender, EventArgs e)
        {
            InitOnlineUserListView();

            group_textbox.ForeColor = ColorTranslator.FromHtml("#999999");
            group_textbox.Text = "请输入Group ID";

            SdkManager.Instance().OnlineForm = this;

            // 获取在线用户列表
            SdkManager.Instance().GetOnlineUserList();
        }

        public void OnInviteCome(String inviterUserId, int inviteId, String groupId, String msg)
        {
            String inviteMsg = String.Format("{0} 邀请您加入分组 {1}，是否同意？", inviterUserId, groupId);

            if (MessageBox.Show(inviteMsg, "邀请", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                SdkManager.Instance().RejectInivte(inviterUserId, inviteId);
            }
            else
            {
                SdkManager.Instance().AcceptInivte(inviterUserId, inviteId);
                if (SdkManager.Instance().MainForm != null)
                {
                    if (SdkManager.Instance().GroupId != groupId)
                    {
                        SdkManager.Instance().MainForm.CloseMainForm();
                        this.Show();
                        curGroupId = groupId;
                    }
                }
                SdkManager.Instance().JoinGroup(groupId);
            }
        }

        private void group_textbox_Leave(object sender, EventArgs e)
        {
            group_textbox.ForeColor = ColorTranslator.FromHtml("#999999");
            if (group_textbox.Text.Length == 0)
                group_textbox.Text = "请输入Group ID";
        }

        private void group_textbox_Enter(object sender, EventArgs e)
        {
            group_textbox.ForeColor = ColorTranslator.FromHtml("#333333");
            group_textbox.Text = "";
        }

        private void online_min_picturebox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void online_listview_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Tag.ToString() == SdkManager.Instance().UserId)
            {
                e.Item.Checked = true; // Deselect myself is not allowed
            }
        }
    }
}
