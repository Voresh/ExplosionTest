using Components.Bomb;
using UnityEngine;

namespace Signals.Bomb
{
    public struct SpawnBombSignal
    {
        public readonly BombView View;
        public readonly BombData Data;
        public readonly Vector3 Position;

        public SpawnBombSignal(BombView view, BombData data, Vector3 position)
        {
            View = view;
            Data = data;
            Position = position;
        }
    }
}