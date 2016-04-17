using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    public partial class CollisionDesigner : Form
    {
        

        public CollisionDesigner()
        {
            InitializeComponent();
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            bool mod = false;
            
            for (int i = 0; i < points.Count; i++)
            {
                Rectangle r = new Rectangle(points[i].Item1.X - 5, points[i].Item1.Y - 5, 14, 14);
                if (r.Contains(PointToClient(Cursor.Position)))
                {
                    points[i] = new Tuple<Point, bool>(points[i].Item1, !points[i].Item2);
                    mod = true;
                    break;
                }
            }

            if (!mod)
            {
                Point p = PointToClient(Cursor.Position);
                points.Add(new Tuple<Point, bool>(p, false));
            }
            
            panel1.Invalidate();
        }

        private void CollisionDesigner_DragDrop(object sender, DragEventArgs e)
        {
            panel1.Invalidate();
        }

        private void CollisionDesigner_Resize(object sender, EventArgs e)
        {
        }

        private void panel1_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].Item2)
                    {
                        points.Remove(points[i]);
                        i--;
                    }
                }
            }
            panel1.Invalidate();
        }
    }
}
