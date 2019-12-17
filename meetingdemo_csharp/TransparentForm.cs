using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meetingdemo_csharp
{
    // Transparent label implemented by two overlay forms, 
    // one form for background over the video panel, which 
    // is semi-transpanret, and one form for text on the
    // top, which is non-transparent.
    public partial class TransparentForm : Form
    {
        private Image bgImg = null;

        public enum FormType
        {
            FORM_TYPE_BG = 0,
            FORM_TYPE_TEXT = 1
        };

        public TransparentForm(FormType formType)
        {
            InitializeComponent();

            if (formType == FormType.FORM_TYPE_BG)
            {
                this.BackColor = Color.FromArgb(0, 0, 1);
                this.TransparencyKey = Color.FromArgb(0, 0, 1);
            }
            else if (formType == FormType.FORM_TYPE_TEXT)
            {
                this.BackColor = Color.Black;
                this.TransparencyKey = Color.Black;
            }

            this.ShowInTaskbar = false;
            this.BackgroundImage = null;
            this.ForeColor = Color.White;
            this.Text = "";
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

        private void TransparentForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; 
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            // Draw background image
            e.Graphics.DrawImage(this.BgImg, new Rectangle(0, 0, this.BgImg.Width, this.BgImg.Height));

            // Draw text, center on vertical
            SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font);

            int X = (this.bgImg.Width - (int)textSize.Width) / 2;
            int Y = (this.bgImg.Height - (int)textSize.Height) / 2;

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), new Point(X, Y));
        }
    }
}
