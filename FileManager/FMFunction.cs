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
        private TagDatabase tagDatabase = new TagDatabase();
        private List<ToolStripMenuItem> MenuTagItemList =  new List<ToolStripMenuItem>();

        #region Initialize
        private void FMIntialize()
        {
            this.DoubleBuffered = true;
            Theme dark = new Theme(Color.FromArgb(30,30,30));

            currentTheme = dark;
            InitializeComponent();
            this.MaximizedBounds = Screen.GetWorkingArea(this);

            HeaderTablePanel.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            LbTitle.MouseDown += new MouseEventHandler(HeaderTablePanel_MouseDown);
            HeaderTablePanel.MouseMove += new MouseEventHandler(HeaderTablePanel_MouseMove);

            BtnExit.Click += new EventHandler(BtnExit_Click);
            BtnMinimize.Click += new EventHandler(BtnMinimize_Click);
            BtnMaximize.Click += new EventHandler (BtnMaximize_Click);
            BtnChangeTheme.Click += new EventHandler(BtnChangeTheme_Click);
            this.listView.MouseHover += ListView_MouseHover;
            this.CbAddress.TextChanged += CbAddress_TextChanged1;


            this.Resize += new EventHandler(MainForm_SizeChanged);
            ReloadTheme();
            this.UpdateMenuTag();
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

            //Toolbar

            this.ToolTablePanel.BackColor = currentTheme.darkerMain;
            this.ToolbarSeparator.BackColor = currentTheme.lighterMain;
            foreach (Button b in new Button[] { BtnCut, BtnCopy, BtnPaste, BtnRename, BtnDelete, BtnChangeTheme, BtnArchive })
            {
                b.BackColor = currentTheme.main;
                b.FlatAppearance.MouseOverBackColor = currentTheme.lighterMain;
            }
            this.MenuNew.BackColor = currentTheme.main;
            this.MenuNew.ForeColor = currentTheme.text;
            this.MenuNewItem.BackColor = currentTheme.main;
            this.MenuNewItem.ForeColor = currentTheme.text;
            this.MenuItemNewFolder.BackColor = currentTheme.main;
            this.MenuItemNewFolder.ForeColor = currentTheme.text;
            this.MenuItemNewTextFile.BackColor = currentTheme.main;
            this.MenuItemNewTextFile.ForeColor = currentTheme.text;
            this.MenuTag.BackColor = currentTheme.main;

            //Navigation

            this.NavigationTablePanel.BackColor = currentTheme.darkerMain;
            foreach (Button b in new Button[] { BtnBack, BtnForward, BtnRecent, BtnParentFolder, BtnGoRefresh})
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

            this.Refresh();

        }
        private void BtnChangeTheme_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    currentTheme = new Theme(colorDialog.Color);
                    ReloadTheme();
                }
            }
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

        #region Tag

        private void UpdateMenuTag()
        {
            MenuTagItemList.Clear();
            this.MenuTagItem.DropDownItems.Clear();
            TagDatabase tagDatabase = new TagDatabase();
            foreach (TagDatabase.Tag tag in TagDatabase.Tags)
            {
                MenuTagItemList.Add(new ToolStripMenuItem()
                {
                    Text = tag.name,
                    BackColor = tag.color,
                    ForeColor = this.ForeColor,
                });

                ToolStripMenuItem ToggleBtn = new ToolStripMenuItem()
                {
                    Text = "Toggle Tag",
                    BackColor = tag.color,
                    ForeColor = this.ForeColor,
                    Tag = tag.id,
                };
                ToggleBtn.Click += TagMenuToggleBtnClick;
                MenuTagItemList.Last().DropDownItems.Add(ToggleBtn);

                ToolStripMenuItem ModifyBtn = new ToolStripMenuItem()
                {
                    Text = "Modify Tag",
                    BackColor = tag.color,
                    ForeColor = this.ForeColor,
                    Tag = tag.id,
                };
                ModifyBtn.Click += TagMenuModifyBtnClick;
                MenuTagItemList.Last().DropDownItems.Add(ModifyBtn);

                ToolStripMenuItem RemoveBtn = new ToolStripMenuItem()
                {
                    Text = "Remove Tag",
                    BackColor = tag.color,
                    ForeColor = this.ForeColor,
                    Tag = tag.id,
                };
                RemoveBtn.Click += TagMenuRemoveBtnClick;
                MenuTagItemList.Last().DropDownItems.Add(RemoveBtn);

                this.MenuTagItem.DropDownItems.Add(MenuTagItemList.Last());
            }
            ToolStripMenuItem AddBtn = new ToolStripMenuItem()
            {
                Text = "Add New Tag",
                BackColor = currentTheme.main,
                ForeColor = currentTheme.text,
            };
            AddBtn.Click += TagMenuAddBtnClick;
            this.MenuTagItem.DropDownItems.Add(AddBtn);
            UpdateViews();
        }

        private void TagMenuAddBtnClick(object sender, EventArgs e)
        {
            using (CreateTagForm frm = new CreateTagForm()
            {
                BackColor = currentTheme.main,
                Font = this.Font,
                ForeColor = this.ForeColor,
                Text = "Create new Tag"
            })
            {
                frm.LblName.BackColor = frm.BackColor;
                frm.LblName.ForeColor = this.ForeColor;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    TagDatabase.AddTag(frm.TxtBoxName.Text, frm.color);
                }
            }

            UpdateMenuTag();
        }

        private void TagMenuToggleBtnClick(object sender, EventArgs e)
        {
            TagDatabase.Tag tag = TagDatabase.GetTag((int)((ToolStripMenuItem)sender).Tag);
            if (this.listView.SelectedItems.Count != 0)
            {
                foreach (ListViewItem item in this.listView.SelectedItems)
                {
                    if (tag.items.Contains(item.SubItems[4].Text))
                    {
                        tag.Remove(item.SubItems[4].Text);
                    }
                    else
                    {
                        tag.Insert(item.SubItems[4].Text);
                    }
                }
            }
            UpdateViews();
        }

        private void TagMenuModifyBtnClick(object sender, EventArgs e)
        {
            TagDatabase.Tag tag = TagDatabase.GetTag((int)((ToolStripMenuItem)sender).Tag);
            using (CreateTagForm frm = new CreateTagForm()
            {
                BackColor = currentTheme.main,
                Font = this.Font,
                ForeColor = this.ForeColor,
                Text = "Modify Tag",
                color = tag.color,
            })
            {
                frm.TxtBoxName.Text = tag.name;
                frm.BtnColor.BackColor = tag.color;
                frm.BtnOk.Text = "Apply";
                frm.LblName.BackColor = frm.BackColor;
                frm.LblName.ForeColor = this.ForeColor;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    tag.Modify(frm.TxtBoxName.Text, frm.color);
                }
            }
            UpdateMenuTag();
        }

        private void TagMenuRemoveBtnClick(object sender, EventArgs e)
        {
            TagDatabase.Tag tag = TagDatabase.GetTag((int)((ToolStripMenuItem)sender).Tag);
            tag.Delete();
            UpdateMenuTag();
        }

        #endregion

        #region Extra

        private void CbAddress_TextChanged1(object sender, EventArgs e)
        {
            LbTitle.Text = currentAddr;
        }

        public void UpdateViews()
        {
            if (this.treeView.Nodes.Count == 0) return;
            clsTreeListView.RefreshTagNode(this.treeView);
            if (this.treeView.Nodes.Find(CbAddress.Text, true).Length == 0) return;
            clsTreeListView.ShowContent(this.listView, this.treeView.Nodes.Find(CbAddress.Text, true)[0]);
        }

        private void ListView_MouseHover(object sender, EventArgs e)
        {

        }
        #endregion
    }


}

