using AsteroidGame.Events;
using AsteroidGame.VisualObjects.Interfaces;
using System;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    public class SpaceShip : VisualObject, ICollision 
    {
        public event EventHandler<StateEvents> ShipOnState;
        public event EventHandler ShipDestroyed; 

        private int _Energy  = 100;
        private int _Score = 0;
        public int Energy => _Energy;
        public int Score
        {
            get
            {
                return _Score;
            }
            set
            {
                stateArgs = new StateEvents();
                _Score = value;
                stateArgs.message = $"Ship has been scored. Ship has score {_Score}.";
                OnShipState(stateArgs);
            }
        }

        StateEvents stateArgs;

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

        protected virtual void OnShipState(StateEvents e) 
        {
            ShipOnState?.Invoke(this, e);
        }

        public void ChangeEnergy(int delta)
        {
            stateArgs = new StateEvents();
            _Energy += delta;
            if (_Energy <= 0)
            {
                ShipDestroyed?.Invoke(this, EventArgs.Empty);
                stateArgs.message = $"Ship has been low energy. Ship has been destoroyed.";
                OnShipState(stateArgs);
            }
            if (_Energy > 100)
            {
                _Energy = 100;
                stateArgs.message = $"Ship has got {delta} energey pack. Ship has high energy.";
                OnShipState(stateArgs);
            } else if (delta > 0)
            {
                stateArgs.message = $"Ship has got {delta} energey pack. Ship has {_Energy} energy.";
                OnShipState(stateArgs);
            } else if (delta < 0)
            {
                stateArgs.message = $"Ship has got {delta} damage. Ship has {_Energy} energy.";
                OnShipState(stateArgs);
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
            if (is_collision && obj is Medkit medkit)
            {
                ChangeEnergy(medkit.Power);
            }

            return is_collision;
        }
    }
}
