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
    }
}
