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
    public partial class TagForm : Form
    {
        private Size NormalSize;
        private Point mouseDownLocation; //Use for dragging the form
        public Theme currentTheme;
        public Color color { get; set; } = Color.Red;

        #region Initialize
        public TagForm()
        {
            currentTheme = new Theme(Color.FromArgb(30, 30, 30));
            this.DoubleBuffered = true;

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
        public void ReloadTheme()
        {
            //Form
            this.BackColor = currentTheme.Unused;
            OuterTablePanel.BackColor = currentTheme.Unused;
            this.TransparencyKey = currentTheme.Unused;
            OuterTablePanel.TrueBackColor = currentTheme.darkerMain;
            this.MainPanel.BackColor = currentTheme.lighterMain;
            this.LbTitle.ForeColor = currentTheme.text;
            
            foreach (Control c in this.Controls)
            {
                c.Font = this.Font;
            }

            this.LblName.BackColor = Color.Transparent;
            this.LblName.ForeColor = currentTheme.text;

            BtnColor.BackColor = color;

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
                //if (MousePosition.Y < 50 && this.WindowState == FormWindowState.Normal)
                //{
                //    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                //    this.Location = mouseOffset;
                //    this.WindowState = FormWindowState.Maximized;
                //}
                //else if (MousePosition.Y >= 50 && this.WindowState == FormWindowState.Maximized)
                //{
                //    mouseDownLocation.X = -NormalSize.Width / 2;
                //    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                //    this.Location = mouseOffset;
                //    this.WindowState = FormWindowState.Normal;
                //}
                //else
                //{
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                //}
            }
        }



        #endregion

        private void BtnColor_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                DialogResult result = colorDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    color = colorDialog.Color;
                    BtnColor.BackColor = color;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }


}

