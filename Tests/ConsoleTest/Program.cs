using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vector2DClass unit = Vector2DClass.Unit;
            //Vector2DClass zero = Vector2DClass.Zero;

            Vector2DClass v1 = new Vector2DClass(5, 7);
            //v1.X = 5;
            //v1.Y = 7;

            Vector2DClass v2 = new Vector2DClass(10, 15);
            //v2.X = 10;
            //v2.Y = 15;

            v2 = new Vector2DClass();
            //v2.X = 33;
            //v2.Y = 55;

            v1.SetX(10);
            v1.Y = 15;

            Console.WriteLine("Вектор x:{0} y:{1}", v1.GetX(), v1.Y);
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
        private double _X;

        public double GetX()
        {
            return _X;
        }

        public void SetX(double value)
        {
            _X = value;
        }

        private double _Y;

        public double Y
        {
            get
            {
                return _Y;
            }
            set
            {
                _Y = value;
            }
        }

        public Vector2DClass() { }

        public Vector2DClass(double X, double Y)
        {
            _X = X;
            _Y = Y;
        }
    }
}
