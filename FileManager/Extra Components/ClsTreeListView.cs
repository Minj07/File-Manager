using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.FileIO;
using System.Data;
using System.Data.SqlClient;

namespace FileManager
{
    internal class ClsTreeListView
    {
        private enum SHGFI
        {
            SmallIcon = 0x00000001,
            LargeIcon = 0x00000000,
            Icon = 0x00000100,
            DisplayName = 0x00000200,
            Typename = 0x00000400,
            SysIconIndex = 0x00004000,
            UseFileAttributes = 0x00000010
        }

        [DllImport("Shell32.dll")]
        private static extern IntPtr SHGetFileInfo
        (
            string pszPath,
            uint dwFileAttributes,
            out SHFILEINFO psfi,
            uint cbfileInfo,
            SHGFI uFlags
        );


        [StructLayout(LayoutKind.Sequential)]
        private struct SHFILEINFO
        {
            public SHFILEINFO(bool b)
            {
                hIcon = IntPtr.Zero; iIcon = 0; dwAttributes = 0; szDisplayName = ""; szTypeName = "";
            }
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.LPStr, SizeConst = 80)]
            public string szTypeName;
        };

        public static Icon GetDirectoryIcon(string dirName, bool largeIcon)
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            int cbFileInfo = Marshal.SizeOf(_SHFILEINFO);
            SHGFI flags = SHGFI.Icon;
            if (largeIcon)
                flags |= SHGFI.LargeIcon;
            else
                flags |= SHGFI.SmallIcon;

            IntPtr IconIntPtr = SHGetFileInfo(dirName, 0, out _SHFILEINFO, (uint)cbFileInfo, flags);
            if (IconIntPtr.Equals(IntPtr.Zero))
                return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }

        #region Create Tree View
        public void CreateTreeView(TreeView treeView)
        {
            TreeNode ThisPC;
            TreeNode Tag;
            //Create ThisPC node
            ThisPC = new TreeNode("This PC");
            ThisPC.Name = "This PC";

            //Create Favorite node
            Tag = new TreeNode("Tag");
            Tag.Name = "Tag";

            //Delete treeView
            treeView.Nodes.Clear();

            Icon icon;

            //Add Tag node                     
            icon = Icon.FromHandle(Properties.Resources.star.GetHicon());
            Tag.Tag = new CustomTreeView.TreeNodeTag(icon, false);
            treeView.Nodes.Add(Tag);

            //Add ThisPC node
            icon = Properties.Resources.Computer;
            ThisPC.Tag = new CustomTreeView.TreeNodeTag(icon, true);
            treeView.Nodes.Add(ThisPC);

            //Get list of disk in ThisPC
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
            ManagementObjectCollection collectionQuery = query.Get();

            foreach (ManagementObject item in collectionQuery)
            {
                //Create tree node for each disk
                TreeNode diskTreeNode = new TreeNode(item["Name"].ToString() + "\\");

                //Add tree node's tag
                diskTreeNode.Tag = GetTreeNodeTag(diskTreeNode.Text);
                ThisPC.Nodes.Add(diskTreeNode);
                ThisPC.LastNode.Name = ClsTreeListView.GetFullPath(ThisPC.LastNode.FullPath);
            }

            // Create Tag nodes
            foreach (TagDatabase.Tag tag in TagDatabase.Tags)
            {
                TreeNode tagNode=new TreeNode(tag.name);
                tagNode.Tag = new CustomTreeView.TreeNodeTag(tag.color, tag.id, (tag.items.Count != 0) ? true : false);
                Tag.Nodes.Add(tagNode);
                Tag.LastNode.Name = Tag.LastNode.FullPath;
            }
        }

        public void RefreshTagNode(TreeView treeView)
        {
            if(treeView.Nodes[0].Nodes.Count==0) return;
                treeView.Nodes[0].Nodes.Clear();
            foreach (TagDatabase.Tag tag in TagDatabase.Tags)
                {
                    TreeNode tagNode = new TreeNode();
                    tagNode.Tag = new CustomTreeView.TreeNodeTag(tag.color, tag.id, (tag.items.Count != 0) ? true : false);
                    treeView.Nodes[0].Nodes.Add(tagNode);
                    treeView.Nodes[0].LastNode.Name = treeView.Nodes[0].LastNode.FullPath;
                }
        }

        public CustomTreeView.TreeNodeTag GetTreeNodeTag(string path)
        {
            Icon icon = GetDirectoryIcon(path, false);
            bool hasChild = false;
            if (new DirectoryInfo(path).GetDirectories().Length != 0)
                hasChild = true;
            return new CustomTreeView.TreeNodeTag(icon, hasChild);
        }
        #endregion

        #region Show Folder Tree
        public bool ShowFolderTree(TreeView treeView, TreeNode currentNode)
        {
            if (currentNode.Name != "This PC" && currentNode.Name != "Tag") 
            {
                try
                {
                    //Check the path
                    if (!Directory.Exists(GetFullPath(currentNode.FullPath)))
                    {
                        MessageBox.Show("'" + GetFullPath(currentNode.FullPath) + "' doesn't exist.", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    //Handle display folder
                    else
                    {
                        string[] strDirectories = Directory.GetDirectories(GetFullPath(currentNode.FullPath));
                        foreach (string strDirectory in strDirectories)
                        {
                            //Check if the dir is unauthorized or not
                            if (CheckUnauthoried(strDirectory)) continue;
                            string strName = GetName(strDirectory);
                            TreeNode dirNode = new TreeNode(strName);
                            dirNode.Tag = GetTreeNodeTag(strDirectory);
                            currentNode.Nodes.Add(dirNode);
                            currentNode.LastNode.Name = ClsTreeListView.GetFullPath(currentNode.LastNode.FullPath);
                        }

                    }
                    return true;
                }
                catch (IOException)
                {
                    MessageBox.Show("'" + GetFullPath(currentNode.FullPath) + "' doesn't exist.", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else if(currentNode.Name=="Tag")
            {
                foreach (TagDatabase.Tag tag in TagDatabase.Tags)
                {
                    currentNode.Nodes.Clear();
                    TreeNode tagNode = new TreeNode(tag.name);
                    tagNode.Tag = new CustomTreeView.TreeNodeTag(tag.color, tag.id, (tag.items.Count != 0) ? true : false);
                    currentNode.Nodes.Add(tagNode);
                    currentNode.LastNode.Name = currentNode.LastNode.FullPath;
                }
            }
            else if(currentNode.Parent.Name=="Tag")
                return true;
            return false;
        }

        //Check if the dir is unauthorized or not
        public bool CheckUnauthoried(string strPath)
        {
            try { new DirectoryInfo(strPath).GetDirectories(); }
            catch (UnauthorizedAccessException) { return true; }
            return false;
        }

        //Return the full path of a tree node after handling
        static public string GetFullPath(string strPath)
        {
            return strPath.Replace(@"This PC\", "").Replace(@"\\", @"\");
        }

        //Get the name of a dirctory from its full path
        public string GetName(string strPath)
        {
            string[] strPlit = strPath.Split('\\');
            int maxIndex = strPlit.Length;
            return strPlit[maxIndex - 1];
        }
        #endregion

        #region Show Content
        //Show content of directory selected in Tree View
        public bool ShowContent(ListView listView, TreeNode currentNode)
        {
            try
            {

                if (currentNode.Name == "This PC")
                {
                    listView.Items.Clear();
                    foreach (TreeNode node in currentNode.Nodes)
                    {
                        string[] item = new string[5];
                        item[0] = node.Text;
                        switch (node.ImageIndex)
                        {
                            case 1:
                                item[2] = "Removable Disk";
                                break;
                            case 2:
                                item[2] = "Local Disk";
                                break;
                            case 3:
                                item[2] = "Network Disk";
                                break;
                            case 4:
                                item[2] = "CD Disk";
                                break;
                            default:
                                item[2] = "File folder";
                                break;
                        }
                        item[4] = node.Text;
                        ListViewItem listViewItem = new ListViewItem(item, node.ImageIndex - 1);
                        listViewItem.Name = node.Name;
                        listViewItem.Tag = new CustomListView.ListViewItemTag(null, GetDirectoryIcon(item[4].Remove(item[4].Length - 1, 1), false), GetDirectoryIcon(item[4].Remove(item[4].Length - 1, 1), true));
                        listView.Items.Add(listViewItem);
                    }
                }
                else if (currentNode.Name == "Tag")
                {
                    listView.Items.Clear();
                    foreach (TagDatabase.Tag tag in TagDatabase.Tags)
                    {
                        string[] item = new string[5];
                        item[0] = tag.name;
                        item[4] = currentNode.Name + "\\" + tag.name;
                        ListViewItem listViewItem = new ListViewItem(item);
                        listViewItem.Name = tag.name;
                        listViewItem.Tag = new CustomListView.ListViewItemTag(tag.color, tag.id);
                        listView.Items.Add(listViewItem);
                    }
                }
                else if (currentNode.Parent.Name == "Tag")
                {
                    int id = ((CustomTreeView.TreeNodeTag)currentNode.Tag).TagId;
                    listView.Items.Clear();
                    List<string> path = new List<string>();
                    foreach (DataRow row in TagDatabase.ds.Tables[1].Rows)
                    {
                        if ((int)row["TagId"] == id)
                            path.Add(row["Path"].ToString());
                    }
                    foreach (string a in path)
                    {
                        if (new FileInfo(a).Exists)
                        {
                            ListViewItem listViewItem = GetLVItems(new FileInfo(a));
                            ((CustomListView.ListViewItemTag)listViewItem.Tag).Tags = TagDatabase.GetTags(a);
                            listView.Items.Add(listViewItem);
                        }
                        else if (new DirectoryInfo(a).Exists)
                            listView.Items.Add(GetLVItems(new DirectoryInfo(a)));
                    }
                }
                else if (currentNode.Name != "This PC" && currentNode.Name != "Tag")
                {  //Delete all items in List View
                    listView.Items.Clear();

                    DirectoryInfo directoryInfo = new DirectoryInfo(GetFullPath(currentNode.FullPath));

                    //Information of directories
                    foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                        listView.Items.Add(GetLVItems(dir));

                    //Information of files
                    foreach (FileInfo file in directoryInfo.GetFiles())
                        listView.Items.Add(GetLVItems(file));
                }
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show("'" + GetFullPath(currentNode.FullPath) + "' doesn't exist.", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You don't currently have permission to access this folder.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        //Get List View item having info from folder
        public ListViewItem GetLVItems(DirectoryInfo folder)
        {
            string[] item = new string[5];
            item[0] = folder.Name;
            item[1] = folder.LastWriteTime.ToString();
            item[2] = "File folder";
            item[4] = folder.FullName;
            ListViewItem listViewItem = new ListViewItem(item);

            listViewItem.Tag = new CustomListView.ListViewItemTag(
                null,
                (GetDirectoryIcon(folder.FullName, false)==null?
                Properties.Resources.Folder:
                GetDirectoryIcon(folder.FullName, false)),
                (GetDirectoryIcon(folder.FullName, true) == null ?
                Properties.Resources.Folder :
                GetDirectoryIcon(folder.FullName, true)));
            ((CustomListView.ListViewItemTag)listViewItem.Tag).Tags = TagDatabase.GetTags(folder.FullName);
            return listViewItem;
        }

        //Get List View item having info from file
        public ListViewItem GetLVItems(FileInfo file)
        {
            string[] item = new string[5];
            item[0] = file.Name;
            item[1] = file.LastWriteTime.ToString();
            item[2] = (file.Extension.Equals("")) ? "File" : file.Extension;
            item[3] = Math.Ceiling(file.Length / (1024 * 1.0)).ToString("###,###") + " KB";
            if (item[3].Equals(" KB")) item[3] = "0 KB";
            item[4] = file.FullName;

            
            ListViewItem listViewItem = new ListViewItem(item);
            listViewItem.Tag = new CustomListView.ListViewItemTag(file.Extension, Icon.ExtractAssociatedIcon(file.FullName), Icon.ExtractAssociatedIcon(file.FullName));
            ((CustomListView.ListViewItemTag)listViewItem.Tag).Tags = TagDatabase.GetTags(file.FullName);
            return listViewItem;
        }

        public void ShowContent(ListView listView, string path)
        {
            try
            {
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    if (directoryInfo.Exists)
                    {
                        listView.Items.Clear();

                        //Information of directories
                        foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                            listView.Items.Add(GetLVItems(dir));

                    //Information of files
                    foreach (FileInfo file in directoryInfo.GetFiles())
                        listView.Items.Add(GetLVItems(file));
                }
                else
                    MessageBox.Show("Can't find '" + path + "'. Check the spelling and try again", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException)
            {
                MessageBox.Show("Can't find '" + path + "'. Check the spelling and try again", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #endregion


        public bool ClickItem(ListView listView, TreeView treeView, ListViewItem item)
        {
            try
            {
                if (!((CustomListView.ListViewItemTag)item.Tag).isTag)
                {
                    string path = item.SubItems[4].Text;
                    // If click a file, run that file
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        Process.Start(path);
                    }
                    // If click a folder, show content of that folder
                    else
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(path);
                        if (!directoryInfo.Exists)
                        {
                            MessageBox.Show("'" + path + "' doesn't exist.", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;

                        }

                        listView.Items.Clear();
                        foreach (DirectoryInfo directoryInfoTemp in directoryInfo.GetDirectories())
                            listView.Items.Add(GetLVItems(directoryInfoTemp));

                        foreach (FileInfo fileInfoTemp in directoryInfo.GetFiles())
                            listView.Items.Add(GetLVItems(fileInfoTemp));

                        // Focus the tree node of the dir clicked
                        List<TreeNode> tn = new List<TreeNode>();
                        tn.AddRange(treeView.Nodes.Find(path, true));
                        if (tn.Count <= 0)
                        {
                            ShowFolderTree(treeView, treeView.Nodes.Find(directoryInfo.Parent.FullName, true)[0]);
                            tn.AddRange(treeView.Nodes.Find(path, true));
                        }
                        tn[0].EnsureVisible();
                    }
                }
                else
                {
                    int id = ((CustomListView.ListViewItemTag)item.Tag).TagId;
                    listView.Items.Clear();
                    List<string> path=new List<string>();
                    foreach(DataRow row in TagDatabase.ds.Tables[1].Rows)
                    {
                        if ((int)row["TagId"] == id)
                            path.Add(row["Path"].ToString());
                    }
                    foreach(string a in path)
                    {
                        if (new FileInfo(a).Exists)
                        {
                            ListViewItem listViewItem = GetLVItems(new FileInfo(a));
                            ((CustomListView.ListViewItemTag)listViewItem.Tag).Tags = TagDatabase.GetTags(a);
                            listView.Items.Add(listViewItem);
                        }
                        else if (new DirectoryInfo(a).Exists)
                            listView.Items.Add(GetLVItems(new DirectoryInfo(a)));
                    }                    
                }
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show("'" + GetFullPath(item.SubItems[4].Text) + "' doesn't exist.", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("You don't currently have permission to access this folder.", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

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
                        {
                            DeleteFolder(new DirectoryInfo(item.SubItems[4].Text));
                        }
                        else
                            new FileInfo(item.SubItems[4].Text).Delete();
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
                    file.Delete();
            }
            directoryInfo.Delete();
        }
    }
}


