using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction, int Size) 
            : base(Position, Direction, new Size(Size, Size))
        {
            
        }

        public override void Draw(Graphics g)
        {
            if (!Enabled) return;

            g.DrawLine(Pens.WhiteSmoke,
                _Position.X, _Position.Y,
                _Position.X + _Size.Width, _Position.Y + _Size.Width);

            g.DrawLine(Pens.WhiteSmoke,
                _Position.X + _Size.Width, _Position.Y,
                _Position.X, _Position.Y + _Size.Width);
        }

        public override void Update()
        {
            if (!Enabled) return;

            _Position.X += _Direction.X;

            if (_Position.X < 0)
                _Position.X = Game.Width + _Size.Width;

            //if (_Position.X > Game.Width /* + _Size.Width*/)
            //    _Position.X = 0 - _Size.Width;
        }
    }
}
