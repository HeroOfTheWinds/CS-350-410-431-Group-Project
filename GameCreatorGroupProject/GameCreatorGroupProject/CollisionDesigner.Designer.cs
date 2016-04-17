using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace GameCreatorGroupProject
{
    partial class CollisionDesigner
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public static Image spr;
        private List<Tuple<Point, bool>> points = new List<Tuple<Point, bool>>();

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new CollisionPanel(ref points, ref spr);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 500);
            this.panel1.TabIndex = 0;
            this.panel1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.panel1_KeyPress);
            // 
            // CollisionDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.panel1);
            this.Name = "CollisionDesigner";
            this.Text = "CollisionDesigner";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CollisionDesigner_DragDrop);
            this.Resize += new System.EventHandler(this.CollisionDesigner_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CollisionPanel panel1;
    }

    public class CollisionPanel : Panel
    {
        private List<Tuple<Point, bool>> points;
        private Image spr;

        public CollisionPanel(ref List<Tuple<Point, bool>> points, ref Image spr)
        {
            this.points = points;
            this.spr = spr;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = CreateGraphics();
            g.DrawImage(spr, new Point(225, 225));

            if (points.Count != 0)
            {
                Point prev = points[points.Count - 1].Item1;
                
                for (int i = 0; i < points.Count; i++)
                {
                    Rectangle r = new Rectangle(points[i].Item1.X - 4, points[i].Item1.Y - 4, 10, 10);
                    g.DrawLine(new Pen(Color.Black, 3), points[i].Item1, prev);
                    if (points[i].Item2)
                    {
                        g.FillEllipse(new SolidBrush(Color.Blue), r);
                    }
                    else
                    {
                        g.FillEllipse(new SolidBrush(Color.Black), r);
                    }
                    prev = points[i].Item1;
                }

            }
            
        }
    }
}