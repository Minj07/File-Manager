using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using FileManager.Properties;

namespace FileManager
{
    public partial class FileManager : Form
    {
        private ClsTreeListView clsTreeListView = new ClsTreeListView(); //Generate a ClsTreeListView object
        private string currentAddr;
        private Point mouseLocation; //Use for dragging the form

        #region Initialize
        private void FMIntialize()
        {
            this.DoubleBuffered = true;
            Theme dark = new Theme(Color.FromArgb(30,30,30));
            currentTheme = dark;
            InitializeComponent();
            reloadTheme();
            currentAddr = "C:/";            
        }
        #endregion


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var graphicsPath = _getRoundRectangle(this.ClientRectangle))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var brush = new SolidBrush(currentTheme.lighterMain))
                    e.Graphics.FillPath(brush, graphicsPath);
                using (var pen = new Pen(currentTheme.lighterMain, 1.0f))
                    e.Graphics.DrawPath(pen, graphicsPath);
                TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, this.ForeColor);
            }
        }

        private GraphicsPath _getRoundRectangle(Rectangle rectangle)
        {
            int cornerRadius = 15; // change this value according to your needs
            int diminisher = 1;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(rectangle.X + rectangle.Width - cornerRadius - diminisher, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(rectangle.X, rectangle.Y + rectangle.Height - cornerRadius - diminisher, cornerRadius, cornerRadius, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private void reloadTheme()
        {
            //Change Back Color
            foreach (Button b in this.Controls.OfType<Button>())
            {
                
            }
            //Form
            this.BackColor = currentTheme.lighterMain;

            //Navigation
            this.NavigationTablePanel.BackColor = currentTheme.darkerMain;
            foreach (Button b in new Button[] {BtnBack, BtnForward, BtnRecent, BtnParentFolder}) {
                b.BackColor = currentTheme.darkerMain;
                b.FlatAppearance.MouseOverBackColor = currentTheme.lighterMain;
            }
            foreach (TextBox t in new TextBox[] {TxtBxAddress, TxtBxSearch })
            {
                t.BackColor = currentTheme.darkerMain;

                t.ForeColor = currentTheme.text;
            }
            this.TxtBxAddress.BackColor = currentTheme.darkerMain;
            //Display
            this.listView.BackColor = currentTheme.main;
            this.listView.ForeColor = currentTheme.text;
            this.treeView.BackColor = currentTheme.main;
            this.treeView.ForeColor = currentTheme.text;
            
        }


        //Functions For Dragging the Form (Open)
        private void HeaderTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void HeaderTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
                if (mouseLocation.Y < 100)
                {

                }
            }
        }
    }
    //Functions For Dragging the Form (Close)

}

