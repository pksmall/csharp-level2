using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.VisualObjects;

namespace AsteroidGame
{
    static class Game
    {
        // <summary>drawing timeout</summary>
        private const int __FrameTimeOut = 10;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        public static int Width { get; set; }

        public static int Height { get; set; }

        private static List<Bitmap> lisimage = new List<Bitmap>();

        //static Game()
        //{

        //}

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            form.BackgroundImage = Properties.Resources.im3;
            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));
            lisimage.Add(Properties.Resources.im1);
            lisimage.Add(Properties.Resources.im2);
            lisimage.Add(Properties.Resources.im3);

            var timer = new Timer { Interval = __FrameTimeOut };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;

        public static void Load()
        {
            var game_objects = new List<VisualObject>();
            var rnd = new Random();

            const int stars_count = 150;
            const int star_size = 5;
            const int star_max_speed = 20;
            for (var i = 0; i < stars_count; i++)
                game_objects.Add(new Star(
                    new Point(rnd.Next(0, Width),rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, star_max_speed), 0),
                    star_size));

            const int ellipses_count = 20;
            const int ellipses_size_x = 20;
            const int ellipses_size_y = 30;
            for (var i = 0; i < ellipses_count; i++)
                game_objects.Add(new EllipseObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(ellipses_size_x, ellipses_size_y)));

            const int asteroids_count = 10;
            const int asteroids_size = 25;
            const int asteroids_max_speed = 20;
            for (var i = 0; i < asteroids_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroids_max_speed), 0),
                    asteroids_size));

            /*Image image = Properties.Resources.Asteroid;
            var image_object = new ImageObject(new Point(0, 5), new Point(5, 6), new Size(70, 70), image);*/

            __GameObjects = game_objects.ToArray();
            __Bullet = new Bullet(200);
        }

        public static void Draw()
        {
            var g = __Buffer.Graphics;
            g.Clear(Color.Black);

            // change backgroup images 
            var indexbackimage = DateTime.Now.Second % lisimage.Count;
            var BackgroundImage = lisimage[indexbackimage];
            g.DrawImage(BackgroundImage, new Point(0, 0));

/*
 *          g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
 *          g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));
*/
            foreach (var visual_object in __GameObjects)
                visual_object.Draw(g);

            __Bullet.Draw(g);

            __Buffer.Render();
        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object.Update();

            __Bullet.Update();
            if (__Bullet.Position.X > Width)
            {
                __Bullet = new Bullet(300);
            }
        }
    }
}
