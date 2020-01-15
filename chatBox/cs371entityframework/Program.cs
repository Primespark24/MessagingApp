using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using cs371entityframework.Models;

namespace cs371entityframework
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the connection with Database
            MySqlDb chatdb = new MySqlDb("db4free.net", "masonc", "Toaster496", "chatboxdb");
            chatdb.OpenConnection();

            chatdb.EnterMessage("Mason", "Hello", "12-03-1423");

            //List<RetrieveMessages> chatObjects;

            /*Console.WriteLine("Full Roster:\n");
            foreach (FullRoster s in FullyRolly)
            {
                Console.WriteLine("First Name: {0} Last Name: {1} \nAge: {2} Role: {3} \nShip Name: {4} Ship Registration: {5}", s.Fname, s.Lname, s.Age, s.role, s.shipName, s.shipRegs);
                Console.WriteLine("\n");
            }*/
        }
    }
}
