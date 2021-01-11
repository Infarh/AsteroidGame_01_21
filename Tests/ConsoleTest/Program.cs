using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2DClass v1 = new Vector2DClass(5, 7);
            //v1.X = 5;
            //v1.Y = 7;

            Vector2DClass v2 = new Vector2DClass(10, 15);
            //v2.X = 10;
            //v2.Y = 15;

            v2 = new Vector2DClass();
            //v2.X = 33;
            //v2.Y = 55;

            Console.WriteLine("Вектор x:{0} y:{1}", v1.X, v1.Y);
        }
    }

    public class Vector2DClass
    {
        static Vector2DClass()
        {
            Unit = new Vector2DClass(1, 1);
            Zero = new Vector2DClass(0, 0);
        }

        public static readonly Vector2DClass Unit;
        public static readonly Vector2DClass Zero;

        //protected
        //internal
        //internal protected 
        private double X;
        private double Y;

        public Vector2DClass() { }

        public Vector2DClass(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
