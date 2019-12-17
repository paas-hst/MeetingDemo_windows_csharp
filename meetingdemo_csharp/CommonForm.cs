using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meetingdemo_csharp
{
    public partial class CommonForm : Form
    {
        private static Point titlePoint;
        private bool mouseDown = false;

        // Control box 
        private bool hasCloseBox = false;
        private bool hasMaxBox = false;
        private bool hasMinBox = false;
        private bool hasSettingBox = false;

        private const int CONTROL_BOX_SPACE_TO_RIGHT = 10;
        private const int CONTROL_BOX_SPACE_BETWEEN = 20;

        //
        // Override functions
        //

        protected virtual void OnFormClosed(){}
        protected virtual void OnSettingClicked() {}
        protected virtual void OnFormMinimized() { }
        protected virtual void OnFormMaximized() { }

        //
        // Properties
        // 

        public String TitleText
        {
            set
            {
                this.title_label.Text = value;
            }
        }

        public bool HasSettingBox
        {
            get
            {
                return hasSettingBox;
            }
            set
            {
                hasSettingBox = value;
                RefreshControlBox();
            }
        }

        public bool HasMinBox
        {
            get
            {
                return hasMinBox;
            }
            set
            {
                hasMinBox = value;
                RefreshControlBox();
            }
        }

        public bool HasMaxBox
        {
            get
            {
                return hasMaxBox;
            }
            set
            {
                hasMaxBox = value;
                RefreshControlBox();
            }
        }

        public bool HasCloseBox
        {
            get
            {
                return hasCloseBox;
            }
            set
            {
                hasCloseBox = value;
                RefreshControlBox();
            }
        }

        public Color TitleBkColor
        {
            set
            {
                this.title_panel.BackColor = value;
            }
        }

        public CommonForm()
        {
            InitializeComponent();
        }

        private void main_min_picturebox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void main_max_picturebox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void close_picturebox_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void min_picturebox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void max_picturebox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void close_picturebox_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void close_picturebox_Click(object sender, EventArgs e)
        {
            OnFormClosed();

            this.Close();
        }

        private void main_max_picturebox_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.max_picturebox.BackgroundImage = Properties.Resources.max_white;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.max_picturebox.BackgroundImage = Properties.Resources.restore_white;
                OnFormMaximized();
            }
        }

        private void main_min_picturebox_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
                OnFormMinimized();
            }
        }

        private void RefreshControlBox()
        {
            int spaceToRight = CONTROL_BOX_SPACE_TO_RIGHT;

            if (hasCloseBox)
            {
                this.close_picturebox.Location = new Point(this.Width - this.close_picturebox.Width - spaceToRight, this.close_picturebox.Location.Y);
                spaceToRight += this.close_picturebox.Width + CONTROL_BOX_SPACE_BETWEEN;
                this.close_picturebox.Show();
            }
            else
            {
                this.close_picturebox.Hide();
            }

            if (hasMaxBox)
            {
                this.max_picturebox.Location = new Point(this.Width - this.max_picturebox.Width - spaceToRight, this.max_picturebox.Location.Y);
                spaceToRight += this.max_picturebox.Width + CONTROL_BOX_SPACE_BETWEEN;
                this.max_picturebox.Show();
            }
            else
            {
                this.max_picturebox.Hide();
            }

            if (hasMinBox)
            {
                this.min_picturebox.Location = new Point(this.Width - this.min_picturebox.Width - spaceToRight, this.min_picturebox.Location.Y);
                spaceToRight += this.min_picturebox.Width + CONTROL_BOX_SPACE_BETWEEN;
                this.min_picturebox.Show();
            }
            else
            {
                this.min_picturebox.Hide();
            }

            if (hasSettingBox)
            {
                this.setting_pictureBox.Location = new Point(this.Width - this.setting_pictureBox.Width - spaceToRight, this.setting_pictureBox.Location.Y);
                spaceToRight += this.setting_pictureBox.Width + CONTROL_BOX_SPACE_BETWEEN;
                this.setting_pictureBox.Show();
            }
            else
            {
                this.setting_pictureBox.Hide();
            }
        }

        private void CommonForm_SizeChanged(object sender, EventArgs e)
        {
            this.title_panel.Width = this.Width;

            RefreshControlBox();
        }

        private void title_panel_MouseDown(object sender, MouseEventArgs e)
        {
            titlePoint = new Point(e.X, e.Y);
            mouseDown = true;
        }

        private void title_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                if (e.Button == MouseButtons.Left)
                {
                    Point mousePos = Control.MousePosition;
                    mousePos.Offset(-titlePoint.X, -titlePoint.Y);
                    this.DesktopLocation = mousePos;
                }
            }
        }

        private void title_panel_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void setting_pictureBox_Click(object sender, EventArgs e)
        {
            OnSettingClicked();
        }
    }
}
