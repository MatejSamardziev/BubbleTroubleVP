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
        public static Random random = new Random();
        public int Level = 1;
        public int Countdown = 3;
        int Screenflag = 0;
        public int brojac = 0;
        public int purple = 1;
        public int red = 3;
        public int blue = 1;
        public int red2 = 2;
        public int blue2 = 2;
        public int purple2 = 2;
        public int red3 = 5;
        int CharSelector = 0;
        public Form1(int charSelector)
        {
            InitializeComponent();
            CharSelector = charSelector;
            Point p = new Point(this.Width / 2, this.Height - 70);
            scene = new Scene(new Hero(p, charSelector));
            label1.Text = "Level :1";
            DoubleBuffered = true;
            timer1.Start();
            brojac = 0;
            red = 3;
            blue = 2;
            purple = 1;
            red2 = 2;
            blue2 = 2;
            purple2 = 2;
            red3 = 5;
            RedCircleTimer.Start();
            Start(Level);
            Invalidate();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
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
            if (scene.lines.Count > 0)
            {
                scene.RemoveLine();
            }
            Point A = new Point(scene.hero.Center.X - 30, scene.hero.Center.Y);
            Point B = new Point(scene.hero.Center.X - 30, scene.hero.Center.Y - 10);

            Line l = new Line(A, B);
            scene.AddLine(l);
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //scene.HasLineHitCircle();
            if (scene.lines.Count != 0)
            {
                brojac++;
                Line l = scene.lines.ElementAt(0);
                Point temp = l.B;
                temp.Y = temp.Y - 10;
                l.B = temp;
                /*if (l.CalculateDistance() > this.Height-200)
                {
                    scene.lines.Remove(l);
                }*/
                // MessageBox.Show(l.B.Y.ToString());
                if (l.B.Y <= 0)
                {
                    scene.lines.Remove(l);
                }
            }


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

                DialogResult dg = MessageBox.Show("Game Over", "Back to Menu?", MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    MenuForm menu = new MenuForm();
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    Application.Exit();
                }

            }

            if (scene.YellowCircles.Count == 0 && scene.RedCircles.Count == 0 && scene.BlueCircles.Count == 0 && scene.PurpleCircles.Count == 0)
            {

                newLeveltimer.Start();
                RedCircleTimer.Stop();
                timer1.Stop();

            }


            foreach (Circle c in scene.RedCircles)
            {

                c.Move(Width, Height);

            }
            foreach (Circle c in scene.YellowCircles)
            {
                c.Move(Width, Height);
            }
            foreach (Circle c in scene.BlueCircles)
            {
                c.Move(Width, Height);
            }
            foreach (Circle c in scene.PurpleCircles)
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
                Point p2 = new Point(150, 150);
                int Distance = random.Next(2);
                Circle c = new Circle(30, Color.Red, p2, this.Width, this.Height, Distance);
                scene.RedCircles.Add(c);
            }
            if (lvl == 2)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p2 = new Point(this.Width - 30, this.Height - 50);
                Point p3 = new Point(this.Width + 30, this.Height - 50);
                Circle c = new Circle(30, Color.Red, p2, this.Width, this.Height, 0);
                Circle c2 = new Circle(30, Color.Red, p3, this.Width, this.Height, 1);
                scene.RedCircles.Add(c);
                scene.RedCircles.Add(c2);
            }
            if (lvl == 3)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p = new Point(this.Width, this.Height - 50);
                Circle c = new Circle(45, Color.Blue, p, this.Width, this.Height, 0);
                scene.BlueCircles.Add(c);

            }
            if (lvl == 4)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p2 = new Point(this.Width - 30, this.Height - 50);
                Point p3 = new Point(this.Width + 30, this.Height - 50);
                Circle c = new Circle(45, Color.Blue, p2, this.Width, this.Height, 0);
                Circle c2 = new Circle(30, Color.Red, p3, this.Width, this.Height, 1);
                scene.BlueCircles.Add(c);
                scene.RedCircles.Add(c2);
            }
            if (lvl == 5)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p2 = new Point(this.Width / 2, this.Height / 2);
                Circle c2 = new Circle(60, Color.Purple, p2, this.Width, this.Height, 0);
                scene.PurpleCircles.Add(c2);
            }
            if (lvl == 6)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p2 = new Point(this.Width - 90, this.Height - 50);
                Point p3 = new Point(this.Width + 60, this.Height - 50);
                Point p = new Point(this.Width / 2, this.Height / 2);
                Circle c = new Circle(45, Color.Blue, p2, this.Width, this.Height, 0);
                Circle c2 = new Circle(45, Color.Blue, p3, this.Width, this.Height, 1);
                Circle c3 = new Circle(30, Color.Red, p, this.Width, this.Height, 0);
                scene.BlueCircles.Add(c);
                scene.BlueCircles.Add(c2);
                scene.RedCircles.Add(c3);

            }
            if (lvl == 7)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p4 = new Point(this.Width / 2 - 70, this.Height - 200);
                Point p = new Point(this.Width / 2 - 50, this.Height - 200);
                Point p2 = new Point(this.Width / 2 - 30, this.Height - 200);
                Point p3 = new Point(this.Width / 2, this.Height - 200);
                Circle c = new Circle(30, Color.Red, p2, this.Width, this.Height, 0);
                Circle c2 = new Circle(30, Color.Red, p3, this.Width, this.Height, 1);
                Circle c3 = new Circle(30, Color.Red, p, this.Width, this.Height, 2);
                Circle c4 = new Circle(30, Color.Red, p4, this.Width, this.Height, 3);
                scene.RedCircles.Add(c);
                scene.RedCircles.Add(c2);
                scene.RedCircles.Add(c3);
                scene.RedCircles.Add(c4);

            }
            if (lvl == 8)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p2 = new Point(this.Width / 2, this.Height / 2);
                Circle c2 = new Circle(60, Color.Purple, p2, this.Width, this.Height, 0);
                scene.PurpleCircles.Add(c2);
                Point p4 = new Point(this.Width / 2 - 70, this.Height - 200);
                Point p = new Point(this.Width / 2 - 50, this.Height - 200);
                Circle c3 = new Circle(30, Color.Red, p, this.Width, this.Height, 2);
                Circle c4 = new Circle(30, Color.Red, p4, this.Width, this.Height, 3);
                scene.RedCircles.Add(c3);
                scene.RedCircles.Add(c4);


            }
            if (lvl == 9)
            {
                RedCircleTimer.Start();
                timer1.Start();
                // Point p4 = new Point(this.Width / 2 - 70, this.Height - 200);
                Point p = new Point(this.Width / 2 - 50, this.Height - 200);
                Point p2 = new Point(this.Width / 2 - 30, this.Height - 200);
                Point p3 = new Point(this.Width / 2, this.Height - 200);
                Circle c = new Circle(45, Color.Blue, p2, this.Width, this.Height, 0);
                Circle c2 = new Circle(45, Color.Blue, p3, this.Width, this.Height, 1);
                Circle c3 = new Circle(45, Color.Blue, p, this.Width, this.Height, 2);
                //  Circle c4 = new Circle(30, Color.Red, p4, this.Width, this.Height, 3);
                scene.BlueCircles.Add(c);
                scene.BlueCircles.Add(c2);
                scene.BlueCircles.Add(c3);
                //scene.RedCircles.Add(c4);
            }
            if (lvl == 10)
            {
                RedCircleTimer.Start();
                timer1.Start();
                Point p2 = new Point(this.Width / 2, this.Height - 400);
                Point p = new Point(this.Width / 2 - 50, this.Height - 400);
                Circle c2 = new Circle(60, Color.Purple, p2, this.Width, this.Height, 0);
                Circle c = new Circle(45, Color.Blue, p, this.Width, this.Height, 1);
                scene.PurpleCircles.Add(c2);
                scene.BlueCircles.Add(c);

            }
            if (lvl > 10)
            {
                if (prost(lvl))
                {
                    RedCircleTimer.Start();
                    timer1.Start();
                    int A = this.Width - 90;
                    int B = this.Height / 2 - 40;
                    int C = this.Width / 2;
                    int D = this.Height / 2 - 40;
                    int br = 0;
                    int br2 = 0;
                    for (int i = 0; i < red; i++)
                    {
                        // int br = random.Next(4);
                        //Circle c = new Circle(30, Color.Red, new Point(A-10,B), this.Width, this.Height, br);
                        A = A - 30;
                        scene.RedCircles.Add(new Circle(30, Color.Red, new Point(A, B), this.Width, this.Height, br));
                        if (br == 3)
                        {
                            br = 0;
                        }
                        else
                        {
                            br++;
                        }
                    }
                    for (int i = 0; i < blue; i++)
                    {
                        // int br = random.Next(4);
                        C = C - 30;
                        D = D - 10;
                        Circle c2 = new Circle(45, Color.Blue, new Point(C, D), this.Width, this.Height, br2);
                        scene.BlueCircles.Add(c2);
                        if (br2 == 3)
                        {
                            br2 = 0;
                        }
                        else
                        {
                            br2++;
                        }
                    }
                    red++;
                    blue++;
                }
                else if (lvl % 2 == 0)
                {
                    RedCircleTimer.Start();
                    timer1.Start();
                    int br = 0;
                    int br2 = 0;
                    int A = this.Width - 90;
                    int B = this.Height / 2;
                    int C = this.Width / 2;
                    int D = this.Height / 2;
                    for (int i = 0; i < blue2; i++)
                    {
                        //int br = random.Next(4);
                        //Circle c = new Circle(30, Color.Red, new Point(A-10,B), this.Width, this.Height, br);
                        A = A - 30;
                        scene.BlueCircles.Add(new Circle(45, Color.Blue, new Point(A, B), this.Width, this.Height, br));
                        if (br == 3)
                        {
                            br = 0;
                        }
                        else
                        {
                            br++;
                        }

                    }
                    for (int i = 0; i < purple; i++)
                    {
                        // int br = random.Next(4);
                        C = C - 30;
                        D = D - 10;
                        Circle c2 = new Circle(60, Color.Purple, new Point(C, D), this.Width, this.Height, br2);
                        scene.PurpleCircles.Add(c2);
                        if (br2 == 3)
                        {
                            br2 = 0;
                        }
                        else
                        {
                            br2++;
                        }

                    }
                    purple++;
                    blue2++;

                }
                else if (lvl % 3 == 0)
                {
                    RedCircleTimer.Start();
                    timer1.Start();
                    int br = 0;
                    int br2 = 0;
                    int A = this.Width - 30;
                    int B = this.Height - 300;
                    int C = this.Width - 60;
                    int D = this.Height / 2;
                    for (int i = 0; i < red2; i++)
                    {
                        // br = random.Next(4);
                        //Circle c = new Circle(30, Color.Red, new Point(A-10,B), this.Width, this.Height, br);
                        A = A - 30;
                        scene.RedCircles.Add(new Circle(30, Color.Red, new Point(A, B), this.Width, this.Height, br));
                        if (br == 3)
                        {
                            br = 0;
                        }
                        else
                        {
                            br++;
                        }
                    }
                    for (int i = 0; i < purple2; i++)
                    {
                        // br = random.Next(4);
                        C = C - 60;
                        D = D - 30;
                        Circle c2 = new Circle(60, Color.Purple, new Point(C, D), this.Width, this.Height, br2);
                        scene.PurpleCircles.Add(c2);
                        if (br2 == 3)
                        {
                            br2 = 0;
                        }
                        else
                        {
                            br2++;
                        }
                    }
                    red2++;
                    purple2++;
                }
                else
                {
                    RedCircleTimer.Start();
                    timer1.Start();
                    int br = 0;
                    int A = this.Width / 2;
                    int B = this.Height - 300;

                    for (int i = 0; i < red3; i++)
                    {
                        // br = random.Next(4);
                        //Circle c = new Circle(30, Color.Red, new Point(A-10,B), this.Width, this.Height, br);
                        A = A - 30;
                        scene.RedCircles.Add(new Circle(30, Color.Red, new Point(A, B), this.Width, this.Height, br));
                        if (br == 3)
                        {
                            br = 0;
                        }
                        else
                        {
                            br++;
                        }
                    }
                    red3++;
                }
            }
        }
        public bool prost(int broj)
        {
            int brojac = 1;
            if (broj == 2 || broj == 3 || broj == 5 || broj == 7)
            {
                return true;
            }
            for (int i = 2; i < broj; i++)
            {
                if (broj % i == 0)
                {
                    brojac++;
                }
            }
            return brojac == 1;


        }

        private void newLeveltimer_Tick(object sender, EventArgs e)
        {


            lblSeconds.Text = Countdown.ToString();
            Countdown--;

            if (Countdown < 0)
            {
                lblSeconds.Text = "";
                newLeveltimer.Stop();
                Level++;
                label1.Text = "Level: " + Level;
                Countdown = 3;
                Start(Level);

            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (Screenflag == 0)
            {
                Screenflag = 1;
                return;
            }
            scene.hero.Center = new Point(this.Width / 2, this.Height - 70);
            //height = Height - 200;
            RedCircleTimer.Interval = 5;
            label1.Location = new Point(2, this.Height - 100);
            lblSeconds.Location = new Point(this.Width / 2, 100);
            this.DoubleBuffered = true;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {


        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
