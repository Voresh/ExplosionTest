using System;
using Components.Bomb;

namespace Services.Generation.Bomb
{
    [Serializable]
    public class BombGenerationData
    {
        public BombData Data;
        public BombView View;
    }
}