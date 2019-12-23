using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Forms.Integration;
using System.Windows;
using System.Windows.Interop;

namespace meetingdemo_csharp
{
    class VideoPanel
    {
        private Panel parentPanel = null;

        // Video
        private Panel videoPanel = new Panel();

        // User label
        private TransparentForm userNameBackgroud = new TransparentForm(TransparentForm.FormType.FORM_TYPE_BG);
        private TransparentForm userNameText = new TransparentForm(TransparentForm.FormType.FORM_TYPE_TEXT);

        // Menu label
        private TransparentForm videoMenuBackground = new TransparentForm(TransparentForm.FormType.FORM_TYPE_BG);
        private TransparentForm videoMenuText = new TransparentForm(TransparentForm.FormType.FORM_TYPE_TEXT);

        // Video info label
        private TransparentForm videoInfoBackgroud = new TransparentForm(TransparentForm.FormType.FORM_TYPE_BG);
        private TransparentForm videoInfoText = new TransparentForm(TransparentForm.FormType.FORM_TYPE_TEXT);

        // Area
        public System.Drawing.Point ShowPos { get; set; }
        public System.Drawing.Size ShowSize { get; set; }

        private fspclr.RenderModeClr renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER;

        public bool hasAudio { get; set; }
        public bool hasVideo { get; set; }
        public String userId { get; set; }
        public bool isLocal { get; set; }
        public String videoId { get; set; }
        public int cameraId { get; set; }

        private System.Windows.Forms.Timer refreshTimer = new Timer();

        public VideoPanel(Panel panel)
        {
            parentPanel = panel;

            hasAudio = hasVideo = isLocal = false;

            // Default video panel background
            videoPanel.BackColor = Color.FromArgb(240, 243, 246); // #F0F3F6
            videoPanel.BackgroundImage = Properties.Resources.video_bg;
            videoPanel.BackgroundImageLayout = ImageLayout.Center;
            videoPanel.Parent = panel;

            Form mainForm = SdkManager.Instance().MainForm;
            userNameBackgroud.Owner     = mainForm;
            userNameText.Owner          = mainForm;
            videoMenuBackground.Owner   = mainForm;
            videoMenuText.Owner         = mainForm;
            videoInfoBackgroud.Owner    = mainForm;
            videoInfoText.Owner         = mainForm;

            userNameBackgroud.BgImg = Properties.Resources.user_name_bg;
            userNameText.BgImg = Properties.Resources.user_name_bg;
            videoMenuBackground.BgImg = Properties.Resources.video_menu_bg;
            videoMenuText.BgImg = Properties.Resources.video_menu_bg;
            videoInfoBackgroud.BgImg = Properties.Resources.video_info_bg;
            videoInfoText.BgImg = Properties.Resources.video_info_bg;

            userNameBackgroud.Opacity   = 0.2;
            userNameText.Opacity        = 1;
            videoMenuBackground.Opacity = 0.2;
            videoMenuText.Opacity       = 1;
            videoInfoBackgroud.Opacity  = 0.2;
            videoInfoText.Opacity       = 1;

            mainForm.LocationChanged += OwnerForm_LocationChanged;
            videoMenuBackground.Click += MenuForm_Click;

            Hide();

            // Start timer
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 500;
            refreshTimer.Tick += OnTimer;
            refreshTimer.Start();
        }

        public void Destroy()
        {
            // Close timer
            refreshTimer.Enabled = false;
            refreshTimer.Stop();
            refreshTimer.Dispose();

            // Close auido and video
            if (isLocal)
            {
                if (hasAudio)
                    SdkManager.Instance().StopPublishLocalMic();

                if (hasVideo)
                    SdkManager.Instance().StopPublishLocalCam(cameraId, (int)videoPanel.Handle);
            }
            else
            {
                if (hasAudio)
                    SdkManager.Instance().CloseRemoteAudio(userId);

                if (hasVideo)
                    SdkManager.Instance().CloseRemoteVideo(userId, videoId);
            }
        }

        private void UpdateTransparentLabels()
        {
            System.Drawing.Point ptLeftTop = videoPanel.PointToScreen(new System.Drawing.Point(0, 0));

            // User Name Label
            userNameBackgroud.Location = new System.Drawing.Point(ptLeftTop.X + 8, ptLeftTop.Y + 8);
            userNameText.Location = new System.Drawing.Point(ptLeftTop.X + 8, ptLeftTop.Y + 8);

            // Menu
            videoMenuBackground.Location = new System.Drawing.Point(ptLeftTop.X + videoPanel.Width - 28, ptLeftTop.Y + 8);
            videoMenuText.Location = new System.Drawing.Point(ptLeftTop.X + videoPanel.Width - 28, ptLeftTop.Y + 8);

            // Video Info
            videoInfoBackgroud.Location = new System.Drawing.Point(ptLeftTop.X + 8, ptLeftTop.Y + videoPanel.Height - 28);
            videoInfoText.Location = new System.Drawing.Point(ptLeftTop.X + 8, ptLeftTop.Y + videoPanel.Height - 28);
        }

