using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using chatbox.Models;

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
            chatdb.OpenConnection();
            ListUsers.Items.Add("");
            if (!CheckForInternetConnection())
            {
                MessageBox.Show("No internet connection found", "Network Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            { return false; }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Send_Button(object sender, MouseButtonEventArgs e)
        {
            string text = userInput.Text;
            string name = UserName.Text;

            string[] flname = name.Split(' ');
            chatdb.EnterMessage(flname[0], flname[1], text);

            /*for (int i = 0; i < chatdb.GetAllUsers().Count; i++)
            {
                ListUsers.Items.Add(chatdb.GetAllUsers().get);
            }
            chatdb.GetAllUsers().TrimExcess();*/
        }

        private void Text_Box_Enter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Button(this, null);
                
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            chatdb.displayAllMessages();
        }
    }
}
