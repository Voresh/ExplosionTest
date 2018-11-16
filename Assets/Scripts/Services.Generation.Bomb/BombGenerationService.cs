using System;
using Context.Game;
using Debug;
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
            _spawnTimer = Observable.Timer(TimeSpan.FromSeconds(1))
                .Repeat()
                .Subscribe(_ =>
                {
                    //todo: рандом можно выделить в отдельный провайдер и добавлять сюда как зависимость
                    var bomb = _settings.GeneratedObjects[Random.Range(0, _settings.GeneratedObjects.Count)];
                    var x = Random.Range(_settings.MinGenerationPoint.x, _settings.MaxGenerationPoint.x);
                    var z = Random.Range(_settings.MinGenerationPoint.y, _settings.MaxGenerationPoint.y);
                    var y = _settings.DefaultStartHeight;
                    _signalService.FireSignal(new SpawnBombSignal(bomb.View, bomb.Data, new Vector3(x, y, z)));
                });
        }

        void IDisposable.Dispose()
        {
            _spawnTimer?.Dispose();
        }
    }
}