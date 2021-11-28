using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    internal class RoundedTablePanel : TableLayoutPanel
    {
        private bool rounded;
        public Color TrueBackColor { get; set; }
        public Color BorderColor { get; set; }
        public bool Rounded {
            get {
                return rounded;
            }

            set
            {
                if (rounded != value)
                {
                    rounded = value;
                    this.Refresh();
                }
            }
        } 
        public int CornerRadius { get; set; } = 50;

        public RoundedTablePanel()
        {
            rounded = true;
            TrueBackColor = Color.Black;
            this.DoubleBuffered = true;
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (BorderColor == null) BorderColor = TrueBackColor;
            BackColor = (rounded?Color.Transparent:TrueBackColor);
            base.OnPaint(e);
            using (var graphicsPath = getRoundRectangle(this.ClientRectangle,Rounded))
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                using (var brush = new SolidBrush(TrueBackColor))
                    e.Graphics.FillPath(brush, graphicsPath);
                using (var pen = new Pen(BorderColor, 1.0f))
                    e.Graphics.DrawPath(pen, graphicsPath);
                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
            
        }

        private GraphicsPath getRoundRectangle(Rectangle rectangle, bool rounded)
        {
            if (CornerRadius == 0) CornerRadius = 50;
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            if (rounded)
            {
                path.AddArc(rectangle.X, rectangle.Y, CornerRadius, CornerRadius, 180, 90);
                path.AddArc(rectangle.X + rectangle.Width - CornerRadius - diminisher, rectangle.Y, CornerRadius, CornerRadius, 270, 90);
                path.AddArc(rectangle.X + rectangle.Width - CornerRadius - diminisher, rectangle.Y + rectangle.Height - CornerRadius - diminisher, CornerRadius, CornerRadius, 0, 90);
                path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - CornerRadius - diminisher, CornerRadius, CornerRadius, 90, 90);
            } else
            {
                path.AddLine(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Y);
                path.AddLine(rectangle.Width, rectangle.Y, rectangle.Width, rectangle.Height);
                path.AddLine(rectangle.Width, rectangle.Height, rectangle.X, rectangle.Height);
                path.AddLine(rectangle.X, rectangle.Height, rectangle.X, rectangle.Y);
            }
            path.CloseAllFigures();
            return path;
        }
    }
}
