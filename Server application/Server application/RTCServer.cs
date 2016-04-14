using System;
using System.Threading;

namespace Server_application
{
    class RTCServer : TCPServer
    {
        private uint thisServerID;
        public static readonly object IDLock = new object();
        private static uint currentID = 0;
        public static ManualResetEventSlim connectExpected = new ManualResetEventSlim(false);
        public static ManualResetEventSlim connected = new ManualResetEventSlim(false);
        private static uint expectedClient;

        public RTCServer(uint serverID)
        {
            thisServerID = serverID;
        }

        /*
        public static void setConnectExpected()
        {
            connectExpected = true;
        }

        public static bool getConnectExpected()
        {
            return connectExpected;
        }
        */

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

        public static void setExpectedClient(uint clientID)
        {
            expectedClient = clientID;
        }
    }
}