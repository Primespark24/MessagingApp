using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;

namespace Messageapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Socket sock;
        public EndPoint local;
        public EndPoint Foreign;
        public MainWindow()
        {
            InitializeComponent();
            
            // creating new socket with IPV4 and setting multi message capablity with Dgram and using UDP
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // allowing for reuse of all sockets
            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            //set Person 1 textbox in window to local Ip
            LocalIp.Text = GetLocalIp();
            //set Person 2 textbox in window to local Ip for testing//////////////// Also remember to change me////////////////////////////
            PartnerIp.Text = GetLocalIp();
        }

        private string GetLocalIp()
        {
            // container for host info
            IPHostEntry Host;
            //Grabing host info
            Host = Dns.GetHostEntry(Dns.GetHostName());

            //looking through Ip addresses in host to verify we grab the correct one
            foreach (IPAddress Ip in Host.AddressList)
            {
                if (Ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    //returning Correct Ip into a string
                    return Ip.ToString();
                }
            }
            //returns local Ip of machine it was coded on in case there is nothing to return
            return "10.200.100.17";
        }

        //message back function that dosent care what operations are happening because it has an asynchronus operation
        public void MessageBack(IAsyncResult Result)
        {
            try
            {
                int recieve = sock.EndReceiveFrom(Result, ref Foreign);
                //parsing data given
                if (recieve > 0)
                {
                    //breaking it into char streams max 500 
                    char[] RecievedData = new char[500];
                    RecievedData = (char[]) Result.AsyncState;

                    UTF8Encoding Encoding = new UTF8Encoding();
                    string MessageRecieved = Encoding.GetString(RecievedData);

                }
            }
            catch(Exception MessageError)
            {
                //show excpetion in message window
                System.Windows.MessageBox.Show(MessageError.ToString())
            }
        }
    }
}
