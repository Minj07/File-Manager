using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    internal class CustomListView : ListView
    {

        public class ListViewItemTag
        {
            public ListViewItemTag(string Extension, Icon SmallIcon, Icon LargeIcon)
            {
                this.Extension = Extension;
                this.SmallIcon = SmallIcon;
                this.LargeIcon = LargeIcon;
            }
            public string Extension { get; set; }
            public Icon SmallIcon { get; set; }
            public Icon LargeIcon { get; set; }
        }

        public CustomListView()
        {
            //this.OwnerDraw = true;
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            base.OnDrawItem(e);
            
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            using (Brush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, this.Font, e.Bounds.Location, Color.FromArgb(50,this.ForeColor));
                e.Graphics.DrawLine(new Pen(Color.FromArgb(50, this.ForeColor),4),
                    new Point(e.Bounds.Right, e.Bounds.Top),
                    new Point(e.Bounds.Right, e.Bounds.Bottom));
            }                
        }
    }
}
