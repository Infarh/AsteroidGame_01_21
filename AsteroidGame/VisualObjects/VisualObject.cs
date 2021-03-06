﻿using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    internal abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        public bool Enabled { get; set; } = true;

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);

        public virtual void Update()
        {
            if(!Enabled) return;

            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if (_Position.X < 0)
                _Direction.X *= -1;
            if (_Position.Y < 0)
                _Direction.Y *= -1;

            if (_Position.X > Game.Width/* + _Size.Width*/)
                _Direction.X *= -1;
            if (_Position.Y > Game.Height/* + _Size.Height*/)
                _Direction.Y *= -1;
        }
    }
}
