using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using fspclr;


namespace MeetingDemo
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();

            SdkManager.Instance().loginForm = this;
        }

        public void CommonEventHandler(CommonEventClr commonEvent, ErrCodeClr errCode)
        {
            if (commonEvent != CommonEventClr.CLR_COMMONEVENT_JOINGROUP_RESULT)
                return; // Only handle join group event

            if (errCode == ErrCodeClr.CLR_ERR_OK)
            {
                MainForm mainForm = new MainForm(textBox_groupId.Text, textBox_userId.Text);
                mainForm.Show();

                this.Hide();
            }
            else
            {
                switch (errCode)
                {
                    case ErrCodeClr.CLR_ERR_USERID_CONFLICT:
                        MessageBox.Show("用户已经登录！", "登录错误");
                        break;

                    case ErrCodeClr.CLR_ERR_APP_NOT_EXIST:
                        MessageBox.Show("应用不存在！", "登录错误");
                        break;

                    case ErrCodeClr.CLR_ERR_TOKEN_INVALID:
                        MessageBox.Show("认证失败！", "登录错误");
                        break;

                    case ErrCodeClr.CLR_ERR_CONNECT_FAIL:
                        MessageBox.Show("连接服务器失败！", "登录错误");
                        break;

                    case ErrCodeClr.CLR_ERR_NO_BALANCE:
                        MessageBox.Show("账户余额不足！", "登录错误");
                        break;

                    default:
                        break;
                }
            }
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            if (!SdkManager.Instance().Init())
            {
                MessageBox.Show("Initialize fsp engine failed!");
                return;
            }

            // Ignored error handle
            SdkManager.Instance().JoinGroup(textBox_groupId.Text, textBox_userId.Text);
        }
    }
}
