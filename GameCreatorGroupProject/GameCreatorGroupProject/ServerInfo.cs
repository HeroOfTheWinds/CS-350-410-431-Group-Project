using System;

namespace GameCreatorGroupProject
{
    //class for holding server information
    internal class ServerInfo
    {
        private static string serverIP = "127.0.0.1";

        internal static string getServerIP()
        {
            return serverIP;
        }

        internal static void setServerIP(string IP)
        {
            serverIP = IP;
        }
    }
}