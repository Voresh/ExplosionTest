namespace Signals.Unit
{
    public struct UnitDiedSignal
    {
        public readonly Entities.Unit Unit;
        
        public UnitDiedSignal(Entities.Unit unit)
        {
            Unit = unit;
        }
    }
}