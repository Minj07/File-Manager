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

namespace FileManager
{
    internal class ClsTreeListView
    {
        #region Create Tree View
        public void CreateTreeView(TreeView treeView)
        {
            TreeNode ThisPC;

            //Create new node
            ThisPC = new TreeNode("This PC", 0, 0);
            ThisPC.Name = "This PC";
            //Delete treeView
            treeView.Nodes.Clear();
            treeView.Nodes.Add(ThisPC);

            //Tree node collection of ThisPC
            TreeNodeCollection treeNodeCollection = ThisPC.Nodes;

            //Get list of disk in ThisPC
            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDisk");
            ManagementObjectCollection collectionQuery = query.Get();

            foreach (ManagementObject item in collectionQuery)
            {
                const int RemovableDisk = 2;
                const int LocalDisk = 3;
                const int NetworkDisk = 4;
                const int CDDisk = 5;

                int imageIndex;

                //Assign icons to disks by using imageIndex and selectIndex
                switch (int.Parse(item["DriveType"].ToString()))
                {
                    case RemovableDisk:
                        imageIndex = 1;
                        break;
                    case LocalDisk:
                        imageIndex = 2;
                        break;
                    case NetworkDisk:
                        imageIndex = 3;
                        break;
                    case CDDisk:
                        imageIndex = 4;
                        break;
                    default:
                        imageIndex = 5;
                        break;
                }

                //Create tree node for each disk
                TreeNode diskTreeNode = new TreeNode(item["Name"].ToString() + "\\", imageIndex, imageIndex);

                //Add to tree view
                treeNodeCollection.Add(diskTreeNode);
            }
        }
        #endregion

        #region Show Folder Tree
        public bool ShowFolderTree(TreeView treeView, ListView listView, TreeNode currentNode)
        {
            if (currentNode.Name != "This PC")
            {
                try
                {
                    //Check the path
                    if (!Directory.Exists(GetFullPath(currentNode.FullPath)))
                    {
                        MessageBox.Show("'" + GetFullPath(currentNode.FullPath) + "' doesn't exist.", "File Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //Handle display folder
                    //else
                    {
                        string[] strDirectories = Directory.GetDirectories(GetFullPath(currentNode.FullPath));
                        foreach (string strDirectory in strDirectories)
                        {
                            string strName = GetName(strDirectory);
                            TreeNode dirNode = new TreeNode(strName, 5, 5);
                            currentNode.Nodes.Add(dirNode);
                        }

                        ShowContent(listView, currentNode);
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
            return false;
        }

        //Return the full path of a tree node after handling
        public string GetFullPath(string strPath)
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
        public void ShowContent(ListView listView, TreeNode currentNode)
        {
            try
            {
                if (currentNode.Name != "This PC")
                {  //Delete all items in List View
                    listView.Items.Clear();

                    DirectoryInfo directoryInfo = new DirectoryInfo(GetFullPath(currentNode.FullPath));

                    //Information of directories
                    foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
                        listView.Items.Add(GetLVItems(dir));

                    //Information of files
                    foreach (FileInfo file in directoryInfo.GetFiles())
                        listView.Items.Add(GetLVItems(file, listView));
                }
                else
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
                        listView.Items.Add(listViewItem);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            listViewItem.ImageIndex = 4;
            return listViewItem;
        }

        //Get List View item having info from file
        public ListViewItem GetLVItems(FileInfo file, ListView listView)
        {
            string[] item = new string[5];
            item[0] = file.Name;
            item[1] = file.LastWriteTime.ToString();
            item[2] = (file.Extension.Equals(""))?"File":file.Extension;
            item[3] = Math.Ceiling(file.Length / (1024 * 1.0)).ToString("###,###") + " KB";
            item[4] = file.FullName;

            //Set a default icon for the file
            Icon iconForFile = SystemIcons.WinLogo;
            ListViewItem listViewItem = new ListViewItem(item, 1);


            string key = file.Extension;
            if(key==".exe")
                key = file.FullName;
            else if(key=="")
            {
                listViewItem.ImageIndex = 5;
                return listViewItem;
            }

            //Check to see if the image collection contains an image for this extension, using the extension as a key
            if (!listView.SmallImageList.Images.ContainsKey(file.Extension))
            {
                //If not, add the image to the image list
                iconForFile = Icon.ExtractAssociatedIcon(file.FullName);
                listView.SmallImageList.Images.Add(key, iconForFile);
                listView.LargeImageList.Images.Add(key, iconForFile);
            }

            listViewItem.ImageKey = key;
            return listViewItem;
        }
        #endregion


        public bool ClickItem(ListView listView, ListViewItem item)
        {
            try
            {
                string path = item.SubItems[4].Text;
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    Process.Start(path);
                }
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
                        listView.Items.Add(GetLVItems(fileInfoTemp, listView));
                }
                return true;
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
    }
}

