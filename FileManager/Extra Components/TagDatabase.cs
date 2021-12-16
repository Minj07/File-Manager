using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Extra_Components
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
            private int id;
            public string name;
            public Color color;
            public List<string> items;
            public void Insert(int id_insert,string path)
            {
                SqlDataAdapter adapter=new SqlDataAdapter();
                String query = "Insert into Tag (Id,Name,R,G,B) values (" + id + ",'" + name + "'," + color.R + "," + color.G + "," + color.B + ")";
                items.Add(path);
                String query1 = "Insert into Tagged (Id,Path,TagId) values (" + id_insert + ",'" + path + "'," + id + ")";
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();

                    command = new SqlCommand(query1, connection);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
            }

            public void Delete()
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                String query = "Delete Tagged where TagId=" + id.ToString();
                String query1= "Delete Tag where Id=" + id.ToString();
                using (connection)
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    adapter.DeleteCommand = command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    command.Dispose();

                    command = new SqlCommand(query1, connection);
                    adapter.DeleteCommand=command;
                    adapter.DeleteCommand.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();
                }
            }
        }
        static SqlConnection connection = new SqlConnection();
        //static string connectString = "FileManager.Properties.Settings.TagConnectionString";
        public List<Tag> Tags=new List<Tag>();
        public TagDatabase()
        {
            connection = new SqlConnection("FileManager.Properties.Settings.TagConnectionString");
            // Create data table
            DataTable dataTableTag = new DataTable("Tag");
            DataTable dataTableTagged=new DataTable("Tagged");
            DataSet ds = new DataSet();
            SqlDataAdapter dataAdapter=new SqlDataAdapter();

            dataAdapter = new SqlDataAdapter("Select * from Tag", connection);
            ds.Tables.Add(dataTableTag);
            dataAdapter.Fill(ds, dataTableTag.TableName);

            dataAdapter = new SqlDataAdapter("Select * from Tagged", connection);
            ds.Tables.Add (dataTableTagged);
            dataAdapter.Fill(ds, dataTableTagged.TableName);
            /*// Declare variables for DataColumn and DataRow objects
            DataColumn column;
            DataRow row;

            // Create new Id DataColumn, set DataType, ColumnName and add to DataTable
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Id";
            column.ReadOnly = true;
            column.Unique = true;
            dataTableTag.Columns.Add(column);
            
            // Create new Name DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Name";
            column.ReadOnly = true;
            dataTableTag.Columns.Add(column);

            // Create new R DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "R";
            column.ReadOnly = true;
            dataTableTag.Columns.Add(column);

            // Create new G DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "G";
            column.ReadOnly = true;
            dataTableTag.Columns.Add(column);*/
        }

    }
}
