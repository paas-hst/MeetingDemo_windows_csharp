using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meetingdemo_csharp
{
    public partial class FullTabControl : TabControl
    {
        public FullTabControl()
        {
            InitializeComponent();

            //this.ItemSize = new Size(0, 1);
            //this.SizeMode = TabSizeMode.Fixed;

            this.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.DrawItem += TabControl_DrawItem;
        }

        private void TabControl_DrawItem(Object sender, DrawItemEventArgs e)
        {
            String text = this.TabPages[e.Index].Text;
            Font textFont = new Font("微软雅黑", 11);

            SizeF textSize = e.Graphics.MeasureString(text, textFont);
            Rectangle tabRect = this.GetTabRect(e.Index);

            Rectangle textRect = new Rectangle(
                tabRect.Left + (tabRect.Width - (int)textSize.Width) / 2, 
                tabRect.Top + (tabRect.Height - (int)textSize.Height) / 2, 
                (int)textSize.Width + 1, 
                (int)textSize.Height + 1);

            if (this.SelectedIndex == e.Index)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(106, 125, 254)), e.Bounds);
                e.Graphics.DrawString(text, textFont, new SolidBrush(Color.White), textRect);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.White), e.Bounds);
                e.Graphics.DrawString(text, textFont, new SolidBrush(Color.Black), textRect);
            }
        }

        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle rect = base.DisplayRectangle;
                return new Rectangle(rect.Left - 4, rect.Top - 4, rect.Width + 8, rect.Height + 8);
            }
        }
    }
}
