using System.IO;
using System.Windows;
using System.Windows.Input;

namespace chatbox
{

    public partial class UserNamePrompt : Window
    {
        public UserNamePrompt()
        {
            InitializeComponent();
        }

        private void Send_Button(object sender, MouseButtonEventArgs e)
        {
            string username;
            string path = "UserNameFile.txt";
            username = UserName2.Text;

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(username);
                sw.Close();
            }
           
            
            this.Close();
        }

        private void Enter_Button(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Button(this, null);
            }
        }
    }
}
