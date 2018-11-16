using UnityEngine;

namespace Services.Generation.Bomb
{
    [CreateAssetMenu(menuName = "Settings/bomb generation settings", fileName = "bomb_generation_settings")]
    public class BombGenerationSettingsProvider: ScriptableObject
    {
        public BombGenerationSettings Settings;
    }
}