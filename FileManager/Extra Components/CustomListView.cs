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
        private ListViewItem HoveringItem = null;
        private int ViewIndex = 1;
        private bool HoldingControl = false;

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

        protected override void OnItemMouseHover(ListViewItemMouseHoverEventArgs e)
        {
            if (HoveringItem == null)
            {
                HoveringItem = e.Item;
            } else
            {
                if (HoveringItem!=e.Item)
                {
                    Invalidate(HoveringItem.Bounds);    
                    HoveringItem = e.Item;
                    Invalidate(HoveringItem.Bounds);
                }
            }
            base.OnItemMouseHover(e);
            
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
                cap(ref ViewIndex, 0, 4);
                switch (ViewIndex)
                {
                    case 0: View = View.Tile; break;
                    case 1: View = View.Details; break;
                    case 2: View = View.List; break;
                    case 3: View = View.SmallIcon; break;
                    case 4: View = View.LargeIcon; break;
                }
            }
            base.OnMouseWheel(e);
        }
         
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);

            Rectangle IconBounds;
            Rectangle TextBounds;

            if (e.Item == HoveringItem)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, HoverOverlayColor)), e.Bounds);
            }

            //if (e.State.HasFlag(ListViewItemStates.Selected))
            //{
            //    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, SelectedOverlayColor)), e.Bounds);
            //}

            switch (this.View)
            {
                case View.Details:
                    
                    break;
            }

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
