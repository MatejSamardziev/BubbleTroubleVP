using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Line
    {
        public Point A { get; set; }
        public Point B { get; set; }

        public Line(Point a, Point b)
        {
            A = a;
            B = b;
        }

        public void Draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 3);
            p.DashPattern = new float[] { 2, 2, 2, 2 };
            g.DrawLine(p, A, B);
            p.Dispose();
        }
    }
}
