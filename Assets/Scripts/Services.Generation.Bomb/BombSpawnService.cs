using System;
using Context.Game;
using Services.Base;
using Signals.Bomb;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Generation.Bomb
{
    public class BombSpawnService : IService, ISignalListener<SpawnBombSignal>
    {
        private readonly ISignalService _signalService;

        public BombSpawnService(ISignalService signalService)
        {
            _signalService = signalService;
        }

        void ISignalListener<SpawnBombSignal>.SignalFired(SpawnBombSignal signal)
        {
            var viewInstance = Object.Instantiate(signal.View, signal.Position, Quaternion.identity);
            var bomb = new Entities.Bomb(signal.Data, viewInstance);
            _signalService.FireSignal(new BombSpawnedSignal(bomb));
        }

        void IService.Initialize()
        {
        }

        void IDisposable.Dispose()
        {
        }
    }
}