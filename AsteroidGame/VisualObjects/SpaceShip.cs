using System;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : VisualObject
    {
        public SpaceShip(Point Position, Point Direction, Size Size) 
            : base(Position, Direction, Size)
        {
        }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
