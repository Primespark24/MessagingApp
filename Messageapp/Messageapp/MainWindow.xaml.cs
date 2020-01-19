﻿using System;
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
        private void MessageBack(IAsyncResult Result)
        {
            try
            {
                int recieve = sock.EndReceiveFrom(Result, ref Foreign);
                //parsing data given
                if (recieve > 0)
                {
                    //breaking it into byte streams max 
                    byte[] RecievedData = new byte[1464];
                    RecievedData = (byte[]) Result.AsyncState;

                    //encoding to utf8 for message send and recieve
                    ASCIIEncoding Encoding = new ASCIIEncoding();
                    string MessageRecieved = Encoding.GetString(RecievedData);

                    //Insert into view box
                    Viewbox.Items.Add("Friend:" + MessageRecieved);
                }

                byte[] buffer = new byte[1500];

                //Begin recieve with properties allocated below
                sock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref Foreign, new AsyncCallback(MessageBack), buffer);
            }
            catch(Exception MessageError)
            {
                //show excpetion in message window
                System.Windows.MessageBox.Show(MessageError.ToString());
            }
        }

        private void Button_Click(object sent, EventArgs error)
        {
            try
            {
                //connection check/bind for local person
                local = new IPEndPoint(IPAddress.Parse(LocalIp.Text), Convert.ToInt32(LocalPort.Text));
                sock.Bind(local);

                //connection check/bind for foreign person
                Foreign = new IPEndPoint(IPAddress.Parse(PartnerIp.Text), Convert.ToInt32(PartnerPort.Text));
                sock.Connect(Foreign);

                //buffer and call back message
                byte[] buffer = new byte[1500];
                sock.BeginReceiveFrom(buffer, 0, buffer.Length, SocketFlags.None, ref Foreign, new AsyncCallback(MessageBack), buffer);

                //focus set on messagebox element
                button_connect.Content = "Connected";
                button_connect.IsEnabled = false;
                button_send.IsEnabled = true;
                MessageBox.Focus();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }

        private void Button_Click2(object sent, EventArgs error)
        {
            try
            {
                //putting text in message box 
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] msg = new byte[2400];
                msg = encoding.GetBytes(MessageBox.Text);

                //send message to client
                sock.Send(msg);

                //put message into chat
                Viewbox.Items.Add( "You:" + MessageBox.Text);
                MessageBox.Clear();
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.ToString());
            }
        }
    }
}
