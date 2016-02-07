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
    class ChatServer : TCPServer
    {
        private List<TcpClient> clientList = new List<TcpClient>();
        private Dictionary<IPAddress, string> collaborators;
        private bool running = true;
        //chat port
        private readonly int port = 20113;

        //starts a chat server
        public override void startServer(Project project)
        {
            //gets collaborator list from project
            collaborators = project.Collaborators;
            //attempts to start listener on chat port
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
            //main server control
            while (running)
            {
                //checks if a new client is waiting to connect
                if (listener.Pending())
                {
                    //connects to client
                    //currently connects to any client, possibly add security later
                    TcpClient client = listener.AcceptTcpClient();
                    clientList.Add(client);
                    //spawns new thread for handling data transmission to other clients
                    Thread t = new Thread(transmitter);
                    t.Start(client);
                }
            }
        }

        //sends messages to all clients
        private void transmitter(Object client)
        {
            using (TcpClient thisClient = (TcpClient)client)
            {
                NetworkStream inStream = ((TcpClient)client).GetStream();
                StringBuilder message = new StringBuilder();
                StreamReader reader = new StreamReader(inStream);
                StreamWriter writer = null;
                NetworkStream outStream;
                while (thisClient.Connected && running)
                {
                    //checks if data is available on the clients stream
                    if (inStream.DataAvailable)
                    {
                        //sends data to all clients in chat
                        foreach (TcpClient c in clientList)
                        {
                            message.Clear();
                            IPAddress userIP;
                            string clientName;
                            //gets client IP, used to determine client name (to be changed)
                            userIP = ((IPEndPoint)thisClient.Client.RemoteEndPoint).Address;
                            //creates StreamWriter for current outgoing client
                            outStream = c.GetStream();
                            writer = new StreamWriter(outStream);
                            //appends sender name to beginning of message
                            collaborators.TryGetValue(userIP, out clientName);
                            message.Append(clientName);
                            message.Append(": ");
                            //appends outgoing message
                            message.Append(reader.ReadLine());
                            //writes message to outgoing stream
                            writer.WriteLine(message.ToString());
                            writer.Flush();
                        }
                    }

                }
                //REMEMBER TO GO BACK THROUGH AND CHECK FOR NULL THINGS WHEN CLOSING, also figure out how to tell clients theyre dced

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
