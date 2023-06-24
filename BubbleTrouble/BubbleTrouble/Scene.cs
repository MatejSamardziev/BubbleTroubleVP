using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    public class Scene
    {
        public Hero hero { get; set; }

        public List<Line> lines { get; set; }//samo edna linija ke ima ama koga ke ja snima da ja izbrisham

        public List<Circle> RedCircles { get; set; }
        public Scene(Hero hero)
        {
            this.hero = hero;
            lines = new List<Line>();
            RedCircles = new List<Circle>();
        }

        public void Draw(Graphics g)
        {
            hero.Draw(g);
            if(lines.Count!=0)
            {
                lines[0].Draw(g);
            }

            foreach(Circle c in RedCircles)
            {
                c.Draw(g);
            }
        }

        public void AddRedCircle(Circle c)
        {
            RedCircles.Add(c);
        }

        public void AddLine(Line l)
        {
            lines.Add(l);
        }
        public void RemoveLine()
        {
            lines.RemoveAt(0);
        }

        public bool isHit()
        {
            foreach(Circle c in RedCircles)
            {
                if (c.isHit(hero))
                {
                    return true;
                    break;
                }
            }
            return false;

        }

        public void outofbounds(int width)
        {
            hero.outofBounds(width);
        }

    }
}
