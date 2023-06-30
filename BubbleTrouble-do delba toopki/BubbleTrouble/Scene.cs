using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public List<Circle> YellowCircles { get; set; }

        public List<Circle> BlueCircles { get; set; }
        public List<Circle> PurpleCircles { get; set; }
        public Scene(Hero hero)
        {
            this.hero = hero;
            lines = new List<Line>();
            RedCircles = new List<Circle>();
            YellowCircles = new List<Circle>();
            BlueCircles = new List<Circle>();
            PurpleCircles = new List<Circle>();
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

            foreach(Circle c in YellowCircles){
                c.Draw(g);
            }

            foreach (Circle c in BlueCircles)
            {
                c.Draw(g);
            }
            foreach (Circle c in PurpleCircles)
            {
                c.Draw(g);
            }

        }

        public void AddRedCircle(Circle c)
        {
            RedCircles.Add(c);
        }

        public void AddBlueCircle(Circle c)
        {
            BlueCircles.Add(c);
        }

        public void AddYellowCircle(Circle c)
        {
            YellowCircles.Add(c);
        }
        public void AddPurpleCircle(Circle c)
        {
            PurpleCircles.Add(c);
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
            foreach(Circle c in BlueCircles)
            {
                if (hero.checkCollison(c))
                {
                    return true;
                }
            }
            foreach (Circle c in PurpleCircles)
            {
                if (hero.checkCollison(c))
                {
                    return true;
                }
            }

            foreach (Circle c in RedCircles)
            {
                if (hero.checkCollison(c))
                {
                    return true;
                    
                }
            }
            foreach(Circle c in YellowCircles)
            {
                if (hero.checkCollison(c))
                {
                    return true;
                }
            }
            return false;

        }
        public void outofbounds(int width)
        {
            hero.outofbounds(width);
        }

        public void HasLineHitCircle()
        {
            if (lines.Count != 0)
            {
                Line l2 = lines.ElementAt(0);
                for (int i = 0; i < PurpleCircles.Count; i++)
                {
                    if (l2.HasLineHitCircle(PurpleCircles[i]))
                    {

                        if (lines.Count == 0)
                        {
                            break;
                        }

                        BlueCircles.Add(new Circle(45, Color.Blue, PurpleCircles[i].Center, PurpleCircles[i].width, PurpleCircles[i].height, 0));
                        BlueCircles.Add(new Circle(45, Color.Blue, PurpleCircles[i].Center, PurpleCircles[i].width, PurpleCircles[i].height, 1));

                        PurpleCircles.RemoveAt(i);
                        lines.RemoveAt(0);





                    }
                }

                for (int i = 0; i < BlueCircles.Count; i++)
                {
                    if (l2.HasLineHitCircle(BlueCircles[i]))
                    {

                        if (lines.Count == 0)
                        {
                            break;
                        }
                        
                        RedCircles.Add(new Circle(30, Color.Red, BlueCircles[i].Center, BlueCircles[i].width, BlueCircles[i].height, 0));
                        RedCircles.Add(new Circle(30, Color.Red, BlueCircles[i].Center, BlueCircles[i].width, BlueCircles[i].height, 1));
                        
                        BlueCircles.RemoveAt(i);
                        lines.RemoveAt(0);





                    }
                }


                for (int i = 0; i < RedCircles.Count; i++)
                {
                    if (l2.HasLineHitCircle(RedCircles[i]))
                    {

                        if (lines.Count == 0)
                        {
                            break;
                        }
                        // MessageBox.Show("Ja udri");
                        //RedCircles.Add(new Circle(RedCircles[i].Radius - 15, RedCircles[i].Color, RedCircles[i].Center, RedCircles[i].width, RedCircles[i].height, 0));
                        //RedCircles.Add(new Circle(RedCircles[i].Radius - 15, RedCircles[i].Color, RedCircles[i].Center, RedCircles[i].width, RedCircles[i].height, 1));
                        YellowCircles.Add(new Circle(RedCircles[i].Radius - 15, Color.Yellow, RedCircles[i].Center, RedCircles[i].width, RedCircles[i].height, 0));
                            YellowCircles.Add(new Circle(RedCircles[i].Radius - 15, Color.Yellow, RedCircles[i].Center, RedCircles[i].width, RedCircles[i].height, 1));
                            RedCircles.RemoveAt(i);
                            lines.RemoveAt(0);
                            
                        
                        
                        

                    }
                }

                for(int i=0;i<YellowCircles.Count; i++)
                {
                    if (l2.HasLineHitCircle(YellowCircles[i]))
                    {

                        if (lines.Count == 0)
                        {
                            break;
                        }
                        YellowCircles.RemoveAt(i);
                        lines.RemoveAt(0);

                        
                    }
                }

                //lines.RemoveAt(0);
            }

            //  lines.Clear();  
        }

    }
}
