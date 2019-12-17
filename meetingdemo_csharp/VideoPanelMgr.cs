using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meetingdemo_csharp
{
    class VideoPanelMgr
    {
        // Video panels
        List<VideoPanel> videoPanels = new List<VideoPanel>();

        // Screen share panels
        List<VideoPanel> screenSharePanels = new List<VideoPanel>();

        PictureBox videoTab = new PictureBox();
        Label videoTabText = new Label();

        Button screenShareTab = new Button();

        Panel tabParentPanel = null;
        Panel videoParentPanel = null;

        public void OnPanelSizeChanged(Size newSize)
        {
            videoParentPanel.Size = newSize;

            switch (videoPanels.Count)
            {
                case 1:
                    DoAdjustVideoPanelLayout(1, 1);
                    break;

                case 2:
                    DoAdjustVideoPanelLayout(1, 2);
                    break;

                case 3:
                case 4:
                    DoAdjustVideoPanelLayout(2, 2);
                    break;

                case 5:
                case 6:
                    DoAdjustVideoPanelLayout(2, 3);
                    break;
            }

            foreach (VideoPanel panel in videoPanels)
            {
                panel.Show();
            }
        }

        public VideoPanelMgr(Panel tabPanel, Panel videoPanel)
        {
            videoParentPanel = videoPanel;
            tabParentPanel = tabPanel;

            videoTab.Size = new Size(90, 24);
            videoTab.Parent = tabParentPanel;
            videoTab.Left = 0;
            videoTab.Top = 0;
            videoTab.BorderStyle = BorderStyle.None;
            videoTab.BackgroundImage = Properties.Resources.tab_bg;

            videoTabText.Parent = videoTab;
            videoTabText.ForeColor = Color.White;
            videoTabText.BackColor = Color.Transparent;
            videoTabText.Text = "视频";
            videoTabText.Location = new Point(0, 0);
            videoTabText.Size = videoTab.Size;
            videoTabText.AutoSize = false;
            videoTabText.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void ShrinkVideoLayoutTo(int num)
        {
            int inUsePanelCount = GetInUseVideoPanelCount();
            int totalCount = videoPanels.Count();

            if (num >= totalCount)
                return;

            int shrinkCount = totalCount - num;

            for (int i = videoPanels.Count - 1; i >= 0; i--)
            {
                if (shrinkCount <= 0)
                    break;

                if (!videoPanels[i].hasAudio && !videoPanels[i].hasVideo)
                {
                    videoPanels[i].Hide();
                    videoPanels[i].Destroy();
                    videoPanels.Remove(videoPanels[i]);
                    shrinkCount--;
                }
            }

            if (shrinkCount > 0)
                ; // !!!
        }

        private int GetInUseVideoPanelCount()
        {
            int inUsePanelCount = 0;
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.hasAudio || panel.hasVideo)
                    ++inUsePanelCount;
            }

            return inUsePanelCount;
        }

        private void DoAdjustVideoPanelLayout(int row, int column)
        {
            int index = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    videoPanels[index].ShowPos = new Point(j * (videoParentPanel.Width / column), i * (videoParentPanel.Height / row));
                    videoPanels[index].ShowSize = new Size(videoParentPanel.Width / column, videoParentPanel.Height / row);

                    index++;
                }
            }
        }

        private void AdjustVideoPanelLayout()
        {
            int inUsePanelCount = GetInUseVideoPanelCount();

            if (inUsePanelCount == videoPanels.Count()) // Add
            {
                switch (videoPanels.Count())
                {
                    case 1:
                        break; // Do nothing

                    case 2: // 1 + 1
                        DoAdjustVideoPanelLayout(1, 2);
                        break;

                    case 3: // 2 + 1 => 4
                        videoPanels.Add(new VideoPanel(videoParentPanel));
                        DoAdjustVideoPanelLayout(2, 2);
                        break;

                    case 4: // 3 + 1
                        break; // Do nothing

                    case 5: // 4 + 1 => 6
                        videoPanels.Add(new VideoPanel(videoParentPanel));
                        DoAdjustVideoPanelLayout(2, 3);
                        break;

                    case 6: // 5 + 1
                        break; // Do nothing
                }
            }
            else if (inUsePanelCount < videoPanels.Count())
            {
                switch (inUsePanelCount)
                {
                    case 0:
                    case 1:
                        ShrinkVideoLayoutTo(1);
                        DoAdjustVideoPanelLayout(1, 1);
                        break;

                    case 2:
                        ShrinkVideoLayoutTo(2);
                        DoAdjustVideoPanelLayout(1, 2);
                        break;

                    case 3:
                    case 4:
                        ShrinkVideoLayoutTo(4);
                        DoAdjustVideoPanelLayout(2, 2);
                        break;

                    case 5:
                    case 6:
                        break; // Do nothing
                }
            }

            foreach (VideoPanel panel in videoPanels)
            {
                panel.Show();
            }
        }

        private bool AddRemoteVideoToIdlePanel(String userId, String videoId)
        {
            // 优先选择此User的Panel
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.userId == userId && !panel.hasVideo)
                {
                    panel.AddRemoteVideo(userId, videoId);
                    return true;
                }
            }

            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.hasVideo)
                {
                    panel.AddRemoteVideo(userId, videoId);
                    return true;
                }
            }

            return false;
        }

        private bool AddRemoteAudioToIdlePanel(String userId)
        {
            // 优先选择此User的Panel
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.userId == userId && !panel.hasAudio)
                {
                    panel.AddRemoteAudio(userId);
                    return true;
                }
            }

            foreach (VideoPanel panel in videoPanels)
            {
                if (!panel.hasAudio)
                {
                    panel.AddRemoteAudio(userId);
                    return true;
                }
            }

            return false;
        }

        private bool AddLocalAudioToIdlePanel()
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && !panel.hasAudio)
                {
                    panel.StartPublishLocalMic();
                    return true;
                }
            }

            return false;
        }

        private bool AddLocalVideoToIdlePanel(int cameraId)
        {
            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && !panel.hasVideo)
                {
                    panel.StartPublishLocalCam(cameraId);
                    return true;
                }
            }

            return false;
        }

        public void AddRemoteVideo(String userId, String videoId)
        {
            Trace.Assert(videoPanels.Count() != 0);

            if (!AddRemoteVideoToIdlePanel(userId, videoId))
            {
                if (videoPanels.Count() >= 6)
                    return; // Full

                VideoPanel panel = new VideoPanel(videoParentPanel);
                videoPanels.Add(panel);
                panel.AddRemoteVideo(userId, videoId);
            }

            AdjustVideoPanelLayout();
        }


        public void DelRemoteVideo(String userId, String videoId)
        {
            Trace.Assert(videoPanels.Count() != 0);

            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.userId == userId && panel.videoId == videoId)
                {
                    panel.DelRemoteVideo();
                    break;
                }
            }

            AdjustVideoPanelLayout();
        }

        public void AddRemoteAudio(String userId)
        {
            Trace.Assert(videoPanels.Count() != 0);

            if (!AddRemoteAudioToIdlePanel(userId))
            {
                if (videoPanels.Count() >= 6)
                    return; // Full

                VideoPanel panel = new VideoPanel(videoParentPanel);
                videoPanels.Add(panel);
                panel.AddRemoteAudio(userId);
            }

            AdjustVideoPanelLayout();
        }

        public void DelRemoteAudio(String userId)
        {
            Trace.Assert(videoPanels.Count() != 0);

            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.userId == userId && panel.hasAudio)
                {
                    panel.DelRemoteAudio(userId);
                    break;
                }
            }

            AdjustVideoPanelLayout();
        }

        public void StartPublishLocalMic()
        {
            Trace.Assert(videoPanels.Count() != 0);

            if (!AddLocalAudioToIdlePanel())
            {
                if (videoPanels.Count() >= 6)
                    return; // Full

                VideoPanel panel = new VideoPanel(videoParentPanel);
                videoPanels.Add(panel);
                panel.StartPublishLocalMic();
            }

            AdjustVideoPanelLayout();
        }

        public void StopPublishLocalMic()
        {
            Trace.Assert(videoPanels.Count() != 0);

            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && panel.hasAudio)
                {
                    panel.StopPublishLocalMic();
                    break;
                }
            }

            AdjustVideoPanelLayout();
        }

        public void StartPublishLocalCam(int cameraId)
        {
            Trace.Assert(videoPanels.Count() != 0);

            if (!AddLocalVideoToIdlePanel(cameraId))
            {
                if (videoPanels.Count() >= 6)
                    return; // Full

                VideoPanel panel = new VideoPanel(videoParentPanel);
                videoPanels.Add(panel);
                panel.StartPublishLocalCam(cameraId);
            }

            AdjustVideoPanelLayout();
        }

        public void StopPublishLocalCam(int cameraId)
        {
            Trace.Assert(videoPanels.Count() != 0);

            foreach (VideoPanel panel in videoPanels)
            {
                if (panel.isLocal && panel.hasVideo && panel.cameraId == cameraId)
                {
                    panel.StopPublishLocalCam();
                    break;
                }
            }

            AdjustVideoPanelLayout();
        }

        public void SwitchToVideoPanel()
        {
            // Hide all screen share videos
            foreach (VideoPanel panel in screenSharePanels)
                panel.Hide();

            // Show video tab
            // TODO:

            if (videoPanels.Count() == 0)
            {
                VideoPanel panel = new VideoPanel(videoParentPanel);
                panel.ShowPos = new Point(0, 0);
                panel.ShowSize = videoParentPanel.Size;

                videoPanels.Add(panel);
            }

            foreach (VideoPanel panel in videoPanels)
            {
                panel.Show();
            }
        }

        public void SwitchToScreenSharePanel()
        {

        }

        public void Destroy()
        {
            foreach (VideoPanel panel in videoPanels)
            {
                panel.Destroy();
            }

            videoPanels.Clear();
        }
    }
}
