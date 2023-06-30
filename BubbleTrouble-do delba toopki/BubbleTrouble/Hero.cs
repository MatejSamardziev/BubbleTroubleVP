using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public class Hero
    {
        public Point Center { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public int Radius { get; set; } = 30;

        int CharSelector { get; set; } = 0;

        public Image CharacterImage { get; set; }

        private Image[] frames;
        private int currentFrameIndex;
        private Timer animationTimer;

        public Hero(Point center,int CharSelector)
        {
            Center = center;

            up = false;
            down = false;
            this.CharSelector = CharSelector;
            if(CharSelector == 0)
            {
                CharacterImage = Properties.Resources.alex_walk;
            }

            else if(CharSelector == 1)
            {
                CharacterImage = Properties.Resources.Zombie;
            }
            else if (CharSelector == 2)
            {
                CharacterImage = Properties.Resources.Darwin;
            }
            else if (CharSelector == 3)
            {
                CharacterImage = Properties.Resources.Edd;
            }
            else if (CharSelector == 4)
            {
                CharacterImage = Properties.Resources.JakeTheDog;
            }

            else if (CharSelector == 5)
            {
                CharacterImage = Properties.Resources.Turtacus;
            }
            else if(CharSelector == 6)
            {
                CharacterImage = Properties.Resources.Squidward;
            }
            
            
            LoadFrames();
            InitializeAnimation();
        }

        private void LoadFrames()
        {
            frames = GetFrames(CharacterImage);
        }

        private void InitializeAnimation()
        {
            currentFrameIndex = 0;

            animationTimer = new Timer();
            animationTimer.Interval = 100; // Adjust the interval based on your desired animation speed
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            currentFrameIndex = (currentFrameIndex + 1) % frames.Length;
        }

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Red);

            g.DrawImage(frames[currentFrameIndex], Center.X - Radius, Center.Y - Radius, Radius * 2, Radius * 2);

            b.Dispose();
        }

        public bool checkCollison(Circle circle)
        {
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
                Center = new Point(Center.X - 10, Center.Y);
                down = false;
            }
        }

        public void MoveRight()
        {
            if (down == false)
            {
                Center = new Point(Center.X + 10, Center.Y);
                up = false;
            }
        }

        public void outofbounds(int width)
        {
            if (Center.X - Radius < 5)
                up = true;
            else if (Center.X + Radius > width)
                down = true;
        }

        private static Image[] GetFrames(Image image)
        {
            List<Image> frames = new List<Image>();

            // Extract the frames from the GIF image
            FrameDimension dimension = new FrameDimension(image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);

            for (int i = 0; i < frameCount; i++)
            {
                image.SelectActiveFrame(dimension, i);
                frames.Add((Image)image.Clone());
            }

            return frames.ToArray();
        }
    }
}