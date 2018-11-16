using Components.Damage;

namespace Signals.Unit
{
    public struct UnitViewUnderAttackSignal
    {
        public readonly Damage Damage;
        public readonly Damagable Target;

        public UnitViewUnderAttackSignal(Damage damage, Damagable target)
        {
            Damage = damage;
            Target = target;
        }
    }
}