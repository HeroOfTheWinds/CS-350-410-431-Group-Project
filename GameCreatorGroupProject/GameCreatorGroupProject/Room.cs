using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;

namespace GameCreatorGroupProject
{
    class Room
    {
        public Dictionary<Vector3, GameObject> Objects;
        private Color Bcolor; //color4 is the struct in OpenTK.Graphics for color
        private int sizeWidth; //dimensions (x) of the room
        private int sizeHeight; //dimensions (y) of the room
        private int FPS; //rate a which the frames go
        private int Tsize; // tile size 
        private bool persistance; //yes/no whether or not the room is saved.
        private int viewx; //smaller portion of the room is visible
        private int viewy; //smaller portion of the room is visible
        private float scrollx; //how fast the view can adjust to the player's movement
        private float scrolly; //how fast the view can adjust to the player's movement

        public Color bcolor
        {
            get
            {
                return Bcolor;
            }
            set
            {
                Bcolor = value;
            }
        }

        public int width
        {
            get
            {
                return sizeWidth;
            }
            set
            {
                sizeWidth = value;
            }
        }

        public int height
        {
            get
            {
                return sizeHeight;
            }
            set
            {
                sizeHeight = value;
            }
        }

        public int fps
        {
            get
            {
                return FPS;
            }
            set
            {
                FPS = value;
            }
        }

        public int tileSize
        {
            get
            {
                return Tsize;
            }
            set
            {
                Tsize = value;
            }
        }

        public bool persistant
        {
            get
            {
                return persistance;
            }
            set
            {
                persistance = value;
            }
        }

        public int viewX
        {
            get
            {
                return viewx;
            }
            set
            {
                viewx = value;
            }
        }

        public int viewY
        {
            get
            {
                return viewy;
            }
            set
            {
                viewy = value;
            }
        }

        public float scrollX //this is capital
        {
            get
            {
                return scrollx;
            }
            set
            {
                scrollx = value;
            }
        }

        public float scrollY
        {
            get
            {
                return scrolly;
            }
            set
            {
                scrolly = value;
            }
        }

    }
}
