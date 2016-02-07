using System;
using System.Collections.Generic;
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
    abstract class TCPClient
    {
        protected TcpClient client = null;
        protected NetworkStream stream = null;

        //connects to a server
        abstract public void connectClient(string serverIP);

        //sends data to the server using a NetworkStream
        abstract public void send(ref Object data);

        //disconnects the client from the server
        abstract public void disconnectClient();
    }
}
