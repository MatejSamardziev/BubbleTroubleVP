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
        public int Radius { get; set; } = 30;

        public Hero(Point center)
        {
            Center = center;
            up = false; down = false;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Red);
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, Radius*2, Radius*2);
            b.Dispose();
        }


        public bool checkCollison(Circle circle)
        {

            //return Math.Pow(Center.X - circle.Center.X, 2) + Math.Pow(Center.Y - circle.Center.Y, 2) <= Radius * circle.Radius;
            //float distanceSquared = (Center.X - circle.Center.X) * (Center.X - circle.Center.X) +
            //(Center.Y - circle.Center.Y) * (Center.Y - circle.Center.Y);

            //float radiusSumSquared = (Radius + circle.Radius) * (Radius + circle.Radius);
            // float radiusSumSquared = (Radius ) * (circle.Radius);

            //return distanceSquared <= radiusSumSquared;*/
            /*float distanceSquared = (Center.X - circle.Center.X) * (Center.X - circle.Center.X) +
                             (Center.Y - circle.Center.Y) * (Center.Y - circle.Center.Y);

            float radiusSumSquared = (Radius + circle.Radius) * (Radius + circle.Radius);

            return distanceSquared <= radiusSumSquared;*/
            int distance = (int)Math.Sqrt(
                Math.Pow(Center.X - circle.Center.X, 2) +
                Math.Pow(Center.Y - circle.Center.Y, 2)
            );
            return distance <= Radius + circle.Radius;
        
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