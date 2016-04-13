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
    class ChatClient : TCPClient
    {
        private StreamWriter writer = null;
        private StreamReader reader = null;
        //chat port
        private readonly int port = 20113;
        private readonly byte serverType = 1;
        private uint serverID;
        private bool dc;

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

            using (client = new TcpClient(serverIP, port))
            {
                if (client.Connected)
                {
                    stream = client.GetStream();
                    writer = new StreamWriter(stream);
                    reader = new StreamReader(stream);
                    //tells server clients username
                    writer.WriteLine(MainClient.getUsername());
                    writer.Flush();
                }
                else
                {
                    MessageBox.Show("A network error has occured.", "Unable to connect to chat server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //reads messages
                while (client.Connected && !dc)
                {
                    //possible issue if server has not yet read sent data
                    if (stream.DataAvailable)
                    {
                        //reads stream data
                        message = reader.ReadLine();


                        //add code to write message to chat interface
                        MessageBox.Show(message);

                    }

                }
                MessageBox.Show("Disconnected.", "Unable to connect to chat server.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //sends a message
        public override void send(ref Object message)
        {
            if (writer != null)
            {
                //writes message to stream
                writer.WriteLine((string)message);
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
    }
}
