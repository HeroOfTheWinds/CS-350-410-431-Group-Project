using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    static class Program
    {
        private static MainClient online = null;
        public static bool connected = false;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            online = new MainClient();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        // making these connect to the functions in online so that they can be easier used in the Form
        public static void connect()
        {
            Thread t = new Thread(connectMain);
            t.Start();
        }

        //connects the main client to the server
        private static void connectMain()
        {
            online.connectClient(ServerInfo.getServerIP());
        }

        public static void disconnect()
        {
            online.disconnect();
        }

        public static bool Online(uint clientID)
        {
            return online.isOnline(clientID);
        }

        public static MainClient getMain()
        {
            return online;
        }

    }
}
