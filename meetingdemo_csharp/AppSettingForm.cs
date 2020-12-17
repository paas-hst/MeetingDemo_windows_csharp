using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace meetingdemo_csharp
{
    public partial class AppSettingForm : CommonForm
    {
        private AppConfig appConfig;

        public AppSettingForm()
        {
            InitializeComponent();

            this.HasCloseBox = true;
            this.TitleText = "应用配置";
            this.TitleBkColor = Color.FromArgb(106,125,254);

            ConfigParser.LoadConfig();
            appConfig = ConfigParser.appConfig;
        }

        private void UpdateSettingUI()
        {
            if (this.appConfig.appUserDefine == "true")
            {
                this.default_app_radio.Checked = false;
                this.user_app_radio.Checked = true;

                this.app_id_textbox.Enabled = true;
                this.app_id_textbox.Text = this.appConfig.userAppId;

                this.app_secret_textbox.Enabled = true;
                this.app_secret_textbox.Text = this.appConfig.userAppSecret;
            }
            else
            {
                this.user_app_radio.Checked = false;
                this.default_app_radio.Checked = true;

                this.app_id_textbox.Enabled = false;
                this.app_id_textbox.Text = this.appConfig.appId;

                this.app_secret_textbox.Enabled = false;
                this.app_secret_textbox.Text = this.appConfig.appSecret;
            }

            if (this.appConfig.serverUserDefine == "true")
            {
                this.default_server_radio.Checked = false;
                this.user_server_radio.Checked = true;

                this.server_addr_textbox.Enabled = true;
                this.server_addr_textbox.Text = this.appConfig.userServerAddr;
            }
            else
            {
                this.user_server_radio.Checked = false;
                this.default_server_radio.Checked = true;

                this.server_addr_textbox.Enabled = false;
                this.server_addr_textbox.Text = this.appConfig.serverAddr;
            }

            if (this.appConfig.forceLogin == "true")
            {
                this.force_login_yes_radio.Checked = true;
                this.force_login_no_radio.Checked = false;
            }
            else
            {
                this.force_login_yes_radio.Checked = false;
                this.force_login_no_radio.Checked = true;
            }
        }

        private void AppSettingForm_Load(object sender, EventArgs e)
        {
            UpdateSettingUI();
        }

        private void app_setting_ok_btn_Click(object sender, EventArgs e)
        {
            ConfigParser.appConfig = this.appConfig;
            ConfigParser.SerializeConfig();
        }

        private void OnAppConfigChanged()
        {
            if (this.default_app_radio.Checked)
            {
                this.appConfig.appUserDefine = "false";
            }
            else
            {
                this.appConfig.appUserDefine = "true";
            }
            UpdateSettingUI();
        }

        private void OnServerConfigChanged()
        {
            if (this.default_server_radio.Checked)
            {
                this.appConfig.serverUserDefine = "false";
            }
            else
            {
                this.appConfig.serverUserDefine = "true";
            }
            UpdateSettingUI();
        }

        private void OnForceLoginChanged()
        {
            if (this.force_login_yes_radio.Checked)
            {
                this.appConfig.forceLogin = "true";
            }
            else
            {
                this.appConfig.forceLogin = "false";
            }
            UpdateSettingUI();
        }

        private void default_app_radio_Click(object sender, EventArgs e)
        {
            OnAppConfigChanged();
        }

        private void user_app_radio_Click(object sender, EventArgs e)
        {
            OnAppConfigChanged();
        }

        private void default_server_radio_Click(object sender, EventArgs e)
        {
            OnServerConfigChanged();
        }

        private void user_server_radio_Click(object sender, EventArgs e)
        {
            OnServerConfigChanged();
        }

        private void app_id_textbox_TextChanged(object sender, EventArgs e)
        {
            if (this.appConfig.appUserDefine == "true")
            {
                this.appConfig.userAppId = ((TextBox)sender).Text;
            }
        }

        private void app_secret_textbox_TextChanged(object sender, EventArgs e)
        {
            if (this.appConfig.appUserDefine == "true")
            {
                this.appConfig.userAppSecret = ((TextBox)sender).Text;
            }
        }

        private void server_addr_textbox_TextChanged(object sender, EventArgs e)
        {
            if (this.appConfig.serverUserDefine == "true")
            {
                this.appConfig.userServerAddr = ((TextBox)sender).Text;
            }
        }

        private void force_login_yes_radio_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void force_login_no_radio_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
