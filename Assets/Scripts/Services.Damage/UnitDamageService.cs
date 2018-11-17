using System;
using System.Collections.Generic;
using Components.Obstacle;
using Components.Unit;
using Context.Game;
using Debug;
using Entities;
using Services.Base;
using Signals.Unit;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Services.Damage
{
    public class UnitDamageService : IService, ISignalListener<UnitViewUnderAttackSignal>, ISignalListener<UnitSpawnedSignal>
    {
        private readonly ISignalService _signalService;
        private readonly DamageSettings _settings;
        private readonly List<Unit> _units = new List<Unit>();

        public UnitDamageService(ISignalService signalService, DamageSettings settings)
        {
            _signalService = signalService;
            _settings = settings;
            ClientOnlyConditionalDebug.Log("hello I am damage service");
        }

        void ISignalListener<UnitViewUnderAttackSignal>.SignalFired(UnitViewUnderAttackSignal signal)
        {
            ClientOnlyConditionalDebug.LogWarning("hey, I got apply damage signal :)");
            var view = signal.View;
            var damage = signal.Damage;
            var unit = GetUnitByView(view);
            if (unit == null)
            {
                ClientOnlyConditionalDebug.LogWarning("unit not found");
                return;
            }
            unit.Damagable.CurrentHealth -= GetCalculatedDamage(damage.Amount, signal.DamagerPosition, unit.View.transform.position);
            if (unit.Damagable.CurrentHealth > 0) 
                return;
            _units.Remove(unit);
            _signalService.FireSignal(new DestroyUnitSignal(unit));
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

        private int GetCalculatedDamage(int damage, Vector3 damagePosition, Vector3 targetPosition)
        {
            RaycastHit hit;
            UnityEngine.Debug.DrawLine(damagePosition, targetPosition);
            if (!Physics.Linecast(damagePosition, targetPosition, out hit) || hit.transform.GetComponent<ObstacleView>() == null) 
                return damage;
            ClientOnlyConditionalDebug.Log("obstacle found");
            return (int) (damage * _settings.ObstacleFactor);
        }

        private Unit GetUnitByView(UnitView view)
        {
            return _units.Find(_ => _.View.Equals(view));
        }
    }
}