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

        public int Radius { get; set; } = 60;

        public Hero(Point center)
        {
            Center = center;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Red);
            g.FillEllipse(b,Center.X - Radius, Center.Y - Radius, Radius , Radius );
            b.Dispose();
        }

        public void MoveLeft()
        {
            Center=new Point(Center.X-4,Center.Y);
        }
        public void MoveRight()
        {
            Center = new Point(Center.X + 4, Center.Y);
        }
    }
}
