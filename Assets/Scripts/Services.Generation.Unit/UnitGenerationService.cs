using System;
using Context.Game;
using Debug;
using Services.Base;
using Signals.Unit;
using UniRx;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Services.Generation.Unit
{
    public class UnitGenerationService: IService
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
            _spawnTimer = Observable.Timer(TimeSpan.FromSeconds(1))
                .Repeat()
                .Subscribe(_ =>
                {
                    //todo: избежание коллизий https://docs.unity3d.com/ScriptReference/Physics.OverlapBox.html
                    //todo: рандом можно выделить в отдельный провайдер и добавлять сюда как зависимость
                    var unit = _settings.GeneratedObjects[Random.Range(0, _settings.GeneratedObjects.Count)];
                    var x = Random.Range(_settings.MinGenerationPoint.x, _settings.MaxGenerationPoint.x);
                    var z = Random.Range(_settings.MinGenerationPoint.y, _settings.MaxGenerationPoint.y);
                    var y = _settings.DefaultStartHeight;
                    _signalService.FireSignal(new SpawnUnitSignal(unit.View, unit.Data, new Vector3(x, y, z)));
                });
        }

        void IDisposable.Dispose()
        {
            _spawnTimer?.Dispose();
        }
    }
}