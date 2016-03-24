namespace GameCreatorGroupProject
{
    internal class Segment
    {
        private double startX;
        private double endX;
        private double startY;
        private double endY;
        private double m;
        private double b;
        private double lX;
        private double hX;

        private bool vert = false;

        //creates a 2d segment with the specified start and end points
        public Segment(double startX, double startY, double endX, double endY)
        {
            double run = startX - endX;
            double rise = startY - endY;
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
        public double StartX
        {
            get
            {
                return startX;
            }

            set
            {
                startX = value;
            }
        }

        public double EndX
        {
            get
            {
                return endX;
            }

            set
            {
                endX = value;
            }
        }

        public double StartY
        {
            get
            {
                return startY;
            }

            set
            {
                startY = value;
            }
        }

        public double EndY
        {
            get
            {
                return endY;
            }

            set
            {
                endY = value;
            }
        }

        public double getM()
        {
            return m;
        }

        public double getB()
        {
            return b;
        }

        //checks if segments intersect on given interval
        public bool intersect(Segment inter)
        {
            double interX;
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

        public double getHX()
        {
            return hX;
        }

        public double getLX()
        {
            return lX;
        }

    }
}