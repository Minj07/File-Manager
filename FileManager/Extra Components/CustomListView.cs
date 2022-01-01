using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FileManager
{
    internal class CustomListView : ListView
    {
        private int ViewIndex = 0;
        private bool HoldingControl = false;
        private Size space;
        public float DiskThreshold { get; set; } = 0.85f;
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
                this.Tags = new List<Database.Tag>();
                isTag = false;
            }
            
            public ListViewItemTag(Color color, int TagId)
            {
                this.color = color;
                this.Extension = null;
                this.SmallIcon = null;
                this.LargeIcon = null;
                this.TagId=TagId;
                isTag = true;
            }
            
            public bool isTag { get; set; }

            public int TagId { get; set; }

            public List<Database.Tag> Tags { get; set; }
            public string Extension { get; set; }
            public Icon SmallIcon { get; set; }
            public Icon LargeIcon { get; set; }

            public Color color { get; set; }

            public bool EditingLabel { get; set; } = false;
        }

        public CustomListView()
        {
            this.View = View.Tile;
            this.OwnerDraw = true;
            space = TextRenderer.MeasureText(" ", this.Font); //W=10 H=16
            
        }

        #region Events
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

        protected override void OnBeforeLabelEdit(LabelEditEventArgs e)
        {
            (this.Items[e.Item].Tag as ListViewItemTag).EditingLabel = true;
            base.OnBeforeLabelEdit(e);
        }

        protected override void OnAfterLabelEdit(LabelEditEventArgs e)
        {
            (this.Items[e.Item].Tag as ListViewItemTag).EditingLabel = false;
            base.OnAfterLabelEdit(e);
        }
        #endregion

        private void cap(ref int input, int min, int max)
        {
            input = (input < min ? min : input);
            input = (input > max ? max : input);
        }

        private void PaintEllipse(IDeviceContext dc, Color color, Color borderColor, Rectangle bounds)
        {
            ((Graphics)dc).FillEllipse(new SolidBrush(color), bounds);
            ((Graphics)dc).DrawEllipse(new Pen(borderColor,1), bounds);
        }

        protected Point GetColumnLocation(int ColumnIndex)
        {
            ColumnHeader column = this.Columns[ColumnIndex];
            int Left = 0;
            int Top = 0;
            for (int i = 0; i < ColumnIndex; i++)
            {
                Left+=this.Columns[i].Width;
            }
            return new Point(Left, Top);
        }

        #region Draw

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Icon icon = ((ListViewItemTag)e.Item.Tag).SmallIcon;
            Icon iconL = ((ListViewItemTag)e.Item.Tag).LargeIcon;
            Rectangle IconBounds = e.Bounds;
            Rectangle LabelBounds = e.Bounds;
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
                    if (e.Item.Text.Last() == '\\')
                    {
                        LabelBounds = new Rectangle(new Point(IconBounds.Right + 9, e.Bounds.Top + 5), new Size(160, 48));
                        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.WordEllipsis | TextFormatFlags.ModifyString;
                        DriveInfo drive = new DriveInfo(e.Item.Text);

                        TextRenderer.DrawText(e.Graphics,
                            (string.IsNullOrEmpty(drive.VolumeLabel)?"Local Disk": drive.VolumeLabel) + " ("+e.Item.Text.Substring(0,e.Item.Text.Length-1)+")" + "\n\n" + drive.AvailableFreeSpace / 1024/1024/1024 + " GB free of " + drive.TotalSize / 1024/1024/1024 + " GB",
                            this.Font, LabelBounds, this.ForeColor, flags);

                        RectangleF capBar = new Rectangle(LabelBounds.X,LabelBounds.Y+(LabelBounds.Height/3),LabelBounds.Width,LabelBounds.Height/5);
                        e.Graphics.FillRectangle(new SolidBrush(this.ForeColor),capBar);

                        capBar.Offset(1, 1);
                        capBar.Size = new SizeF(capBar.Width - 1, capBar.Height - 1);

                        SolidBrush usage = new SolidBrush((float)drive.AvailableFreeSpace / drive.TotalSize < (1-DiskThreshold) ? Color.Red : Color.DeepSkyBlue);
                        capBar.Size = new SizeF((capBar.Width)*(1.0f-(float)drive.AvailableFreeSpace / drive.TotalSize) , capBar.Height);

                        e.Graphics.FillRectangle(usage, capBar);
                        
                    } else if (!(e.Item.Tag as ListViewItemTag).EditingLabel)
                    {
                        LabelBounds = new Rectangle(new Point(IconBounds.Right + 9, e.Bounds.Top + 5), new Size(160, 48));
                        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.WordEllipsis | TextFormatFlags.ModifyString;
                        string extraSpace = "";
                        if (!((ListViewItemTag)e.Item.Tag).isTag)
                        {
                            int pixel = 10;
                            Rectangle temp = new Rectangle(new Point (LabelBounds.Location.X, LabelBounds.Location.Y+1), new Size(10, 10));
                            foreach (Database.Tag tag in (e.Item.Tag as ListViewItemTag).Tags)
                            {
                                PaintEllipse(e.Graphics, tag.color, this.ForeColor, temp);
                                temp.Offset(5, 0);
                                pixel += 5;

                            }
                            
                            if (pixel!=10)
                            {
                                int spaces = (int)Math.Ceiling(pixel*1d/4);
                                for (int i = 0; i < spaces; i++)
                                {
                                    extraSpace = extraSpace + " ";
                                }
                            }
                        }
                        TextRenderer.DrawText(e.Graphics,
                            extraSpace + e.Item.Text + "\n" + e.Item.SubItems[1].Text + "\n" + e.Item.SubItems[2].Text,
                            this.Font, LabelBounds, this.ForeColor, flags);
                    }
                    break;
                case View.Details:
                    IconBounds = new Rectangle(new Point(e.Bounds.Left + 5, e.Bounds.Top + 2), new Size(16, 16));
                    if (!(e.Item.Tag as ListViewItemTag).EditingLabel)
                    {
                        LabelBounds = new Rectangle(new Point(IconBounds.Right + 5, e.Bounds.Top + 2), new Size(1000, 16));
                        TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.WordEllipsis | TextFormatFlags.ModifyString;

                        Rectangle Name = new Rectangle(LabelBounds.Location, new Size(this.Columns[1].Width - LabelBounds.Location.X, 16));
                        Rectangle Date = new Rectangle(new Point(GetColumnLocation(1).X, LabelBounds.Y), new Size(this.Columns[1].Width, 16));
                        Rectangle Type = new Rectangle(new Point(GetColumnLocation(2).X, LabelBounds.Y), new Size(this.Columns[2].Width, 16));
                        Rectangle Size = new Rectangle(new Point(GetColumnLocation(3).X, LabelBounds.Y), new Size(this.Columns[3].Width, 16));

                        string extraSpace = "";
                        if (!((ListViewItemTag)e.Item.Tag).isTag)
                        {
                            int pixel = 10;
                            Rectangle temp = new Rectangle(new Point(LabelBounds.Location.X, LabelBounds.Location.Y + 1), new Size(10, 10));
                            foreach (Database.Tag tag in (e.Item.Tag as ListViewItemTag).Tags)
                            {
                                PaintEllipse(e.Graphics, tag.color, this.ForeColor, temp);
                                temp.Offset(5, 0);
                                pixel += 5;

                            }

                            if (pixel != 10)
                            {
                                int spaces = (int)Math.Ceiling(pixel * 1d / 4);
                                for (int i = 0; i < spaces; i++)
                                {
                                    extraSpace = extraSpace + " ";
                                }
                            }
                        }

                        TextRenderer.DrawText(e.Graphics, extraSpace+e.Item.SubItems[0].Text, this.Font, Name, this.ForeColor, flags);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[1].Text, this.Font, Date, this.ForeColor, flags);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[2].Text, this.Font, Type, this.ForeColor, flags);
                        TextRenderer.DrawText(e.Graphics, e.Item.SubItems[3].Text, this.Font, Size, this.ForeColor, flags);
                    }
                        break;
                case View.LargeIcon:
                    IconBounds = new Rectangle(new Point(e.Bounds.Left + 21, e.Bounds.Top + 3), new Size(48, 48));
                    icon = iconL;

                    if (!(e.Item.Tag as ListViewItemTag).EditingLabel)
                    {
                        LabelBounds = new Rectangle(new Point(e.Bounds.Left, IconBounds.Bottom + 3), new Size(e.Bounds.Width, e.Bounds.Height - 56));
                        TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.WordBreak | TextFormatFlags.Top;
                        string extraSpace = "";

                        if (!((ListViewItemTag)e.Item.Tag).isTag)
                        {
                            int pixel = 10;
                            Rectangle temp = new Rectangle(new Point(LabelBounds.Location.X+10, LabelBounds.Location.Y + 1), new Size(10, 10));
                            foreach (Database.Tag tag in (e.Item.Tag as ListViewItemTag).Tags)
                            {
                                PaintEllipse(e.Graphics, tag.color, this.ForeColor, temp);
                                temp.Offset(5, 0);
                                pixel += 5;

                            }

                            if (pixel != 10)
                            {
                                int spaces = (int)Math.Ceiling(pixel * 1d / 4);
                                for (int i = 0; i < spaces; i++)
                                {
                                    extraSpace = extraSpace + " ";
                                }
                            }
                        }
                        TextRenderer.DrawText(e.Graphics, extraSpace + e.Item.Text, this.Font, LabelBounds, this.ForeColor,flags);
                    }
                    break;
            }
            
            if (!((ListViewItemTag)e.Item.Tag).isTag)
            {
                e.Graphics.DrawIcon(icon, IconBounds);
            } else
            {
                PaintEllipse(e.Graphics, ((ListViewItemTag)e.Item.Tag).color, this.ForeColor, IconBounds);
            }
            
            //TextRenderer.DrawText(e.Graphics,e.Item.Text,this.Font,LabelBounds,this.ForeColor);
            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue),LabelBounds);
            //e.DrawDefault = true;
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

        #endregion
    }
}
