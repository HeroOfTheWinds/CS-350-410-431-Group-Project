using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    internal class MainClient
    {
        //TEMPORARY, each program should have unique clientID
        private static readonly uint thisClientID = 0;
        //have some way for user to provide username
        private static string username = "";

        public static List<TCPClient> clients = new List<TCPClient>();

        private TcpClient client = null;
        private NetworkStream stream = null;
        //handle incoming requests
        private BinaryWriter writer = null;
        private BinaryReader reader = null;
        //takes care of outgoing requests
        private TcpClient staticClient = null;
        private BinaryWriter staticWriter = null;
        private BinaryReader staticReader = null;
        private NetworkStream staticStream = null;

        private bool dc;

        private Queue<TCPClient> available = new Queue<TCPClient>();
        //main port
        private readonly int port = 20112;

        //returns the next generated client, or null if no clients have been generated
        //use this to create something that checks for available clients and does stuff with them
        public TCPClient getAvailable()
        {
            if (available.Count != 0)
            {
                return available.Dequeue();
            }
            else
            {
                return null;
            }
        }


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
        public TCPClient connectClient(string serverIP)
        {
            TCPClient c = null;
            dc = false;
            try
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
                        Program.connected = true;
                        stream = client.GetStream();
                        writer = new BinaryWriter(stream);
                        reader = new BinaryReader(stream);
                        //indicates to server this is the incoming request client
                        writer.Write((byte)1);
                        //tells server clientID
                        writer.Write(thisClientID);
                        writer.Flush();
                        MessageBox.Show("Connected to the main server at " + ServerInfo.getServerIP().ToString() + "!");
                    }
                    else
                    {
                        //shows error box if could not connect
                        MessageBox.Show("A network error has occured.", "Unable to connect to server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //reads connection requests from server
                    while (client.Connected && !dc)
                    {
                        //checks if server has sent a connection request
                        if (stream.DataAvailable)
                        {
                            //reads stream data
                            connectInfo = new Tuple<byte, uint>(reader.ReadByte(), reader.ReadUInt32());
                            c = null;
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
                            available.Enqueue(c);
                            clients.Add(c);
                        }
                    }
                    //tells user if client disconnected
                    MessageBox.Show("Disconnected.", "Unable to connect to server.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception e)
            {
                disconnect();
                MessageBox.Show("A network error has occured.", "Unable to connect to server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return c;
        }


        //connects the given client to the server
        private void startClient(object connectClient)
        {
            if (connectClient == null)
            {
                throw new ArgumentNullException("No client to connect");
            }
            ((TCPClient)connectClient).connectClient(ServerInfo.getServerIP());
        }

        //sends request for server type specified by message, and sends request for connection for itself
        private uint send(byte type)
        {
            uint serverID;
            //checks to ensure parameter is valid
            if (type == 1 || type == 2 || type == 3)
            {
                //ensures client has been connected
                if (staticWriter != null)
                {
                    //writes request to stream
                    staticWriter.Write(type);
                    staticWriter.Flush();
                    //not sure if this is a blocking method, might have to find some way to wait for data to be available
                    //gets serverID for connection from main server
                    serverID = staticReader.ReadUInt32();
                    //connects this client
                    if (!connectClient(type, serverID, thisClientID))
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
            return serverID;
        }

        //disconnects the client
        public void disconnect()
        {
            dc = true;
            foreach (TCPClient c in clients)
            {
                c.disconnectClient();
            }
            if (writer != null) { writer.Close(); }
            if (reader != null) { reader.Close(); }
            if (staticWriter != null) { writer.Close(); }
            if (staticReader != null) { reader.Close(); }
        }

        public void disconnectClient(TCPClient c)
        {
            if (clients.Remove(c))
            {
                c.disconnectClient();
            }
        }

        //starts chat server
        public uint requestChatServer()
        {
            byte requestType = 1;
            return send(requestType);
        }

        //starts server for resource sharing
        public uint requestResourceServer()
        {
            byte requestType = 2;
            return send(requestType);
        }

        //starts server for real time collaboration
        public uint requestRTCServer()
        {
            byte requestType = 3;
            return send(requestType);
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