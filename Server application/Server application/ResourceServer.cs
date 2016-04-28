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

        private static uint currentID = 0;
        private static uint expectedClient = 0;

        //this will probably need to be changed when implimented for resources
        public static readonly object IDLock = new object();
        private Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();
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
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    //if client attempting to connect directly without going through main server, denies connection (closes clients stream)
                    //may also occur if connection attempted aftr timeout
                    if (!(connectExpected.IsSet && reader.ReadLine().Equals(expectedClient.ToString()) && reader.ReadLine().Equals(currentID.ToString())))
                    {
                        writer.WriteLine("err");
                        writer.Flush();
                        client.GetStream().Close();
                        client.Close();
                    }
                    //else spawns new thread for handling data transmission to other clients
                    else
                    {
                        //reports to client if successfully connected
                        writer.WriteLine("success");
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
        ***************************************/

        private void transmitter(Object client)
        {

            using (TcpClient thisClient = (TcpClient)client)
            {
                NetworkStream inStream = thisClient.GetStream();
                string message = "";
                //   StreamReader reader = new StreamReader(inStream);
                //adds client to clientList, client name sent in clients stream
                clientList.Add(thisClient, getAppDataPath());
                StreamWriter writer = null;
                NetworkStream outStream;
                while (thisClient.Connected && running)
                {
                    try
                    {
                        //checks if data is available on the clients stream
                        if (inStream.DataAvailable)
                        {
                            message = getAppDataPath();
                            //message = reader.ReadLine();
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

        /**************************************
        getAppDataPath()
            this function uses the system environment to fint he current user's
            application data folder, and returns the path as a string.
        ***************************************/
        private string getAppDataPath()
        {
            // Use the system-defined path to the User's AppData folder.
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            return path;
        }
    }
}
