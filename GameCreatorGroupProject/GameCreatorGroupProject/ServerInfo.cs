using System;

namespace GameCreatorGroupProject
{
    //class for holding server information
    internal class ServerInfo
    {
        private static string serverIP;

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