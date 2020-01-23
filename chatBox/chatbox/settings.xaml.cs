using System.IO;
using System.Windows;
using System.Windows.Input;


namespace chatbox
{
    /// <summary>
    /// Interaction logic for settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        public settings()
        {
            InitializeComponent();
            string path = "UserNameFile.txt";
            StreamReader sr = File.OpenText(path);
            string username = sr.ReadLine();
            UserNameLabel.Content = username;
            sr.Close();
        }

        private void DeleteUserName(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Close();
            
            string path = "UserNameFile.txt";
            File.Delete(path);
            Window1 userNamePrompt = new Window1();
            userNamePrompt.ShowDialog();
        }

        private void GoToPhpMyAdmin(object sender, MouseButtonEventArgs e)
        {
            if (AdminUserName.Text == "mcaird" && AdminPass.Text == "password")
            {
                System.Diagnostics.Process.Start("http://www.phpmyadmin.co/sql.php?db=sql3319340&table=chatboxdb&pos=0");
            }
        }
    }
}
