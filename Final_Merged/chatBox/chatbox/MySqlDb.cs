using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using chatbox.Models;

namespace chatbox
{
    public class MySqlDb
    {

        // This represents the MySql connection
        private MySqlConnection conn;

        // Constructor
        public MySqlDb(string server, string user, string pw, string db) {
            var connStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = server,
                UserID = user,
                Password = pw,
                Database = db,
                OldGuids = true
            };

            string connstr = connStringBuilder.ConnectionString;
            conn = new MySqlConnection(connstr);
        }

        //Open connection
        public void OpenConnection() {
            conn.Open();
        }

        // CLose connection
        public void CloseConnection() {
            conn.Close();
        }

        // method of GetAllUsers with type List<RetrieveMessages>. This grabs all users
        public List<RetrieveMessages> GetAllUsers()
        {

            // Userobject has a list of type RetrieveMessages
            List<RetrieveMessages> showUserObject = new List<RetrieveMessages>();

            // Sql messaage
            string sql = "SELECT DISTINCT * FROM chatboxdb";

            //While using the MySqlCommand...
            using (MySqlCommand cmd = new MySqlCommand())
            {
                
                // Attach varibales to pass through information
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                // Keep reading fname and lname while there exists.
                while (reader.Read())
                {
                    showUserObject.Add(new RetrieveMessages
                    {
                        fname = (string)reader["fname"],
                        lname = (string)reader["lname"],
                    });
                }
                // Close reader
                reader.Close();
            }

            // Return objects
            return showUserObject;
        }

        // Show all messages
        public List<RetrieveMessages> GetAllMessages() {
            
            // This will capture messages with type RetrieveMessages
            List<RetrieveMessages> showMessageObject = new List<RetrieveMessages>();
            
            // String for sql command
            string sql = "SELECT * FROM chatboxdb";
            
            // While using the commmand
            using (MySqlCommand cmd = new MySqlCommand()) {
                
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                
                // Keep reading and grabbing information about messages
                while (reader.Read()) {
                    showMessageObject.Add(new RetrieveMessages { 
                        fname = (string)reader["fname"],
                        lname = (string)reader["lname"],
                        text = (string)reader["message"],
                        date = (string)reader["messagedate"]
                    });
                }

                reader.Close();
            }
            return showMessageObject;
        }

        // Inputing a message
        public void EnterMessage(string fname, string lname, string message)
        { 
            // This grabs date of the message
            String Year = DateTime.Now.Year.ToString();
            String Month = DateTime.Now.Month.ToString();
            string day = Convert.ToString(DateTime.Now.Day);

            // This sends the message into the database.
            string date = Year + "-" + Month + "-" + day;
            string sql = "";
            var cmd = new MySqlCommand(sql, conn); 
            sql = "INSERT INTO chatboxdb (fname, lname, message, messagedate) VALUES ('"+ fname +"','"+ lname +"', '"+ message +"', '"+ date +"' )";
            cmd.CommandText = sql;
            cmd.Connection = conn;

           
            int result = cmd.ExecuteNonQuery();
        }

        // This will delete old messages
        // *** This was my future plan *** I didn't want to delete this code yet because I was curious if will work.
        // private void deleteOldMessages()
        // {

        //     string sql = "DELETE FROM chatboxdb;";
        //     /*MySqlParameter param = new MySqlParameter
        //     {
        //         ParameterName = "@Lname",
        //         Value = "simple instructions",
        //         MySqlDbType = MySqlDbType.VarChar,
        //         Size = 20
        //     };*/
        //     var cmd = new MySqlCommand(sql, conn);
        //     cmd.CommandText = sql;
        //     cmd.Connection = conn;
        //     /*cmd.Parameters.Add(param);*/
        // }
    }  
}
            
            
            

