using Components.Damage;
using Components.Unit;

namespace Entities
{
    public class Unit: IDamagable
    {
        public Damagable Damagable { get; }
        private UnitData _data;
        private readonly UnitView _view;

        public Unit(UnitData data, UnitView view)
        {
            _data = data;
            _view = view;
            Damagable = new Damagable();
        }
    }
}