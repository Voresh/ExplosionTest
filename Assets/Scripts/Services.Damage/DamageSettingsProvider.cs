using UnityEngine;

namespace Services.Damage
{
    [CreateAssetMenu(menuName = "Settings/damage settings", fileName = "damage_settings")]
    public class DamageSettingsProvider : ScriptableObject
    {
        public DamageSettings Settings;
    }
}