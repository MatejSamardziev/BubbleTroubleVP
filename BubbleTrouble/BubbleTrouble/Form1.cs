using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class Form1 : Form
    {
        public Scene scene { get; set; }
        public Form1()
        {
            InitializeComponent();
            Point p = new Point(this.Width / 2, this.Height-40);
            scene = new Scene(new Hero(p));
            
            DoubleBuffered = true;
            timer1.Start();
            RedCircleTimer.Start();
            Point p2 = new Point(150, 150);

            Circle c = new Circle(30,Color.Red,p2,this.Width,this.Height);
            scene.RedCircles.Add(c);
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);  
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                scene.hero.MoveLeft();
            }
            if (e.KeyCode == Keys.Right)
            {
                scene.hero.MoveRight();
            }
            Invalidate();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (scene.lines.Count>0)
            {
                scene.RemoveLine();
            }
            Point A = new Point(scene.hero.Center.X - 30, scene.hero.Center.Y);
            Point B = new Point(scene.hero.Center.X-30, scene.hero.Center.Y - 10);
            
            Line l = new Line(A,B);
            scene.AddLine(l);
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (scene.lines.Count != 0)
            {
                Line l=scene.lines.ElementAt(0);
                Point temp = l.B;
                temp.Y = temp.Y - 10;
                l.B = temp; 
            }

            if (scene.isHit())
            {
                RedCircleTimer.Stop();
                timer1.Stop();
                MessageBox.Show("Game over");

            }

            if (scene.lines.Count != 0)
            {
                Line l2 = scene.lines.ElementAt(0);
                if (l2.HasLineHitCircle(scene.RedCircles.ElementAt(0)))
                {
                    MessageBox.Show("Ja udri");
                }
            }
            
            




            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            foreach (Circle c in scene.RedCircles)
            {

                c.Move(Width, Height);

            }
           
            Invalidate();
        }
    }
}
