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
            clsTreeListView.ShowContent(listView, treeView.Nodes[1]);
        }

        //Handle event when a tree node is selected
        //Refresh tree view
        public void RefreshTreeView(TreeView treeView, TreeNode treeNode)
        {
            if (treeNode.Name != "This PC" && treeNode.Name != "Tag")
            {
                treeNode.Nodes.Clear();
                clsTreeListView.ShowFolderTree(treeView, treeNode);
            }
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Nodes.Count == 0)
                clsTreeListView.ShowFolderTree(treeView, e.Node);
            if (clsTreeListView.ShowContent(listView, e.Node))
                CbAddress.Text = ClsTreeListView.GetFullPath(e.Node.FullPath);
        }

        private void MainTablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

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
                //BtnForward.Enabled = true;
            }
        }

        private void CbAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                BtnGoRefresh_Click(sender, e);
        }

        #region Create button
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
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            Copy();
        }

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

        private void Paste()
        {
            try
            {
                List<string> pathSource = path;
                List<string> pathDest = new List<string>();

                List<string> listConflict = new List<string>();
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
                            int copy = 2;
                            pathDest[i] += " - Copy";
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
                    for (int i = 0; i < pathSource.Count; i++)
                    {
                        if (pathSource[i] != null)
                        {
                            tmpSrc.AddRange(ClsTreeListView.GetFullPath(pathSource[i]).Split('\\'));
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
                    DialogResult result = MessageBox.Show(((isCopying) ? "Copying " : "Moving ") + countCopying + " item" + ((countCopying > 1) ? "s" : "") + " from \"" + src.Remove(src.Length - 1, 1) + "\" to \"" + dst + "\"" +
                                                        "\nThe destination has " + listConflict.Count + " file" + ((listConflict.Count > 1) ? "s" : "") + " with the same name" + ((listConflict.Count > 1) ? "s" : "") + " : " + a +
                                                        "\nDo you want to replace the file" + ((listConflict.Count > 1) ? "s" : "") + " in the destination ? ", "Replace Files", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.Yes)
                        isReplace = true;
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
                    }
                    else if (isCutting)
                    {
                        if (isFolder[i])
                        {
                            FileSystem.MoveDirectory(pathSource[i], pathDest[i], isReplace);
                            if (parent != null)
                                RefreshTreeView(treeView, parent);
                        }
                        else FileSystem.MoveFile(pathSource[i], pathDest[i], isReplace);
                        

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
        public void Delete()
        {
            if (GetSelectedListViewItems().Count == 0) return;
            clsTreeListView.Delete(GetSelectedListViewItems());
            //Refresh 
            TreeNode treeNode = treeView.Nodes.Find(currentAddr, true)[0];
            RefreshTreeView(treeView, treeNode);
            clsTreeListView.ShowContent(listView, currentAddr);
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private bool isRenaming = false;
        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if(e.Label == null) return;
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
                        FileSystem.MoveFile(a, directoryDst.FullName + "\\" + newName);
                    }
                }
                else if (newName != null) FileSystem.MoveFile(file.FullName, directoryDst.FullName + "\\" + file.Name);
            }
            foreach (DirectoryInfo directory in directorySrc.GetDirectories())
            {
                HandleRename(directory.Name, directoryDst,directory.FullName);                                
            }
            DirectoryInfo[] directories = directorySrc.GetDirectories();
            FileInfo[] files = directorySrc.GetFiles();
            if (directories.Length == 0 && files.Length == 0)
                directorySrc.Delete();
        }

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
    }
}
