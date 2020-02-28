using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public abstract class ImageObject : VisualObject
    {
        private Image _image;
        protected ImageObject(Point Position, Point Direction, Size Size, Image image) : base(Position, Direction, Size)
        {
            _image = image;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_image, Rect);
        }

/*        public override void Update()
        {
            _Position = new Point(
                _Position.X + _Direction.X,
                _Position.Y + _Direction.Y);

            if (_Position.X < 0)
                //_Direction.X *= -1;
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y < 0)
                _Direction = new Point(_Direction.X, -_Direction.Y);

            if (_Position.X > Game.Width)
                _Direction = new Point(-_Direction.X, _Direction.Y);
            if (_Position.Y > Game.Height)
                _Direction = new Point(_Direction.X, -_Direction.Y);
        }
*/    }
}
