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

namespace Server_application
{
    abstract class TCPServer
    {
        //starts the server for use with the specified project
        abstract public void startServer();

        //stops the server
        abstract public void stopServer();
    }
}
