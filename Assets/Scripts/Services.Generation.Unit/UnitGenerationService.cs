using System;
using System.Linq;
using Components.Obstacle;
using Components.Unit;
using Context.Game;
using Debug;
using Extensions;
using Services.Base;
using Signals.Unit;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.Generation.Unit
{
    public class UnitGenerationService : IService
    {
        private readonly ISignalService _signalService;
        private readonly UnitGenerationSettings _settings;
        private IDisposable _spawnTimer;

        public UnitGenerationService(ISignalService signalService, UnitGenerationSettings settings)
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
                    var unit = _settings.GeneratedObjects[Random.Range(0, _settings.GeneratedObjects.Count)];
                    var targetPosition =
                        GenerationExtensions.GetRandomPoint(_settings.MinGenerationPoint, _settings.MaxGenerationPoint, _settings.DefaultStartHeight);
                    if (UnitCanBeSpawned(targetPosition, unit.View.transform.localScale))
                        _signalService.FireSignal(new SpawnUnitSignal(unit.View, unit.Data, targetPosition));
                });
        }

        private static bool UnitCanBeSpawned(Vector3 position, Vector3 scale)
        {
            var overlappingColliders = Physics.OverlapBox(position, scale / 2f);
            return !overlappingColliders.Any(_ => _.GetComponent<UnitView>() != null || _.GetComponent<ObstacleView>() != null);
        }

        void IDisposable.Dispose()
        {
            _spawnTimer?.Dispose();
        }
    }
}