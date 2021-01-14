using System;

namespace ConsoleTest
{
    struct Vector2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public double Length => Math.Sqrt(X * X + Y * Y);

        //public Vector2D()
        //{

        //}

        public Vector2D(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}