using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileManager
{
    public class Database
    {

        #region  Database

        static SqlConnection connection = new SqlConnection();

        static string connectionString;

        static public List<Tag> Tags = new List<Tag>();

        static public List<User> Users = new List<User>();

        static public DataSet ds;

        public Database()
        {
            UpdateTags();
            UpdateUsers();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        static public bool AddUser(string name, string password)
        {
            List<string> nameList = (from DataRow Row in ds.Tables[2].Rows select (string)Row["Username"]).ToList();

            if (nameList.Contains(name)) return false;

            List<int> idList = (from DataRow Row in ds.Tables[2].Rows select (int)Row["UID"]).ToList();
            

            int i = 0;
            while (idList.Contains(i))
            {
                i++;
            }

            InsertUser(i, name, ComputeSha256Hash(password), i == 0);
            return true;
        }

        static public void AddTag(int uid, string name, Color color)
        {
            List<int> idList = (from DataRow Row in ds.Tables[0].Rows select (int)Row["Id"]).ToList();
            int i = 0;
            while (idList.Contains(i))
            {
                i++;
            }
            InsertTag(i, uid, name, color);
        }

        static public User Login(string name, string password)
        {
            User user = Users.Find(u => u.username == name);
            if (user == null) return null;
            if (ComputeSha256Hash(password) == user.password)
            {
                return user;
            }

            return null;
        }

        static public void UpdateTags()
        {
            UpdateDatabase();
            Tags.Clear();
            foreach (DataRow Row in ds.Tables[0].Rows)
            {
                Tags.Add(new Tag((int)Row["Id"], (int)Row["UID"], (string)Row["Name"], Color.FromArgb((byte)Row["R"], (byte)Row["G"], (byte)Row["B"])));
            }
            foreach (DataRow Row in ds.Tables[1].Rows)
            {
                foreach (var tag in Tags.Where(tag => tag.id == (int)Row["TagId"]))
                {
                    tag.items.Add((string)Row["Path"]);
                }
            }

        }
        static public void UpdateUsers()
        {
            UpdateDatabase();
            Users.Clear();
            foreach (DataRow Row in ds.Tables[2].Rows)
            {
                Users.Add(new User((int)Row["UID"], (string)Row["Username"], (string)Row["Password"], (bool)Row["IsAdministrator"]));
            }

            foreach (DataRow Row in ds.Tables[0].Rows)
            {
                foreach (var user in Users.Where(user => user.uid == (int)Row["UID"]))
                {
                    user.tags.Add(new Tag(
                            (int)Row["Id"],
                            (int)Row["UID"],
                            (string)Row["Name"],
                            Color.FromArgb(
                                (byte)Row["R"],
                                (byte)Row["G"],
                                (byte)Row["B"]
                            )
                        )
                    );
                }
            }

            foreach (DataRow Row in ds.Tables[3].Rows)
            {
                foreach (var user in Users.Where(user => user.uid == (int)Row["UID"]))
                {
                    user.activities.Add(new User.Activity(
                        (User.Activity.ActionType)int.Parse((string)Row["Action"]),
                        SqlDateTime.Parse((string)Row["Time"]).Value,
                        (string)Row["Source"],
                        (string)Row["Destination"]
                    ));
                }
            }

        }
        static public void UpdateDatabase()
        {
            if (ds != null) ds.Clear();
            connectionString = ConfigurationManager.ConnectionStrings["FileManager.Properties.Settings.TagConnectionString"].ConnectionString;
            connection = new SqlConnection(connectionString);
            // Create data table
            DataTable dataTableTag = new DataTable("Tag");
            DataTable dataTableTagged = new DataTable("Tagged");
            DataTable dataTableUser = new DataTable("User");
            DataTable dataTableActivity = new DataTable("Activity");
            ds = new DataSet();
            SqlDataAdapter dataAdapter;

            dataAdapter = new SqlDataAdapter("Select * from [Tag]", connection);
            dataAdapter.Fill(dataTableTag);
            ds.Tables.Add(dataTableTag);

            dataAdapter = new SqlDataAdapter("Select * from [Tagged]", connection);
            dataAdapter.Fill(dataTableTagged);
            ds.Tables.Add(dataTableTagged);

            dataAdapter = new SqlDataAdapter("Select * from [User]", connection);
            dataAdapter.Fill(dataTableUser);
            ds.Tables.Add(dataTableUser);

            dataAdapter = new SqlDataAdapter("Select * from [Activity]", connection);
            dataAdapter.Fill(dataTableActivity);
            ds.Tables.Add(dataTableActivity);
        }


        #endregion

        #region Users

        public class User
        {
            public User(int uid, string username, string password, bool isAdministrator)
            {
                this.uid = uid;
                this.username = username;
                this.password = password;
                this.isAdministrator = isAdministrator;
                this.tags = new List<Tag>();
                this.activities = new List<Activity>();
            }
            public int uid { get;}

            public string username { get;}

            public string password { get; }

            public bool isAdministrator { get; }

            public List<Tag> tags { get; }

            public List<Activity> activities { get; }

            public class Activity
            {
                public enum ActionType
                {
                    Cut = 0,
                    Copy = 1,
                    Rename = 2,
                    Delete = 3,
                    Merge = 4,
                    New = 5,
                }

                public ActionType actionType { get;}

                public DateTime time { get; }

                public string source { get; }

                public string destination { get; }

                public Activity(ActionType actionType, DateTime time, string source, string destination)
                {
                    this.actionType = actionType;
                    this.time = time;
                    this.source = source;
                    this.destination = destination;
                }

            }

            public void ChangePriviliege(bool isAdministrator)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (connection)
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(("Update User set IsAdministrator=" + (isAdministrator?"true":"false") + " where UID=" + this.uid), connection);
                    adapter.UpdateCommand = command;
                    adapter.UpdateCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                UpdateUsers();
            }

            public void InsertTag(string name, Color color)
            {
                Database.AddTag(this.uid,name,color);
            }

            public void InsertActivity(Activity.ActionType actionType, DateTime time, string source, string destination)
            {
                List<int> idList = (from DataRow Row in ds.Tables[3].Rows select (int)Row["Id"]).ToList();
                int i = 0;
                while (idList.Contains(i))
                {
                    i++;
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "InsertItem into Activity (Id,UID,Action,Time,Source,Destination) values ("
                               + i.ToString() + ","
                               + this.uid.ToString() + ","
                               + ((int) actionType).ToString() + ",'"
                               + (new SqlDateTime(time)).ToString() + "','"
                               + source + "','"
                               + destination + "')";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                UpdateTags();
            }

            public void Delete()
            {
                foreach (Tag tag in tags)
                {
                    tag.Delete();
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "Delete User where UID = " + uid.ToString();
                String query1 = "Delete Activity where UID=" + uid.ToString();
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
                UpdateTags();
            }

            public List<Tag> GetTags(string path)
            {
                List<Tag> tl = new List<Tag>();
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    if (row["Path"].ToString() == path)
                    {
                        if (GetTag((int) row["TagId"]).uid == this.uid)
                        {
                            tl.Add(GetTag((int)row["TagId"]));
                        }
                    }
                }

                return tl;
            }

        }
        
        static private void InsertUser(int uid, string name, string password, bool isAdministrator)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Insert into [dbo].[User] (UID,Username,Password,IsAdministrator) values (" + uid + ",'" + name + "','" + password + "'," + ((isAdministrator)?1:0) + ")";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            UpdateDatabase();
        }

        internal static User GetUser(int uid)
        {
            return Users.FirstOrDefault(user => user.uid == uid);
        }
        #endregion

        #region Tags
        public class Tag
        {
            public Tag(int _id, int _uid, string _name, Color _color)
            {
                this.id = _id;
                this.uid = _uid;
                this.name = _name;
                this.color = _color;
                this.items = new List<string>();
            }
            public int id { get; }

            public int uid { get; }
            public string name { get; }
            public Color color { get; }
            public List<string> items { get; }
            public void InsertItem(string path)
            {
                List<int> idList = (from DataRow Row in ds.Tables[1].Rows select (int) Row["Id"]).ToList();
                int i = 0;
                while (idList.Contains(i))
                {
                    i++;
                }
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "Insert into Tagged (Id,Path,TagId) values (" + i.ToString() + ",'" + path + "'," + id + ")";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                UpdateTags();
                UpdateUsers();
            }
            public void Modify(string newName, Color newColor)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                string queryName = "";
                string queryColor = "";
                if (newName != null)
                    queryName = "Update Tag set Name='" + newName + "' where Id=" + this.id;
                if (newColor != null)
                    queryColor = "Update Tag set R=" + newColor.R + ", G=" + newColor.G + ", B=" + newColor.B + " where Id=" + this.id;
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
                    if (newColor != null)
                    {
                        SqlCommand command = new SqlCommand(queryColor, connection);
                        adapter.UpdateCommand = command;
                        adapter.UpdateCommand.ExecuteNonQuery();
                        command.Dispose();
                    }
                    connection.Close();
                }
                UpdateTags();
                UpdateUsers();
            }

            public void RemoveItem(string path)
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "Delete from Tagged where TagId=" + id.ToString() + " and  Convert(VARCHAR(MAX), Path)='" + path + "'";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.DeleteCommand = command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
                UpdateTags();
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
                UpdateTags();
                UpdateUsers();
            }

            public List<string> GetPaths()
            {
                List<string> paths = new List<string>();
                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    if ((int)row["TagId"] == this.id)
                        paths.Add(row["Path"].ToString());
                }
                return paths;
            }
        }
        
        static public List<Tag> GetTags(string path)
        {
            List<int> id_path = (from DataRow row in ds.Tables[1].Rows where row["Path"].ToString() == path select (int) row["TagId"]).ToList();

            return id_path.Select(GetTag).ToList();
        }

        static public Tag GetTag(int tagid)
        {
            return Tags.FirstOrDefault(tag => tag.id == tagid);
        }

        static private void InsertTag(int id, int uid, string name, Color color)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Insert into Tag (Id,UID,Name,R,G,B) values (" + id + ","+uid+",'" + name + "'," + color.R + "," + color.G + "," + color.B + ")";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.InsertCommand = command;
                adapter.InsertCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            UpdateTags();
            UpdateUsers();
        }

        static public void UpdateItem(string oldPath, string newPath)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Update Tagged set Path='" + newPath + "' where Convert(VARCHAR(MAX), Path)='" + oldPath + "'";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.UpdateCommand = command;
                adapter.UpdateCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            UpdateTags();
        }

        static public void DeleteItem(string path)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            String query = "Delete from Tagged where Convert(VARCHAR(MAX), Path)='" + path + "'";
            using (connection)
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                adapter.DeleteCommand = command;
                adapter.DeleteCommand.ExecuteNonQuery();
                command.Dispose();

                connection.Close();
            }
            UpdateTags();
        }

        #endregion




    }
}
