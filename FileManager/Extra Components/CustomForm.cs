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
using System.Threading;

namespace FileManager
{
    public partial class CustomForm : Form
    {
        private Size NormalSize;
        private Point mouseDownLocation; //Use for dragging the form
        public Theme currentTheme;

        #region Initialize
        public CustomForm()
        {
            this.DoubleBuffered = true;
            Theme dark = new Theme(Color.FromArgb(30, 30, 30));

            currentTheme = dark;
            InitializeComponent();
            this.MaximizedBounds = Screen.GetWorkingArea(this);

            HeaderTablePanel.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            LbTitle.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            HeaderTablePanel.MouseMove += new MouseEventHandler(HeaderTablePanel_MouseMove);

            BtnExit.Click += new EventHandler(BtnExit_Click);
            BtnMinimize.Click += new EventHandler(BtnMinimize_Click);
            BtnMaximize.Click += new EventHandler(BtnMaximize_Click);


            this.Resize += new EventHandler(MainForm_SizeChanged);
            ReloadTheme();
            NormalSize = this.Size;
        }



        #endregion

        #region Flags
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                OuterTablePanel.Rounded = true;
                this.BtnMaximize.Image = Resources.maximize;
                NormalSize = this.Size;
            }
            else
            {
                OuterTablePanel.Rounded = false;
                this.BtnMaximize.Image = Resources.shrink;

            }
            OuterTablePanel.Refresh();
        }

        #endregion

        #region Control Buttons
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }


        #endregion

        #region Theme
        private void ReloadTheme()
        {
            //Form
            this.BackColor = currentTheme.Unused;
            OuterTablePanel.BackColor = currentTheme.Unused;
            this.TransparencyKey = currentTheme.Unused;
            OuterTablePanel.TrueBackColor = currentTheme.lighterMain;
            this.LbTitle.ForeColor = currentTheme.text;
            this.LbTitle.Font = this.Font;

            foreach (Control c in this.Controls)
            {
                c.Font = this.Font;
            }


            this.Refresh();

        }

        #endregion

        #region Dragging
        private void HeaderTablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownLocation = new Point(-e.X, -e.Y);
        }

        private void HeaderTablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mouseOffset = Control.MousePosition;
                if (MousePosition.Y < 50 && this.WindowState == FormWindowState.Normal)
                {
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (MousePosition.Y >= 50 && this.WindowState == FormWindowState.Maximized)
                {
                    mouseDownLocation.X = -NormalSize.Width / 2;
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                    this.WindowState = FormWindowState.Normal;
                }
                else
                {
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                }
            }
        }



        #endregion

    }


}