        public void Show()
        {
            videoPanel.Width = ShowSize.Width;
            videoPanel.Height = ShowSize.Height;
            videoPanel.Location = ShowPos;

            videoPanel.Show();

            if (hasVideo)
            {
                userNameBackgroud.Show();
                userNameText.Show();
                videoMenuBackground.Show();
                videoMenuText.Show();
                videoInfoBackgroud.Show();
                videoInfoText.Show();

                userNameText.BringToFront();
                videoMenuText.BringToFront();
                videoInfoText.BringToFront();

                UpdateTransparentLabels();
            }
        }

        public void Hide()
        {
            videoPanel.Hide();
            userNameBackgroud.Hide();
            userNameText.Hide();
            videoMenuBackground.Hide();
            videoMenuText.Hide();
            videoInfoBackgroud.Hide();
            videoInfoText.Hide();
        }

        public void Refresh()
        {
            Hide();

            videoPanel.Refresh();

            Show();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            if (!refreshTimer.Enabled)
                return;

            if (hasVideo && userId != null && videoId != null)
            {
                fspclr.VideoStatsInfoClr videoStats = SdkManager.Instance().GetVideoStats(userId, videoId);
                videoInfoText.Text = String.Format("{0}K {1}F {2}*{3}",
                    videoStats.bitrate / 1024,
                    videoStats.framerate,
                    videoStats.width,
                    videoStats.height);
                videoInfoText.Invalidate();
            }
        }

        private void MenuForm_Click(object sender, EventArgs e)
        {
            if (!hasVideo) return;

            Form control = sender as Form;
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

        private void SetVideoRenderMode(int renderId, fspclr.RenderModeClr mode)
        {
            if (!hasVideo) return;

            if (isLocal)
            {
                SdkManager.Instance().StartPublishLocalCam(cameraId, renderId, mode);
            }
            else
            {
                SdkManager.Instance().OpenRemoteVideo(userId, videoId, renderId, mode);
            }
        }

        private void OnMenuItemPpsfClicked(object sender, EventArgs e)
        { 
            SetVideoRenderMode((int)videoPanel.Handle, fspclr.RenderModeClr.CLR_RENDERMODE_SCALE_FILL);
            renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_SCALE_FILL;
        }

        private void OnMenuItemDbcjClicked(object sender, EventArgs e)
        {
            SetVideoRenderMode((int)videoPanel.Handle, fspclr.RenderModeClr.CLR_RENDERMODE_CROP_FILL);
            renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_CROP_FILL;
        }

        private void OnMenuItemDbwzClicked(object sender, EventArgs e)
        {
            SetVideoRenderMode((int)videoPanel.Handle, fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER);
            renderMode = fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER;
        }

        public void StartPublishLocalCam(int cameraId)
        {
            SdkManager.Instance().StartPublishLocalCam(cameraId, 
                (int)videoPanel.Handle, fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER);

            // Update states and parameters
            userId = SdkManager.Instance().UserId;
            hasVideo = true;
            isLocal = true;
            videoId = cameraId.ToString();
            this.cameraId = cameraId;

            // Update user name label
            userNameText.Text = userId;
        }

        public void StopPublishLocalCam()
        {
            SdkManager.Instance().StopPublishLocalCam(cameraId, (int)videoPanel.Handle);

            hasVideo = false;

            Refresh();
        }

        public void StartPublishLocalMic()
        {
            SdkManager.Instance().StartPublishLocalMic();

            hasAudio = true;
            isLocal = true;
            userId = SdkManager.Instance().UserId;

            userNameText.Text = userId;
        }

        public void StopPublishLocalMic()
        {
            SdkManager.Instance().StopPublishLocalMic();
            videoPanel.Refresh();

            hasAudio = false;

            if (!hasVideo)
            {
                userNameText.Text = "Nobody";
                userId = null;
            }
        }

        public void AddRemoteVideo(String userId, String videoId)
        {
            SdkManager.Instance().OpenRemoteVideo(userId, videoId, 
                (int)videoPanel.Handle, fspclr.RenderModeClr.CLR_RENDERMODE_FIT_CENTER);

            if (!hasAudio && !hasVideo)
            {
                userNameText.Text = userId;
            }

            hasVideo = true;
            isLocal = false;

            this.userId = userId;
            this.videoId = videoId;
        }

        public void DelRemoteVideo()
        {
            SdkManager.Instance().CloseRemoteVideo(userId, videoId);

            hasVideo = false;

            if (!hasVideo && !hasAudio)
            {
                userNameText.Text = "Nobody";
                userId = null;
            }

            Refresh();
        }

        public void AddRemoteAudio(String userId)
        {
            SdkManager.Instance().OpenRemoteAudio(userId);

            if (!hasAudio && !hasVideo)
            {
                userNameText.Text = userId;
            }

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
                userNameText.Text = "Nobody";
                userId = null;
            }
        }

        public void OwnerForm_LocationChanged(object sender, EventArgs e)
        {
            UpdateTransparentLabels();
        }
    }
}
