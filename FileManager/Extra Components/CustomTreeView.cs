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

        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo
        (
            string pszPath,
            uint dwFileAttributes,
            out SHFILEINFO psfi,
            uint cbfileInfo,
            SHGFI uFlags
        );


        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero; iIcon = 0; dwAttributes = 0; szDisplayName = ""; szTypeName = "";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
            public string szTypeName;
        };



        //public int Indent { get; set; } = 10;

        private Icon ExpandDown = ResizeImage(Properties.Resources.expand_down_arrow,16,16);

        private Icon ExpandRight = ResizeImage(Properties.Resources.expand_right_arrow, 16, 16);

        private int angle = 0;

        public int Angle
        {
            get { return angle; }
            set { angle = value; Invalidate(); } }

        private Timer AngleDelay = new Timer();

        private System.ComponentModel.IContainer components;

        public Color SelectedOverlayColor { get; set; } = Color.FromArgb(255, 255, 255);
       
        public Color HoverOverlayColor { get; set; } = Color.FromArgb(255, 255, 255);

        private int TopOffset;

        public class TreeNodeTag
        {
            public TreeNodeTag(string address,Icon CustomIcon = null)
            {
                this.address = address;
                this.icon = CustomIcon;
            }

            public string address { get; set; }

            public Icon icon { get; set; }
        }
        public CustomTreeView()
        {
            DrawMode = TreeViewDrawMode.OwnerDrawAll;
            HotTracking = true;
            ShowLines = false;
            Scrollable = false;
            Graphics g = this.CreateGraphics();
            ItemHeight = (int)g.MeasureString(" ", this.Font).Height * 7 / 4;   //(1.75)
            TopOffset = ItemHeight * 3 / 14;                                    //((0.75/2)/1.75)
            AngleDelay.Interval = 50;
            AngleDelay.Start();
            AngleDelay.Tick += (s, e) => { Angle = (Angle + 1) % 360; };
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Icon ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return Icon.FromHandle(destImage.GetHicon());
        }

        private int NodeLevel(TreeNode node)
        {
            if (node.Parent == null) return 0;
            return NodeLevel(node.Parent)+1;
        }

        public static Icon GetDirectoryIcon(string dirName, bool largeIcon)
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            int cbFileInfo = Marshal.SizeOf(_SHFILEINFO);
            SHGFI flags = SHGFI.Icon;
            if (largeIcon)
                flags |= SHGFI.LargeIcon;
            else
                flags |= SHGFI.SmallIcon;

            IntPtr IconIntPtr = SHGetFileInfo(dirName, 0, out _SHFILEINFO, (uint)cbFileInfo, flags);
            if (IconIntPtr.Equals(IntPtr.Zero))
                return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle Bound = new Rectangle(this.Location.X,e.Bounds.Y,this.Bounds.Width,e.Bounds.Height);

            e.Graphics.FillRectangle(new SolidBrush(this.BackColor),Bound);

            if (e.State.HasFlag(TreeNodeStates.Hot))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, HoverOverlayColor)), Bound);
            }

            if (e.State.HasFlag(TreeNodeStates.Selected))
            {
               e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40,SelectedOverlayColor)), Bound);
            }

            if (e.Node.Text != "This PC")
            {
                string FullPath = ClsTreeListView.GetFullPath(e.Node.FullPath);
                try
                {
                    bool hasChild = (new DirectoryInfo(FullPath))
                        .GetDirectories().Count() != 0;
                }
                catch (UnauthorizedAccessException) { }
                Icon icon = GetDirectoryIcon(FullPath, false);

                Point StartingPoint = new Point(Bound.Location.X + (NodeLevel(e.Node) * Indent), Bound.Location.Y + TopOffset);

                if (icon==null)
                {
                    icon = Properties.Resources.Folder;
                    
                }

                if (icon.Size!=new Size(16,16))
                {
                    icon = ResizeImage(icon.ToBitmap(), 16, 16);
                }

                e.Graphics.DrawIcon(icon, Bound.Location.X + (NodeLevel(e.Node) * Indent), Bound.Location.Y+TopOffset);
                TextRenderer.DrawText(e.Graphics, e.Node.Text, this.Font, new Point(Bound.Location.X + (NodeLevel(e.Node) * Indent) + icon.Width, Bound.Location.Y+TopOffset), this.ForeColor);
            } else
            {
                TextRenderer.DrawText(e.Graphics, e.Node.Text, this.Font, new Point(Bound.Location.X + (NodeLevel(e.Node) * Indent), Bound.Location.Y+TopOffset), this.ForeColor);
            }
            
            //e.Graphics.DrawString(e.Node.Text, this.Font, new SolidBrush(this.ForeColor), Bound);
            base.OnDrawNode(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.FillRectangle(new LinearGradientBrush(pevent.ClipRectangle, this.BackColor, Color.Yellow, Angle), pevent.ClipRectangle);
        }

    }
}
