using System;
using UnityEngine;

namespace Services.Damage
{
    [Serializable]
    public class DamageSettings
    {
        [Range(0, 1)] 
        public float ObstacleFactor;
    }
}