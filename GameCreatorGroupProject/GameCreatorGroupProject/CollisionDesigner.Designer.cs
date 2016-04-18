using OpenTK;
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
        //private CollisionPanel panel1;
        private Panel panel1;
        private Button button1;

        public static Image spr;
        public static Vector2[] offsets;
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
            this.button1 = new Button();
            this.SuspendLayout();
            
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(425, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            
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
            this.KeyPreview = true;
            // 
            // CollisionDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.panel1);
            this.panel1.Controls.Add(this.button1);
            this.Name = "CollisionDesigner";
            this.Text = "CollisionDesigner";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CollisionDesigner_DragDrop);
            this.Resize += new System.EventHandler(this.CollisionDesigner_Resize);
            this.FormClosing += new FormClosingEventHandler(CollisionDesigner_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


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