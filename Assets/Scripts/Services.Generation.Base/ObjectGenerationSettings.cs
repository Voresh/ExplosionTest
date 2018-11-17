using System.Collections.Generic;
using UnityEngine;

namespace Services.Generation.Base
{
    public abstract class ObjectGenerationSettings<T>
    {
        public List<T> GeneratedObjects;
        public Vector2 MinGenerationPoint;
        public Vector2 MaxGenerationPoint;
        public float DefaultStartHeight;
        public float GenerationRateInSeconds;
    }
}