using System;
using Context.Game;
using Services.Base;
using Signals.Bomb;
using Object = UnityEngine.Object;

namespace Services.Destroy
{
    public class BombDestroyService: IService, ISignalListener<DestroyBombSignal>
    {     
        void ISignalListener<DestroyBombSignal>.SignalFired(DestroyBombSignal signal)
        {
            Object.Destroy(signal.bomb.View.gameObject);
        }
        
        void IService.Initialize()
        {
        }

        void IDisposable.Dispose()
        {
        }
    }
}