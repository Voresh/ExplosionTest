namespace Signals.Unit
{
    public struct DestroyUnitSignal
    {
        public readonly Entities.Unit Unit;

        public DestroyUnitSignal(Entities.Unit unit)
        {
            Unit = unit;
        }
    }
}