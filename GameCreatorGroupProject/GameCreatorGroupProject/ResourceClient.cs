using System;

namespace GameCreatorGroupProject
{
    internal class ResourceClient : TCPClient
    {
<<<<<<< HEAD
        //special clients should only be invoked by main client
        internal class ResourceClient : TCPClient
        {

            private StreamWriter writer = null;
            private StreamReader reader = null;

            //resource port
            private readonly int port = 20115;
            public static readonly byte serverType = 2;
            private uint serverID;
            private bool dc;

            public ResourceClient(uint serverID)
            {
                this.serverID = serverID;
            }



            //connects to specified server
            public override void connectClient(string serverIP)
            {
                string data;
                dc = false;

                using (client = new TcpClient())
                {
                    //attempts to connect with 5 second timeout
                    IAsyncResult r = client.BeginConnect(serverIP, port, null, null);
                    bool connected = r.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(5));
                    if (connected)
                    {
                        stream = client.GetStream();
                        writer = new StreamWriter(stream);
                        reader = new StreamReader(stream);
                        //verifies client with server
                        writer.WriteLine(MainClient.getThisClientID());
                        writer.WriteLine(serverID);
                        writer.Flush();
                        //stops if method called improperly, or timeout reached on connection resulting in connection to be improperly established
                        if (reader.ReadLine().Equals("err"))
                        {
                            disconnectClient();
                            MessageBox.Show("Connection refused by server.", "Connection declined.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //resets priority after connected
                        Thread.CurrentThread.Priority = ThreadPriority.Normal;
                        //tells server clients username
                        writer.WriteLine(MainClient.getUsername());
                        writer.Flush();
                    }
                    else
                    {
                        client.EndConnect(r);
                        //shows error box if could not connect
                        MessageBox.Show("Connection timeout.", "Unable to connect to server, connection request timed out.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    //gets data 
                    while (client.Connected && !dc)
                    {
                        //if disconnected dataavailable field will throw and acception, and should set connected to false
                        try
                        {
                            //possible issue if server has not yet read sent data
                            if (stream.DataAvailable)
                            {
                                //reads stream data and returns as a string
                                data = reader.ReadLine();
                            }

=======
        private uint serverID;
        private readonly int port = 20115;
>>>>>>> b1f9e660103dc9f5de79a6fdb9b050399778f499

        public ResourceClient(uint serverID)
        {
            this.serverID = serverID;
        }

        public override void connectClient(string serverIP)
        {
            throw new NotImplementedException();
        }

        public override void disconnectClient()
        {
            throw new NotImplementedException();
        }

<<<<<<< HEAD
            public override int getClientType()
            {
                return serverType;
            }


=======
        public override void send(Object data)
        {
            throw new NotImplementedException();
>>>>>>> b1f9e660103dc9f5de79a6fdb9b050399778f499
        }
    }
}