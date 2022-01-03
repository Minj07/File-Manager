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
        private ClsTreeListView clsTreeListView; //Generate a ClsTreeListView object

        public MainForm(Database.User user)
        {
            this.user = user;
            clsTreeListView = new ClsTreeListView(user);
            FMInitialize();//Just like Initailize Components
        }


        //Create tree view when File Manger loads
        private void FileManager_Load(object sender, EventArgs e)
        {
            this.clsTreeListView.CreateTreeView(treeView);
            clsTreeListView.ShowContent(listView, treeView.Nodes[1]);
        }

        //Handle event when a tree node is selected
        //Refresh tree view
        public void RefreshTreeView(TreeView treeView, TreeNode treeNode)
        {
            if (treeNode.Name != "This PC")
            {
                treeNode.Nodes.Clear();
                clsTreeListView.ShowFolderTree(treeView, treeNode);
            }
        }

        // Handle when click tree node
        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
                if (e.Node.Parent.Name == "Tag")
                {
                    clsTreeListView.ShowContent(listView, e.Node);
                    CbAddress.Text = ClsTreeListView.GetFullPath(e.Node.FullPath);
                    return;
                }
            if (e.Node.Nodes.Count == 0)
                clsTreeListView.ShowFolderTree(treeView, e.Node);
            if (clsTreeListView.ShowContent(listView, e.Node))
                CbAddress.Text = ClsTreeListView.GetFullPath(e.Node.FullPath);
        }

        
        // Handle when click on list view item
        private void listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = this.listView.FocusedItem;
            if (clsTreeListView.ClickItem(this.listView, this.treeView, item))
                CbAddress.Text = item.SubItems[4].Text;
        }

        private void listView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (this.listView.FocusedItem == null) return;
            ListViewItem item = this.listView.FocusedItem;
            if (e.KeyChar == (int)Keys.Enter)
                if (clsTreeListView.ClickItem(this.listView, this.treeView, this.listView.FocusedItem))
                    CbAddress.Text = item.SubItems[4].Text;
        }

        #region Create go/refresh button
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
                        DirectoryInfo directoryInfo = fileInfo.Directory;
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
            else
            {
                currentAddr = CbAddress.Text;
                UpdateStatus();
                if (!backForward)
                {
                    if (indexBackForward < pathBackForward.Count - 1)
                        pathBackForward.RemoveRange(indexBackForward + 1, pathBackForward.Count - indexBackForward - 1);
                    pathBackForward.Add(CbAddress.Text);
                    indexBackForward++;
                    BtnBack.Enabled = true;
                    BtnForward.Enabled = false;
                }
                else backForward = false;
            }
        }

        private void CbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BtnGoRefresh_Click(sender, e);
        }
        #endregion

        #region Create copy button
        //Create button cut,copy,paste,delete
        private bool isCopying;
        private List<bool> isFolder;
        private bool isListView;
        private List<ListViewItem> itemPaste;
        private TreeNode treeNodePaste;
        private List<string> path;

        private void Copy()
        {
            isFolder = new List<bool>();
            path = new List<string>();
            isCopying = true;
            isCutting = false;
            if (isListView)
            {
                itemPaste = GetSelectedListViewItems();

                if (itemPaste == null)
                    return;

                foreach (ListViewItem item in itemPaste)
                {
                    isFolder.Add(item.SubItems[2].Text == "File folder");
                    path.Add(item.SubItems[4].Text);
                }
            }
            else
            {
                if (treeView.SelectedNode == null)
                    return;
                treeNodePaste = treeView.SelectedNode;
                isFolder.Add(true);
                path.Add(ClsTreeListView.GetFullPath(treeNodePaste.FullPath));
            }
            if (itemPaste != null || treeNodePaste != null)
                BtnPaste.Enabled = true;
        }
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }
        #endregion

        #region Create cut button
        private bool isCutting;
        private void Cut()
        {
            isFolder = new List<bool>();
            path = new List<string>();
            isCutting = true;
            isCopying = false;
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
            else
            {
                if (treeView.SelectedNode == null)
                    return;
                treeNodePaste = treeView.SelectedNode;
                isFolder.Add(true);
                path.Add(ClsTreeListView.GetFullPath(treeNodePaste.FullPath));
            }
            if (itemPaste != null || treeNodePaste != null)
                BtnPaste.Enabled = true;
        }
        private void BtnCut_Click(object sender, EventArgs e)
        {
            Cut();
        }
        #endregion

        #region Create paste button
        private void Paste()
        {
            try
            {
                List<string> pathSource = path;
                List<string> pathDest = new List<string>();

                List<string> listConflict = new List<string>();
                List<string> listConflictSrc = new List<string>();
                int countCopying = 0;
                if (isListView)
                {
                    //Assign name to file copied
                    foreach (ListViewItem item in itemPaste)
                        pathDest.Add(ClsTreeListView.GetFullPath(currentAddr + "\\" + item.Text));
                }
                else pathDest.Add(ClsTreeListView.GetFullPath(currentAddr + "\\" + treeNodePaste.Text));

                //Check if having problem
                for (int i = 0; i < pathSource.Count; i++)
                {
                    if (pathSource[i] == null) continue;
                    //Check if the destination folder is a subfolder of the source folder or not and handle it
                    if (isFolder[i])
                    {
                        List<string> src = new List<string>();
                        src.AddRange(pathSource[i].Split('\\'));
                        List<string> dst = new List<string>();
                        dst.AddRange(currentAddr.Split('\\'));
                        bool isSub = false;
                        if (src.Count <= dst.Count)
                        {
                            isSub = true;
                            for (int j = 0; j < src.Count; j++)
                                if (src[j] != dst[j])
                                {
                                    isSub = false;
                                    break;
                                }
                        }
                        if (isSub)
                        {
                            DialogResult result = MessageBox.Show("The destination folder is a subfolder of the source folder : " +
                                             "\n" + pathSource[i] + "\nDo you want to skip ? ", "Interrupted Action", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                BtnPaste.Enabled = false;
                                pathSource[i] = null;
                                continue;
                            }
                            else
                            {
                                BtnPaste.Enabled = false;
                                return;
                            }
                        }
                    }

                    //Count copy items
                    if (isFolder[i])
                        countCopying += CountItem(pathSource[i]);
                    else countCopying++;

                    //Handle problem copy and cut same path
                    if (pathDest[i] == pathSource[i])
                    {
                        if (isCopying)
                        {
                            string extension = new FileInfo(pathDest[i]).Extension;
                            int copy = 2;
                            int idRename = 2;
                            if (new FileInfo(pathDest[i]).Exists)
                            {
                                string a = "";
                                extension =new FileInfo(pathDest[i]).Extension;
                                pathDest[i] = pathDest[i].Remove(pathDest[i].Length - extension.Length);
                                pathDest[i] += " - Copy"+extension;
                            }
                            else pathDest[i] += " - Copy";
                            
                            DirectoryInfo directoryInfo = new DirectoryInfo(currentAddr);
                            if (!directoryInfo.Exists)
                                return;
                            if (isFolder[i])
                            {
                                bool flag = false;
                                //Check if currentAddr folder has the same name "... - Copy"
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
                            else
                            {
                                
                                bool flag = false;
                                //Check if currentAddr folder has the file with the same name "... - Copy"
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
                                {
                                    {
                                        string a = "";
                                        extension = new FileInfo(pathDest[i]).Extension;
                                        pathDest[i] = pathDest[i].Remove(pathDest[i].Length - extension.Length);
                                        pathDest[i] += " " + "(" + copy.ToString() + ")";
                                        pathDest[i] += extension;
                                    }

                                    foreach (FileInfo file in directoryInfo.GetFiles())
                                    {
                                        if (file.FullName == pathDest[i])
                                        {
                                            copy++;
                                            string a = "";
                                            extension = new FileInfo(pathDest[i]).Extension;
                                            pathDest[i] = pathDest[i].Remove(pathDest[i].Length - extension.Length);
                                            pathDest[i] = pathDest[i].Remove(pathDest[i].Length - 2, 2);
                                            pathDest[i] += copy.ToString() + ")";
                                            pathDest[i] += extension;
                                        }
                                    }
                                }
                                
                            }
                        }
                        else if (isCutting)
                        {
                            DialogResult result = MessageBox.Show(((isFolder[i]) ? "The destination folder is the same as the source folder." : "The source and destination file names are the same.") + "\n" + currentAddr +
                                                                  "\nDo you want to skip ? ", "Interupted Action", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                            if (result == DialogResult.OK)
                            {
                                BtnPaste.Enabled = false;
                                pathSource[i] = null;
                            }
                            else
                            {
                                BtnPaste.Enabled = false;
                                return;
                            }
                        }
                    }

                    //Handle when different path source and destination
                    else
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(currentAddr);
                        bool isConflict = false;
                        //Check if the destination folder has the file of folder with the source
                        if (isFolder[i])
                        {
                            if (isListView)
                            {
                                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                                    if (dir.Name == itemPaste[i].Text)
                                    {
                                        isConflict = true;
                                        break;
                                    }
                            }
                            else
                                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                                    if (dir.Name == treeNodePaste.Text)
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
                            //Get the full name of parent directory of dst path
                            if (isFolder[i])
                            {
                                listConflict.AddRange(GetConflict(new DirectoryInfo(pathSource[i]), new DirectoryInfo(currentAddr)));
                                listConflictSrc.AddRange(GetConflictSrc(new DirectoryInfo(pathSource[i]), new DirectoryInfo(currentAddr)));
                            }
                            else
                            {
                                listConflict.AddRange(GetConflict(new FileInfo(pathSource[i]), new DirectoryInfo(currentAddr)));
                                listConflictSrc.AddRange(GetConflictSrc(new FileInfo(pathSource[i]), new DirectoryInfo(currentAddr)));
                            }
                        }
                    }
                }

                //Show the message box to inform Conflict files
                bool isReplace = false;
                if (listConflict.Count > 0)
                {
                    //Get the source folder and the destination source 
                    List<string> tmpSrc = new List<string>();
                    for (int i = 0; i < pathSource.Count; i++)
                    {
                        if (pathSource[i] != null)
                        {
                            tmpSrc.AddRange(ClsTreeListView.GetFullPath(pathSource[i]).Split('\\'));
                            break;
                        }
                    }
                    string src = "";
                    for (int j = 0; j < tmpSrc.Count - 1; j++)
                        src += (tmpSrc[j] + "\\");
                    string dst = currentAddr;
                    string a = "";
                    foreach (string i in listConflict)
                        a += ("\n" + i);
                    DialogResult result = MessageBox.Show(((isCopying) ? "Copying " : "Moving ") + countCopying + " item" + ((countCopying > 1) ? "s" : "") + " from \"" + src.Remove(src.Length - 1, 1) + "\" to \"" + dst + "\"" +
                                                        "\nThe destination has " + listConflict.Count + " file" + ((listConflict.Count > 1) ? "s" : "") + " with the same name" + ((listConflict.Count > 1) ? "s" : "") + " : " + a +
                                                        "\nDo you want to replace the file" + ((listConflict.Count > 1) ? "s" : "") + " in the destination ? ", "Replace Files", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        isReplace = true;
                    else if (result == DialogResult.No)
                    {
                        for (int j =0;j<pathSource.Count;j++)
                            foreach (string srcConfilct in listConflictSrc)
                                if (srcConfilct == pathSource[j])
                                    pathSource[j] = null;
                    }
                    else if (result == DialogResult.Cancel)
                        return;
                }
                //Copy or Cut
                for (int i = 0; i < pathSource.Count; i++)
                {
                    if (pathSource[i] == null || pathDest[i] == null)
                        continue;
                    // Get the parent of the source node for refreshing
                    TreeNode parent = null;
                    if (treeView.Nodes.Find(currentAddr, true) != null)
                        parent = treeView.Nodes.Find(currentAddr, true)[0];
                    
                    if (isCopying)
                    {
                        if (isFolder[i])
                        {
                            FileSystem.CopyDirectory(pathSource[i], pathDest[i], isReplace);
                            if (parent != null)
                                RefreshTreeView(treeView, parent);
                        }
                        else FileSystem.CopyFile(pathSource[i], pathDest[i], isReplace);
                        user.InsertActivity(Database.User.Activity.ActionType.Copy,DateTime.Now, pathSource[i],pathDest[i]);
                    }
                    else if (isCutting)
                    {
                        Database.UpdateItem(pathSource[i], pathDest[i]);
                        if (isFolder[i])
                        {
                            
                            FileSystem.MoveDirectory(pathSource[i], pathDest[i], isReplace);
                            if (parent != null)
                                RefreshTreeView(treeView, parent);
                        }
                        else FileSystem.MoveFile(pathSource[i], pathDest[i], isReplace);
                        
                        user.InsertActivity(Database.User.Activity.ActionType.Cut,DateTime.Now, pathSource[i],pathDest[i]);
                    }              
                }

                //Refresh 
                TreeNode treeNode = treeView.Nodes.Find(currentAddr, true)[0];
                RefreshTreeView(treeView, treeNode);
                clsTreeListView.ShowContent(listView, currentAddr);

                if (isCutting)
                {
                    BtnPaste.Enabled = false;
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You don't currently have permission to access this folder.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                foreach (DirectoryInfo directoryInfo in directoryDst.GetDirectories())
                    if (directoryInfo.Name == directoryInfo.Name)
                        directoryDst = directoryInfo;

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
            foreach (FileInfo fileDst in directoryDst.GetFiles())
                if (fileSrc.Name.Equals(fileDst.Name))
                    listConflict.Add(fileDst.FullName);
            return listConflict;
        }

        private List<string> GetConflictSrc(DirectoryInfo directorySrc, DirectoryInfo directoryDst)
        {
            List<string> listConflict = new List<string>();
            if (!directorySrc.Exists || !directoryDst.Exists)
                return listConflict;
            else
            {
                foreach (DirectoryInfo directoryInfo in directoryDst.GetDirectories())
                    if (directoryInfo.Name == directoryInfo.Name)
                        directoryDst = directoryInfo;

                foreach (DirectoryInfo dirSrc in directorySrc.GetDirectories())
                    foreach (DirectoryInfo dirDst in directoryDst.GetDirectories())
                        if (dirSrc.Name.Equals(dirDst.Name))
                            listConflict.AddRange(GetConflictSrc(new DirectoryInfo(dirSrc.FullName), new DirectoryInfo(directoryDst.FullName)));

                foreach (FileInfo fileSrc in directorySrc.GetFiles())
                    foreach (FileInfo fileDst in directoryDst.GetFiles())
                        if (fileSrc.Name.Equals(fileDst.Name))
                            listConflict.Add(fileSrc.FullName);
            }
            return listConflict;
        }

        private List<string> GetConflictSrc(FileInfo fileSrc, DirectoryInfo directoryDst)
        {
            List<string> listConflict = new List<string>();
            foreach (FileInfo fileDst in directoryDst.GetFiles())
                if (fileSrc.Name.Equals(fileDst.Name))
                    listConflict.Add(fileSrc.FullName);
            return listConflict;
        }
        private int CountItem(string path)
        {
            int count = 1;
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
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

        private void treeView_MouseClick(object sender, MouseEventArgs e)
        {
            isListView = false;
        }
        #endregion

        #region Create delete button
        public void Delete(List<ListViewItem> listItem)
        {
            if (listItem == null) return;
            try
            {
                string a = "";
                // Check if list view item is null or not
                foreach (ListViewItem item in listItem)
                {
                    if (item.SubItems[2].Text == "File folder")
                    {
                        if (!new DirectoryInfo(item.SubItems[4].Text).Exists)
                            return;
                    }
                    else if (!new FileInfo(item.SubItems[4].Text).Exists)
                        return;
                    a += ("\n" + item.SubItems[4].Text);
                }

                // Show message box to make sure want to permanently delete
                DialogResult result;
                if (listItem.Count == 1)
                    result = MessageBox.Show("Are you sure you want to permanently delete this " + ((listItem[0].SubItems[2].Text == "File folder") ? "folder" : "file") + " ?" + a, "Delete " + ((listItem[0].SubItems[2].Text == "File folder") ? "folder" : "file"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                else result = MessageBox.Show("Are you sure you want to permanently delete these " + listItem.Count + " items ?" + a, "Delete Multiple Items", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                    return;

                //Delete item
                else
                    foreach (ListViewItem item in listItem)
                        if (item.SubItems[2].Text == "File folder")

                            DeleteFolder(new DirectoryInfo(item.SubItems[4].Text));
                        else
                        {
                            Database.DeleteItem(item.SubItems[4].Text);
                            user.InsertActivity(Database.User.Activity.ActionType.Delete, DateTime.Now,
                                item.SubItems[4].Text, "");
                            new FileInfo(item.SubItems[4].Text).Delete();
                        }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void DeleteFolder(DirectoryInfo directoryInfo)
        {
            DirectoryInfo[] directories = directoryInfo.GetDirectories();
            FileInfo[] files = directoryInfo.GetFiles();
            if (directories.Length != 0 || files.Length != 0)
            {
                foreach (DirectoryInfo dir in directories)
                    DeleteFolder(dir);
                foreach (FileInfo file in files)
                {
                    Database.DeleteItem(file.FullName);
                    file.Delete();
                }
            }
            Database.DeleteItem(directoryInfo.FullName);
            user.InsertActivity(Database.User.Activity.ActionType.Delete, DateTime.Now, directoryInfo.FullName, "");
            directoryInfo.Delete();
        }
        public void Delete()
        {
            if (GetSelectedListViewItems().Count == 0) return;
            Delete(GetSelectedListViewItems());
            //Refresh 
            TreeNode treeNode = treeView.Nodes.Find(currentAddr, true)[0];
            RefreshTreeView(treeView, treeNode);
            clsTreeListView.ShowContent(listView, currentAddr);
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        #endregion

        #region Create rename button
        private bool isRenaming = false;
        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null) return;
            RenameItem(e.Label);
            e.CancelEdit = true;
            isRenaming = false;
            if (treeView.Nodes.Find(currentAddr, true) != null)
                RefreshTreeView(treeView, treeView.Nodes.Find(currentAddr, true)[0]);
            clsTreeListView.ShowContent(this.listView, currentAddr);
        }
        private void Rename()
        {
            if (GetSelectedListViewItems().Count == 0) return;
            isRenaming = true;
            ListViewItem listViewItem = GetSelectedListViewItems()[0];
            if (listViewItem.Text == "C:\\" || listViewItem.Text == "D:\\")
            {
                MessageBox.Show("You don't have authorization to rename this drive", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            listViewItem.BeginEdit();
        }
        private void BtnRename_Click(object sender, EventArgs e)
        {
            Rename();
        }

        private void RenameItem(string e)
        {
            try
            {
                if (isRenaming)
                {
                    if (GetSelectedListViewItems() == null)
                        return;
                    ListViewItem listViewItem = GetSelectedListViewItems()[0];
                    if (listViewItem == null) return;
                    string path = listViewItem.SubItems[4].Text;
                    if (e.Contains("\\") || e.Contains("/") || e.Contains(":") || e.Contains("*") || e.Contains("?") || e.Contains("\"") || e.Contains("<") || e.Contains(">") || e.Contains("|"))
                    {
                        MessageBox.Show("A file name can't contain any of the following characters:\n\\ / ; * ? ” < > |", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        clsTreeListView.ShowContent(this.listView, currentAddr);
                        return;
                    }
                    else if (e != null)
                    {
                        string newName = "";
                        if (listViewItem.SubItems[2].Text != "File folder")
                        {
                            FileInfo fileInfo = new FileInfo(listViewItem.SubItems[4].Text);
                            if (!e.Contains(fileInfo.Extension))
                            {
                                DialogResult result = MessageBox.Show("If you change a file name extension, the file might become unusable.\nAre you sure you want to change it?", "Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (result == DialogResult.No)
                                    return;
                            }
                            
                            newName = HandleRename(e, new DirectoryInfo(currentAddr));
                            if (newName == null)
                                return;
                            else if(newName!=e)
                            {
                                DialogResult result = MessageBox.Show("Do you want to rename \"" + fileInfo.Name + "\" to \"" + newName + "\"? \nThere is already a file with the same name in this location.","Rename File", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if(result == DialogResult.No)
                                    return;
                            }
                            Database.UpdateItem(fileInfo.FullName, fileInfo.FullName.Remove(fileInfo.FullName.Length - fileInfo.Name.Length, fileInfo.Name.Length) + newName);
                            user.InsertActivity(Database.User.Activity.ActionType.Rename,DateTime.Now, fileInfo.FullName, fileInfo.FullName.Remove(fileInfo.FullName.Length - fileInfo.Name.Length, fileInfo.Name.Length) + newName);
                            FileSystem.RenameFile(fileInfo.FullName, newName);
                        }
                        else
                        {
                            DirectoryInfo directoryInfo = new DirectoryInfo(listViewItem.SubItems[4].Text);
                            newName = HandleRename(e, new DirectoryInfo(currentAddr), directoryInfo.FullName);
                            if (newName == null)
                                return;
                            else 
                            {
                                Database.UpdateItem(directoryInfo.FullName, directoryInfo.FullName.Remove(directoryInfo.FullName.Length - directoryInfo.Name.Length, directoryInfo.Name.Length) + newName);
                                user.InsertActivity(Database.User.Activity.ActionType.Rename, DateTime.Now, directoryInfo.FullName, directoryInfo.FullName.Remove(directoryInfo.FullName.Length - directoryInfo.Name.Length, directoryInfo.Name.Length) + newName);
                                FileSystem.RenameDirectory(directoryInfo.FullName, newName);
                            }   
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private string HandleRename(string newName,DirectoryInfo directory, string pathFolderRenamed=null)
        {
            bool isConflict = false;
            bool isFolderConflict = true;
            string path = "";
            foreach(FileInfo file in directory.GetFiles())
            {
                if(file.Name == newName)
                {
                    isConflict = true;
                    isFolderConflict = false;
                    path = file.FullName;
                    break;
                }
            }
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                if (dir.Name == newName)
                {
                    isConflict = true;
                    path = dir.FullName;
                    break;
                }
            }
            if (isConflict)
            {
                if (pathFolderRenamed!=null)
                {
                    DirectoryInfo FolderRenamed = new DirectoryInfo(pathFolderRenamed);
                   if(isFolderConflict)
                    {
                        DialogResult result = MessageBox.Show("This destination already contains a folder named '" + newName + "'." +
                                                              "\nIf any files have the same names, you will be asked if you want to replace those files." +
                                                              "\nDo you still want to merge this folder" +
                                                              "\n" + path +
                                                              "\nwith this one?" +
                                                              "\n" + FolderRenamed.FullName, "Confirm Folder Replace", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                            MergeFolder(FolderRenamed, new DirectoryInfo(path));
                        return null;
                    }
                    else
                    {
                        MessageBox.Show("There is already a file with the same name as the folder name you specified.\n" + path + "\nSpecify a different name.", "Rename File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                }
                else
                {
                    if (isFolderConflict)
                    {
                        MessageBox.Show("There is already a folder with the same name as the file name you specified.\n" + path + "\nSpecify a different name.", "Rename File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return null;
                    }
                    else
                    {
                        string extension = "";
                        // Assign name without extension to string a
                        if (newName.Contains('.'))
                        {
                            string a = "";
                            string[] b = newName.Split('.');
                            for (int i = 0; i < b.Length - 1; i++)
                                a += (b[i] + ".");
                            a = a.Remove(a.Length - 1, 1);

                            // Assign extension to string extension
                            extension = "." + b[b.Length - 1];
                            newName = a;
                        }
                        int idRename = 2;
                        newName += (" (" + idRename.ToString() + ")" + extension);
                        foreach (FileInfo file in directory.GetFiles())
                        {
                            if (file.Name == newName)
                            {
                                idRename++;
                                newName = newName.Remove(newName.Length - extension.Length - 2, 2 + extension.Length);
                                newName += (idRename.ToString() + ")" + extension);
                            }
                        }
                    }
                }
            }
            return newName;       
        }

        private void MergeFolder(DirectoryInfo directorySrc,DirectoryInfo directoryDst)
        {
            foreach(FileInfo file in directorySrc.GetFiles())
            {
                string newName = HandleRename(file.Name, directoryDst);
                if (newName != file.Name && newName != null)
                {
                    DialogResult result = MessageBox.Show("Do you want to rename \"" + file.Name + "\" to \"" + newName + "\"? \nThere is already a file with the same name in this location.", "Rename File", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                    {
                        FileSystem.RenameFile(file.FullName, newName);
                        string a = "";
                        string[] b = file.FullName.Split('\\');
                        for (int i = 0; i < b.Length - 1; i++)
                            a += (b[i] + "\\");
                        a += newName;
                        Database.UpdateItem(a, directoryDst.FullName + "\\" + newName);
                        user.InsertActivity(Database.User.Activity.ActionType.Cut,DateTime.Now, a, directoryDst.FullName + "\\" + newName);
                        FileSystem.MoveFile(a, directoryDst.FullName + "\\" + newName);
                    }
                }
                else if (newName != null)
                {
                    Database.UpdateItem(file.FullName, directoryDst.FullName + "\\" + file.Name);
                    user.InsertActivity(Database.User.Activity.ActionType.Cut, DateTime.Now, file.FullName,
                        directoryDst.FullName + "\\" + file.Name);
                    FileSystem.MoveFile(file.FullName, directoryDst.FullName + "\\" + file.Name);
                }
            }
            foreach (DirectoryInfo directory in directorySrc.GetDirectories())
            {
                HandleRename(directory.Name, directoryDst,directory.FullName);                                
            }
            DirectoryInfo[] directories = directorySrc.GetDirectories();
            FileInfo[] files = directorySrc.GetFiles();
            if (directories.Length == 0 && files.Length == 0)
            {
                Database.DeleteItem(directorySrc.FullName);
                user.InsertActivity(Database.User.Activity.ActionType.Merge,DateTime.Now, 
                    directorySrc.FullName + " ; " + directoryDst.FullName, directoryDst.FullName);
                directorySrc.Delete();
            }
        }
        #endregion

        #region Create short cut
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.C:
                        Copy();
                        break;
                    case Keys.X:
                        Cut();
                        break;
                    case Keys.V:
                        if (BtnPaste.Enabled)
                            Paste();
                        break;
                    case Keys.D:
                        Delete();
                        break;
                }
            }
            else if (e.KeyCode == Keys.F2)
                Rename();
        }
        #endregion

        #region Create back, forward, up
        // Create button Back, Forward
        // Get list of all the path had passed through
        public List<string> pathBackForward=new List<string>();
        public int indexBackForward = -1;
        public bool backForward = false;
        private void BtnBack_Click(object sender, EventArgs e)
        {
            backForward = true;
            indexBackForward--;
            CbAddress.Text = pathBackForward[indexBackForward];
            if (CbAddress.Text != "This PC" && CbAddress.Text != "Tag")
                clsTreeListView.ShowContent(this.listView, CbAddress.Text);
            else if (CbAddress.Text == "This PC")
                clsTreeListView.ShowContent(this.listView, this.treeView.Nodes[1]);
            if(indexBackForward==0) BtnBack.Enabled=false;
            BtnForward.Enabled=true;
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            backForward = true;
            indexBackForward++;
            CbAddress.Text = pathBackForward[indexBackForward];
            if (CbAddress.Text != "This PC" && CbAddress.Text != "Tag")
                clsTreeListView.ShowContent(this.listView, CbAddress.Text);
            else if (CbAddress.Text == "This PC")
                clsTreeListView.ShowContent(this.listView, this.treeView.Nodes[1]);
            if (indexBackForward == pathBackForward.Count-1) BtnForward.Enabled = false;
            BtnBack.Enabled=true;
        }

        private void BtnParentFolder_Click(object sender, EventArgs e)
        {
            if (treeView.Nodes.Find(CbAddress.Text, true).Length == 0) return;
            TreeNode treeNode = treeView.Nodes.Find(CbAddress.Text,true)[0].Parent;
            if (treeNode != null)
            {
                clsTreeListView.ShowContent(this.listView, treeNode);
                CbAddress.Text = ClsTreeListView.GetFullPath(treeNode.FullPath);
            }
            else return;
        }
        #endregion

        #region Create new button
        private void newFolderToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string new_path=ClsTreeListView.GetFullPath(currentAddr.ToString())+"\\New Folder";
            if(new DirectoryInfo(new_path).Exists)
            {
                int new_id = 2;
                new_path += " (2)";
                while(new DirectoryInfo(new_path).Exists)
                {
                    new_id++;
                    new_path=new_path.Remove(new_path.Length-2,2);
                    new_path+=new_id.ToString()+")";
                }
            }
            user.InsertActivity(Database.User.Activity.ActionType.New, DateTime.Now, "", new_path);
            Directory.CreateDirectory(new_path);
            
            //Refresh
            RefreshTreeView(treeView,treeView.Nodes.Find(currentAddr.ToString(),true)[0]);
            clsTreeListView.ShowContent(listView,currentAddr);
        }

        private void newTextDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string new_path = ClsTreeListView.GetFullPath(currentAddr.ToString()) + "\\New Text Document";
            if (new FileInfo(new_path+".txt").Exists)
            {
                int new_id = 2;
                new_path += " (2)";
                while (new FileInfo(new_path+".txt").Exists)
                {
                    new_id++;
                    new_path = new_path.Remove(new_path.Length - 2, 2);
                    new_path += new_id.ToString() + ")";
                }
            }
            user.InsertActivity(Database.User.Activity.ActionType.New, DateTime.Now, "", new_path + ".txt");
            using (StreamWriter sw = File.CreateText(new_path+".txt"));

            //Refresh
            clsTreeListView.ShowContent(listView, currentAddr);
        }
        #endregion

        #region Create status
        public void UpdateStatus()
        {
            LbStatus.Text = "";
            int count = listView.Items.Count;
            LbStatus.Text = count.ToString() + ((count == 1) ? " item" : " items" + "  | ");
            count=GetSelectedListViewItems().Count;
            if (count > 0)
                LbStatus.Text += (count.ToString() + ((count == 1) ? " item" : " items") + " selected  |");
        }
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStatus();
        }
        #endregion


    }
}
