using System;

namespace GameCreatorGroupProject
{
    internal class RTCClient : TCPClient
    {
        private uint serverID;
        private readonly int port = 20114;

        public RTCClient(uint serverID)
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

        public override void send(ref object data)
        {
            throw new NotImplementedException();
        }
    }
}