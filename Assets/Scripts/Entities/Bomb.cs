using Components.Bomb;

namespace Entities
{
    public class Bomb
    {
        public BombData Data;
        public BombView View;

        public Bomb(BombData data, BombView view)
        {
            Data = data;
            View = view;
        }
    }
}