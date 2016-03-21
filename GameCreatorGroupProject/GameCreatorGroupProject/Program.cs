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

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
            //creates a main client for the program
            online = new MainClient();
        }

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
    }
}
