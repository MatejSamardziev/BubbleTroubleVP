using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
     public class Circle
    {
        public int Radius { get; set; }
        public Color Color { get; set; }
       
        public Point Center { get; set; }

        public Random Random { get; set; }

        public int width { get; set; }
        public int height { get; set; }

        public int Direction { get; set; }//0=down-left, 1=down-right, 2==top-left 3=top-right

        public Circle(int radius, Color color, Point center,int width,int height,int Direction)
        {
            Radius = radius;
            Color = color;
            Center = center;
            Random = new Random();
            //Direction = Random.Next(2);
            this.Direction = Direction;
            this.width = width;
            this.height = height;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            Pen p = new Pen(Color.Black);
            
            g.FillEllipse(b, Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);
            g.DrawLine(p, Center.X, Center.Y, Center.X + 1, Center.Y + 1);
            b.Dispose();
            p.Dispose();
        }

        public bool isHit(Hero hero)
        {
            double distance = Math.Sqrt(Math.Pow(Center.X - hero.Center.X, 2) + Math.Pow(Center.Y - hero.Center.Y, 2));
            double sumRadii = Radius + hero.Radius;
            return distance <= sumRadii;
        }


        public void Move(int width, int height)
        {
            
            
            if (Center.Y <= height/2-60)
            {
                if (Direction == 2)
                {
                    Direction = 0;
                }
                else if (Direction == 3)
                {
                    Direction = 1;
                }
            }
            else if (Center.Y >= height - Radius-30)
            {
                if (Direction == 1)
                    Direction = 3;

                else if (Direction == 0)
                    Direction = 2;

            }


            //ako se udri vo desniot zid
            else if (Center.X >= width - Radius)
            {
                if (Direction == 3)
                    Direction = 2;

                else if (Direction == 1)
                    Direction = 0;

                
            }


            //ako se udri vo leviot zid
            else if (Center.X <= Radius)
            {
                if (Direction == 0)
                    Direction = 1;

                else if (Direction == 2)
                    Direction = 3;
                
            }

            

            //move up left
             if (Direction == 2)
            {
                Center = new Point(Center.X - 2, Center.Y - 2);
            }

            //move up right
            else if (Direction == 3)
            {
                Center = new Point(Center.X + 2, Center.Y - 2);
            }

            //move down right
            else if (Direction == 1)
            {
                Center = new Point(Center.X + 2, Center.Y + 2);
            }

            //move down left
            else if (Direction == 0)
            {
                Center = new Point(Center.X - 2, Center.Y + 2);
            }

        }



    }
}
