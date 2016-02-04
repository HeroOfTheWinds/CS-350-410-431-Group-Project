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
    class ChatClient : TCPClient
    {
        //chat port
        private readonly int port = 20113;

        //connects to specified chat server
        public override void connectClient(string serverIP)
        {
            string message;

            client = new TcpClient(serverIP, port);
            stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            //reads messages
            while (true)
            {
                //allows other threads to execute
                Thread.Sleep(10);
                //possible issue if server has not yet read sent data
                if (stream.DataAvailable)
                {
                    //reads stream data
                    message = reader.ReadLine();
                }

                //add code to write message to chat interface

            }
        }

        //sends a message
        public override void send(ref Object message)
        {
            //writes message to stream
            StreamWriter writer = new StreamWriter(stream);
            writer.WriteLine((string)message);
            writer.Flush();
        }
    }
}
