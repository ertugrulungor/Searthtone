using System;
using System.Collections.Generic;
using Searthtone;

namespace LibraryTest
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            GameEngine gameEngine = new GameEngine();

            Face playerOne = GetFace("ertugrulungor");
            Face playerTwo = GetFace("onuar");

            var firstPlayer = gameEngine.Start(playerOne, playerTwo);

            Card pickedCard;
            if(playerOne.PlayerType == firstPlayer)
            {
                pickedCard = gameEngine.PickCard(playerOne);
            }
            else
            {
                pickedCard = gameEngine.PickCard(playerTwo);
            }
            var selectedPlayer = playerOne.PlayerType == firstPlayer ? playerOne : playerTwo;

            var mana = gameEngine.PlayToBattleGround(selectedPlayer, pickedCard);
            gameEngine.NextTurn();

        }

        private static Face GetFace(string username)
        {
            List<Card> cards = new List<Card>();

            Warrior warrior0 = new Warrior("warrior0", 1, 1, 1);
            Warrior warrior1 = new Warrior("warrior1", 2, 2, 1);
            Warrior warrior2 = new Warrior("warrior2", 4, 1, 2);
            Warrior warrior3 = new Warrior("warrior3", 3, 3, 2);
            Warrior warrior4 = new Warrior("warrior4", 5, 4, 3);
            Warrior warrior5 = new Warrior("warrior5", 5, 7, 4);
            Warrior warrior6 = new Warrior("warrior6", 10, 5, 5);
            Warrior warrior7 = new Warrior("warrior7", 5, 10, 6);
            Warrior warrior8 = new Warrior("warrior8", 9, 8, 6);
            Warrior warrior9 = new Warrior("warrior9", 10, 10, 8);

            cards.Add(warrior0);
            cards.Add(warrior1);
            cards.Add(warrior2);
            cards.Add(warrior3);
            cards.Add(warrior4);
            cards.Add(warrior5);
            cards.Add(warrior6);
            cards.Add(warrior7);
            cards.Add(warrior8);
            cards.Add(warrior9);

            Face face = new Face(username, cards);

            return face;
        }
    }
}
