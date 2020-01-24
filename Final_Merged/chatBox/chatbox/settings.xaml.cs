using System.IO;
using System.Windows;
using System.Windows.Input;


namespace chatbox
{
    
    public partial class settings : Window
    {

        // Default constructor
        public settings()
        {
            InitializeComponent();

            // Get path name so we can read the user name
            string path = "UserNameFile.txt";
            StreamReader sr = File.OpenText(path);
            string username = sr.ReadLine();
            // Set the username into the label so the user can see their name
            UserNameLabel.Content = username;
            sr.Close();
        }

        // Delete the username and make a new one
        private void DeleteUserName(object sender, MouseButtonEventArgs e)
        {
            // We close the main window
            DBChat mainwindow = new DBChat();
            mainwindow.Close();
            // We grab the file with user name in it and delete the file
            string path = "UserNameFile.txt";
            File.Delete(path);
            // We start the userNamePrompt and get the user to input a username
            UserNamePrompt userNamePrompt = new UserNamePrompt();
            userNamePrompt.ShowDialog();
        }

        // This will pass you to the phpmyadmin to change any database configuration
        private void GoToPhpMyAdmin(object sender, MouseButtonEventArgs e)
        {
            // username and password must be correct to access website.
            if (AdminUserName.Text == "mcaird" && AdminPass.Text == "password")
            {
                System.Diagnostics.Process.Start("http://www.phpmyadmin.co/sql.php?db=sql3319340&table=chatboxdb&pos=0");
            }
        }
    }
}
