using Components.Unit;
using UnityEngine;

namespace Signals.Unit
{
    public struct SpawnUnitSignal
    {
        public readonly UnitView View;
        public readonly UnitData Data;
        public readonly Vector3 Position;

        public SpawnUnitSignal(UnitView view, UnitData data, Vector3 position)
        {
            View = view;
            Data = data;
            Position = position;
        }
    }
}