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
        private static TCPClient online = null;

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
