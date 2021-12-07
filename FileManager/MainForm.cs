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
using Microsoft.VisualBasic.FileIO;

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
            bool isOK;
            if (e.Node.Name == "This PC" || e.Node.Checked)
                isOK = clsTreeListView.ShowContent(listView, e.Node);

            else isOK = clsTreeListView.ShowFolderTree(treeView, listView, e.Node);

            if(isOK)
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
            if (this.listView.FocusedItem == null) return;
            ListViewItem item = this.listView.FocusedItem;
            if (e.KeyChar == (int)Keys.Enter)
                if(clsTreeListView.ClickItem(this.listView, this.listView.FocusedItem))
                    CbAddress.Text=item.SubItems[4].Text;
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
                currentAddr = CbAddress.Text;
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
            if (this.CbAddress.Focused)
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
            else currentAddr = CbAddress.Text;
        }

        private void CbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)
                BtnGoRefresh_Click(sender, e);
        }

        #region Create button
        //Create button cut,copy,paste,delete
        private bool isCopying;
        private List<bool> isFolder;
        private bool isListView;
        private List<ListViewItem> itemPaste;
        private List<string> path;

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            isFolder = new List<bool>();
            path = new List<string>();
            isCopying = true;
            if (isListView)
            {
                itemPaste = GetSelectedListViewItems();

                if (itemPaste == null)
                    return;

                foreach (ListViewItem item in itemPaste)
                {
                    if (item.SubItems[2].Text == "File folder")
                        isFolder.Add(true);
                    else isFolder.Add(false);
                    path.Add(item.SubItems[4].Text);
                }
            }
            /*else if(this.treeView.Focused)
            {
                isListView=false;
                isFolder = true;
                path = clsTreeListView.GetFullPath(nodeFocus.FullPath);
            }*/
            BtnPaste.Enabled = true;
        }

        //private bool isCutting;
        private void BtnCut_Click(object sender, EventArgs e)
        {
            isCopying=false;
            if(isListView)
            {

                itemPaste = GetSelectedListViewItems();                
                if (itemPaste == null)
                    return;

                foreach (ListViewItem item in itemPaste)
                {
                    item.ForeColor = Color.LightGray;
                    if (item.SubItems[2].Text == "File folder")
                        isFolder.Add(true);
                    else isFolder.Add(false);
                    path.Add(item.SubItems[4].Text);
                }
            }
            /*else if(this.treeView.Focused)
            {
                isListView = false;
                isFolder=true;
                path = clsTreeListView.GetFullPath(this.treeView.SelectedNode.FullPath);
            }*/
            BtnPaste.Enabled=true;
        }
        #endregion

        private void Paste()
        {
            try
            {
                List<string> pathSource = path;
                List<string> pathDest = new List<string>();
                //Assign name to file copied
                foreach (ListViewItem item in itemPaste)
                    pathDest.Add(clsTreeListView.GetFullPath(currentAddr + "\\" + item.Text));

                List<string> listConflict = new List<string>();
                int countCopying = 0;
                //Check if having problem
                for (int i = 0; i < itemPaste.Count; i++)
                {
                    //Check if the destination folder is a subfolder of the source folder or not and handle it
                    if (isFolder[i])
                    {
                        if (currentAddr.Contains(pathSource[i]))
                        {
                            DialogResult result = MessageBox.Show("The destination folder is a subfolder of the source folder : " +
                                             "\n" + pathSource[i] + "\nDo you want to skip ? ", "Interrupted Action", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                pathSource[i] = null;
                                continue;
                            }
                            else return;
                        }
                    }

                    //Count copy items
                    if (isFolder[i])
                        countCopying += CountItem(pathSource[i]);
                    else countCopying++;

                    //Handle problem 
                    if (pathDest[i] == pathSource[i])
                    {
                        int copy = 2;
                        pathDest[i] += " - Copy";
                        if (isFolder[i])
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(currentAddr);
                            if (!directoryInfo.Exists)
                                return;
                            else
                            {

                                bool flag = false;

                                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                                {
                                    if (dir.FullName == pathDest[i])
                                    {
                                        flag = true;
                                        break;
                                    }
                                }
                                if (flag)
                                    pathDest[i] += " " + "(" + copy.ToString() + ")";

                                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                                {
                                    if (dir.FullName == pathDest[i])
                                    {
                                        copy++;
                                        pathDest[i] = pathDest[i].Remove(pathDest[i].Length - 2, 2);
                                        pathDest[i] += copy.ToString() + ")";
                                    }
                                }
                            }
                        }
                        else
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(currentAddr);
                            if (!directoryInfo.Exists)
                                return;
                            else
                            {

                                bool flag = false;
                                //Check if currentAddr folder has the same name "... - Copy"
                                foreach (FileInfo file in directoryInfo.GetFiles())
                                {
                                    if (file.FullName == pathDest[i])
                                    {
                                        flag = true;
                                        break;
                                    }
                                }

                                //Handle if the currentAddr folder has the same name "... - Copy" by adding "... - Copy (2)","(3)",...
                                if (flag)
                                    pathDest[i] += " " + "(" + copy.ToString() + ")";

                                foreach (FileInfo file in directoryInfo.GetFiles())
                                {
                                    if (file.FullName == pathDest[i])
                                    {
                                        copy++;
                                        pathDest[i] = pathDest[i].Remove(pathDest[i].Length - 2, 2);
                                        pathDest[i] += copy.ToString() + ")";
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(currentAddr);
                        bool isConflict = false;
                        if (isFolder[i])
                        {
                            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                                if (dir.Name == itemPaste[i].Text)
                                {
                                    isConflict = true;
                                    break;
                                }
                        }
                        else
                        {
                            foreach (FileInfo file in directoryInfo.GetFiles())
                                if (file.Name == itemPaste[i].Text)
                                {
                                    isConflict = true;
                                    break;
                                }
                        }

                        //Get the list full path of conflicted file
                        if (isConflict)
                        {
                            //Get the full name of parent directory of source path
                            if (isFolder[i]) listConflict.AddRange(GetConflict(new DirectoryInfo(pathSource[i]), new DirectoryInfo(currentAddr)));
                            else listConflict.AddRange(GetConflict(new FileInfo(pathSource[i]), new DirectoryInfo(currentAddr)));
                        }
                    }
                }

                //Show the message box to inform Conflict files
                bool isReplace = false;
                if (listConflict.Count > 0)
                {
                    //Get the source folder and the destination source 
                    List<string> tmpSrc = new List<string>();
                    for (int i = 0; i < itemPaste.Count; i++)
                    {
                        if (pathSource[i] != null)
                        {
                            tmpSrc.AddRange(clsTreeListView.GetFullPath(pathSource[i]).Split('\\'));
                            break;
                        }
                    }
                    string src = "";
                    for (int i = 0; i < tmpSrc.Count - 1; i++)
                        src += (tmpSrc[i] + "\\");
                    string dst = currentAddr;
                    string a = "";
                    foreach (string i in listConflict)
                        a += ("\n" + i);
                    DialogResult result = MessageBox.Show("Copying " + countCopying + " item" + ((countCopying > 1) ? "s" : "") + " from \"" + src.Remove(src.Length-1,1) + "\" to \"" + dst + "\"" +
                                                        "\nThe destination has " + listConflict.Count + " file" + ((listConflict.Count > 1) ? "s" : "") + " with the same name" + ((listConflict.Count > 1) ? "s" : "") + " : " + a +
                                                        "\nDo you want to replace the file" + ((listConflict.Count > 1) ? "s" : "") + " in the destination ? ", "Replace Files", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        isReplace = true;
                }

                //Copy or Cut
                for (int i = 0; i < itemPaste.Count; i++)
                {
                    if (pathSource[i] == null || pathDest[i] == null)
                        continue;
                    if (isCopying)
                    {
                        if (isFolder[i])
                            FileSystem.CopyDirectory(pathSource[i], pathDest[i], isReplace);
                        else FileSystem.CopyFile(pathSource[i], pathDest[i], isReplace);
                    }
                    else
                    {
                        if (isFolder[i])
                            FileSystem.MoveDirectory(pathSource[i], pathDest[i]);
                        else FileSystem.MoveFile(pathSource[i], pathDest[i]);
                        BtnPaste.Enabled = false;
                    }
                }

                //Refresh list view
                clsTreeListView.ShowContent(listView, currentAddr);


            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You don't currently have permission to access this folder.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IOException)
            {
                /*if (isFolder[i])
                    MessageBox.Show("The destination folder is the same as the source folder.", "Interrupted", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                else
                    MessageBox.Show("The source and the destination file names are the same.", "Interrupted", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BtnPaste_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private List<string> GetConflict(DirectoryInfo directorySrc, DirectoryInfo directoryDst)
        {
            List<string> listConflict = new List<string>();
            if (!directorySrc.Exists || !directoryDst.Exists)
                return listConflict;
            else
            {
                foreach(DirectoryInfo directoryInfo in directoryDst.GetDirectories())
                    if(directoryInfo.Name ==directoryInfo.Name)
                        directoryDst=directoryInfo;

                foreach (DirectoryInfo dirSrc in directorySrc.GetDirectories())
                    foreach (DirectoryInfo dirDst in directoryDst.GetDirectories())
                        if (dirSrc.Name.Equals(dirDst.Name))
                            listConflict.AddRange(GetConflict(new DirectoryInfo(dirSrc.FullName), new DirectoryInfo(directoryDst.FullName)));

                foreach (FileInfo fileSrc in directorySrc.GetFiles())
                    foreach (FileInfo fileDst in directoryDst.GetFiles())
                        if (fileSrc.Name.Equals(fileDst.Name))
                            listConflict.Add(fileDst.FullName);
            }
            return listConflict;
        }

        private List<string> GetConflict(FileInfo fileSrc, DirectoryInfo directoryDst)
        {
            List<string> listConflict = new List<string>();
            foreach(FileInfo fileDst in directoryDst.GetFiles())
                        if (fileSrc.Name.Equals(fileDst.Name))
                listConflict.Add(fileDst.FullName);
            return listConflict;
        }
        private int CountItem(string path)
        {
            int count = 1;
            DirectoryInfo directoryInfo=new DirectoryInfo(path);
            if (!directoryInfo.Exists)
                return count;
            else
            {
                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                    count += CountItem(dir.FullName);

                foreach (FileInfo file in directoryInfo.GetFiles())
                    count++;
            }
            return count;
        }
 
        //Get list of selected list view items when click button copy or cut
        private List<ListViewItem> GetSelectedListViewItems()
        {
            List<ListViewItem> itemSelected = new List<ListViewItem>();
            foreach (ListViewItem item in listView.SelectedItems)
                itemSelected.Add(item);
            return itemSelected;

        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            isListView = true;
        }

        /*private TreeNode nodeFocus;
        private void treeView_MouseClick(object sender, MouseEventArgs e)
        {
            isListView=false;
            nodeFocus=treeView.SelectedNode;
        }*/
    }
}
