using System;
using System.Collections.Generic;
using Searthtone.Type;

namespace Searthtone
{
    public class Face
    {
        internal string Username { get; set; }
        internal int Health { get; set; }
        internal int Mana { get; set; }
        internal List<Card> CardCollection { get; set; }
        public List<Card> PickedCards { get; internal set; }
        public PlayerType PlayerType { get; internal set; }

        public Face(string username, List<Card> cardCollection, int health = 30, int mana = 1)
        {
            this.Username = username;
            this.Health = health;
            this.CardCollection = cardCollection;
            this.Mana = mana;

            PickedCards = new List<Card>();
        }
    }
}
