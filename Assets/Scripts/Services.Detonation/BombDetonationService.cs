using System;
using System.Linq;
using Components.Unit;
using Context.Game;
using Entities;
using Services.Base;
using Signals.Bomb;
using Signals.Unit;
using UniRx.Triggers;
using UniRx;
using UnityEngine;

namespace Services.Detonation
{
    public class BombDetonationService : IService, ISignalListener<BombSpawnedSignal>
    {
        private readonly ISignalService _signalService;

        public BombDetonationService(ISignalService signalService)
        {
            _signalService = signalService;
        }

        void ISignalListener<BombSpawnedSignal>.SignalFired(BombSpawnedSignal signal)
        {
            var bomb = signal.Bomb;
            var collisionTrigger = bomb.View.gameObject.AddComponent<ObservableCollisionTrigger>();
            IDisposable collisionSubscription = null;
            collisionSubscription = collisionTrigger.OnCollisionEnterAsObservable().Subscribe(_ =>
            {
                // ReSharper disable once AccessToModifiedClosure
                collisionSubscription?.Dispose();
                IDisposable detonateDelay = null;
                detonateDelay = Observable.Timer(TimeSpan.FromSeconds(bomb.Data.DamageDelay)).Subscribe(__ =>
                {
                    // ReSharper disable once AccessToModifiedClosure
                    detonateDelay?.Dispose();
                    Detonate(bomb);
                });
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
            Physics.OverlapSphere(bomb.View.transform.position, bomb.Data.DamageRadius)
                .ToList()
                .ForEach(_ =>
                {
                    var unit = _.GetComponent<UnitView>();
                    if (unit != null)
                        _signalService.FireSignal(new UnitViewUnderAttackSignal(bomb.Data.Damage, unit, bomb.View.transform.position));
                });
            _signalService.FireSignal(new DestroyBombSignal(bomb));
        }
    }
}