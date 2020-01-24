// Owners: Mason Caird & Brycen Martin
// Class: CS 371-1

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using chatbox.Models;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using MessageBox = System.Windows.MessageBox;

namespace chatbox
{


    public partial class DBChat : Window
    {
        private MySqlDb chatdb;

        // Constructor
        public DBChat()
        {
            chatdb = new MySqlDb("cs1", "mason", "YouMustTrainAndPolishYourself", "mason");
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
                
                // We then call Brycens project to chat over LAN
                IPChat emergencyWindows = new IPChat();
                emergencyWindows.ShowDialog();

            }
        }

        // Grabs users and places them into the userBox (ListBox)
        private void GetUserMethod()
        {
            // a list of users in list with type RetrieveMessages
            List<RetrieveMessages> userList = chatdb.GetAllUsers();

            // Checks list if all users in database are in the 
            foreach (RetrieveMessages u in userList)
            {
                // Username already exsists
                if (ListUsers.Items.Contains(u.fname + " " + u.lname))
                {
                    // do nothing
                }
                else
                {
                    // add user to the list
                    ListUsers.Items.Add(u.fname + " " + u.lname);
                }
            }

            // Trim the list if possible
            chatdb.GetAllUsers().TrimExcess();
            // Grab any new messages
            GetMessageMethod();
        }

        private void GetMessageMethod()
        {
            // We grab the users name and bring it username.
            string username = GetUsersName();
            // we make a list of messages with type RetrieveMessages
            List<RetrieveMessages> messageList = chatdb.GetAllMessages();

            // For every message in messageLIst
            foreach (RetrieveMessages m in messageList)
            {
                // if it already exsists
                if (MessageView.Items.Contains("\t\t\t" + m.fname + " " + m.lname + "\n\t\t\t" + m.text + "\n\t\t\t" + m.date) || MessageView.Items.Contains(m.fname + " " + m.lname + "\n" + m.text + "\n" + m.date))
                {
                    // do nothing since it already exists in the message
                }
                // If the current username matches the messages username
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

        // Submit the username and text
        private void submitNameNTxt(string username, string text)
        {
            //Splits the name of user. EX: Mason Caird;  flname[0] = Mason; lname[1] = Caird
            string[] flname = username.Split(' ');

            // Sends a message. If the user didn't submit a lastname, the lastname then defaults to a empty string
            try
            {
                // Try to send message with fname and lname and text
                chatdb.EnterMessage(flname[0], flname[1], text);
               
            }
            catch (Exception)
            {
                // If user doesnt type last name, we make last name null with space
                chatdb.EnterMessage(flname[0], " ", text);
            }

            // Grab messages
            GetMessageMethod();
        }

        // This opens a new window to ask user for a username
        private void setUserName()
        {
            // Opening the userNamePrompt window
            UserNamePrompt userNamePrompt = new UserNamePrompt();
            userNamePrompt.ShowDialog();
            
        }

        // Grabing the current users name
        private string GetUsersName()
        {
            string username;
            string path = "UserNameFile.txt";

            // if file already exists with username in it.
            if (File.Exists(path))
            {
                StreamReader sr = File.OpenText(path); // opening file
                username = sr.ReadLine(); // read file
                UserName.Text = username; // grab username
                UserName.IsEnabled = false; // Makes it so you cant change username unless you go to settings
                sr.Close();
                return username;
                
            } 
            else
            {
                // If file path didn't exist...
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
            string text = userInput.Text; // Grab the text from textbox (UserInput)
            submitNameNTxt(GetUsersName(), text); // Submit the users name with text
            GetUserMethod(); // Get UserMethod to update the database of users
            GetMessageMethod(); // get messages
            userInput.Text = ""; // Replace text in userInput text box with blank
        }

        // When the textbox is focused and a user hits enter.
        private void Text_Box_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Button(this, null);
            }
        }

        // if settings label is clicked
        private void GoToSettings(object sender, MouseButtonEventArgs e)
        {
            // Go to Settings Page
            settings settingPage = new settings();
            settingPage.ShowDialog();
        }

        // If the refresh label is clicked.
        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Refresh messages on screen.
            GetMessageMethod();
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
    }
}
