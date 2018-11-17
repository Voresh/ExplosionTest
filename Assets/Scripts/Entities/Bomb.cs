using Components.Bomb;

namespace Entities
{
    public class Bomb
    {
        public readonly BombData Data;
        public readonly BombView View;

        public Bomb(BombData data, BombView view)
        {
            Data = data;
            View = view;
        }
    }
}