using System;
using Context.Game;
using Entities;
using Services.Base;
using Signals.Bomb;
using UniRx.Triggers;
using UniRx;
using Object = UnityEngine.Object;

namespace Services.Detonation
{
    public class BombDetonationService: IService, ISignalListener<BombSpawnedSignal>
    {
        private const float DestroyDelay = 0.5f;
        
        void ISignalListener<BombSpawnedSignal>.SignalFired(BombSpawnedSignal signal)
        {
            var bomb = signal.Bomb;
            var collisionTrigger = bomb.View.gameObject.AddComponent<ObservableCollisionTrigger>();
            IDisposable collisionSubscription = null;
            collisionSubscription = collisionTrigger.OnCollisionEnterAsObservable().Subscribe(_ =>
            {
                // ReSharper disable once AccessToModifiedClosure
                collisionSubscription?.Dispose();
                Detonate(bomb);
            });
        }
        
        void IService.Initialize()
        {
        }

        void IDisposable.Dispose()
        {
        }

        private void Detonate(Bomb bomb)
        {
            Object.Destroy(bomb.View.gameObject, DestroyDelay);
        }
    }
}