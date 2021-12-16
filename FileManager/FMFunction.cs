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
    public partial class MainForm
    {
        private Size NormalSize;
        private string currentAddr;
        private bool changingAddress = false;
        private Point mouseDownLocation; //Use for dragging the form

        #region Initialize
        private void FMIntialize()
        {
            this.DoubleBuffered = true;
            Theme dark = new Theme(Color.FromArgb(30,30,30));
            currentTheme = dark;
            InitializeComponent();
            this.MaximizedBounds = Screen.GetWorkingArea(this);

            HeaderTablePanel.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            HeaderTablePanel.MouseMove += new MouseEventHandler(HeaderTablePanel_MouseMove);

            BtnExit.Click += new EventHandler(BtnExit_Click);
            BtnMinimize.Click += new EventHandler(BtnMinimize_Click);
            BtnMaximize.Click += new EventHandler (BtnMaximize_Click);
            this.listView.MouseHover += ListView_MouseHover;

            this.Resize += new EventHandler(MainForm_SizeChanged);
          

            ReloadTheme();

            currentAddr = "C:/";
            NormalSize = this.Size;
        }

        #endregion

        #region Flags
        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                OuterTablePanel.Rounded = true;
                NormalSize = this.Size;
            }
            else
            {
                OuterTablePanel.Rounded = false;

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
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            } else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }
        #endregion

        #region Reload Theme
        private void ReloadTheme()
        {
            //Form
            this.BackColor = currentTheme.Unused;
            OuterTablePanel.BackColor = currentTheme.Unused;
            this.TransparencyKey = currentTheme.Unused;
            OuterTablePanel.TrueBackColor = currentTheme.lighterMain;

            foreach (Control c in this.Controls)
            {
                c.Font = this.Font;
            }

            //Toolbar

            this.ToolTablePanel.BackColor = currentTheme.darkerMain;
            foreach (Button b in new Button[] { BtnCut, BtnCopy, BtnPaste, BtnRename, BtnDelete })
            {
                b.BackColor = currentTheme.main;
                b.FlatAppearance.MouseOverBackColor = currentTheme.lighterMain;
            }

            //Navigation

            this.NavigationTablePanel.BackColor = currentTheme.darkerMain;
            foreach (Button b in new Button[] { BtnBack, BtnForward, BtnRecent, BtnParentFolder, BtnGoRefresh, BtnDisplayInfo, BtnDisplayThumbnail})
            {
                b.BackColor = currentTheme.darkerMain;
                b.FlatAppearance.MouseOverBackColor = currentTheme.lighterMain;
            }

            AddressTablePanel.BackColor = currentTheme.darkerMain;
            AddressTablePanel.BorderColor = currentTheme.lighterMain;
            CbAddress.BackColor = currentTheme.darkerMain;
            CbAddress.ForeColor = currentTheme.text;

            foreach (TextBox t in new TextBox[] { TxtBxSearch })
            {
                t.BackColor = currentTheme.darkerMain;
                t.ForeColor = currentTheme.text;
            }



            //Display
            this.listView.BackColor = currentTheme.main;
            this.listView.ForeColor = currentTheme.text;
            this.treeView.BackColor = currentTheme.main;
            this.treeView.ForeColor = currentTheme.text;

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
                if (MousePosition.Y<50 && this.WindowState == FormWindowState.Normal)
                {
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                    this.WindowState = FormWindowState.Maximized;
                } else if (MousePosition.Y>=50 && this.WindowState == FormWindowState.Maximized)
                {
                    mouseDownLocation.X = -NormalSize.Width / 2;
                    TxtBxSearch.Text = mouseDownLocation.ToString();
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                    this.WindowState = FormWindowState.Normal;
                } else
                {
                    mouseOffset.Offset(mouseDownLocation.X, mouseDownLocation.Y);
                    this.Location = mouseOffset;
                }
            }
        }



        #endregion

        #region Extra

        private void ListView_MouseHover(object sender, EventArgs e)
        {

        }
        #endregion
    }


}

