using System;

namespace GameCreatorGroupProject
{
    internal class ResourceClient : TCPClient
    {
        private uint serverID;
        private readonly int port = 20115;

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

        public override void send(Object data)
        {
            throw new NotImplementedException();
        }
    }
}