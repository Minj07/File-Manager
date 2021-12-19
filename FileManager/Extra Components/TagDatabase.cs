using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    internal class TagDatabase
    {
        public class Tag
        {
            public Tag(int _id, string _name, Color _color)
            {
                this.id = _id;
                this.name = _name; 
                this.color = _color;
                this.items = new List<string>() ;
            }
            public int id { get; }
            public string name { get; }
            public Color color { get; }
            public List<string> items { get; }
            public void Insert(string path)
            {
                List<int> idList = new List<int>();
                foreach (DataRow Row in ds.Tables[1].Rows)
                {
                    idList.Add((int)Row["Id"]);
                }
                int i = 0;
                while (idList.Contains(i))
                {
                    i++;
                }
                SqlDataAdapter adapter=new SqlDataAdapter();
                String query = "Insert into Tagged (Id,Path,TagId) values ("+i.ToString()+",'" + path + "'," + id + ")";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                RefreshTags();
            }

            public void Modify (string newName, Color newColor)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string queryName = "";
                string queryColor = "";
                if(newName != null)
                    queryName = "Update Tag set Name='" + newName + "' where Id=" + this.id;
                if(newColor != null)
                    queryColor="Update Tag set R="+newColor.R+", G="+newColor.G+", B="+newColor.B+" where Id="+this.id;
                using (connection)
                {                    
                    connection.Open();
                    if (newName != null)
                    {
                        SqlCommand command = new SqlCommand(queryName, connection);
                        adapter.UpdateCommand = command;
                        adapter.UpdateCommand.ExecuteNonQuery();
                        command.Dispose();
                    }
                    if(newColor != null)
                    {
                        SqlCommand command = new SqlCommand(queryColor, connection);
                        adapter.UpdateCommand = command;
                        adapter.UpdateCommand.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                }
            }

            public void Remove(string path)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "Delete from Tagged where TagId=" + id.ToString()+" and  Convert(VARCHAR, Path)='"+path+"'";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.DeleteCommand = command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                RefreshTags();
            }

            public void Delete()
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "Delete Tagged where TagId = " + id.ToString();
                String query1 = "Delete Tag where Id=" + id.ToString();
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.DeleteCommand = command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    command.Dispose();

                    command = new SqlCommand(query1, connection);

                    adapter.DeleteCommand = command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                RefreshTags();
            }

            public List<string> GetPaths()
            {
                List<string> paths = new List<string>();
                foreach(DataRow row in ds.Tables[1].Rows)
                {
                    if ((int)row["TagId"] == this.id)
                        paths.Add(row["Path"].ToString());
                }
                return paths;
            }
        }

        static SqlConnection connection = new SqlConnection();

        static string connectionString;

        static public List<Tag> Tags=new List<Tag>();

        static public DataSet ds;

        public TagDatabase()
        {
            RefreshTags();
        }

        static public void AddTag(string name, Color color)
        {
            List<int> idList = new List<int>();
            foreach (DataRow Row in ds.Tables[0].Rows)
            {
                idList.Add((int)Row["Id"]);
            }
            int i = 0;
            while (idList.Contains(i))
            {
                i++;
            }
            InsertTag(i, name, color); 
        }

        static public List<Tag> GetTags(string path)
        {
            List<Tag> result = new List<Tag>();
            List<int> id_path=new List<int>();
            foreach (DataRow row in ds.Tables[1].Rows)
                if (row["Path"].ToString() == path)
                    id_path.Add((int)row["TagId"]);
            foreach (int a in id_path)
                result.Add(GetTag(a));

            return result;
        }
        static public Tag GetTag(int tagid)
        {
            foreach (Tag tag in Tags)
                if (tag.id == tagid)
                    return tag;
            return null;
        }

        static private void InsertTag(int id, string name, Color color)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Insert into Tag (Id,Name,R,G,B) values (" + id + ",'" + name + "'," + color.R + "," + color.G + "," + color.B + ")";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            RefreshTags();
        }

        static public void UpdateItem(string oldPath, string newPath)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Update Tagged set Path='" + newPath + "' where Convert(VARCHAR, Path)='" + oldPath + "'";
            using(connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            RefreshTags();
        }

        static public void DeleteItem(string path)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Delete from Tagged where Convert(VARCHAR, Path)='" + path + "'";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.DeleteCommand = command;
                adapter.DeleteCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            RefreshTags();
        }
        static public void RefreshTags()
        {
            RefreshDatabase();
            Tags.Clear();
            foreach (DataRow Row in ds.Tables[0].Rows)
            {
                Tags.Add(new Tag((int)Row["Id"], (string)Row["Name"], Color.FromArgb((byte)Row["R"], (byte)Row["G"], (byte)Row["B"])));
            }
            foreach (DataRow Row in ds.Tables[1].Rows)
            {
                foreach (Tag tag in Tags)
                {
                    if (tag.id==(int)Row["TagId"])
                    {
                        tag.items.Add((string)Row["Path"]);
                    }
                }
            }
            
        }

        static public void RefreshDatabase()
        {
            if (ds!=null) ds.Clear();
            connectionString = ConfigurationManager.ConnectionStrings["FileManager.Properties.Settings.TagConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            // Create data table
            DataTable dataTableTag = new DataTable("Tag");
            DataTable dataTableTagged=new DataTable("Tagged");
            ds = new DataSet();
            SqlDataAdapter dataAdapter=new SqlDataAdapter();

            dataAdapter = new SqlDataAdapter("Select * from Tag", connection);
            dataAdapter.Fill(dataTableTag);
            ds.Tables.Add(dataTableTag);

            dataAdapter = new SqlDataAdapter("Select * from Tagged", connection);
            dataAdapter.Fill(dataTableTagged);
            ds.Tables.Add (dataTableTagged);
            
        }

    }
}
