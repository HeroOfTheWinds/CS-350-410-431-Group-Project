using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    //special clients should only be invoked by main client
    public class ChatClient : TCPClient
    {
        private StreamWriter writer = null;
        private StreamReader reader = null;
        //chat port
        private readonly int port = 20113;
        public static readonly byte serverType = 1;
        private uint serverID;
        private bool dc;

        //Event
        public delegate void DataReceivedHandler(string data);
        public event DataReceivedHandler DataReceived;

        public ChatClient(uint serverID)
        {
            this.serverID = serverID;
        }

        public uint getServerID()
        {
            return serverID;
        }

        //connects to specified chat server
        public override void connectClient(string serverIP)
        {
            string message;
            dc = false;

            using (client = new TcpClient())
            {
                //attempts to connect with 5 second timeout
                IAsyncResult r = client.BeginConnect(serverIP, port, null, null);
                bool connected = r.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
                if (connected)
                {
                    stream = client.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);
                    //verifies client with server
                    writer.WriteLine(MainClient.getThisClientID());
                    writer.WriteLine(serverID);
                    writer.Flush();
                    //stops if method called improperly, or timeout reached on connection resulting in connection to be improperly established
                    if (reader.ReadLine().Equals("err"))
                    {
                        disconnectClient();
                        MessageBox.Show("Connection refused by server.", "Connection declined.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    //resets priority after connected
                    Thread.CurrentThread.Priority = ThreadPriority.Normal;
                    //tells server clients username
                    writer.WriteLine(MainClient.getUsername());
                    writer.Flush();
                }
                else
                {
                    client.EndConnect(r);
                    //shows error box if could not connect
                    MessageBox.Show("Connection timeout.", "Unable to connect to server, connection request timed out.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //reads messages
                while (client.Connected && !dc)
                {
                    //if disconnected dataavailable field will throw an acception, and should set connected to false
                    try
                    {
                        //possible issue if server has not yet read sent data
                        if (stream.DataAvailable)
                        {
                            //reads stream data
                            message = reader.ReadLine();

                        //add code to write message to chat interface
                        if (DataReceived != null) // check if subscribed
                            DataReceived(message); // raise event with data
                            //add code to write message to chat interface
                            MessageBox.Show(message);

                        }
                    }
                    catch (Exception) { }

                }
                MessageBox.Show("Disconnected.", "Unable to connect to chat server.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //sends a message
        public override void send(Object message)
        {
            if (writer != null)
            {
                //writes message to stream
                //writer.WriteLineAsync(MainClient.getUsername());
                //writer.WriteLine(MainClient.getUsername());
                writer.WriteLine(message);
                writer.Flush();
            }
            else
            {
                throw new notConnectedException("Client must be connected to server before send is invoked");
            }
        }

        public override void disconnectClient()
        {
            dc = true;
            if (writer != null) { writer.Close(); }
            if (reader != null) { reader.Close(); }
            if (client != null) { client.Close(); }
        }


        public override int getClientType()
        {
            return serverType;
        }
    }
}
