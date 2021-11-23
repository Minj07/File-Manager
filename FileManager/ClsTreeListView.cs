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

        public bool ShowFolderTree(TreeView treeView, TreeNode currentNode)
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

        //Show
    }
}
