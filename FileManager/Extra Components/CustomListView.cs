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
        private bool HoldingControl = false;
        private ListViewItem HoveringItem = null;

        public Color SelectedOverlayColor { get; set; } = Color.FromArgb(255, 255, 255);

        public Color HoverOverlayColor { get; set; } = Color.FromArgb(255, 255, 255);

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

        protected override void OnMouseMove(MouseEventArgs e)
        {
            ListViewItem currentItem = this.GetItemAt(e.X, e.Y);
            if (currentItem != null)
            {
                if (HoveringItem != currentItem)
                {
                    HoveringItem = currentItem;
                }                
            } else
            {
                this.HoveringItem = null;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            HoveringItem = null;
            base.OnMouseLeave(e);
        }

        protected void cap(ref int input, int min, int max)
        {
            input = (input < min ? min : input);
            input = (input > max ? max : input);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Control&&!HoldingControl)
            {
                HoldingControl = true;
            }
            if (e.KeyCode == Keys.I)
            {
                Invalidate();
            }
            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (!e.Control&&HoldingControl)
            {
                HoldingControl = false;
            }
            base.OnKeyUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            this.VirtualListSize = 100;
            if (HoldingControl)
            {
                ViewIndex += e.Delta / SystemInformation.MouseWheelScrollDelta;
                cap(ref ViewIndex, 0, 2);
                switch (ViewIndex)
                {
                    case 0: View = View.Tile; break;
                    case 1: View = View.Details; break;
                    case 2: View = View.LargeIcon; break;
                    //case 2: View = View.List; break;
                    //case 3: View = View.SmallIcon; break;
                    //case 4: View = View.LargeIcon; break;
                }
            }
            base.OnMouseWheel(e);
        }
         
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Icon icon = ((ListViewItemTag)e.Item.Tag).SmallIcon;
            Icon iconL = ((ListViewItemTag)e.Item.Tag).LargeIcon;
            Rectangle IconBounds = e.Bounds;
            Rectangle TagBounds = e.Bounds;

            if (this.SelectedItems.Contains(e.Item))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, SelectedOverlayColor)), e.Bounds);
            }
            if (e.Item == HoveringItem)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, SelectedOverlayColor)), e.Bounds);
            }
            
            switch (this.View)
            {
                case View.Tile:
                    IconBounds = new Rectangle(new Point(e.Bounds.Left + 9, e.Bounds.Top + 9), new Size(32, 32));
                    icon = iconL;
                    break;
                case View.Details:
                    IconBounds = new Rectangle(new Point(e.Bounds.Left + 2, e.Bounds.Top + 2), new Size(16, 16));
                    break;
                case View.LargeIcon:
                    IconBounds = new Rectangle(new Point(e.Bounds.Left + 21, e.Bounds.Top + 3), new Size(48, 48));
                    icon = iconL;
                    break;
            }
            e.Graphics.DrawIcon(icon, IconBounds);
            //e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue),IconBounds);
            e.DrawDefault = true;
            //e.Item.Text = e.Bounds.ToString();         
            base.OnDrawItem(e);

        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
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
