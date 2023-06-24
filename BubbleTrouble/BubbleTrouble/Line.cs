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
            p.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            p.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            p.DashPattern = new float[] { 2, 2, 2, 2 };

            g.DrawLine(p, A, B);
        }


        public bool HasLineHitCircle( Circle c)
        {
            // Calculate the squared length of the line segment
            int lineLengthSquared = (B.X - A.X) * (B.X - A.X) + (B.Y - A.Y) * (B.Y - A.Y);

            // Calculate the vector representing the line
            int lineVectorX = B.X - A.X;
            int lineVectorY = B.Y - A.Y;

            // Calculate the vector representing the distance between the circle center and the start of the line
            int circleToLineStartX = c.Center.X - A.X;
            int circleToLineStartY = c.Center.Y -A.Y;

            // Calculate the dot product between the line vector and the distance vector
            int dotProduct = lineVectorX * circleToLineStartX + lineVectorY * circleToLineStartY;

            // Calculate the parameter value of the closest point on the line to the circle center
            double t = (double)dotProduct / lineLengthSquared;

            // Find the closest point on the line to the circle center
            int closestPointX, closestPointY;

            if (t < 0)
            {
                closestPointX = A.X;
                closestPointY = A.Y;
            }
            else if (t > 1)
            {
                closestPointX = B.X;
                closestPointY = B.Y;
            }
            else
            {
                closestPointX = (int)(A.X + t * (B.X - A.X));
                closestPointY = (int)(A.Y + t * (B.Y - A.Y));
            }

            // Calculate the distance between the closest point on the line and the circle center
            int distanceSquared = (c.Center.X - closestPointX) * (c.Center.X - closestPointX) +
                                  (c.Center.Y - closestPointY) * (c.Center.Y - closestPointY);

            // Check if the distance is less than or equal to the radius squared
            return distanceSquared <= c.Radius * c.Radius;
        }

    }
}
