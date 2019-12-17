using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace meetingdemo_csharp
{
    public partial class SettingForm : CommonForm
    {
        private int selectedCamId = 0;

        struct VideoResolution
        {
            public VideoResolution(int w, int h)
            {
                width = w;
                height = h;
            }

            public int width;
            public int height;
        };

        static VideoResolution[] videoResolutions =
        {
            new VideoResolution(320, 240),
            new VideoResolution(480, 360),
            new VideoResolution(640, 480),
            new VideoResolution(1280, 720),
            new VideoResolution(1920, 1080)
        };

        public SettingForm()
        {
            InitializeComponent();

            this.HasMaxBox = false;
            this.HasMinBox = false;
            this.TitleText = "设置";

            System.Windows.Forms.Timer refreshTimer = new Timer();
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 500;
            refreshTimer.Tick += OnTimer;
            refreshTimer.Start();
        }

        private void OnTimer(object sender, EventArgs e)
        {
            mic_energy_progressbar.Value = SdkManager.Instance().GetLocalMicEnergy();

            spk_energy_progressbar.Value = SdkManager.Instance().GetLocalSpkEnergy();
        }

        private void setting_ok_btn_Click(object sender, EventArgs e)
        {
            //
            // Microphone
            //

            if (mic_combobox.SelectedIndex >= 0)
            {
                AudioDeviceInfo selectedMic = (AudioDeviceInfo)(mic_combobox.Items[mic_combobox.SelectedIndex]);

                SdkManager.Instance().MainForm.CurMicId = selectedMic.devId;
                SdkManager.Instance().SetCurrentMicrophone(selectedMic.devId);

                SdkManager.Instance().MainForm.MicVolumn = mic_volumn_trackbar.Value;
                SdkManager.Instance().SetMicVolumn(mic_volumn_trackbar.Value);
            }

            //
            // Speaker
            //

            if (spk_combobox.SelectedIndex >= 0)
            {
                AudioDeviceInfo selectedSpk = (AudioDeviceInfo)(spk_combobox.Items[spk_combobox.SelectedIndex]);

                SdkManager.Instance().MainForm.CurSpkId = selectedSpk.devId;
                SdkManager.Instance().SetCurrentSpeaker(selectedSpk.devId);

                SdkManager.Instance().MainForm.SpkVolumn = spk_volumn_trackbar.Value;
                SdkManager.Instance().SetSpkVolumn(spk_volumn_trackbar.Value);
            }

            //
            // Camera
            //

            if (cam_combobox.SelectedIndex >= 0 && cam_resolve_combobox.SelectedIndex >= 0)
            {
                VideoDeviceInfo selectedCam = (VideoDeviceInfo)(cam_combobox.Items[cam_combobox.SelectedIndex]);
                fspclr.VideoProfileClr profile = new fspclr.VideoProfileClr();
                profile.framerate = cam_framerate_trackbar.Value;
                profile.width = videoResolutions[cam_resolve_combobox.SelectedIndex].width;
                profile.height = videoResolutions[cam_resolve_combobox.SelectedIndex].height;
                SdkManager.Instance().SetVideoProfile((selectedCam.cameraId).ToString(), profile);
            }

            //
            // Screen Share
            //

            fspclr.ScreenShareQualityBiasClr shareQosType;
            if (this.fluent_radio.Checked)
            {
                shareQosType = fspclr.ScreenShareQualityBiasClr.CLR_SCREEN_SHARE_BIAS_SPEED;
            }
            else
            {
                shareQosType = fspclr.ScreenShareQualityBiasClr.CLR_SCREEN_SHARE_BIAS_QUALITY;
            }

            ScreenShareMode shareMode;
            if (this.desktop_radio.Checked)
            {
                shareMode = ScreenShareMode.SCREEN_SHARE_MODE_DESKTOP;
            }
            else
            {
                shareMode = ScreenShareMode.SCREEN_SHARE_MODE_REGION;
            }

            Rectangle shareRegion = new Rectangle(System.Math.Abs(int.Parse(this.left_textbox.Text)),
                System.Math.Abs(int.Parse(this.top_textbox.Text)),
                System.Math.Abs(int.Parse(this.right_textbox.Text) - int.Parse(this.left_textbox.Text)),
                System.Math.Abs(int.Parse(this.bottom_textbox.Text) - int.Parse(this.top_textbox.Text)));


            if (shareQosType != SdkManager.Instance().MainForm.ShareQosType
                || shareMode != SdkManager.Instance().MainForm.ShareMode)
            {
                SdkManager.Instance().MainForm.ShareMode = shareMode;
                SdkManager.Instance().MainForm.ShareQosType = shareQosType;
                SdkManager.Instance().MainForm.ShareRegion = shareRegion;

                SdkManager.Instance().StopScreenshare();
                SdkManager.Instance().MainForm.StartScreenShare();
            }
            else
            {
                if (shareMode == ScreenShareMode.SCREEN_SHARE_MODE_REGION
                    && SdkManager.Instance().MainForm.ShareRegion != shareRegion)
                {
                    SdkManager.Instance().MainForm.ShareRegion = shareRegion;

                    SdkManager.Instance().StopScreenshare();
                    SdkManager.Instance().MainForm.StartScreenShare();
                }
            }

            //
            // Local record
            //

            SdkManager.Instance().MainForm.RecordSavePath = this.record_path_textbox.Text;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //
            // Microphone
            //

            List<AudioDeviceInfo> micList = SdkManager.Instance().GetLocalMicrophoneList();
            mic_combobox.DataSource = micList;
            mic_combobox.DisplayMember = "devName";

            int micIndex = 0;
            foreach (AudioDeviceInfo dev in micList)
            {
                if (dev.devId == SdkManager.Instance().MainForm.CurMicId)
                {
                    mic_combobox.SelectedIndex = micIndex;
                    break;
                }
                micIndex++;
            }

            mic_volumn_trackbar.Value = SdkManager.Instance().MainForm.MicVolumn;

            //
            // Speaker
            //

            List<AudioDeviceInfo> spkList = SdkManager.Instance().GetLocalSpeakerList();
            spk_combobox.DataSource = spkList;
            spk_combobox.DisplayMember = "devName";

            int spkIndex = 0;
            foreach (AudioDeviceInfo dev in spkList)
            {
                if (dev.devId == SdkManager.Instance().MainForm.CurSpkId)
                {
                    spk_combobox.SelectedIndex = spkIndex;
                    break;
                }
                spkIndex++;
            }

            spk_volumn_trackbar.Value = SdkManager.Instance().MainForm.SpkVolumn;

            //
            // Camera
            //

            List<VideoDeviceInfo> camList = SdkManager.Instance().GetLocalCameraList();
            cam_combobox.DataSource = camList;
            cam_combobox.DisplayMember = "devName";

            foreach (VideoResolution res in videoResolutions)
            {
                cam_resolve_combobox.Items.Add(String.Format("{0}*{1}", res.width, res.height));
            }

            if (camList.Count > 0)
            {
                fspclr.VideoStatsInfoClr stats = SdkManager.Instance().GetVideoStats(SdkManager.Instance().UserId, camList[0].cameraId.ToString());

                cam_combobox.SelectedIndex = 0;
                cam_framerate_trackbar.Value = stats.framerate;
                cam_framerate_label.Text = String.Format("{0} 帧/秒", stats.framerate);

                int resIndex = 0;
                foreach (VideoResolution res in videoResolutions)
                {
                    if (res.width == stats.width)
                    {
                        cam_resolve_combobox.SelectedIndex = resIndex;
                        break;
                    }
                    resIndex++;
                }

                selectedCamId = camList[0].cameraId;
                SdkManager.Instance().AddVideoPreview(selectedCamId, (int)cam_preview_picturebox.Handle);
            }

            cam_framerate_trackbar.ValueChanged += CamFramerateTrackBar_ValueChanged;
            cam_combobox.SelectedIndexChanged += CamComboBox_SelectedIndexChanged;

            //
            // Screen share
            //

            if (SdkManager.Instance().MainForm.ShareQosType == fspclr.ScreenShareQualityBiasClr.CLR_SCREEN_SHARE_BIAS_QUALITY)
            {
                this.quality_radio.Select();
            }
            else
            {
                this.fluent_radio.Select();
            }

            if (SdkManager.Instance().MainForm.ShareMode == ScreenShareMode.SCREEN_SHARE_MODE_DESKTOP)
            {
                this.desktop_radio.Select();
            }
            else
            {
                this.region_radio.Select();
            }

            this.left_textbox.Text = SdkManager.Instance().MainForm.ShareRegion.Left.ToString();
            this.top_textbox.Text = SdkManager.Instance().MainForm.ShareRegion.Top.ToString();
            this.right_textbox.Text = SdkManager.Instance().MainForm.ShareRegion.Right.ToString();
            this.bottom_textbox.Text = SdkManager.Instance().MainForm.ShareRegion.Bottom.ToString();

            //
            // Local record
            //

            this.record_path_textbox.Text = SdkManager.Instance().MainForm.RecordSavePath;
        }

        private void CamFramerateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            cam_framerate_label.Text = String.Format("{0} 帧/秒", cam_framerate_trackbar.Value);
        }

        private void CamComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoDeviceInfo selectedCam = (VideoDeviceInfo)(cam_combobox.Items[cam_combobox.SelectedIndex]);

            // Change preview video
            SdkManager.Instance().DelVideoPreview(selectedCamId, (int)cam_preview_picturebox.Handle);
            SdkManager.Instance().AddVideoPreview(selectedCam.cameraId, (int)cam_preview_picturebox.Handle);

            // Get video stats
            fspclr.VideoStatsInfoClr stats = SdkManager.Instance().GetVideoStats(SdkManager.Instance().UserId,
                selectedCam.cameraId.ToString());

            // Update framerate
            cam_framerate_trackbar.Value = stats.framerate;
            cam_framerate_label.Text = String.Format("{0} 帧/秒", stats.framerate);

            // Update resolution
            int resIndex = 0;
            foreach (VideoResolution res in videoResolutions)
            {
                if (res.width == stats.width)
                {
                    cam_resolve_combobox.SelectedIndex = resIndex;
                    break;
                }
                resIndex++;
            }
        }

        private void select_path_btn_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fileDialog = new FolderBrowserDialog();
            if (DialogResult.OK == fileDialog.ShowDialog())
            { 
                this.record_path_textbox.Text = fileDialog.SelectedPath;
            }
        }
    }
}
