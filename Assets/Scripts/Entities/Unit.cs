using Components.Damage;
using Components.Unit;

namespace Entities
{
    public class Unit: IDamagable
    {
        private readonly UnitData _data;
        private readonly UnitView _view;
        public Damagable Damagable { get; }
        
        public Unit(UnitData data, UnitView view)
        {
            _data = data;
            _view = view;
            Damagable = new Damagable();
        }
    }
}