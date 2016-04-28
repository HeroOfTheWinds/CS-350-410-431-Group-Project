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
    class ResourceServer : TCPServer
    {
        protected static TcpListener listener = null;
        protected static bool listenerStarted = false;

        public int arrayLength = 0;

        private static uint currentID = 0;
        private static uint expectedClient = 0;

        //this will probably need to be changed when implimented for resources
        public static readonly object IDLock = new object();
        private Dictionary<TcpClient, byte[]> clientList = new Dictionary<TcpClient, byte[]>();
        private bool running = true;
        private uint serverID = 0;
        //chat port
        private readonly int port = 20115;
        public static ManualResetEventSlim connectExpected = new ManualResetEventSlim(false);
        public static ManualResetEventSlim connected = new ManualResetEventSlim(false);


        /*************************************
                Starting client connection 
          **************************************/

        public ResourceServer(uint serverID)
        {
            this.serverID = serverID;
        }

        /*
           public static void setConnectExpected(bool expected)
           {
               if(expected)
               {
                   connectExpected.Set();
               }
               else
               {
                   connectExpected.Reset();
               }
           }

           public static bool getConnectExpected()
           {
               return connectExpected.IsSet;
           }
   */

        public static uint getCurrentID()
        {
            return currentID;
        }

        public static void setCurrentID(uint ID)
        {
            currentID = ID;
        }

        /*************************************
        Starting Server
        **************************************/
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

            while (running)
            {
                //checks if a new client is waiting to connect
                if (listener.Pending() && currentID == serverID)
                {
                    //connects to client
                    TcpClient client = listener.AcceptTcpClient();
                    //reads info from the client to ensure the proper client is attempting to connect
                    BinaryReader reader = new BinaryReader(client.GetStream());
                    BinaryWriter writer = new BinaryWriter(client.GetStream());
                    //if client attempting to connect directly without going through main server, denies connection (closes clients stream)
                    //may also occur if connection attempted aftr timeout
                    if (!(connectExpected.IsSet && reader.ReadByte().Equals(expectedClient.ToString()) && reader.ReadByte().Equals(currentID.ToString())))
                    {
                        writer.Write("err");
                        writer.Flush();
                        client.GetStream().Close();
                        client.Close();
                    }
                    //else spawns new thread for handling data transmission to other clients
                    else
                    {
                        //reports to client if successfully connected
                        writer.Write("success");
                        writer.Flush();
                        connectExpected.Reset();
                        Thread t = new Thread(transmitter);
                        t.Start(client);
                        connected.Set();
                    }
                }
            }
        }



        public override void stopServer()
        {
            if (listener != null) { listener.Stop(); }
            running = false;
        }

        public static void setExpectedClient(uint clientID)
        {
            expectedClient = clientID;
        }

        /**************************************
        transmisster method: (server side) sends resource to clients
        NO STRING ONLY INT AND BYTE[]
        ***************************************/

        private void transmitter(Object client)
        {

            using (TcpClient thisClient = (TcpClient)client)
            {
                NetworkStream inStream = thisClient.GetStream();
                //string message = "";
                byte[] message = null;
                BinaryReader reader = new BinaryReader(inStream);
                //adds client to clientList, client name sent in clients stream
                clientList.Add(thisClient, reader.ReadBytes(arrayLength));
                BinaryWriter writer = null;
                NetworkStream outStream;
                while (thisClient.Connected && running)
                {
                    try
                    {
                        //checks if data is available on the clients stream
                        if (inStream.DataAvailable)
                        {

                            // message =reader.ReadLine(); 
                            char data = reader.ReadChar();
                            //sends data to all clients in chat
                            foreach (KeyValuePair<TcpClient, byte[]> c in clientList)
                            {
                                byte[] clientName;

                                //creates StreamWriter for current outgoing client
                                outStream = c.Key.GetStream();
                                writer = new BinaryWriter(outStream);
                                //appends sender name to beginning of message
                                clientList.TryGetValue(thisClient, out clientName);
                                //writes sender and message to outgoing stream
                                writer.Write(arrayLength);//this is set to zero and shouldnt be
                                writer.Write(clientName + ": " + message.ToString()); //this should be a byte
                                writer.Flush();
                            }
                        }
                    }
                    catch (Exception) { }
                }

                if (writer != null) { writer.Close(); }
                //    if (reader != null) { reader.Close(); }

                lock (clientList)
                {
                    clientList.Remove(thisClient);
                }
            }

        }
    }
}

