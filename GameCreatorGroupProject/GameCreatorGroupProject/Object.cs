using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;



namespace GameCreatorGroupProject
{
    class GameObject
    {
        String objectname;
        double x;
        double y;
        double speed;
        //for map array, 0 max x value, 1 min x value, 2 max y value, 3 min y value

        double[] map = new double[4];
        

        //constructor takes as inputs, the name of the object, spawn location, and map details as an array of doubles that holds the maps size. The final value is the speed of the object.
        public GameObject(String name, double xspawn, double yspawn, double[] inputmap, double ispeed)
        {
            objectname = name;
            speed = ispeed;
            //if given spawn location is valid, make the 
            if (isvalid(xspawn, yspawn))
            {
                x = xspawn;
                y = yspawn;
            }
        }
        //Update should check for user input at the start or end of each frame.a
        void Update() {
            //how to correctly use IsKeyDown Function?
            if (System.Windows.Input.Keyboard.IsKeyDown(w) == true) {
                if (isvalid(x, y + speed))
                    y = y + speed;

            }
            
        }
        //check if location is valid, x coordinate, and y coordinate, max and min xy are the map boundaries
        bool isvalid(double xc, double yc) {
            if (xc < map[0] && xc > map[1] && yc < map[2] && yc > map[3]) {
                return true;
            }
            return false;
        }
    }

}
