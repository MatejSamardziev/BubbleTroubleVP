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

        public Scene(Hero hero)
        {
            this.hero = hero;
            lines = new List<Line>();
        }

        public void Draw(Graphics g)
        {
            hero.Draw(g);
            if(lines.Count!=0)
            {
                lines[0].Draw(g);
            }
        }

        public void AddLine(Line l)
        {
            lines.Add(l);
        }
        public void RemoveLine()
        {
            lines.RemoveAt(0);
        }
           
    }
}
