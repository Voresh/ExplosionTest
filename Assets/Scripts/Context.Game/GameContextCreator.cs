using Debug;
using Services.Damage;
using Services.Generation;
using Services.Generation.Bomb;
using Services.Generation.Unit;
using UnityEngine;
using UnityEngine.Assertions;

namespace Context.Game
{
    public class GameContextCreator : MonoBehaviour
    {
        [SerializeField] 
        private UnitGenerationSettingsProvider _unitGenerationSettingsProvider;
        [SerializeField] 
        private BombGenerationSettingsProvider _bombGenerationSettingsProvider;
        [SerializeField] 
        private DamageSettingsProvider _damageSettingsProvider;
        private Context.Base.Context _currentContext;

        private void Awake()
        {
            ClientOnlyConditionalDebug.Log("game started");
            Assert.IsNotNull(_unitGenerationSettingsProvider);
            Assert.IsNotNull(_bombGenerationSettingsProvider);
            Assert.IsNotNull(_damageSettingsProvider);
        
            _currentContext = new GameContext(_unitGenerationSettingsProvider.Settings, _bombGenerationSettingsProvider.Settings, _damageSettingsProvider.Settings);
            _currentContext.Init();
            ClientOnlyConditionalDebug.Log("context created");
        }
    }
}