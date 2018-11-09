namespace MeetingDemo
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.textBox_groupId = new System.Windows.Forms.TextBox();
            this.textBox_userId = new System.Windows.Forms.TextBox();
            this.btn_join = new System.Windows.Forms.Button();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_groupId
            // 
            this.textBox_groupId.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_groupId.Location = new System.Drawing.Point(296, 164);
            this.textBox_groupId.Name = "textBox_groupId";
            this.textBox_groupId.Size = new System.Drawing.Size(360, 41);
            this.textBox_groupId.TabIndex = 0;
            // 
            // textBox_userId
            // 
            this.textBox_userId.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_userId.Location = new System.Drawing.Point(296, 232);
            this.textBox_userId.Name = "textBox_userId";
            this.textBox_userId.Size = new System.Drawing.Size(360, 41);
            this.textBox_userId.TabIndex = 1;
            // 
            // btn_join
            // 
            this.btn_join.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(115)))), ((int)(((byte)(220)))));
            this.btn_join.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_join.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_join.ForeColor = System.Drawing.Color.White;
            this.btn_join.Location = new System.Drawing.Point(296, 326);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(360, 40);
            this.btn_join.TabIndex = 2;
            this.btn_join.Text = "加 入";
            this.btn_join.UseVisualStyleBackColor = false;
            this.btn_join.Click += new System.EventHandler(this.btn_join_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginLabel.Font = new System.Drawing.Font("微软雅黑", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.loginLabel.ForeColor = System.Drawing.Color.White;
            this.loginLabel.Location = new System.Drawing.Point(432, 62);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(94, 48);
            this.loginLabel.TabIndex = 3;
            this.loginLabel.Text = "登录";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.label1.Location = new System.Drawing.Point(326, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copyright 2013-2018 hst.com. All Rights Reserved.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(93)))), ((int)(((byte)(117)))));
            this.label2.Location = new System.Drawing.Point(403, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "深圳银澎云计算有限公司";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MeetingDemo.Properties.Resources.login_bg;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.btn_join);
            this.Controls.Add(this.textBox_userId);
            this.Controls.Add(this.textBox_groupId);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "好视通云通信";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_groupId;
        private System.Windows.Forms.TextBox textBox_userId;
        private System.Windows.Forms.Button btn_join;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

