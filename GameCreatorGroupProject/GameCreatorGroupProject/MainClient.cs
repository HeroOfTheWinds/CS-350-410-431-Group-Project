using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    internal class MainClient : TCPClient
    {
        //TEMPORARY, each program should have unique clientID
        private static readonly uint thisClientID = 0;
        //have some way for user to provide username
        private static string username = "";

        //handle incoming requests
        private BinaryWriter writer = null;
        private BinaryReader reader = null;
        //takes care of outgoing requests
        private TcpClient staticClient = null;
        private BinaryWriter staticWriter = null;
        private BinaryReader staticReader = null;
        private NetworkStream staticStream = null;
        //main port
        private readonly int port = 20112;

        //returns this clients ID
        public static uint getThisClientID()
        {
            return thisClientID;
        }

        //sets username
        public static void setUsername(string name)
        {
            username = name;
        }

        //returns username
        public static string getUsername()
        {
            return username;
        }

        //connects to specified chat server
        public override void connectClient(string serverIP)
        {
            staticClient = new TcpClient(serverIP, port);
            staticStream = staticClient.GetStream();
            staticReader = new BinaryReader(staticStream);
            staticWriter = new BinaryWriter(staticStream);
            //indicates to server this is the outgoing request client
            staticWriter.Write((byte)0);
            //tells server clientID
            staticWriter.Write(thisClientID);
            staticWriter.Flush();

            Tuple<byte, uint> connectInfo = null;
            using (client = new TcpClient(serverIP, port))
            {
                if (client.Connected)
                {
                    stream = client.GetStream();
                    writer = new BinaryWriter(stream);
                    reader = new BinaryReader(stream);
                    //indicates to server this is the incoming request client
                    writer.Write((byte)1);
                    //tells server clientID
                    writer.Write(thisClientID);
                    writer.Flush();
                }
                else
                {
                    //shows error box if could not connect
                    MessageBox.Show("A network error has occured.", "Unable to connect to chat server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //reads connection requests from server
                while (client.Connected)
                {
                    //checks if server has sent a connection request
                    if (stream.DataAvailable)
                    {
                        //reads stream data
                        connectInfo = new Tuple<byte, uint>(reader.ReadByte(), reader.ReadUInt32());
                        TCPClient c = null;
                        //creates requested client
                        //might need to add way to control clients (eg disconnect, etc), probably add to a list or somthing
                        switch (connectInfo.Item1)
                        {
                            case 1:
                                c = new ChatClient(connectInfo.Item2);
                                break;
                            case 2:
                                c = new ResourceClient(connectInfo.Item2);
                                break;
                            case 3:
                                c = new RTCClient(connectInfo.Item2);
                                break;
                        }
                        //connects client to server in new thread
                        Thread t = new Thread(startClient);
                        t.Start(c);
                    }
                }
                //tells user if client disconnected
                MessageBox.Show("Disconnected.", "Unable to connect to server.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        //connects the given client to the server
        private void startClient(object connectClient)
        {
            if (connectClient == null)
            {
                throw new ArgumentNullException("No client to connect");
            }
            //will this work without client type cast?
            ((TCPClient)connectClient).connectClient(ServerInfo.getServerIP());
        }

        //sends request for server type specified by message, and sends request for connection for itself
        public override void send(ref Object message)
        {
            //checks to ensure parameter is valid
            if ((byte)message == 1 || (byte)message == 2 || (byte)message == 3)
            {
                //ensures client has been connected
                if (staticWriter != null)
                {
                    //writes request to stream
                    staticWriter.Write((byte)message);
                    staticWriter.Flush();
                    //not sure if this is a blocking method, might have to find some way to wait for data to be available
                    //gets serverID for connection from main server
                    uint serverID = staticReader.ReadUInt32();
                    //connects this client
                    if (!connectClient((byte)message, serverID, thisClientID))
                    {
                        //throws an exception if this client not in server side client list, probably an issue with the server app
                        throw new notConnectedException("Main client not in server's connection list");
                    }
                    
                }
                else
                {
                    throw new notConnectedException("Client must be connected to server before send is invoked");
                }
            }
            //argument invalid
            else
            {
                throw new ArgumentException("Invalid server type");
            }
        }

        //disconnects the client
        public override void disconnectClient()
        {
            if (writer != null) { writer.Close(); }
            if (reader != null) { reader.Close(); }
            if (staticWriter != null) { writer.Close(); }
            if (staticReader != null) { reader.Close(); }
        }

        //starts chat server
        public void requestChatServer()
        {
            Object requestType = 1;
            send(ref requestType);
        }

        //starts server for resource sharing
        public void requestResourceServer()
        {
            Object requestType = 2;
            send(ref requestType);
        }

        //starts server for real time collaboration
        public void requestRTCServer()
        {
            Object requestType = 3;
            send(ref requestType);
        }

        //should probably check if connected in all these methods
        //requests specified client be connected to specified server, returns true if successfully connected, else false
        public bool connectClient(byte serverType, uint serverID, uint clientID)
        {
            if (staticWriter != null && staticClient.Connected)
            {
                //writes connect info to stream
                staticWriter.Write((byte)4);
                staticWriter.Write(serverType);
                staticWriter.Write(serverID);
                staticWriter.Write(clientID);
                staticWriter.Flush();
                //not sure if this is a blocking method, might have to find some way to wait for data to be available
                return staticReader.ReadBoolean();
            }
            else
            {
                MessageBox.Show("Disconnected.", "Unable to connect clients, server unavailable.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        //querys if specified user is online
        public bool isOnline(uint clientID)
        {
            staticWriter.Write((byte)5);
            staticWriter.Write(clientID);
            return staticReader.ReadBoolean();
        }

    }
}