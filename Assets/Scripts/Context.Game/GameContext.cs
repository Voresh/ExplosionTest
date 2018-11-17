using Services.Damage;
using Services.Destroy;
using Services.Detonation;
using Services.Generation;
using Services.Generation.Bomb;
using Services.Generation.Unit;

namespace Context.Game
{
    public class GameContext : Context.Base.Context, ISignalService
    {
        private readonly UnitGenerationSettings _unitGenerationSettings;
        private readonly BombGenerationSettings _bombGenerationSettings;
        private readonly DamageSettings _settings;
        private static GameContext _currentContext;

        public GameContext(UnitGenerationSettings unitGenerationSettings, BombGenerationSettings bombGenerationSettings, DamageSettings settings)
        {
            _unitGenerationSettings = unitGenerationSettings;
            _bombGenerationSettings = bombGenerationSettings;
            _settings = settings;
        }

        public override void Init()
        {
            //todo: внедрение зависимостей можно автоматизировать
            AddService(new UnitGenerationService(this, _unitGenerationSettings));
            AddService(new UnitSpawnService(this));
            AddService(new UnitDamageService(this, _settings));
            AddService(new UnitDestroyService());
            
            AddService(new BombGenerationService(this, _bombGenerationSettings));
            AddService(new BombSpawnService(this));
            AddService(new BombDetonationService(this));
            AddService(new BombDestroyService());
            
            InitializeServices();
        }

        public void FireSignal<T>(T signal) where T : struct
        {
            //todo: можно кешировать
            Services.ForEach(_ =>
            {
                if (!(_ is ISignalListener<T>))
                    return;
                ((ISignalListener<T>) _).SignalFired(signal);
            });
        }
    }
}