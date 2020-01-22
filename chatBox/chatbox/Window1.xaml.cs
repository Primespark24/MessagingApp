using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace chatbox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
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
