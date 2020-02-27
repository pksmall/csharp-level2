using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    public class ImageObject : VisualObject
    {
        private Image _image;
        public ImageObject(Point Position, Point Direction, Size Size, Image image) : base(Position, Direction, Size)
        {
            _image = image;
        }
    }
}
