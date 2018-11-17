using Components.Damage;
using Components.Unit;

namespace Entities
{
    public class Unit : IDamagable
    {
        public readonly UnitData Data;
        public readonly UnitView View;
        public Damagable Damagable { get; }

        public Unit(UnitData data, UnitView view)
        {
            Data = data;
            View = view;
            Damagable = new Damagable {CurrentHealth = data.Health};
        }
    }
}