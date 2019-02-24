using System;
using Searthtone.Type;

namespace Searthtone
{
    public abstract class Card
    {
        internal string Name { get; set; }
        internal int ManaValue { get; set; }
        internal int AttackValue { get; set; }
        internal int Health { get; set; }
        internal CardStateType CardState { get; set; }
        public PlayerType Owner { get; internal set; }

        protected Card()
        {
            CardState = CardStateType.NotAvailable;
        }
    }
}
