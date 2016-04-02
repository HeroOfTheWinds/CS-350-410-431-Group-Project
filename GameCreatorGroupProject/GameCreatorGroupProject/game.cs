using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Room
{
    class Game
    {
        private GEngine gEngine;



        public void startGraphics(Graphics g)
        {
            gEngine = new GEngine(g);
            gEngine.init();
        }

        public void stopGame()
        {
            gEngine.stop();
        }
    }
}
