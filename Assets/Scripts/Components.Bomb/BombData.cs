using System;

namespace Components.Bomb
{
    [Serializable]
    public class BombData
    {
        //todo: тут можно описывать поведение бомбы/характер урона через абстрактные классы которые юнити не сериализует по дефолту (удобнее хранить такие вещи не в SO)
        public Damage.Damage Damage;
        public float DamageRadius;
        public float DamageDelay;
    }
}