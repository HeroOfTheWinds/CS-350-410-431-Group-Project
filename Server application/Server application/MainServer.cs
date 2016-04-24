using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_application
{
    class MainServer : TCPServer
    {
        protected static TcpListener listener = null;
        protected static bool listenerStarted = false;

        //dictionary of connected clients by clientID
        private Dictionary<uint, TcpClient> clientList = new Dictionary<uint, TcpClient>();
        private bool running = true;
        private static readonly object serverCounterLock = new Object();
        private uint serverCounter = 0;
        //main server port
        private readonly int port = 20112;

        public async override void startServer()
        {
            //attempts to start listener on chat port
            if (!listenerStarted)
            {
                try
                {
                    //possible issues with conflicts if multiple chat servers running, to be fixed later
                    listener = new TcpListener(IPAddress.Any, port);
                    listener.Start();
                }
                //displays error box if unable to start server
                catch (SocketException e)
                {
                    MessageBox.Show("A network error has occured.", "Unable to start chat server.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //main server control
            while (running)
            {
                //checks if a new client is waiting to connect
                if (listener.Pending())
                {
                    //connects to client
                    //currently connects to any client, possibly add security later
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    NetworkStream stream = client.GetStream();
                    BinaryReader reader = new BinaryReader(stream);
                    byte type = reader.ReadByte();

                    //client type sends requests to server
                    if (type == 0)
                    {
                        Thread t = new Thread(transmitter);
                        t.Start(client);
                    }
                    //client type waits for requests from server
                    else if (type == 1)
                    {
                        uint thisClientID = reader.ReadUInt32();
                        //adds client to a dictionary for use
                        clientList.Add(thisClientID, client);
                    }
                }
            }
        }

        //communicates between clients
        private void transmitter(Object client)
        {
            using (TcpClient thisClient = (TcpClient)client)
            {
                NetworkStream stream = thisClient.GetStream();
                BinaryReader reader = new BinaryReader(stream);
                BinaryWriter writer = new BinaryWriter(stream);

                uint thisClientID = reader.ReadUInt32();

                //control while client connected and server running
                while (thisClient.Connected && running)
                {
                    //checks if data is available on the clients stream
                    if (stream.DataAvailable)
                    {
                        //gets the type of request sent by the client
                        byte reqType = reader.ReadByte();
                        switch (reqType)
                        {
                            //request for chat server
                            case 1:
                                //locks to ensure server counter not modified by another thread
                                lock (serverCounterLock)
                                {
                                    //increments server counter
                                    serverCounter++;
                                    //creates chat server with serverCounter as its ID in new thread
                                    Thread tC = new Thread(startChatServer);
                                    tC.Start(serverCounter);
                                    //writes the assigned serverID to client
                                    writer.Write(serverCounter);
                                }
                                break;
                            //request for resource server
                            case 2:
                                //locks to ensure server counter not modified by another thread
                                lock (serverCounterLock)
                                {
                                    //increments server counter
                                    serverCounter++;
                                    //creates resource server with serverCounter as its ID in new thread
                                    Thread tR = new Thread(startResourceServer);
                                    tR.Start(serverCounter);
                                    //writes the assigned serverID to client
                                    writer.Write(serverCounter);
                                }
                                break;
                            //request for real time collaboration server
                            case 3:
                                //locks to ensure server counter not modified by another thread
                                lock (serverCounterLock)
                                {
                                    //increments server counter
                                    serverCounter++;
                                    //creates real time collaboration server with serverCounter as its ID in new thread
                                    Thread tRTC = new Thread(startRTCServer);
                                    tRTC.Start(serverCounter);
                                    //writes the assigned serverID to client
                                    writer.Write(serverCounter);
                                }
                                break;
                            //request to connect a client to a server
                            case 4:
                                TcpClient connect;
                                //reads connection info from stream
                                byte serType = reader.ReadByte();
                                uint serverID = reader.ReadUInt32();
                                uint clientID = reader.ReadUInt32();
                                //checks if specified client connected, and gets corresponding TcpClient
                                if (clientList.TryGetValue(clientID, out connect))
                                {
                                    //creates reader and writer on requested clients stream
                                    NetworkStream cStream = connect.GetStream();
                                    BinaryWriter cWriter = new BinaryWriter(cStream);
                                    //indicates whether client successfully connected
                                    bool success = false;
                                    //checks the type of server connection request for
                                    switch (serType)
                                    {
                                        //connection request for chat server
                                        case 1:
                                            //locks to ensure ChatServer's currentID is not changed
                                            lock (ChatServer.IDLock)
                                            {
                                                //tells chat servers listener that incoming request is for server with specified ID
                                                ChatServer.setCurrentID(serverID);
                                                ChatServer.setExpectedClient(clientID);
                                                //tells chat server that a connection is expected
                                                ChatServer.connectExpected.Set();
                                                //tells client to connect
                                                cWriter.Write(serType);
                                                cWriter.Write(serverID);
                                                //waits for client to connect to unlock, connectExpected set to false when it does
                                                success = ChatServer.connected.Wait(TimeSpan.FromSeconds(5));
                                                //ensures values reset regardless of outcome
                                                ChatServer.connectExpected.Reset();
                                                ChatServer.connected.Reset();
                                            }
                                            break;
                                        //connection request for resource server
                                        case 2:
                                            //structure same as chat server, see comments for case 1
                                            lock (ResourceServer.IDLock)
                                            {
                                                ResourceServer.setCurrentID(serverID);
                                                ResourceServer.setExpectedClient(clientID);
                                                ResourceServer.connectExpected.Set();
                                                cWriter.Write(serType);
                                                cWriter.Write(serverID);
                                                success = ResourceServer.connected.Wait(TimeSpan.FromSeconds(5));
                                                //ensures values reset regardless of outcome
                                                ResourceServer.connectExpected.Reset();
                                                ResourceServer.connected.Reset();
                                            }
                                            break;
                                        //connection request for real time collaboration server
                                        case 3:
                                            //structure same as chat server, see comments for case 1
                                            lock (RTCServer.IDLock)
                                            {
                                                RTCServer.setCurrentID(serverID);
                                                RTCServer.setExpectedClient(clientID);
                                                RTCServer.connectExpected.Set();
                                                cWriter.Write(serType);
                                                cWriter.Write(serverID);
                                                success = RTCServer.connected.Wait(TimeSpan.FromSeconds(5));
                                                //ensures values reset regardless of outcome
                                                RTCServer.connectExpected.Reset();
                                                RTCServer.connected.Reset();
                                            }
                                            break;
                                    }
                                    //checks if requested client still connected
                                    if (connect.Connected && success)
                                    {
                                        //tells requester client successfully connected if it is
                                        writer.Write(true);
                                    }
                                    else
                                    {
                                        //else indicates connection unsuccessful
                                        writer.Write(false);
                                    }

                                }
                                //requested client not connected
                                else
                                {
                                    //tells client connection request was unsuccessful
                                    writer.Write(false);
                                }

                                break;
                            //request for status of indicated client
                            case 5:
                                TcpClient temp;
                                //checks if indicated client is in list of connected clients
                                if (clientList.TryGetValue(reader.ReadUInt32(), out temp))
                                {
                                    //tells requester specified client is connected
                                    writer.Write(true);
                                }
                                else
                                {
                                    //tells requester specified client is not connected
                                    writer.Write(false);
                                }
                                break;

                        }
                    }
                }

                //cleanup
                if (writer != null) { writer.Close(); }
                if (reader != null) { reader.Close(); }
                //removes client from list of connected clients
                lock (clientList)
                {
                    TcpClient close;
                    if (clientList.TryGetValue(thisClientID, out close))
                    {
                        close.GetStream().Close();
                        close.Close();
                        clientList.Remove(thisClientID);
                    }
                }
            }
        }

        //starts a real time collaboration server with specidied serverID
        private void startRTCServer(object serverID)
        {
            TCPServer server = new RTCServer((uint)serverID);
            server.startServer();
        }

        //starts a resource server with specidied serverID
        private void startResourceServer(object serverID)
        {
            TCPServer server = new ResourceServer((uint)serverID);
            server.startServer();
        }

        //starts a chat server with specidied serverID
        private void startChatServer(object serverID)
        {
            TCPServer server = new ChatServer((uint)serverID);
            server.startServer();
        }

        //stops the main server
        public override void stopServer()
        {
            if (listener != null) { listener.Stop(); }
            running = false;
        }
    }
}
