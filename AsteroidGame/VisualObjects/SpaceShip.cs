using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : VisualObject, ICollision 
    {
        public event EventHandler ShipDestroyed; 

        private int _Energy  = 100;
        public int Energy => _Energy;

        public SpaceShip(Point Position, Point Direction, Size Size) 
            : base(Position, Direction, Size)
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = Rect;
            g.FillEllipse(Brushes.Blue, rect);
            g.DrawEllipse(Pens.Red, rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + 2, _Position.Y);
        }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;
            if (_Energy < 0)
            {
                ShipDestroyed?.Invoke(this, EventArgs.Empty);
            }

        }

        public void MoveUp(int Offset = 1)
        {
            if (_Position.Y > 0)
                _Position = new Point(_Position.X, _Position.Y - _Direction.Y);
        }

        public void MoveDown(int Offset = 1)
        {
            if (_Position.Y - _Size.Height < Game.Height)
                _Position = new Point(_Position.X, _Position.Y + _Direction.Y);
        }

        public bool CheckCollision(ICollision obj)
        {
            var is_collision = Rect.IntersectsWith(obj.Rect);
            if (is_collision && obj is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
            }

            return is_collision;
        }
    }
}
