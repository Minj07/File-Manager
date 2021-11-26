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
    public class RoundedButton : Button
    {
        public Color BorderColor { get; set; } = DefaultBackColor;
        public Color HoverColor { get; set; } = DefaultBackColor;
        public Color ActivatedColor { get; set; }
        public int CornerRadius { get; set; } = 15;
        public float BorderSize { get; set; } = 1;


        public RoundedButton()
        {
            this.DoubleBuffered = true;
            if (BorderColor == null) BorderColor = BackColor;
            if (ActivatedColor == null) ActivatedColor = BackColor;
        }

        #region Activated and Hover

        private bool Hover { get; set; } = false;
        private bool Activated { get; set; } = false;

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            Activated = true;
            this.Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            Activated = false;
            this.Refresh();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Hover = true;
            this.Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Hover = false;
            this.Refresh();
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = getRoundRectangle(this.ClientRectangle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                using (var brush = new SolidBrush((Hover ? (Activated ? ActivatedColor : HoverColor) : BackColor)))
                    e.Graphics.FillPath(brush, graphicsPath);
                using (var pen = new Pen(BorderColor, 1.0f))
                    e.Graphics.DrawPath(pen, graphicsPath);
                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }

        private GraphicsPath getRoundRectangle(Rectangle rectangle)
        {

            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - CornerRadius - diminisher, rectangle.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - CornerRadius - diminisher, rectangle.Y + rectangle.Height - CornerRadius - diminisher, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - CornerRadius - diminisher, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
