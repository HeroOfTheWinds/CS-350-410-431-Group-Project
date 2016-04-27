using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Application_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hit Ctrl-C to exit.");
            new MainServer().startServer().Wait();
        }
    }
}
