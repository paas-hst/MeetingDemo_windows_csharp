using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MeetingDemo
{
    class VideoPanel
    {
        // Video
        private Panel videoPanel = new Panel();

        // Info bar at the bottom
        private Panel InfoPanel = new Panel();
        private const int infoPanelHeight = 29;

        // User info
        private PictureBox userPictureBox = new PictureBox();
        private Label userLabel = new Label();
        private const int userPictureBoxWidth = 20;
        private const int userLabelWidth = 60;

        // Audio info
        private PictureBox micPictureBox = new PictureBox();
        private PictureBox volumePictureBox = new PictureBox();
        private const int micPictureBoxWidth = 12;
        private const int volumePictureBoxWidth = 100;

        // Video info
        private Label videoInfoLabel = new Label();
        private const int videoInfoLabelWidth = 130;

        // Context menu
        private PictureBox menuPictureBox = new PictureBox();
        private const int menuPictureBoxWidth = 20;

        // Info panel common define
        private const int splitWidth = 10;
        private const int infoPanelPaddingTop = 5;
        private const int innerSplitWidth = 5;
        private const int infoPanelControlHeight = 20;

        // Area
        Point showStartPos;
        Size panelSize;

        private fspclr.RenderModeClr renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER;

        public bool hasAudio { get; set; }
        public bool hasVideo { get; set; }
        public String userId { get; set; }
        public bool isLocal { get; set; }
        public String videoId { get; set; }
        public int cameraId { get; set; }

        private Image[] energyImgList = new Image[10];

        private System.Windows.Forms.Timer refreshTimer = new Timer();

        public VideoPanel(Form parent, Point pos, Size size)
        {
            showStartPos = pos;
            panelSize = size;

            hasAudio = false;
            hasVideo = false;
            isLocal = false;

            videoPanel.Width = size.Width;
            videoPanel.Height = size.Height - infoPanelHeight - 1; // 1 pixel split
            videoPanel.Location = pos;
            videoPanel.BackColor = Color.FromArgb(81,89,108); // #51596c
            videoPanel.BackgroundImage = Properties.Resources.video_icon_default;
            videoPanel.BackgroundImageLayout = ImageLayout.Center;
            videoPanel.Parent = parent;

            InfoPanel.Width = size.Width;
            InfoPanel.Height = infoPanelHeight;
            InfoPanel.Parent = parent;
            InfoPanel.Location = new Point(pos.X, pos.Y + size.Height - infoPanelHeight);
            InfoPanel.BackColor = Color.Black;
            InfoPanel.BackgroundImageLayout = ImageLayout.Center;

            userPictureBox.Width = userPictureBoxWidth;
            userPictureBox.Height = infoPanelControlHeight;
            userPictureBox.Parent = InfoPanel;
            userPictureBox.Location = new Point(innerSplitWidth, infoPanelPaddingTop);
            userPictureBox.BackColor = Color.Transparent;
            userPictureBox.BackgroundImage = Properties.Resources.video_user_disable;
            userPictureBox.BackgroundImageLayout = ImageLayout.Center;

            int userLabelLeft = innerSplitWidth + userPictureBoxWidth + innerSplitWidth;
            userLabel.Width = userLabelWidth;
            userLabel.Height = infoPanelControlHeight;
            userLabel.Parent = InfoPanel;
            userLabel.Location = new Point(userLabelLeft, infoPanelPaddingTop);
            userLabel.BackColor = Color.Transparent;
            userLabel.Text = "Nobody";
            userLabel.AutoSize = false;
            userLabel.MaximumSize = new Size(60,0);
            userLabel.ForeColor = Color.White;
            userLabel.TextAlign = ContentAlignment.MiddleLeft;

            int micPictureBoxLeft = userLabelLeft + userLabelWidth + splitWidth;
            micPictureBox.Width = micPictureBoxWidth;
            micPictureBox.Height = infoPanelControlHeight;
            micPictureBox.Parent = InfoPanel;
            micPictureBox.Location = new Point(micPictureBoxLeft, infoPanelPaddingTop);
            micPictureBox.BackColor = Color.Transparent;
            micPictureBox.BackgroundImage = Properties.Resources.video_stat_audio;
            micPictureBox.BackgroundImageLayout = ImageLayout.Center;

            int volumePictureBoxLeft = micPictureBoxLeft + micPictureBoxWidth;
            volumePictureBox.Width = volumePictureBoxWidth;
            volumePictureBox.Height = infoPanelControlHeight;
            volumePictureBox.Parent = InfoPanel;
            volumePictureBox.Location = new Point(volumePictureBoxLeft, infoPanelPaddingTop);
            volumePictureBox.BackColor = Color.Transparent;
            volumePictureBox.BackgroundImage = Properties.Resources.video_stats_volume_bg;
            volumePictureBox.BackgroundImageLayout = ImageLayout.Center;

            int videoInfoLabelLeft = volumePictureBoxLeft + volumePictureBoxWidth + splitWidth;
            videoInfoLabel.Width = videoInfoLabelWidth;
            videoInfoLabel.Height = infoPanelControlHeight;
            videoInfoLabel.Parent = InfoPanel;
            videoInfoLabel.Location = new Point(videoInfoLabelLeft, infoPanelPaddingTop);
            videoInfoLabel.BackColor = Color.Transparent;
            videoInfoLabel.Text = "10240K 60F 1920*1080";
            videoInfoLabel.ForeColor = Color.White;
            videoInfoLabel.TextAlign = ContentAlignment.MiddleLeft;

            int menuPictureBoxLeft = videoInfoLabelLeft + videoInfoLabelWidth + splitWidth;
            menuPictureBox.Width = menuPictureBoxWidth;
            menuPictureBox.Height = infoPanelControlHeight;
            menuPictureBox.Parent = InfoPanel;
            menuPictureBox.Location = new Point(menuPictureBoxLeft, infoPanelPaddingTop);
            menuPictureBox.BackColor = Color.Transparent;
            menuPictureBox.BackgroundImage = Properties.Resources.video_more;
            menuPictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            menuPictureBox.Click += new System.EventHandler(menuPictureBox_Click);

            //fspclr.FspEngineClr.Instance.AddVideoPreview(0, (int)videoPanel.Handle);

            // Refresh microphone energy and video stats
            //System.Timers.Timer t = new System.Timers.Timer(500);
            //t.Elapsed += OnTimer;
            //t.Enabled = true;
            //t.AutoReset = true;

            refreshTimer.Enabled = true;
            refreshTimer.Interval = 500;
            refreshTimer.Tick += OnTimer;
            refreshTimer.Start();

            energyImgList[0] = Properties.Resources.video_stats_volume0;
            energyImgList[1] = Properties.Resources.video_stats_volume1;
            energyImgList[2] = Properties.Resources.video_stats_volume2;
            energyImgList[3] = Properties.Resources.video_stats_volume3;
            energyImgList[4] = Properties.Resources.video_stats_volume4;
            energyImgList[5] = Properties.Resources.video_stats_volume5;
            energyImgList[6] = Properties.Resources.video_stats_volume6;
            energyImgList[7] = Properties.Resources.video_stats_volume7;
            energyImgList[8] = Properties.Resources.video_stats_volume8;
            energyImgList[9] = Properties.Resources.video_stats_volume9;

            System.Console.WriteLine("Create Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);

        }

        public void Destroy()
        {
            refreshTimer.Enabled = false;
            refreshTimer.Stop();
            refreshTimer.Dispose();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            System.Console.WriteLine("OnTimer Thread: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);

            if (!refreshTimer.Enabled)
                return;

            if (hasAudio)
            {
                int energy = isLocal ? SdkManager.Instance().GetLocalMicEnergy() : SdkManager.Instance().GetRemoteMicEnergy(userId);
                volumePictureBox.BackgroundImage = energyImgList[energy / 10];
            }

            if (hasVideo && userId != null && videoId != null)
            {
                fspclr.VideoStatsInfoClr videoStats = SdkManager.Instance().GetVideoStats(userId, videoId);
                videoInfoLabel.Text = String.Format("{0}K {1}F {2}*{3}", 
                    videoStats.bitrate / 1024, 
                    videoStats.framerate, 
                    videoStats.width, 
                    videoStats.height);
            }
        }

        private void menuPictureBox_Click(object sender, EventArgs e)
        {
            if (!hasVideo) return;

            PictureBox control = sender as PictureBox;
            MouseEventArgs mouseEvent = (MouseEventArgs)e;

            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("视频缩放平铺显示", 
                renderMode == fspclr.RenderModeClr.CLR_RENDERMODE_SCALE_FILL ? Properties.Resources.radio_sel : Properties.Resources.radio, 
                OnMenuItemPpsfClicked);
            menu.Items.Add("视频等比裁剪显示", 
                renderMode == fspclr.RenderModeClr.CLR_RENDERMODE_CROP_FILL ? Properties.Resources.radio_sel : Properties.Resources.radio, 
                OnMenuItemDbcjClicked);
            menu.Items.Add("视频等比完整显示", 
                renderMode == fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER ? Properties.Resources.radio_sel : Properties.Resources.radio, 
                OnMenuItemDbwzClicked);
            menu.Show(control.PointToScreen(mouseEvent.Location),ToolStripDropDownDirection.AboveRight);
        }

        private void OnMenuItemPpsfClicked(object sender, EventArgs e)
        {
            renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_SCALE_FILL;
            SdkManager.Instance().SetVideoRenderMode((int)videoPanel.Handle, renderMode);
        }

        private void OnMenuItemDbcjClicked(object sender, EventArgs e)
        {
            renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_CROP_FILL;
            SdkManager.Instance().SetVideoRenderMode((int)videoPanel.Handle, renderMode);
        }

        private void OnMenuItemDbwzClicked(object sender, EventArgs e)
        {
            renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER;
            SdkManager.Instance().SetVideoRenderMode((int)videoPanel.Handle, renderMode);
        }

        public void StartPublishLocalCam(int cameraId)
        {
            SdkManager.Instance().StartPublishLocalCam(cameraId, (int)videoPanel.Handle);

            userPictureBox.BackgroundImage = Properties.Resources.video_user_enable;
            userLabel.Text = userId;

            hasVideo = true;
            videoId = cameraId.ToString();
            isLocal = true;
            this.cameraId = cameraId;
        }

        public void StopPublishLocalCam()
        {
            SdkManager.Instance().StopPublishLocalCam(cameraId, (int)videoPanel.Handle);
            videoPanel.Refresh();

            hasVideo = false;

            if (!hasAudio)
            {
                userPictureBox.BackgroundImage = Properties.Resources.video_user_disable;
                userLabel.Text = "Nobody";
            }
        }

        public void StartPublishLocalMic()
        {
            SdkManager.Instance().StartPublishLocalMic();

            userPictureBox.BackgroundImage = Properties.Resources.video_user_enable;
            userLabel.Text = userId;
            micPictureBox.BackgroundImage = Properties.Resources.video_stat_audio_open;

            hasAudio = true;
            isLocal = true;
        }

        public void StopPublishLocalMic()
        {
            SdkManager.Instance().StopPublishLocalMic();
            videoPanel.Refresh();

            hasAudio = false;

            if (!hasVideo)
            {
                userPictureBox.BackgroundImage = Properties.Resources.video_user_disable;
                userLabel.Text = "Nobody";
            }

            micPictureBox.BackgroundImage = Properties.Resources.video_stat_audio;
            volumePictureBox.BackgroundImage = Properties.Resources.video_stats_volume_bg;
        }

        public void AddRemoteVideo(String userId, String videoId)
        {
            SdkManager.Instance().OpenRemoteVideo(userId, videoId, (int)videoPanel.Handle);

            if (!hasAudio && !hasVideo)
            {
                userPictureBox.BackgroundImage = Properties.Resources.video_user_enable;
                userLabel.Text = userId;
            }

            hasVideo = true;
            isLocal = false;

            this.userId = userId;
            this.videoId = videoId;
        }

        public void DelRemoteVideo()
        {
            SdkManager.Instance().CloseRemoteVideo(userId, videoId);
            videoPanel.Refresh();

            hasVideo = false;

            if (!hasVideo && !hasAudio)
            {
                userPictureBox.BackgroundImage = Properties.Resources.video_user_disable;
                userLabel.Text = "Nobody";
            }
        }

        public void AddRemoteAudio(String userId)
        {
            SdkManager.Instance().OpenRemoteAudio(userId);

            if (!hasAudio && !hasVideo)
            {
                userPictureBox.BackgroundImage = Properties.Resources.video_user_enable;
                userLabel.Text = userId;
            }

            micPictureBox.BackgroundImage = Properties.Resources.video_stat_audio_open;

            hasAudio = true;
            isLocal = false;

            this.userId = userId;
        }

        public void DelRemoteAudio(String userId)
        {
            SdkManager.Instance().CloseRemoteAudio(userId);

            hasAudio = false;

            if (!hasVideo && !hasAudio)
            {
                userPictureBox.BackgroundImage = Properties.Resources.video_user_disable;
                userLabel.Text = "Nobody";
            }

            micPictureBox.BackgroundImage = Properties.Resources.video_stat_audio;
            volumePictureBox.BackgroundImage = Properties.Resources.video_stats_volume_bg;
        }
    }
}
