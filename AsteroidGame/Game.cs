﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteroidGame
{
    static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static void Initialize(Form GameForm)
        {
            Width = GameForm.Width;
            Height = GameForm.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = GameForm.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 100 };
            //timer.Interval = 100;
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Load()
        {
            const int visual_objects_count = 30;
            __GameObjects = new VisualObject[visual_objects_count];

            for (var i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new VisualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }

            for (var i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new Star(
                    new Point(600, (int)(i / 2.0 * 20)),
                    new Point( - i, 0),
                    10);
            }
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;

            g.Clear(Color.Black);

            //g.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 100, 200, 200));

            foreach (var game_object in __GameObjects)
                game_object.Draw(g);


            __Buffer.Render();
        }

        private static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.Update();
        }
    }
}