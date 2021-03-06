﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame.VisualObjects
{
    internal class Asteroid : ImageObject, ICollision
    {
        private static readonly Image __Image = Image.FromFile("Images/Asteroid.png");

        //public Asteroid(Point Position, Point Direction, int Size)
        //    : base(Position, Direction, new Size(Size, Size), __Image)
        //{ 
        //}

        public int Power { get; set; } = 3;

        public Asteroid(Point Position, Point Direction, int Size)
            : base(Position, Direction, new Size(Size, Size), Properties.Resources.Asteroid)
        {
        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
    }
}
