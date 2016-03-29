using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using OpenTK.Input;
using System.Windows.Forms;
using OpenTK;

namespace GameCreatorGroupProject
{
    class GameObject
    {
        //contains all gameObjects with collision detection on, might have to move to external class rather than static var in case user is working on more than one project
        private static List<GameObject> collision = new List<GameObject>();
        private bool col;

        private String objectname;
        private float speed;
        private float baseSpeed;
        private float acc;
        //for map array, 0 max x value, 1 min x value, 2 max y value, 3 min y value

        float[] map = new float[4];

        //indicates direction last moved
        private bool uAcc;
        private bool dAcc;
        private bool rAcc;
        private bool lAcc;
        //location of objects vertices
        private Vector2[] loc;
        //line segments composing the object
        private List<Segment> segs = new List<Segment>();
        //minimum and maximum x, y vals
        private float maxX;
        private float minX;
        private float maxY;
        private float minY;

        //indicates if object has been spawned
        private bool isSpawned = false;


        //constructor takes as inputs, the name of the object, spawn location, map details as an array of floats that holds the maps size, the speed of the object, acceleration of the object, and whether object has collision.
        //NOTE: spawCoords must be vertices in order, with the last vertex connecting to the first
        public GameObject(String name, Vector2[] spawnCoords, float[] inputmap, float ispeed, float acceleration, bool collision)
        {
            col = collision;
            objectname = name;
            baseSpeed = ispeed;
            speed = ispeed;
            acc = acceleration;
            map = new float[4];
            Array.Copy(inputmap, map, 4);
            if (collision)
            {
                GameObject.collision.Add(this);
            }
            //tells user if spawn failed
            if (!spawn(spawnCoords))
            {
                MessageBox.Show("Spawn failed.", "Could not spawn object, invalid coordinates.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //indicates if object was successfully spawned
            else
            {
                isSpawned = true;
                loc = new Vector2[spawnCoords.Length];
                Array.Copy(spawnCoords, loc, spawnCoords.Length);
            }
        }

        //attempts to spawn object with given coordinates, returns true if successful, else false
        public virtual bool spawn(Vector2[] spawnCoords)
        {
            maxX = spawnCoords[0].X;
            minX = maxX;
            maxY = spawnCoords[0].Y;
            minY = maxY;
            List<Segment> temp = new List<Segment>();
            //checks if each coordinate valid and sets values
            for (int i = 0; i < spawnCoords.Length; i++)
            {
                //creates segments from coordinates, connecting them together as vertices, with the last vertex connecting to the first
                if (i + 1 < spawnCoords.Length)
                {
                    temp.Add(new Segment(spawnCoords[i].X, spawnCoords[i].Y, spawnCoords[i + 1].X, spawnCoords[i + 1].Y));
                }
                else
                {
                    temp.Add(new Segment(spawnCoords[i].X, spawnCoords[i].Y, spawnCoords[0].X, spawnCoords[0].Y));
                }
                //finds maximum x and y values
                if (spawnCoords[i].X > maxX)
                {
                    maxX = spawnCoords[i].X;
                }
                if (spawnCoords[i].X < minX)
                {
                    minX = spawnCoords[i].X;
                }
                if (spawnCoords[i].Y > maxY)
                {
                    maxY = spawnCoords[i].Y;
                }
                if (spawnCoords[i].Y < minY)
                {
                    minY = spawnCoords[i].Y;
                }
            }
            //checks if intersects with any existing object
            if (intersects(0, "l", temp))
            {
                return false;
            }
            //if all conditions met, sets object params and returns true
            isSpawned = true;
            segs = new List<Segment>(temp);
            return true;

        }

        //Update should check for user input at the start or end of each frame.a
        public virtual void Update() {
            //does nothing if object not spawned
            if (isSpawned)
            {
                //get state of all keyboards on device
                var state = OpenTK.Input.Keyboard.GetState();
                //checks up key, if it is pressed it will check if location is valid then update location.
                if (state[Key.Up])
                {
                    //checks if accelerating and adds speed if it is
                    if (uAcc)
                    {
                        speed += acc;
                    }
                    else
                    {
                        speed = baseSpeed;
                    }
                    bool valid = true;
                    //checks if the new coordinates are valid
                    foreach (Vector2 c in loc)
                    {
                        float x = c.X;
                        float y = c.Y;
                        //checks if x and y coordinates will be valid after movement
                        if (intersects(speed, "u", segs))
                        {
                            valid = false;
                            break;
                        }    
                    }
                    //modifies object location if valid
                    if (valid)
                    {
                        //updates each relevant coordinate and segment location
                        for (int i = 0; i < loc.GetLength(0); i++)
                        {
                            loc[i].Y += speed;
                            segs[i].StartY += speed;
                            segs[i].EndY += speed;
                        }
                    }
                    //indicates that other directions are not accelerating
                    dAcc = false;
                    rAcc = false;
                    lAcc = false;
                }
                //checks if down key is pressed (see above comments)
                if (state[Key.Down])
                {
                    if (dAcc)
                    {
                        speed += acc;
                    }
                    else
                    {
                        speed = baseSpeed;
                    }
                    bool valid = true;
                    foreach (Vector2 c in loc)
                    {
                        float x = c.X;
                        float y = c.Y;

                        if (intersects(speed, "d", segs))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid)
                    {
                        for (int i = 0; i < loc.GetLength(0); i++)
                        {
                            loc[i][1] -= speed;
                            segs[i].StartY -= speed;
                            segs[i].EndY -= speed;
                        }
                    }

                    uAcc = false;
                    rAcc = false;
                    lAcc = false;

                }
                //checks if left key is pressed (see above comments)
                if (state[Key.Left])
                {
                    if (lAcc)
                    {
                        speed += acc;
                    }
                    else
                    {
                        speed = baseSpeed;
                    }
                    bool valid = true;
                    foreach (Vector2 c in loc)
                    {
                        float x = c.X;
                        float y = c.Y;

                        if (intersects(speed, "l", segs))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid)
                    {
                        for (int i = 0; i < loc.GetLength(0); i++)
                        {
                            loc[i][0] -= speed;
                            segs[i].StartX -= speed;
                            segs[i].EndX -= speed;
                        }
                    }

                    uAcc = false;
                    rAcc = false;
                    dAcc = false;

                }
                //checks if right key is pressed (see above comments)
                if (state[Key.Right])
                {
                    if (rAcc)
                    {
                        speed += acc;
                    }
                    else
                    {
                        speed = baseSpeed;
                    }
                    bool valid = true;
                    foreach (Vector2 c in loc)
                    {
                        float x = c.X;
                        float y = c.Y;

                        if (intersects(speed, "r", segs))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (valid)
                    {
                        for (int i = 0; i < loc.GetLength(0); i++)
                        {
                            loc[i][0] += speed;
                            segs[i].StartX += speed;
                            segs[i].EndX += speed;
                        }
                    }

                    uAcc = false;
                    lAcc = false;
                    dAcc = false;

                }
            }

        }

        //chacks if segments in seg intersect with any collidable objects after given movement
        private bool intersects(float speed, string dir, List<Segment> seg)
        {
            //this object has no collision
            if (!col)
            {
                return false;
            }
            //copies given list
            List<Segment> temp = new List<Segment>(seg);

            bool first = true;
            //iterates through collidable objects
            foreach (GameObject o in collision)
            {
                //indicates movement in upwards direction
                if (dir.Equals("u"))
                {
                    //checks if objects intersect on two axis, else doesn't bother to check intersections
                    if ((maxX < o.getMaxX() && maxX > o.minX) || (minX > o.getMinX() && minX < o.maxX)
                        && (maxY < o.getMaxY() && maxY > o.minY) || (minY > o.getMinY() && minY < o.maxY))
                    {
                        foreach (Segment s in temp)
                        {
                            //modifies segment in temp based on movement, if first iteration
                            if (first)
                            {
                                //modifies segments accordingly
                                s.StartY += speed;
                                s.EndY += speed;
                            }
                                
                            //compares with each collidable objects segments
                            foreach (Segment l in o.getSegments())
                            {
                                //chacks if intersect
                                if (s.intersect(l))
                                {
                                    return true;
                                }
                            }
                        }
                        //indicates segments in temp have already been updated
                        first = false;
                    }
                }
                //indicates movement in downward direction (see above comments)
                else if (dir.Equals("d"))
                {
                    if ((maxX < o.getMaxX() && maxX > o.minX) || (minX > o.getMinX() && minX < o.maxX)
                        && (maxY < o.getMaxY() && maxY > o.minY) || (minY > o.getMinY() && minY < o.maxY))
                    {
                        foreach (Segment s in temp)
                        {
                            if (first)
                            {
                                s.StartY -= speed;
                                s.EndY -= speed;
                            }
                                foreach (Segment l in o.getSegments())
                                {
                                    if (s.intersect(l))
                                    {
                                        return true;
                                    }
                                }
                            }
                        first = false;
                        }
                    }
                //indicates movement in left direction (see above comments)
                else if (dir.Equals("l"))
                {
                    if ((maxX < o.getMaxX() && maxX > o.minX) || (minX > o.getMinX() && minX < o.maxX)
                        && (maxY < o.getMaxY() && maxY > o.minY) || (minY > o.getMinY() && minY < o.maxY))
                        {
                        foreach (Segment s in temp)
                        {
                            if (first)
                            {
                                s.StartX -= speed;
                                s.EndX -= speed;
                            }
                            foreach (Segment l in o.getSegments())
                            {
                                if (s.intersect(l))
                                {
                                    return true;
                                }
                            }
                        }
                        first = false;
                    }
                }
                //indicates movement in right direction (see above comments)
                else if (dir.Equals("r"))
                {
                    if ((maxX < o.getMaxX() && maxX > o.minX) || (minX > o.getMinX() && minX < o.maxX)
                        && (maxY < o.getMaxY() && maxY > o.minY) || (minY > o.getMinY() && minY < o.maxY))
                    {
                        foreach (Segment s in temp)
                        {
                            if (first)
                            {
                                s.StartX += speed;
                                s.EndX += speed;
                            }
                            foreach (Segment l in o.getSegments())
                            {
                                if (s.intersect(l))
                                {
                                    return true;
                                }
                            }
                        }
                        first = false;
                    }
                }
                else
                {
                    throw new ArgumentException("invalid direction");
                }
            }
            //returns false if no collision detected
            return false;
        }


        //check if location is valid, x coordinate, and y coordinate, max and min xy are the map boundaries
        //currently unused
        public virtual bool isvalid(float xc, float yc) {
            if (!(xc < map[0] && xc > map[1] && yc < map[2] && yc > map[3]))
            {
                return false;
            }
            return true;
            
        }

        //sets collision on and adds to collidable object list if not already in it
        public void setCollision()
        {
            col = true;
            if(!collision.Contains(this))
            {
                collision.Add(this);
            }
        }

        //sets collision off and removes from collidable object list
        public void removeCollision()
        {
            col = false;
            collision.Remove(this);
        }

        //returns collision status
        public bool getCol()
        {
            return col;
        }


        //getter and setter methods, many getter and setter methods
        public String getName()
        {
            return objectname;
        }

        public void setName(String name)
        {
            objectname = name;
        }

        public Vector2[] getLoc()
        {
            return loc;
        }

        public float[] getMap()
        {
            return map;
        }

        public void setMap(float[] map)
        {
            this.map = map;
        }

        public float getAcc()
        {
            return acc;
        }

        public void setAcc(float acceleration)
        {
            acc = acceleration;
        }

        public float getBaseSpeed()
        {
            return baseSpeed;
        }

        public void setBaseSpeed(float ispeed)
        {
            baseSpeed = ispeed;
        }

        public float getSpeed()
        {
            return speed;
        }

        public void setSpeed(float speed)
        {
            this.speed = speed;
        }



        public float getMaxX()
        {
            return maxX;
        }

        public float getMinX()
        {
            return minX;
        }

        public float getMaxY()
        {
            return maxY;
        }

        public float getMinY()
        {
            return minY;
        }


        public bool spawned()
        {
            return isSpawned;
        }

        public List<Segment> getSegments()
        {
            return segs;
        }
    }

}
