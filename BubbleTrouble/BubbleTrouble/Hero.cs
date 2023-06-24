using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Hero
    {
        public Point Center { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public int Radius { get; set; } = 60;

        public Hero(Point center)
        {
            Center = center;
            up = false; down = false;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Red);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, Radius, Radius);
            b.Dispose();
        }

        public void MoveLeft()
        {
            if (up == false)
            {
                Center = new Point(Center.X - 4, Center.Y);
                down = false;
            }
        }
        public void MoveRight()
        {
            if (down == false)
            {
                Center = new Point(Center.X + 4, Center.Y);
                up = false;
            }
        }
        public void outofBounds(int width)
        {
            if (Center.X - Radius < 5)
                up = true;
            else if (Center.X + Radius > width + 30)
                down = true;
        }
    }
}