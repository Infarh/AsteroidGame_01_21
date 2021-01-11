using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p = new Player("Иван", "Иванов");

            //Vector2DClass unit = Vector2DClass.Unit;
            //Vector2DClass zero = Vector2DClass.Zero;

            Vector2DClass v1 = new Vector2DClass(5, 7);
            //v1.X = 5;
            //v1.Y = 7;

            Vector2DClass v2 = new Vector2DClass(10, 15);
            //v2.X = 10;
            //v2.Y = 15;

            Vector2DClass v3 = v1 + v2;
            Vector2DClass v4 = 5 * v1 ;

            if (v3 == v4)
            {
                ///
            }

            //double length = v4;
            //int length_int = (int) v4;


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

        public double GetX() => _X;
        //{
        //    return _X;
        //}

        public void SetX(double value) => _X = value;
        //{
        //    _X = value;
        //}

        private double _Y;

        public double Y
        {
            get => _Y;
            //{
            //    return _Y;
            //}
            set => _Y = value;
            //{
            //    _Y = value;
            //}
        }

        public double Length => Math.Sqrt(_X * _X + _Y * _Y);
        //{
        //    get
        //    {
        //        return Math.Sqrt(_X * _X + _Y * _Y);
        //    }
        //}

        public Vector2DClass() { }

        public Vector2DClass(double X, double Y)
        {
            _X = X;
            _Y = Y;
        }

        public static Vector2DClass operator +(Vector2DClass a, Vector2DClass b)
        {
            return new Vector2DClass(a._X + b._X, a._Y + b._Y);
        }

        public static Vector2DClass operator *(Vector2DClass a, double b)
        {
            return new Vector2DClass(a._X * b, a._Y * b);
        }

        public static Vector2DClass operator *(double b, Vector2DClass a)
        {
            return new Vector2DClass(a._X * b, a._Y * b);
        }

        public static bool operator ==(Vector2DClass a, Vector2DClass b)
        {
            return a._X == b._X && a._Y == b._Y;
        }

        public static bool operator !=(Vector2DClass a, Vector2DClass b)
        {
            return !(a == b);
        }

        public static implicit operator double(Vector2DClass v)
        {
            return v.Length;
        }

        public static explicit operator int(Vector2DClass v)
        {
            return (int)v.Length;
        }
    }
}
