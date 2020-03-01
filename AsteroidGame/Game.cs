using AsteroidGame.VisualObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AsteroidGame.VisualObjects.Interfaces;
using AsteroidGame.Events;
using System.IO;

namespace AsteroidGame
{
    static class Game
    {
        // <summary>drawing timeout</summary>
        private const int __FrameTimeOut = 10;
        private const string _logFile = "debug.log";

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static Timer __Timer;

        public static int Width { get; set; }

        public static int Height { get; set; }

        private static List<Bitmap> lisimage = new List<Bitmap>();

        private const int asteroids_count = 25;
        private const int asteroids_size = 40;
        private const int asteroids_max_speed = 10;

        private const int medkit_count = 15;
        private const int medkit_size = 25;
        private const int medkit_max_speed = 5;

        //static Game()
        //{

        //}

        public static void Initialize(Form form)
        {

            Width = form.Width;
            Height = form.Height;

            const int max_width = 1000;
            const int max_height = 1000;
            const int min_width = 136;
            const int min_heigth = 39;
            try
            {
                if (Width > max_width || Width <= min_width || Height > max_height || Height <= min_heigth)
                {
                    throw new ArgumentOutOfRangeException($"Width and/or Height out of range. {Width}x{Height}");
                }
            }
            finally { }

            form.BackgroundImage = Properties.Resources.im3;
            __Context = BufferedGraphicsManager.Current;
            var g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));
            lisimage.Add(Properties.Resources.im1);
            lisimage.Add(Properties.Resources.im2);
            lisimage.Add(Properties.Resources.im3);

            //MessageBox.Show($"{Width} x {Height}", "WxH", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var timer = new Timer { Interval = __FrameTimeOut };
            timer.Tick += OnTimerTick;
            timer.Start();
            __Timer = timer;

            form.KeyDown += OnFormKeyDown;

        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    __Bullet = new Bullet(__Ship.Position.Y);
                    break;
                case Keys.Up:
                    __Ship.MoveUp();
                    break;
                case Keys.Down:
                    __Ship.MoveDown();
                    break;
            }
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        private static SpaceShip __Ship;

        /// <summary>
        /// Load main scene
        /// </summary>
        /// 
        public static void Load()
        {
            var game_objects = new List<VisualObject>();
            var rnd = new Random();


            // stars
            const int stars_count = 150;
            const int star_size = 5;
            const int star_max_speed = 20;
            for (var i = 0; i < stars_count; i++)
                game_objects.Add(new Star(
                    new Point(rnd.Next(0, Width),rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, star_max_speed), 0),
                    star_size));

            // asteroids
            for (var i = 0; i < asteroids_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(1, asteroids_max_speed), 0),
                    asteroids_size));

            // medkit
            for (var i = 0; i < medkit_count; i++)
                game_objects.Add(new Medkit(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(2, medkit_max_speed), 0),
                    medkit_size));

            /*Image image = Properties.Resources.Asteroid;
            var image_object = new ImageObject(new Point(0, 5), new Point(5, 6), new Size(70, 70), image);*/

            __GameObjects = game_objects.ToArray();
            __Bullet = new Bullet(200);
            __Ship = new SpaceShip(new Point(10, 400), new Point(5, 5), new Size(10, 10));
            __Ship.ShipDestroyed += OnShipDestroyed;
            __Ship.ShipOnState += OnShipOnState;
        }

        private static void OnShipOnState(object sender, StateEvents e)
        {
            Console.WriteLine(e.message);
            using (StreamWriter sw = new StreamWriter(_logFile, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(e.message);
            }
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();
            __Buffer.Graphics.Clear(Color.DarkBlue);
            __Buffer.Graphics.
                DrawString("Game Over!", 
                new Font(FontFamily.GenericSansSerif, 60, FontStyle.Bold), 
                Brushes.Red, 100,200);
            __Buffer.Render();
        }

        public static void Draw()
        {
            if (__Ship.Energy <= 0)
            {
                return;
            }
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
                visual_object?.Draw(g);

            __Ship.Draw(g);

            __Bullet?.Draw(g);

            g.DrawString($"Energy: {__Ship.Energy} Score: {__Ship.Score}",
                new Font(FontFamily.GenericSerif, 14, FontStyle.Italic),
                Brushes.White, 10, 10);
            __Buffer.Render();

        }

        public static void Update()
        {
            foreach (var visual_object in __GameObjects)
                visual_object?.Update();

            __Bullet?.Update();

            var rnd = new Random();
            for(var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];

                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    __Ship.CheckCollision(collision_object);

                    if (__Bullet != null && __Bullet.CheckCollision(collision_object))
                    {
                        //__Bullet = new Bullet(new Random().Next(Width));
                        __Bullet = null;
                        if (__GameObjects[i] is Asteroid)
                        {
                            __GameObjects[i] = new Asteroid(
                                                   new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                                                   new Point(-rnd.Next(1, asteroids_max_speed), 0),
                                                   asteroids_size);
                            __Ship.Score++;

                        }
                        else
                        {
                            __GameObjects[i] = null;
                            __Ship.Score--;
                        }

                        //MessageBox.Show("Astroid has been destroyed.", "Collision", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
