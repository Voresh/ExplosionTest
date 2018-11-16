namespace Signals.Unit
{
    public struct UnitSpawnedSignal
    {
        public readonly Entities.Unit Unit;
        
        public UnitSpawnedSignal(Entities.Unit unit)
        {
            Unit = unit;
        }
    }
}