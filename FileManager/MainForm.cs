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
using System.IO;
using System.Diagnostics;
using FileManager.Properties;

namespace FileManager
{
    public partial class MainForm : Form
    {
        private ClsTreeListView clsTreeListView = new ClsTreeListView(); //Generate a ClsTreeListView object
        public MainForm()
        {
            FMIntialize();//Just like Initailize Components
        }

        //Create tree view when File Manger loads
        private void FileManager_Load(object sender, EventArgs e)
        {
            this.clsTreeListView.CreateTreeView(treeView);
        }

        //Handle event when a tree node is selected
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "This PC"||e.Node.Checked)
                clsTreeListView.ShowContent(listView, e.Node);

            else clsTreeListView.ShowFolderTree(treeView, listView, e.Node);

            CbAddress.Text = clsTreeListView.GetFullPath(e.Node.FullPath);
        }

        private void MainTablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.listView.FocusedItem;
            if(clsTreeListView.ClickItem(this.listView, item))
                CbAddress.Text = item.SubItems[4].Text;
        }

        private void listView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(int)Keys.Enter)
                clsTreeListView.ClickItem(this.listView, this.listView.FocusedItem);
        }

        private void BtnGoRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                if (CbAddress.Text == "This PC")
                    clsTreeListView.ShowContent(listView, treeView.Nodes[0]);
                else if (CbAddress.Text != " ") 
                {
                    FileInfo fileInfo = new FileInfo(CbAddress.Text.Trim());
                    if (fileInfo.Exists)
                    {
                        Process.Start(fileInfo.FullName);
                        DirectoryInfo directoryInfo= fileInfo.Directory;
                        CbAddress.Text = directoryInfo.FullName;
                    }
                    else
                    {
                        clsTreeListView.ShowContent(listView, CbAddress.Text.Trim());
                    }
                }
                CbAddress.Items.Add(CbAddress.Text);
            }
            catch (IOException)
            {
                MessageBox.Show("Can't find '" + CbAddress.Text + "'. Check the spelling and try again", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You don't currently have permission to access this file.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            changingAddress = false;
            if (changingAddress)
            {
                BtnGoRefresh.Image = Resources.right_arrow;
            }
            else
            {
                BtnGoRefresh.Image = Resources.reboot;
            }
        }

        private void CbAddress_TextChanged(object sender, EventArgs e)
        {
            changingAddress = true;
            if (changingAddress)
            {
                BtnGoRefresh.Image = Resources.right_arrow;
            }
            else
            {
                BtnGoRefresh.Image = Resources.reboot;
            }
        }

        private void CbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
                BtnGoRefresh_Click(sender, e);
        }
    }
}
