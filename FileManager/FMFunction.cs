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
    public partial class MainForm
    {
        
        private string currentAddr;
        private bool changingAddress = false;
        private Point mouseLocation; //Use for dragging the form

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

            this.Resize += new EventHandler(MainForm_SizeChanged);

            

            ReloadTheme();

            currentAddr = "C:/";            
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

        private void ReloadTheme()
        {
            //Form
            this.BackColor = currentTheme.Unused;
            OuterTablePanel.BackColor = currentTheme.Unused;
            this.TransparencyKey = currentTheme.Unused;
            OuterTablePanel.TrueBackColor = currentTheme.lighterMain;

            //Navigation

            this.NavigationTablePanel.BackColor = currentTheme.darkerMain;
            foreach (Button b in new Button[] { BtnBack, BtnForward, BtnRecent, BtnParentFolder ,BtnGoRefresh})
            {
                b.BackColor = currentTheme.darkerMain;
                b.FlatAppearance.MouseOverBackColor = currentTheme.lighterMain;
            }

            if (changingAddress)
            {
                BtnGoRefresh.Image = Resources.right_arrow;
            } else
            {
                BtnGoRefresh.Image = Resources.reboot;
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

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                OuterTablePanel.Rounded = true;
                
            } else
            {
                OuterTablePanel.Rounded=false;

            }
            OuterTablePanel.Refresh();
        }

        #region Dragging
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
                if (MousePosition.Y<50)
                {
                    this.WindowState = FormWindowState.Maximized;
                } else if (MousePosition.Y>=50 && this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                }
            }
        }

        

        #endregion
    }


}

