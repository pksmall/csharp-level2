using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class ImageObject : VisualObject
    {
        private Image _image;
        public ImageObject(Point Position, Point Direction, Size Size, Image image) : base(Position, Direction, Size)
        {
            _image = image;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(_image, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }
    }
}
