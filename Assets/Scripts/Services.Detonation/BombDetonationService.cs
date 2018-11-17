﻿using System;
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
using Object = UnityEngine.Object;

namespace Services.Detonation
{
    public class BombDetonationService: IService, ISignalListener<BombSpawnedSignal>
    {
        private readonly ISignalService _signalService;
        private const float DestroyDelay = 0.5f;

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
            Physics.OverlapSphere(bomb.View.transform.position, bomb.Data.DamageRadius)
                .ToList()
                .ForEach(_ =>
                {
                    var unit = _.GetComponent<UnitView>();
                    if (unit != null)
                        _signalService.FireSignal(new UnitViewUnderAttackSignal(bomb.Data.Damage, unit));
                });
        }
    }
}