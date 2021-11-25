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



        private void reloadTheme()
        {
            //Change Back Color
            foreach (Button b in this.Controls.OfType<Button>())
            {
                
            }
            //Form
            this.BackColor = currentTheme.Unused;
            OuterTablePanel.BackColor = currentTheme.Unused;
            this.TransparencyKey = currentTheme.Unused;
            OuterTablePanel.TrueBackColor = currentTheme.lighterMain;
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


        
    }
    //Functions For Dragging the Form (Close)

}

