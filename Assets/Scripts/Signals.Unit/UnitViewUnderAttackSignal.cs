using Components.Damage;
using Components.Unit;

namespace Signals.Unit
{
    public struct UnitViewUnderAttackSignal
    {
        public readonly Damage Damage;
        public readonly UnitView View;

        public UnitViewUnderAttackSignal(Damage damage, UnitView view)
        {
            Damage = damage;
            View = view;
        }
    }
}