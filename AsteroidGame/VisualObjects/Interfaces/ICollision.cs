using System.Drawing;

namespace AsteroidGame.VisualObjects.Interfaces
{
    public interface ICollision
    {
        Rectangle Rect { get;  }
        bool CheckCollision(ICollision obj);
    }
}
