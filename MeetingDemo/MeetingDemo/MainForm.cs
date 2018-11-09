using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

using fspclr;

namespace MeetingDemo
{
    public partial class MainForm : Form
    {
        public String groupId { get; private set; }
        public String userId { get; private set; }

        private bool hasPublishVideo;
        private bool hasPublishAudio;

        public int curMicId { get; private set; }
        public int curSpkId { get; private set; }
        public int spkVolumn { get; private set; }
        public int micVolumn { get; private set; }
        //public fspclr.VideoProfileClr videoProfile { get; private set; }

        private System.Collections.Generic.HashSet<int> publishedCamSet = new HashSet<int>();

        // Calc from 1200 * 700 form area
        private const int videoPanelWidth = 393;
        private const int videoPanelHeight = 280;

        // 2 rows, 3 columns
        private const int videoPanelTotalCount = 6;
        private const int videoPanelRowCount = 3;

        private ArrayList videoPanels = new ArrayList();

        public MainForm(String groupId, String userId)
        {
            InitializeComponent();

            // Login info
            this.groupId = groupId;
            this.userId = userId;

            curMicId = 0;
            curSpkId = 0;

            micVolumn = 50;
            spkVolumn = 50;

            this.FormClosed += mainForm_Closed;
        }

        private void mainForm_Closed(object sender, EventArgs e)
        {
            System.Console.WriteLine("Close Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);

            foreach (VideoPanel panel in videoPanels)
            {
                panel.Destroy();
            }

            SdkManager.Instance().Destroy();
            SdkManager.Instance().mainForm = null;

            // It's rude to do this but simple.
            System.Environment.Exit(0);
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("好视通云通信 - (Group ID: {0}, User ID: {1})", groupId, userId);

            // Set callback object
            SdkManager.Instance().mainForm = this;

            // Set audio devices
            SdkManager.Instance().SetCurrentMicrophone(curMicId);
            SdkManager.Instance().SetCurrentSpeaker(curSpkId);

            // Create video panels
            for (int i = 0; i < videoPanelTotalCount; i++)
            {
                videoPanels.Add(new VideoPanel(this,
                    new Point((i % videoPanelRowCount) * videoPanelWidth + ((i % videoPanelRowCount) * 3),
                        (i / videoPanelRowCount) * videoPanelHeight + (i / videoPanelRowCount == 0 ? 0 : 3)),
                    new Size(videoPanelWidth, videoPanelHeight)));
            }

            // Bind event handler
            micPictureBox.MouseEnter += micPictureBox_MouseEnter;
            micPictureBox.MouseLeave += micPictureBox_MouseLeave;
            micPictureBox.MouseDown += micPictureBox_MouseDown;

            camPictureBox.MouseEnter += camPictureBox_MouseEnter;
            camPictureBox.MouseLeave += camPictureBox_MouseLeave;
            camPictureBox.MouseDown += camPictureBox_MouseDown;

            settingPictureBox.MouseEnter += settingPictureBox_MouseEnter;
            settingPictureBox.MouseLeave += settingPictureBox_MouseLeave;
            settingPictureBox.MouseDown += settingPictureBox_MouseDown;

            // Set audio device
            SdkManager.Instance().SetCurrentMicrophone(curMicId);
            SdkManager.Instance().SetMicVolumn(micVolumn);

            SdkManager.Instance().SetCurrentSpeaker(curSpkId);
            SdkManager.Instance().SetSpkVolumn(spkVolumn);
        }

        public void SetMicrophoneDevice(int micId)
        {
            this.curMicId = micId;
            SdkManager.Instance().SetCurrentMicrophone(micId);
        }

        public void SetMicVolumn(int volumn)
        {
            this.micVolumn = volumn;
            SdkManager.Instance().SetMicVolumn(volumn);
        }

        public void SetSpeakerDevice(int spkId)
        {
            this.curSpkId = spkId;
            SdkManager.Instance().SetCurrentSpeaker(spkId);
        }

        public void SetSpkVolumn(int volumn)
        {
            this.spkVolumn = volumn;
            SdkManager.Instance().SetSpkVolumn(volumn);
        }

        public void SetVideoProfile(int cameraId, VideoProfileClr profile)
        {
            SdkManager.Instance().SetVideoProfile(cameraId.ToString(), profile);
        }

        #region Microphone mouse event handle
        private void micPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (!hasPublishAudio)
            {
                micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic_hot;
            }
            else
            {
                micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic_open_hot;
            }
        }

