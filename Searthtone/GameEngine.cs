using System.Collections.Generic;
using Searthtone.Service;
using Searthtone.Type;

namespace Searthtone
{
    public class GameEngine
    {
        private readonly CardService cardService;

        public GameEngine()
        {
            cardService = new CardService();
        }

        /// <summary>
        /// Returns who should start first 
        /// </summary>
        public PlayerType Start(Face playerOne, Face playerTwo)
        {
            return cardService.Start(playerOne, playerTwo);
        }

        /// <summary>
        /// Returns killed cards
        /// </summary>
        public List<Card> Attack(Card attacker, Card opponent)
        {
            return cardService.Attack(attacker, opponent);
        }

        /// <summary>
        /// Returns game state
        /// </summary>
        public GameStateType Attack(Card attacker, Face opponent)
        {
            return cardService.Attack(attacker, opponent);
        }

        /// <summary>
        /// Returns picked card 
        /// </summary>
        public Card PickCard(Face player)
        {
            return cardService.PickCard(player);
        }

        /// <summary>
        /// Returns picked cards for player 
        /// </summary>
        public List<Card> GetPickedCard(Face player)
        {
            return cardService.GetPickedCard(player);
        }

        /// <summary>
        /// Returns who play next turn
        /// </summary>
        public PlayerType NextTurn()
        {
            return cardService.NextTurn();
        }

        /// <summary>
        /// Returns remaining mana
        /// </summary>
        public int PlayToBattleGround(Face player, Card card)
        {
            return cardService.PlayToBattleGround(player, card);
        }

        /// <summary>
        /// Returns winner
        /// </summary>
        public PlayerType GetWinner()
        {
            return cardService.GetWinner();
        }
    }
}
