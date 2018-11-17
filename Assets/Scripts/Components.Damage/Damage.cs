using System;

namespace Components.Damage
{
    [Serializable]
    public class Damage
    {
        public int Amount;

        public Damage(int amount)
        {
            Amount = amount;
        }
    }
}