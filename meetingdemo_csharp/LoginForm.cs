using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fspclr;

namespace meetingdemo_csharp
{
    public partial class LoginForm : CommonForm
    {
        // Default APP parameters
        private const String APP_ID = "925aa51ebf829d49fc98b2fca5d963bc";
        private const String APP_SECRET = "d52be60bb810d17e";

        private String userId;

        public LoginForm()
        {
            InitializeComponent();

            this.HasSettingBox = true;
            this.HasMinBox = true;
            this.HasCloseBox = true;

            ConfigParser.LoadConfig();

            SdkManager.Instance().LoginForm = this;
        }

        protected override void OnSettingClicked()
        {
            base.OnSettingClicked();

            AppSettingForm appSettingForm = new AppSettingForm();
            appSettingForm.ShowDialog(this);
        }

        protected override void OnFormClosed()
        {
            base.OnFormClosed();

            SdkManager.Instance().Destroy();

            System.Environment.Exit(0);
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            if(user_textbox.Text.Length <= 0)
            {
                MessageBox.Show("请填写User ID");
                return;
            }

            String appId = (ConfigParser.appConfig.appUserDefine == "true") ? ConfigParser.appConfig.userAppId : ConfigParser.appConfig.appId;
            String appSecret = (ConfigParser.appConfig.appUserDefine == "true") ? ConfigParser.appConfig.userAppSecret : ConfigParser.appConfig.appSecret;
            String serverAddr = (ConfigParser.appConfig.serverUserDefine == "true") ? ConfigParser.appConfig.userServerAddr : ConfigParser.appConfig.serverAddr;

            if (!SdkManager.Instance().Init(appId, appSecret, serverAddr))
            {
                MessageBox.Show("初始化引擎失败！");
                return;
            }

            userId = user_textbox.Text;
            if (!SdkManager.Instance().Login(userId))
            {
                MessageBox.Show("登录失败！");
                return;
            }
        }

        public void LoginResultHandler(CommonEventClr commonEvent, ErrCodeClr errCode)
        {
            if (commonEvent != CommonEventClr.CLR_COMMONEVENT_LOGIN_RESULT)
                return; // Only handle login event

            if (errCode != ErrCodeClr.CLR_ERR_OK) // Login failed
            {
                MessageBox.Show("登录平台失败！", "登录失败");
                return;
            }

            SdkManager.Instance().UserId = userId;

            this.Hide();

            OnlineForm onlineForm = new OnlineForm();
            onlineForm.Show();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            user_textbox.ForeColor = ColorTranslator.FromHtml("#999999");
            user_textbox.Text = "请输入User ID";
        }

        private void user_textbox_Enter(object sender, EventArgs e)
        {
            user_textbox.ForeColor = ColorTranslator.FromHtml("#333333");
            user_textbox.Text = "";
        }

        private void user_textbox_Leave(object sender, EventArgs e)
        {
            user_textbox.ForeColor = ColorTranslator.FromHtml("#999999");
            if (user_textbox.Text.Length == 0)
                user_textbox.Text = "请输入User ID";
        }
    }
}
