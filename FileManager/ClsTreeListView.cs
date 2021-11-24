using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace FileManager
{
    internal class ClsTreeListView
    {
        public void CreateTreeView(TreeView treeView)
        {
            TreeNode ThisPC;

            //Create new node
            ThisPC = new TreeNode("This PC", 0, 0);

            //Delete treeView
            treeView.Nodes.Clear();
            treeView.Nodes.Add(ThisPC);

            //Tree node collection of ThisPC
            TreeNodeCollection treeNodeCollection= ThisPC.Nodes;

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

                switch(int.Parse(item["DriveType"].ToString()))
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

        public bool ShowFolderTree(TreeView treeView, ListView listView, TreeNode currentNode)
        {
            if(currentNode.Name!="This PC")
            {
                try
                {
                    //Check the path
                    if (!Directory.Exists(GetFullPath(currentNode.FullPath)))
                    {
                        MessageBox.Show("'" + GetFullPath(currentNode.FullPath) + "' doesn't exist.", "File Manager",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                    //Handle display folder
                    else
                    {
                        string[] strDirectories= Directory.GetDirectories(GetFullPath(currentNode.FullPath));
                        foreach (string strDirectory in strDirectories)
                        {
                            string strName=GetName(strDirectory);
                            TreeNode dirNode= new TreeNode(strName, 5,5);
                            currentNode.Nodes.Add(dirNode);
                        }

                        ShowContent(listView, currentNode);
                    }
                    return true;
                }
                catch(IOException)
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
            int maxIndex=strPlit.Length;
            return strPlit[maxIndex - 1];
        }

        //Show content of directory selected in Tree View
        public void ShowContent(ListView listView, TreeNode currentNode)
        {
            try
            {
                //Delete all items in List View
                listView.Items.Clear();

                DirectoryInfo directoryInfo = GetPathDir(currentNode);

                //Information of directories
                foreach (DirectoryInfo dir in directoryInfo.GetDirectories())                  
                    listView.Items.Add(GetLVItems(dir));

                //Information of files
                foreach (FileInfo file in directoryInfo.GetFiles())
                    listView.Items.Add(GetLVItems(file));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Get directory of a Tree Node
        public DirectoryInfo GetPathDir(TreeNode currentNode)
        {
            return new DirectoryInfo(GetFullPath(currentNode.FullPath));
        }

        //Get List View item having info from folder
        public ListViewItem GetLVItems(DirectoryInfo folder)
        {
            string[] item = new string[4];
            item[0] = folder.Name;
            item[1] = folder.LastWriteTime.ToString();
            item[2] = "File folder";
            
            ListViewItem listViewItem = new ListViewItem(item);
            listViewItem.ImageIndex = 13;
            return listViewItem;
        }

        //Get List View item having info from file
        public ListViewItem GetLVItems(FileInfo file)
        {
            string[] item = new string[4];
            item[0] = file.Name;
            item[1] = file.LastWriteTime.ToString();
            item[2] = file.Extension;
            item[3] = (file.Length / 1024).ToString() + " KB";

            ListViewItem listViewItem = new ListViewItem(item);
            listViewItem.ImageIndex = GetImageIndex(file);
            return listViewItem;
        }

        //Get Image Index from file type
        public int GetImageIndex(FileInfo file)
        {
            switch (file.Extension.ToUpper())
            {
                case ".TXT":
                case ".DIZ":
                case ".LOG":
                    return 0;
                case ".PDF":
                    return 1;
                case ".HTM":
                case "HTML.":
                    return 2;
                case ".DOC":
                case ".DOCX":
                    return 3;
                case ".EXE":
                    return 4;
                case ".JPG":
                case ".PNG":
                case ".BMP":
                case ".GIF":
                    return 5;
                case ".MP3":
                case ".WAV":
                case ".WMV":
                case ".ASF":
                case ".MPEG":
                case ".AVI":
                    return 6;
                case ".RAR":
                case ".ZIP":
                    return 7;
                case ".PPT":
                case ".PPTX":
                    return 8;
                case ".MDB":
                    return 9;
                case ".XLS":
                case ".XLSX":
                    return 10;
                case ".SWF":
                case ".FLV":
                case ".FLA":
                    return 11;
                default:
                    return 12;
            }
        }
    }
}
