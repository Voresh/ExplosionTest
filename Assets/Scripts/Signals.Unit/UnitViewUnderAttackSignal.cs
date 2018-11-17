using Components.Damage;
using Components.Unit;
using UnityEngine;

namespace Signals.Unit
{
    public struct UnitViewUnderAttackSignal
    {
        public readonly Vector3 DamagerPosition; 
        public readonly Damage Damage;
        public readonly UnitView View;

        public UnitViewUnderAttackSignal(Damage damage, UnitView view, Vector3 damagerPosition)
        {
            Damage = damage;
            View = view;
            DamagerPosition = damagerPosition;
        }
    }
}