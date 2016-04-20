using OpenTK;
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
        private bool saved = false;

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

        private void CollisionDesigner_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult d = MessageBox.Show("Would you like to close the designer?\nCurrent design will be lost.", "", MessageBoxButtons.YesNo);
                if (d == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (points.Count > 2)
            {
                offsets = new Vector2[points.Count - 1];
                for (int i = 1; i < points.Count; i++)
                {
                    offsets[i - 1] = new Vector2(points[i].Item1.X - points[0].Item1.X, points[i].Item1.Y - points[0].Item1.Y);
                }
                saved = true;
                Close();
            }
            else
            {
                DialogResult d = MessageBox.Show("Collision objects must have at least 3 points.\nWould you like to continue?", "Invalid design", MessageBoxButtons.YesNo);
                if (d == DialogResult.No)
                {
                    Close();
                }
            }
        }
    }
}
