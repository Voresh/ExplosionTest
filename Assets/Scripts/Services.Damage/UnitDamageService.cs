using System;
using System.Collections.Generic;
using Context.Game;
using Debug;
using Entities;
using Services.Base;
using Signals.Unit;

namespace Services.Damage
{
    public class UnitDamageService : IService, ISignalListener<UnitViewUnderAttackSignal>, ISignalListener<UnitSpawnedSignal>
    {
        private readonly ISignalService _signalService;
        private readonly List<Unit> _units = new List<Unit>();

        public UnitDamageService(ISignalService signalService)
        {
            _signalService = signalService;
            ClientOnlyConditionalDebug.Log("hello I am damage service");
        }

        void ISignalListener<UnitViewUnderAttackSignal>.SignalFired(UnitViewUnderAttackSignal signal)
        {
            ClientOnlyConditionalDebug.LogWarning("hey, I got apply damage signal :)");
            //_units.Remove(unit);
            //_signalService.FireSignal(new UnitDiedSignal(unit));
        }

        void ISignalListener<UnitSpawnedSignal>.SignalFired(UnitSpawnedSignal signal)
        {
            _units.Add(signal.Unit);
        }

        void IService.Initialize()
        {
        }

        void IDisposable.Dispose()
        {
        }
    }
}