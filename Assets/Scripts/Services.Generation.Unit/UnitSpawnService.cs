using System;
using Context.Game;
using Debug;
using Services.Base;
using Signals.Unit;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Generation.Unit
{
    public class UnitSpawnService: IService, ISignalListener<SpawnUnitSignal>
    {
        private readonly ISignalService _signalService;

        public UnitSpawnService(ISignalService signalService)
        {
            _signalService = signalService;
        }

        void ISignalListener<SpawnUnitSignal>.SignalFired(SpawnUnitSignal signal)
        {
            ClientOnlyConditionalDebug.Log("spawn");
            var viewInstance = Object.Instantiate(signal.View, signal.Position, Quaternion.identity);
            var unit = new Entities.Unit(signal.Data, viewInstance);
            _signalService.FireSignal(new UnitSpawnedSignal(unit));
        }
        
        void IService.Initialize()
        {
        }
        
        void IDisposable.Dispose()
        {
        }
    }
}