        private void micPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!hasPublishAudio)
            {
                micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic;
            }
            else
            {
                micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic_open;
            }
        }

        private void micPictureBox_MouseDown(object sender, EventArgs e)
        {
            if (hasPublishAudio)
            {
                micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic_open_pressed;
            }
        }

        private void micPictureBox_Click(object sender, EventArgs e)
        {
            if (!hasPublishAudio)
            {
                VideoPanel panel = GetAvailableLocalAudioPanel();
                if (panel != null)
                {
                    panel.userId = this.userId;
                    hasPublishAudio = true;

                    panel.StartPublishLocalMic();
                    
                    micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic_open;
                }
            }
            else
            {
                VideoPanel panel = FindLocalAudioPanel();
                if (panel != null)
                {
                    panel.StopPublishLocalMic();
                    hasPublishAudio = false;
                    micPictureBox.BackgroundImage = Properties.Resources.toolbar_mic;
                }
            }
        }
        #endregion

        #region Camera mouse event handle
        private void camPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (!hasPublishVideo)
            {
                camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam_hot;
            }
            else
            {
                camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam_open_hot;
            }
        }

        private void camPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!hasPublishVideo)
            {
                camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam;
            }
            else
            {
                camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam_open;
            }
        }

        private void camPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (hasPublishVideo)
            {
                camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam_open_pressed;
            }
        }

        private void camPictureBox_Click(object sender, EventArgs e)
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

            PictureBox camControl = (PictureBox)sender;
            Point camScreenLocation = camControl.PointToScreen(new Point(0, 0));

            Point menuLocation = new Point();
            menuLocation.X = camScreenLocation.X - camMenu.Width / 2 + camControl.Width / 2; 
            menuLocation.Y = camScreenLocation.Y - 5;

            camMenu.Show(menuLocation, ToolStripDropDownDirection.AboveRight);
        }

        private void OnCameraMenuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int cameraId = int.Parse(e.ClickedItem.Name);

            if (publishedCamSet.Contains(cameraId))
            {
                publishedCamSet.Remove(cameraId);

                VideoPanel panel = FindLocalVideoPanel(cameraId);
                if (panel != null)
                {
                    panel.StopPublishLocalCam();
                }

                if (publishedCamSet.Count == 0)
                {
                    hasPublishVideo = false;
                    camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam;
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

                VideoPanel panel = GetAvailableLocalVideoPanel();
                if (panel != null)
                {
                    panel.userId = this.userId;
                    panel.StartPublishLocalCam(cameraId);
                }

                hasPublishVideo = true;
                camPictureBox.BackgroundImage = Properties.Resources.toolbar_cam_open;
            }
        }

        #endregion

        #region Setting mouse event handle
        private void settingPictureBox_MouseEnter(object sender, EventArgs e)
        {
            settingPictureBox.BackgroundImage = Properties.Resources.toolbar_settings_hot;
        }

        private void settingPictureBox_MouseLeave(object sender, EventArgs e)
        {
            settingPictureBox.BackgroundImage = Properties.Resources.toolbar_settings;
        }

        private void settingPictureBox_MouseDown(object sender, EventArgs e)
        {
            settingPictureBox.BackgroundImage = Properties.Resources.toolbar_settings_pressed;
        }

        private void settingPictureBox_Click(object sender, EventArgs e)
        {
            SettingForm settingForm = new SettingForm(this);
            settingForm.Owner = this;
            settingForm.ShowDialog();
        }
        #endregion

        public void RemoteAudioEventHandler(String userId, RemoteAudioEventClr remoteAudioEvent)
        {
            switch (remoteAudioEvent)
            {
                case RemoteAudioEventClr.CLR_REMOTE_AUDIO_EVENT_PUBLISHE_STARTED:
                    OnRemoteStartPublishAudio(userId);
                    break;

                case RemoteAudioEventClr.CLR_REMTOE_AUDIO_EVENT_PUBLISHE_STOPED:
                    OnRemoteStopPublishAudio(userId);
                    break;

                default:
                    break;
            }
        }

        public void RemoteVideoEventHandler(String userId, String videoId, RemoteVideoEventClr remoteVideoEvent)
        {
            switch (remoteVideoEvent)
            {
                case RemoteVideoEventClr.CLR_REMOTE_VIDEO_EVENT_PUBLISHE_STARTED:
                    OnRemoteStartPublishVideo(userId, videoId);
                    break;

                case RemoteVideoEventClr.CLR_REMOTE_VIDEO_EVENT_PUBLISHE_STOPED:
                    OnRemoteStopPublishVideo(userId, videoId);
                    break;

                default:
                    break; // Ignored
            }
        }

        private VideoPanel GetAvailableLocalAudioPanel()
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && panel.hasVideo && !panel.hasAudio)
                    return panel;
            }

            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.hasAudio && !panel.hasVideo)
                    return panel;
            }

            return null;
        }

        private VideoPanel GetAvailableLocalVideoPanel()
        {
            // Has local audio without previewed camera
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && panel.hasAudio && !panel.hasVideo)
                    return panel;
            }

            // Find idle panel
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.hasAudio && !panel.hasVideo)
                    return panel;
            }

            return null; // No available
        }

        private VideoPanel GetAvailableRemoteAudioPanel(String userId)
        {
            // Has published video without published audio
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.isLocal && panel.userId == userId
                    && !panel.hasAudio && panel.hasVideo)
                    return panel;
            }

            // Find idle panel
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.hasAudio && !panel.hasVideo)
                    return panel;
            }

            return null;
        }

        private VideoPanel GetAvailableRemoteVideoPanel(String userId)
        {
            // Has published audio without published video 
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.isLocal && panel.userId == userId 
                    && panel.hasAudio && !panel.hasVideo)
                    return panel;
            }

            // Find idle panel
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.hasAudio && !panel.hasVideo)
                    return panel;
            }

            return null; // No available
        }

        private void OnRemoteStartPublishVideo(String userId, String videoId)
        {
            VideoPanel panel = GetAvailableRemoteVideoPanel(userId);
            if (panel != null)
            {
                panel.AddRemoteVideo(userId, videoId);
            }
        }

        private VideoPanel FindRemoteVideoPanel(String userId, String videoId)
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.isLocal && panel.userId == userId && panel.videoId == videoId)
                    return panel;
            }

            return null;
        }

        private VideoPanel FindRemoteAudioPanel(String userId)
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.isLocal && panel.userId == userId)
                    return panel;
            }

            return null;
        }

        private void OnRemoteStopPublishVideo(String userId, String videoId)
        {
            VideoPanel panel = FindRemoteVideoPanel(userId, videoId);
            if (panel != null)
            {
                panel.DelRemoteVideo();
            }
        }

        private VideoPanel FindLocalVideoPanel(int cameraId)
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && panel.hasVideo && panel.cameraId == cameraId)
                    return panel;
            }

            return null;
        }

        private VideoPanel FindLocalAudioPanel()
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && panel.hasAudio)
                    return panel;
            }

            return null;
        }

        private void OnRemoteStartPublishAudio(String userId)
        {
            VideoPanel panel = GetAvailableRemoteAudioPanel(userId);
            if (panel != null)
            {
                panel.AddRemoteAudio(userId);
            }
        }

        private void OnRemoteStopPublishAudio(String userId)
        {
            VideoPanel panel = FindRemoteAudioPanel(userId);
            if (panel != null)
            {
                panel.DelRemoteAudio(userId);
            }
        }
    }
}
