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

namespace FileManager
{
    public partial class FileManager : Form
    {
        public FileManager()
        {
            FMIntialize();//Just like Initailize Components
            //Add event
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            this.Load += new System.EventHandler(this.FileManager_Load);
        }

        //Create tree view when File Manger loads
        private void FileManager_Load(object sender, EventArgs e)
        {
            this.clsTreeListView.CreateTreeView(treeView);
        }

        //Handle event when a tree node is selected
        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;
            if (tn.Text != "This PC")
                clsTreeListView.ShowFolderTree(treeView, listView, e.Node);
        }

        private void MainTablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.listView.FocusedItem;
            clsTreeListView.ClickItem(this.listView, item);
        }

        private void listView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar ==(int)Keys.Enter)
            {
                ListViewItem item=this.listView.FocusedItem;
                clsTreeListView.ClickItem(this.listView, item);
            }
        }
    }
}
