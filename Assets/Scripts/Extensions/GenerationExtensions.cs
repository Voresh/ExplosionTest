using UnityEngine;

namespace Extensions
{
    public static class GenerationExtensions
    {
        //todo: рандом можно выделить в отдельный провайдер
        public static Vector3 GetRandomPoint(Vector2 min, Vector2 max, float height)
        {
            var x = Random.Range(min.x, max.x);
            var z = Random.Range(min.y, max.y);
            var y = height;
            return new Vector3(x, y, z);
        }
    }
}