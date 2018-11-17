namespace Signals.Bomb
{
    public struct DestroyBombSignal
    {
        public readonly Entities.Bomb bomb;

        public DestroyBombSignal(Entities.Bomb bomb)
        {
            this.bomb = bomb;
        }
    }
}