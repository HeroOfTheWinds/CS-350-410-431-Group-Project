using System;
using System.Drawing;

namespace JustTheBasics
{
    //creates segments with points using y = mx + b equation format and provides methods for movement and intersection checking
    internal class Segment
    {
        private float startX;
        private float endX;
        private float startY;
        private float endY;
        private float m;
        private float b;
        private float lX;
        private float hX;
        private float lY;
        private float hY;

        private bool vert = false;

        //copy constructor
        public Segment(Segment cpy)
        {
            startX = cpy.StartX;
            endX = cpy.EndX;
            startY = cpy.StartY;
            endY = cpy.EndY;
            m = cpy.getM();
            b = cpy.getB();
            lX = cpy.getLX();
            hY = cpy.getHY();
            lY = cpy.getLY();
            hX = cpy.getHX();
            vert = cpy.isVert();
        }

        //creates a 2d segment with the specified start and end points
        public Segment(float startX, float startY, float endX, float endY)
        {
            float run = startX - endX;
            float rise = startY - endY;
            //if equation valid, sets segments equation
            if (run != 0)
            {
                m = rise / run;
                b = startY - m * startX;
            }
            //else indicates vertical line
            else
            {
                m = (float)Double.PositiveInfinity;
                b = (float)Double.PositiveInfinity;
                vert = true;
            }

            this.startX = startX;
            this.endX = endX;
            this.startY = startY;
            this.endY = endY;
            //sets highest and lowest x values
            if (startX < endX)
            {
                lX = startX;
                hX = endX;
            }
            else
            {
                hX = startX;
                lX = endX;
            }
            if (startY < endY)
            {
                lY = startY;
                hY = endY;
            }
            else
            {
                hY = startY;
                lY = endY;
            }
        }

        //getter and setters
        public float StartX
        {
            get
            {
                return startX;
            }
        }

        public float EndX
        {
            get
            {
                return endX;
            }
        }

        public float StartY
        {
            get
            {
                return startY;
            }
        }

        public float EndY
        {
            get
            {
                return endY;
            }
        }

        public void move(float speed, string dir)
        {
            //indicates movement in upward direction
            if (dir.Equals("u"))
            {
                //modifies segments accordingly
                startY += speed;
                endY += speed;
                hY += speed;
                lY += speed;
            }
            //indicates movement in downward direction (see above comments)
            else if (dir.Equals("d"))
            {
                startY -= speed;
                endY -= speed;
                hY -= speed;
                lY -= speed;
            }
            //indicates movement in left direction (see above comments)
            else if (dir.Equals("l"))
            {
                startX -= speed;
                endX -= speed;
                hX -= speed;
                lX -= speed;
            }
            //indicates movement in right direction (see above comments)
            else if (dir.Equals("r"))
            {
                startX += speed;
                endX += speed;
                hX += speed;
                lX += speed;
            }
            else
            {
                throw new ArgumentException("invalid direction");
            }
            //recalculates y intercept if not vertical
            if (!vert)
            {
                b = startY - m * startX;
            }
        }

        public float getM()
        {
            return m;
        }

        public float getB()
        {
            return b;
        }

        //checks if segments intersect on given interval
        public bool intersect(Segment inter)
        {
            float interX;
            //returns false if lines are parallel
            if (inter.getM() == m && inter.getB() == b)
            {
                return false;
            }
            //if one of the segments is verticle, chacks if second segment intersects it
            if (vert)
            {
                //makes sure the segments intersect on the x and y axis
                if ((startX < inter.getHX() && startX > inter.getLX()) && (hY > inter.getLY() && lY < inter.getHY()))
                {
                    return true;
                }
            }
            else if (inter.isVert())
            {
                //makes sure the segments intersect on the x and y axis
                if ((inter.startX < hX && inter.startX > lX) && (inter.getHY() > lY && inter.getLY() < hY))
                {
                    return true;
                }
            }
            //else determines point of intersection based on m and b values and checks if intersection on interval bounded by the segments
            else
            {
                interX = (b - inter.b) / (inter.m - m);
                if (interX > lX && interX < hX)
                {
                    return true;
                }
            }

            return false;
        }

        //more getter and setter methods
        public bool isVert()
        {
            return vert;
        }

        public float getHX()
        {
            return hX;
        }

        public float getLX()
        {
            return lX;
        }

        public float getHY()
        {
            return hY;
        }

        public float getLY()
        {
            return lY;
        }

    }

}