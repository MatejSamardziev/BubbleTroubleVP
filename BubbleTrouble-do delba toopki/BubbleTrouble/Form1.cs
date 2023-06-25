using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class Form1 : Form
    {
        public Scene scene { get; set; }
        public static Random Random = new Random();
        public Form1()
        {
            InitializeComponent();
            Point p = new Point(this.Width / 2, this.Height-70);
            scene = new Scene(new Hero(p));
            
            DoubleBuffered = true;
            timer1.Start();
            RedCircleTimer.Start();
            Point p2 = new Point(150, 150);
            int Distance=Random.Next(2);
            Circle c = new Circle(30,Color.Red,p2,this.Width,this.Height,Distance);
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
            //scene.HasLineHitCircle();
            if (scene.lines.Count != 0)
            {
                Line l=scene.lines.ElementAt(0);
                Point temp = l.B;
                temp.Y = temp.Y - 10;
                l.B = temp;
                if (l.CalculateDistance() > 200)
                {
                    scene.lines.Remove(l);
                }
            }

            /*if (scene.isHit())
            {
                RedCircleTimer.Stop();
                timer1.Stop();
                MessageBox.Show("Game over");

            }*/

            /* if (scene.lines.Count != 0)
             {
                 Line l2 = scene.lines.ElementAt(0);
                 if (l2.HasLineHitCircle(scene.RedCircles.ElementAt(0)))
                 {
                    // MessageBox.Show("Ja udri");

                 }
             }*/
           
            scene.outofbounds(Width);
            
            




            Invalidate();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            scene.HasLineHitCircle();
            if (scene.isHit())
            {
                RedCircleTimer.Stop();
                timer1.Stop();
                MessageBox.Show("Game over");

            }
            

            foreach (Circle c in scene.RedCircles)
            {

                c.Move(Width, Height);

            }
            foreach(Circle c in scene.YellowCircles)
            {
                c.Move(Width, Height);
            }
           
            Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Start(int lvl)
        {
            if (lvl == 1)
            {

            }
        }
    }
}
