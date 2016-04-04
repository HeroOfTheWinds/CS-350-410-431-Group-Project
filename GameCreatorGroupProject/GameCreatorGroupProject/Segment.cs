using System;

namespace GameCreatorGroupProject
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

        private bool vert = false;

        public Segment(Segment cpy)
        {
            startX = cpy.StartX;
            endX = cpy.EndX;
            startY = cpy.StartY;
            endY = cpy.EndY;
            m = cpy.getM();
            b = cpy.getB();
            lX = cpy.getLX();
            hX = cpy.getHX();
            vert = cpy.isVert();
        }

        //creates a 2d segment with the specified start and end points
        public Segment(float startX, float startY, float endX, float endY)
        {
            float run = startX - endX;
            float rise = startY - endY;
            //if equation valid, sets segments equation
            if(run != 0)
            {
                m = rise / run;
                b = startY - m * startX;
            }
            //else indicates vertical line
            else
            {
                m = 0;
                b = 0;
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
            }
            //indicates movement in downward direction (see above comments)
            else if (dir.Equals("d"))
            {
                startY -= speed;
                endY -= speed;
            }
            //indicates movement in left direction (see above comments)
            else if (dir.Equals("l"))
            {
                startX -= speed;
                endX -= speed;
            }
            //indicates movement in right direction (see above comments)
            else if (dir.Equals("r"))
            {
                startX += speed;
                endX += speed;
            }
            else
            {
                throw new ArgumentException("invalid direction");
            }
            //recalculates y intercept
            b = startY - m * startX;
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
                if (startX < inter.getHX() && startX > inter.getLX())
                {
                    return true;
                }
            }
            else if (inter.isVert())
            {
                if (inter.startX < hX && inter.startX > lX)
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

    }
}