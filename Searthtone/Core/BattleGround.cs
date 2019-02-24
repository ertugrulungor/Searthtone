using System;
using System.Collections.Generic;

namespace Searthtone
{
    public class BattleGround
    {
        public List<Card> PlayerOneCards { get; set; }
        public List<Card> PlayerTwoCards { get; set; }

        public BattleGround()
        {
            PlayerOneCards = new List<Card>();
            PlayerTwoCards = new List<Card>();
        }
    }
}
