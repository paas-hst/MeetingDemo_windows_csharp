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
    public partial class TransparentTextForm : Form
    {
        private Image bgImg = null;

        public TransparentTextForm()
        {
            InitializeComponent();

            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            this.ShowInTaskbar = false;

            this.ForeColor = Color.White;
        }

        public Image BgImg
        {
            get
            {
                return bgImg;
            }
            set
            {
                bgImg = value;

                this.Size = bgImg.Size;
            }
        }

        private void TransparentTextForm_Paint(object sender, PaintEventArgs e)
        {
            SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font);

            int X = (this.bgImg.Width - (int)textSize.Width) / 2;
            int Y = (this.bgImg.Height - (int)textSize.Height) / 2;

            e.Graphics.DrawImage(this.BgImg, new Rectangle(0, 0, this.BgImg.Width, this.BgImg.Height));

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Point(X, Y));
        }
    }
}
