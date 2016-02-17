using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
//using System.Object.Input.Keyboard;


namespace GameCreatorGroupProject
{
    class GameObject
    {
        double x = 0;
        double y = 0;
        //change map boundaries to an array later, would be easier.
        double maxx = 10;
        double maxy = 10;
        double minx = 0;
        double miny = 0;
        public GameObject(double xspawn, double yspawn)// map boundaries should be part of this constructor
        {
            //if given spawn location is valid, make the 
            if (isvalid(xspawn, yspawn))
            {
                x = xspawn;
                y = yspawn;
            }
        }
        //Update should check for user input at the start or end of each frame.a
        void Update() {
            //if w , increase on the y axis, etc?
        }
        //check if location is valid, x coordinate, and y coordinate, max and min xy are the map boundaries
        bool isvalid(double xc, double yc) {
            if (xc < maxx && xc > minx && yc < maxy && yc > miny) {
                return true;
            }
            return false;
        }
    }

}
