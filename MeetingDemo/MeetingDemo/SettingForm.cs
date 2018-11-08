using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeetingDemo
{
    public partial class SettingForm : Form
    {
        private int selectedCamId = 0;

        private MainForm mainForm;

        private Image[] energyImgList = new Image[10];

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

        public SettingForm(MainForm form)
        {
            InitializeComponent();

            mainForm = form;

            energyImgList[0] = Properties.Resources.menu_wave0;
            energyImgList[1] = Properties.Resources.menu_wave1;
            energyImgList[2] = Properties.Resources.menu_wave2;
            energyImgList[3] = Properties.Resources.menu_wave3;
            energyImgList[4] = Properties.Resources.menu_wave4;
            energyImgList[5] = Properties.Resources.menu_wave5;
            energyImgList[6] = Properties.Resources.menu_wave6;
            energyImgList[7] = Properties.Resources.menu_wave7;
            energyImgList[8] = Properties.Resources.menu_wave8;
            energyImgList[9] = Properties.Resources.menu_wave9;

            System.Windows.Forms.Timer refreshTimer = new Timer();
            refreshTimer.Enabled = true;
            refreshTimer.Interval = 500;
            refreshTimer.Tick += OnTimer;
            refreshTimer.Start();
        }

        private void framerateTrackBar_ValueChanged(object sender, EventArgs e)
        {
            framerateLabel.Text = String.Format("{0} 帧/秒", framerateTrackBar.Value);
        }

        private void camComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoDeviceInfo selectedCam = (VideoDeviceInfo)(camComboBox.Items[camComboBox.SelectedIndex]);

            // Change preview video
            SdkManager.Instance().DelVideoPreview(selectedCamId, (int)previewPictureBox.Handle);
            SdkManager.Instance().AddVideoPreview(selectedCam.cameraId, (int)previewPictureBox.Handle);

            // Get video stats
            fspclr.VideoStatsInfoClr stats = SdkManager.Instance().GetVideoStats(mainForm.userId, 
                selectedCam.cameraId.ToString());
            
            // Update framerate
            framerateTrackBar.Value = stats.framerate;
            framerateLabel.Text = String.Format("{0} 帧/秒", stats.framerate);

            // Update resolution
            int resIndex = 0;
            foreach (VideoResolution res in videoResolutions)
            {
                if (res.width == stats.width)
                {
                    resComboBox.SelectedIndex = resIndex;
                    break;
                }
                resIndex++;
            }

            selectedCamId = selectedCam.cameraId;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            int energy = SdkManager.Instance().GetLocalMicEnergy();
            micEnergyPictureBox.Image = energyImgList[energy / 10];

            energy = SdkManager.Instance().GetLocalSpkEnergy();
            spkEnergyPictureBox.Image = energyImgList[energy / 10];
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            
            if (micComboBox.SelectedIndex >= 0)
            {
                AudioDeviceInfo selectedMic = (AudioDeviceInfo)(micComboBox.Items[micComboBox.SelectedIndex]);
                mainForm.SetMicrophoneDevice(selectedMic.devId);
                mainForm.SetMicVolumn(micVolumnTrackBar.Value);
            }
            
            if (spkComboBox.SelectedIndex >= 0)
            {
                AudioDeviceInfo selectedSpk = (AudioDeviceInfo)(spkComboBox.Items[spkComboBox.SelectedIndex]);
                mainForm.SetSpeakerDevice(selectedSpk.devId);
                mainForm.SetSpkVolumn(spkVolumnTrackBar.Value);
            }

            if (camComboBox.SelectedIndex >= 0 && resComboBox.SelectedIndex >= 0)
            {
                VideoDeviceInfo selectedCam = (VideoDeviceInfo)(camComboBox.Items[camComboBox.SelectedIndex]);
                fspclr.VideoProfileClr profile = new fspclr.VideoProfileClr();
                profile.framerate = framerateTrackBar.Value;
                profile.width = videoResolutions[resComboBox.SelectedIndex].width;
                profile.height = videoResolutions[resComboBox.SelectedIndex].height;
                mainForm.SetVideoProfile(selectedCam.cameraId, profile);
            }
            
            this.Close();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            // Microphone
            List<AudioDeviceInfo> micList = SdkManager.Instance().GetLocalMicrophoneList();
            micComboBox.DataSource = micList;
            micComboBox.DisplayMember = "devName";

            int micIndex = 0;
            foreach (AudioDeviceInfo dev in micList)
            {
                if (dev.devId == mainForm.curMicId)
                {
                    micComboBox.SelectedIndex = micIndex;
                    break;
                }
                micIndex++;
            }

            micVolumnTrackBar.Value = mainForm.micVolumn;

            // Speaker
            List<AudioDeviceInfo> spkList = SdkManager.Instance().GetLocalSpeakerList();
            spkComboBox.DataSource = spkList;
            spkComboBox.DisplayMember = "devName";

            int spkIndex = 0;
            foreach (AudioDeviceInfo dev in spkList)
            {
                if (dev.devId == mainForm.curSpkId)
                {
                    spkComboBox.SelectedIndex = spkIndex;
                    break;
                }
                spkIndex++;
            }

            spkVolumnTrackBar.Value = mainForm.spkVolumn;

            // Camera
            List<VideoDeviceInfo> camList = SdkManager.Instance().GetLocalCameraList();
            camComboBox.DataSource = camList;
            camComboBox.DisplayMember = "devName";

            foreach (VideoResolution res in videoResolutions)
            {
                resComboBox.Items.Add(String.Format("{0}*{1}", res.width, res.height));
            }

            if (camList.Count > 0)
            {
                fspclr.VideoStatsInfoClr stats = SdkManager.Instance().GetVideoStats(mainForm.userId, camList[0].cameraId.ToString());

                camComboBox.SelectedIndex = 0;
                framerateTrackBar.Value = stats.framerate;
                framerateLabel.Text = String.Format("{0} 帧/秒", stats.framerate);

                int resIndex = 0;
                foreach (VideoResolution res in videoResolutions)
                {
                    if (res.width == stats.width)
                    {
                        resComboBox.SelectedIndex = resIndex;
                        break;
                    }
                    resIndex++;
                }

                selectedCamId = camList[0].cameraId;
                SdkManager.Instance().AddVideoPreview(selectedCamId, (int)previewPictureBox.Handle);
            }

            framerateTrackBar.ValueChanged += framerateTrackBar_ValueChanged;
            camComboBox.SelectedIndexChanged += camComboBox_SelectedIndexChanged;
        }
    }
}
