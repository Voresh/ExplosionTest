using System;
using Context.Game;
using Services.Base;
using Signals.Unit;
using Object = UnityEngine.Object;

namespace Services.Destroy
{
    public class UnitDestroyService: IService, ISignalListener<DestroyUnitSignal>
    {
        private const float DestroyDelay = 0.5f;
        
        void ISignalListener<DestroyUnitSignal>.SignalFired(DestroyUnitSignal signal)
        {
            Object.Destroy(signal.Unit.View.gameObject, DestroyDelay);
        }
        
        void IService.Initialize()
        {
        }

        void IDisposable.Dispose()
        {
        }
    }
}