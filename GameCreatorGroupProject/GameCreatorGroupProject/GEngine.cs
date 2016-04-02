using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;

namespace Room
{
    class GEngine
    {
        /*______________members_________________________________*/
        private Graphics drawHandle;
        private Thread renderThread;

        /*______________functions_______________________________*/

        public GEngine(Graphics g)
        {
            drawHandle = g;
        }

        public void init()
        {
            renderThread = new Thread(new ThreadStart(render));
            renderThread.Start();
        }

        public void stop()
        {
            renderThread.Abort();
        }

        private void render()
        {
            int framesRendered = 0;
            long startTime = Environment.TickCount;


            while (true)
            {
                drawHandle.FillRectangle(new SolidBrush(Color.Yellow), 0, 0, 1200, 700);

                //benchmarking
                framesRendered++;
                if((Environment.TickCount) >= startTime + 1000)
                {
                    Console.WriteLine("GEngine: " + framesRendered + " fps");
                    framesRendered = 0;
                    startTime = Environment.TickCount;
                 
                }
            }
        }
    }
}
