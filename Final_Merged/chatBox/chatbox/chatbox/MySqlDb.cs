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

        private MySqlConnection conn;

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

        public void OpenConnection() {
            conn.Open();
        }

        public void CloseConnection() {
            conn.Close();
        }

        // Show all messages
        public List<RetrieveMessages> GetAllUsers()
        {

            List<RetrieveMessages> showUserObject = new List<RetrieveMessages>();

            string sql = "SELECT DISTINCT * FROM chatboxdb";

            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    showUserObject.Add(new RetrieveMessages
                    {
                        fname = (string)reader["fname"],
                        lname = (string)reader["lname"],
                    });
                }

                reader.Close();
            }
            return showUserObject;
        }

        // Show all messages
        public List<RetrieveMessages> GetAllMessages() {
            
            List<RetrieveMessages> showMessageObject = new List<RetrieveMessages>();
            
            string sql = "SELECT * FROM chatboxdb";
            
            using (MySqlCommand cmd = new MySqlCommand()) {
                
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader();
                
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

        public void displayAllMessages()
        {
            List<RetrieveMessages> messages = this.GetAllMessages();
            foreach (RetrieveMessages m in messages)
            {
                Console.WriteLine("\n{0}: {1}\n{2}", m.fname, m.text, m.date);
            }
        }

        // Inputing a message
        public void EnterMessage(string fname, string lname, string message)
        { 

            String Year = DateTime.Now.Year.ToString();
            String Month = DateTime.Now.Month.ToString();
            string day = Convert.ToString(DateTime.Now.Day);

            string date = Year + "-" + Month + "-" + day;
            string sql = "";
            var cmd = new MySqlCommand(sql, conn); 
            sql = "INSERT INTO chatboxdb (fname, lname, message, messagedate) VALUES ('"+ fname +"','"+ lname +"', '"+ message +"', '"+ date +"' )";
            cmd.CommandText = sql;
            cmd.Connection = conn;

           
            int result = cmd.ExecuteNonQuery();
        }
    }  
}
            
            
            

