using System;

namespace Server_application
{
    class RTCServer : TCPServer
    {
        private uint thisServerID;
        public static readonly object IDLock = new object();
        private static uint currentID = 0;
        private static bool connectExpected;

        public RTCServer(uint serverID)
        {
            thisServerID = serverID;
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