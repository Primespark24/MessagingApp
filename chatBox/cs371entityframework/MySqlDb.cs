using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using cs371entityframework.Models;

namespace cs371entityframework
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

        public List<RetrieveMessages> GetAllMessages() {
            List<RetrieveMessages> showMessageObject = new List<RetrieveMessages>();
            string sql = "SELECT username, message FROM messages";
            using (MySqlCommand cmd = new MySqlCommand()) {
                cmd.CommandText = sql;
                cmd.Connection = conn;
                MySqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read()) {
                    showMessageObject.Add(new RetrieveMessages { 
                        name = (string)reader["username"],
                        text = (string)reader["message"],
                        date = (string)reader["textsubmit"]
                    });
                }
                reader.Close();
            }
            return showMessageObject;
        }

        public void EnterMessage(string name, string message, string date)
        {
            string sql = "";
            var cmd = new MySqlCommand(sql, conn); 
            sql = "INSERT INTO chatboxdb (name, message, date) VALUES ("+ name +", "+ message +", "+ date +" )";
            cmd.CommandText = sql;
            cmd.Connection = conn;

            int result = cmd.ExecuteNonQuery();
        }
    }  
}
            
            
            

