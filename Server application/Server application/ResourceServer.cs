using System;

namespace Server_application
{
    class ResourceServer : TCPServer
    {
        private uint serverID;
        private static bool connectExpected;
        private static uint currentID;
        public static readonly object IDLock = new object();

        public ResourceServer(uint serverID)
        {
            this.serverID = serverID;
        }

        public static void setConnectExpected()
        {
            connectExpected = true;
        }

        public static bool getConnectExpected()
        {
            return connectExpected;
        }

        public static uint getCurrentID()
        {
            return currentID;
        }

        public static void setCurrentID(uint ID)
        {
            currentID = ID;
        }

        public override void startServer()
        {
            throw new NotImplementedException();
        }

        public override void stopServer()
        {
            throw new NotImplementedException();
        }
    }
}