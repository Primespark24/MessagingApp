using System.IO;
using System.Windows;
using System.Windows.Input;

namespace chatbox
{
    public partial class UserNamePrompt : Window
    {
        // Default constructor
        public UserNamePrompt()
        {
            // initialize the component.
            InitializeComponent();
        }

        // The send button when its clicked
        private void Send_Button(object sender, MouseButtonEventArgs e)
        {
            string username;
            string path = "UserNameFile.txt";
            // grab prefered username and take to variable username
            username = UserName2.Text;

            // Make a file and place the username in the file
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(username);
                sw.Close();
            }
            this.Close();
        }

        // If the textbox is focused and the user hits, enter, we submit the username.
        private void Enter_Button(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Button(this, null);
            }
        }
    }
}
