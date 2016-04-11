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

namespace Server_application
{
    class ChatServer : TCPServer
    {
        protected static TcpListener listener = null;
        protected static bool listenerStarted = false;

        private static uint currentID = 0;
        public static readonly object IDLock = new object();
        private Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();
        private bool running = true;
        private uint serverID = 0;
        //chat port
        private readonly int port = 20113;
        private static bool connectExpected = false;


        public ChatServer(uint serverID)
        {
            this.serverID = serverID;
        }


        public static void setConnectExpected()
        {
            connectExpected = true;
        }

        public static bool getConnectExpected()
        {
            return connectExpected;
        }

        public static uint getCurrentID()
        {
            return currentID;
        }

        public static void setCurrentID(uint ID)
        {
            currentID = ID;
        }

        //starts a chat server
        public override void startServer()
        {
            //attempts to start listener on chat port
            if (!listenerStarted)
            {
                try
                {
                    listener = new TcpListener(IPAddress.Any, port);
                    listener.Start();
                    listenerStarted = true;
                }
                //displays error box if unable to start server
                catch (SocketException e)
                {
                    MessageBox.Show("A network error has occured.", "Unable to start chat server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //server control loop
            while (running)
            {
                //checks if a new client is waiting to connect
                if (listener.Pending() && currentID == serverID)
                {
                    //connects to client
                    TcpClient client = listener.AcceptTcpClient();
                    //if client attempting to connect directly without going through main server, denies connection (closes clients stream)
                    if (!connectExpected)
                    {
                        client.GetStream().Close();
                        client.Close();
                    }
                    //else spawns new thread for handling data transmission to other clients
                    else
                    {
                        Thread t = new Thread(transmitter);
                        t.Start(client);
                        connectExpected = false;
                    }
                }
            }
        }

        //sends messages to all clients
        private void transmitter(Object client)
        {
            using (TcpClient thisClient = (TcpClient)client)
            {
                NetworkStream inStream = (thisClient).GetStream();
                string message = "";
                StreamReader reader = new StreamReader(inStream);
                //adds client to clientList, client name sent in clients stream
                clientList.Add(thisClient, reader.ReadLine());
                StreamWriter writer = null;
                NetworkStream outStream;
                while (thisClient.Connected && running)
                {
                    //checks if data is available on the clients stream
                    if (inStream.DataAvailable)
                    {
                        message = reader.ReadLine();
                        //sends data to all clients in chat
                        foreach (KeyValuePair<TcpClient, string> c in clientList)
                        {
                            string clientName;
                            
                            //creates StreamWriter for current outgoing client
                            outStream = c.Key.GetStream();
                            writer = new StreamWriter(outStream);
                            //appends sender name to beginning of message
                            clientList.TryGetValue(thisClient, out clientName);
                            //writes sender and message to outgoing stream
                            writer.WriteLine(clientName + ": " + message.ToString());
                            writer.Flush();
                        }
                    }

                }

                if (writer != null) { writer.Close(); }
                if (reader != null) { reader.Close(); }

                lock (clientList)
                {
                    clientList.Remove(thisClient);
                }
            }
        }

        public override void stopServer()
        {
            if (listener != null) { listener.Stop(); }
            running = false;
        }
    }

}
