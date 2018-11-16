using UnityEngine;

namespace Services.Generation.Unit
{
    [CreateAssetMenu(menuName = "Settings/unit generation settings", fileName = "unit_generation_settings")]
    public class UnitGenerationSettingsProvider: ScriptableObject
    {
        public UnitGenerationSettings Settings;
    }
}