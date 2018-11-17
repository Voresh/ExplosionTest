namespace Signals.Bomb
{
    public struct BombSpawnedSignal
    {
        public readonly Entities.Bomb Bomb;
        
        public BombSpawnedSignal(Entities.Bomb bomb)
        {
            Bomb = bomb;
        }
    }
}