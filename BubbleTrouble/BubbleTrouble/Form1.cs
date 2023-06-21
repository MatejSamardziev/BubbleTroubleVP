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
            Invalidate();
            DoubleBuffered = true;
            timer1.Start();
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
            Invalidate();
        }
    }
}
