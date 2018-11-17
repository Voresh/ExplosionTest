using System;
using Context.Game;
using Debug;
using Extensions;
using Services.Base;
using Signals;
using Signals.Bomb;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.Generation.Bomb
{
    public class BombGenerationService: IService
    {
        private readonly ISignalService _signalService;
        private readonly BombGenerationSettings _settings;
        private IDisposable _spawnTimer;

        public BombGenerationService(ISignalService signalService, BombGenerationSettings settings)
        {
            _signalService = signalService;
            _settings = settings;
            ClientOnlyConditionalDebug.Log("hello I am unit generation service");
        }

        void IService.Initialize()
        {
            _spawnTimer = Observable.Timer(TimeSpan.FromSeconds(_settings.GenerationRateInSeconds))
                .Repeat()
                .Subscribe(_ =>
                {
                    var bomb = _settings.GeneratedObjects[Random.Range(0, _settings.GeneratedObjects.Count)];
                    _signalService.FireSignal(new SpawnBombSignal(bomb.View, bomb.Data,
                        GenerationExtensions.GetRandomPoint(_settings.MinGenerationPoint, _settings.MaxGenerationPoint, _settings.DefaultStartHeight)));
                });
        }

        void IDisposable.Dispose()
        {
            _spawnTimer?.Dispose();
        }
    }
}