using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using chatbox.Models;
using MySql.Data.MySqlClient;
using Application = System.Windows.Application;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using ListView = System.Windows.Forms.ListView;
using ListViewItem = System.Windows.Controls.ListViewItem;
using MessageBox = System.Windows.MessageBox;
using Path = System.IO.Path;
using System;
using System.Threading;

namespace chatbox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MySqlDb chatdb = new MySqlDb("sql3.freesqldatabase.com", "sql3319340", "bFxgnIiN4x", "sql3319340");

        public MainWindow()
        {
            InitializeComponent();
            chatdb.OpenConnection(); // Opens connection to database
            CheckForInternetConnection(); // Checks for internet connection
            ListUsers.Items.Add(""); // adds a space to add a user from the tabel of listBox
            ListUsers.Items.Add("");
            GetUserMethod(); // gets the users of UserList
        }

        // Checks for internet connection
        public static void CheckForInternetConnection()
        {
            try
            {
                // Makes a connection to secure internet protocol
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"));
            }
            catch
            {
                // If no internet exists, then we prompt the user that they are offline.
                MessageBox.Show("No internet connection found", "Network Error", MessageBoxButton.OK,
                      MessageBoxImage.Error);
                //
                //
                //
                // Do something for brycen stuff.
                Environment.Exit(0);
            }
        }

        // Grabs users and places them into the userBox (ListBox)
        private void GetUserMethod()
        {
            List<RetrieveMessages> userList = chatdb.GetAllUsers();

            // Checks list if all users in database are in the 
            foreach (RetrieveMessages u in userList)
            {
                if (ListUsers.Items.Contains(u.fname + " " + u.lname))
                {
                    // do nothing
                }
                else
                {
                    ListUsers.Items.Add(u.fname + " " + u.lname);
                }
            }
            chatdb.GetAllUsers().TrimExcess();
            GetMessageMethod();
        }

        private void GetMessageMethod()
        {

            string username = GetUsersName();
            List<RetrieveMessages> messageList = chatdb.GetAllMessages();

            foreach (RetrieveMessages m in messageList)
            {
                
                if (MessageView.Items.Contains("\t\t\t" + m.fname + " " + m.lname + "\n\t\t\t" + m.text + "\n\t\t\t" + m.date) || MessageView.Items.Contains(m.fname + " " + m.lname + "\n" + m.text + "\n" + m.date))
                {
                    // do nothing since it already exists in the message
                }
                else if (username == m.fname + " " + m.lname)
                {
                    // Indent on right
                    MessageView.Items.Add("\t\t\t" + m.fname + " " + m.lname + "\n\t\t\t" + m.text + "\n\t\t\t" + m.date);
                } 
                else
                {
                    // Indent on left
                    MessageView.Items.Add(m.fname + " " + m.lname + "\n" + m.text + "\n" + m.date);
                }
            }
        }

        private void submitNameNTxt(string username, string text)
        {
            string[] flname = username.Split(' ');

            // Sends a message. If the user didn't submit a lastname, the lastname then defaults to a empty string
            try
            {
                chatdb.EnterMessage(flname[0], flname[1], text);
               
            }
            catch (Exception)
            {
                chatdb.EnterMessage(flname[0], " ", text);
               
            }

            GetMessageMethod();
        }

        // This opens a new window to ask user for a username
        private void setUserName()
        {
            Window1 userNamePrompt = new Window1();
            userNamePrompt.ShowDialog();
            
        }

        private string GetUsersName()
        {
            string username;
            string path = "UserNameFile.txt";

            // if file already exists with username in it.
            if (File.Exists(path))
            {
                StreamReader sr = File.OpenText(path);
                username = sr.ReadLine();
                UserName.Text = username;
                UserName.IsEnabled = false; // Makes it so you cant change username unless you go to settings
                sr.Close();
                return username;
                
            } 
            else
            {
                
                username = "";
                // calls function to open window for username input
                setUserName();
                // Calls the getUsersName since there is now a file made to grab the username
                GetUsersName();
                return username;
              
            }
        }

        // Everytime the send button gets hit
        private void Send_Button(object sender, MouseButtonEventArgs e)
        {
            string text = userInput.Text;
            submitNameNTxt(GetUsersName(), text);
            GetUserMethod();
            GetMessageMethod();
            userInput.Text = "";
            GetMessageMethod();
        }

        // When the textbox is focused and a user hits enter.
        private void Text_Box_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Button(this, null);
            }
        }

        private void getMessagesMethod(object sender, RoutedEventArgs e)
        {
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            GetMessageMethod();
        }

        private void GoToSettings(object sender, MouseButtonEventArgs e)
        {
            settings settingPage = new settings();
            settingPage.ShowDialog();
        }
    }
}
