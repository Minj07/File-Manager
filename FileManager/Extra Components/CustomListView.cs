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

        private int ViewIndex = 1;
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
            this.OwnerDraw = true;            
        }

        protected void cap(ref int input, int min, int max)
        {
            input = (input < min ? min : input);
            input = (input > max ? max : input);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {

            ViewIndex += e.Delta / SystemInformation.MouseWheelScrollDelta;
            cap(ref ViewIndex, 0, 4);
            switch (ViewIndex)
            {
                case 0: View = View.Tile; break;
                case 1: View = View.Details; break;
                case 2: View = View.List; break;
                case 3: View = View.SmallIcon; break;
                case 4: View = View.LargeIcon; break;
            }

            base.OnMouseWheel(e);
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            //e.Item.Text = e.Bounds.Size.ToString();            
            base.OnDrawItem(e);
            
        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            //if (e.ColumnIndex == this.Columns.Count-1)
            //{
            //    int s = 0;
            //    foreach (ColumnHeader c in this.Columns)
            //    {
            //        s+=c.Width;
            //    }
            //    this.Columns[e.ColumnIndex].Width = e.Bounds.Width-s;
            //}
            using (Brush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
                TextRenderer.DrawText(e.Graphics, e.Header.Text, this.Font, e.Bounds.Location, Color.FromArgb(50,this.ForeColor));
                
                e.Graphics.DrawLine(new Pen(Color.FromArgb(50, this.ForeColor), 3),
                    new Point(e.Bounds.Right, e.Bounds.Top),
                    new Point(e.Bounds.Right, e.Bounds.Bottom));
            }
            
        }
    }
}
