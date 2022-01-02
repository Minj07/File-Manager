using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace FileManager
{
    internal class CustomTreeView : TreeView
    {
        private enum SHGFI
        {
            SmallIcon = 0x00000001,
            LargeIcon = 0x00000000,
            Icon = 0x00000100,
            DisplayName = 0x00000200,
            Typename = 0x00000400,
            SysIconIndex = 0x00004000,
            UseFileAttributes = 0x00000010
        }

        protected void cap(ref int input, int min, int max)
        {
            input = (input < min ? min : input);
            input = (input > max ? max : input);
        }

        private Icon ExpandDown;

        private Icon ExpandRight;

        //private int Offset = 0;

        public Color SelectedOverlayColor { get; set; } = Color.FromArgb(255, 255, 255);
       
        public Color HoverOverlayColor { get; set; } = Color.FromArgb(255, 255, 255);

        private int TopOffset;

        public class TreeNodeTag
        {
            public TreeNodeTag( Icon CustomIcon, bool hasChild)
            {
                this.icon = CustomIcon;
                this.hasChild = hasChild;
                color = Color.Empty;
                isTag = false;
            }

            public TreeNodeTag(Color color,int id, bool hasChild)
            {
                this.color = color;
                this.hasChild= hasChild;
                isTag = true;
                this.TagId = id;
            }

            public int TagId { get; set; }
            public bool hasChild { get; set; }

            public bool isTag { get; set; }

            public Color color;

            public Icon icon { get; set; }
        }
        public CustomTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            HotTracking = true;
            Graphics g = this.CreateGraphics();
            ItemHeight = (int)g.MeasureString(" ", this.Font).Height * 7 / 4;   //(1.75)
            TopOffset = ItemHeight * 3 / 14;                                    //((0.75/2)/1.75)
            ExpandDown = Icon.FromHandle(
                Theme.Recolor(
                    Theme.ResizeImage(Properties.Resources.expand_down_arrow, 16, 16), Color.White)
                .GetHicon()
                );
            ExpandRight = Icon.FromHandle(
                Theme.Recolor(
                    Theme.ResizeImage(Properties.Resources.expand_right_arrow, 16, 16), Color.White)
                .GetHicon()
                );
        }


        private int NodeLevel(TreeNode node)
        {
            if (node.Parent == null) return 0;
            return NodeLevel(node.Parent)+1;
            
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            object debug = this.Nodes;
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            Rectangle Bound = e.Bounds;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor),e.Bounds);
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);

            if (e.State.HasFlag(TreeNodeStates.Hot))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, HoverOverlayColor)), Bound);
            }

            if (e.State.HasFlag(TreeNodeStates.Selected))
            {
               e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40,SelectedOverlayColor)), Bound);
            }


            bool hasChild = ((TreeNodeTag)e.Node.Tag).hasChild;
            Icon icon = ((TreeNodeTag)e.Node.Tag).icon;
            Point StartingPoint = new Point(Bound.Location.X + (NodeLevel(e.Node) * Indent), Bound.Location.Y);// + TopOffset);

            if (icon==null)
            {
                icon = Properties.Resources.Folder;                    
            }

            if (icon.Size!=new Size(16,16))
            {
                icon = Icon.FromHandle(Theme.ResizeImage(icon.ToBitmap(), 16, 16).GetHicon());
            }
            if (((TreeNodeTag)e.Node.Tag).hasChild&& !((TreeNodeTag)e.Node.Tag).isTag)
            {
                if (e.Node.IsExpanded)
                {
                    e.Graphics.DrawIcon(this.ExpandDown, Bound.Location.X + (NodeLevel(e.Node) * Indent), Bound.Location.Y + TopOffset);
                } else
                {
                    e.Graphics.DrawIcon(this.ExpandRight, Bound.Location.X + (NodeLevel(e.Node) * Indent), Bound.Location.Y + TopOffset);
                }
            }
            if (!((TreeNodeTag)e.Node.Tag).isTag)
            {
                e.Graphics.DrawIcon(icon, Bound.Location.X + (NodeLevel(e.Node) * Indent) + 20, Bound.Location.Y + TopOffset);
                
            } else
            {
                Rectangle colorBall = new Rectangle((NodeLevel(e.Node) * Indent) + 20, Bound.Location.Y + TopOffset, 16, 16);
                e.Graphics.FillEllipse(new SolidBrush(((TreeNodeTag)e.Node.Tag).color), colorBall);
                e.Graphics.DrawEllipse(new Pen(this.ForeColor, 1), colorBall);
            }
            TextRenderer.DrawText(e.Graphics,e.Node.Text, this.Font, new Point(Bound.Location.X + (NodeLevel(e.Node) * Indent) + 36, Bound.Location.Y+TopOffset), this.ForeColor);

           
            base.OnDrawNode(e);
        }


    }
}
