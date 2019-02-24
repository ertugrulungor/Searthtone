using System;
using System.Collections.Generic;
using Searthtone.Exceptions;
using Searthtone.Type;

namespace Searthtone.Service
{
    internal class CardService
    {

        internal List<Card> Attack(Card attacker, Card opponent)
        {
            if(Context.GameState == GameStateType.Ready)
            {
                throw new NotStartedException();
            }

            if (Context.GameState == GameStateType.Finished)
            {
                throw new GameOverException();
            }

            if (attacker == null || opponent == null)
            {
                throw new CardNullException();
            }

            if(attacker.CardState != CardStateType.Ready || opponent.CardState != CardStateType.Ready)
            {
                throw new CardNotReadyException();
            }

            if (attacker.Owner == PlayerType.PlayerOne)
            {
                if (!Context.BattleGround.PlayerOneCards.Contains(attacker))
                {
                    throw new BattlegroundNotContainsThisCardException();
                }

                if (!Context.BattleGround.PlayerTwoCards.Contains(opponent))
                {
                    throw new BattlegroundNotContainsThisCardException();
                }
            }
            else
            {
                if (!Context.BattleGround.PlayerOneCards.Contains(opponent))
                {
                    throw new BattlegroundNotContainsThisCardException();
                }

                if (!Context.BattleGround.PlayerTwoCards.Contains(attacker))
                {
                    throw new BattlegroundNotContainsThisCardException();
                }
            }

            var killedCards = new List<Card>();

            opponent.Health -= attacker.AttackValue;
            attacker.Health -= opponent.AttackValue;

            if(attacker.Health < 1)
            {
                killedCards.Add(attacker);

                if(attacker.Owner == PlayerType.PlayerOne)
                {
                    Context.BattleGround.PlayerOneCards.Remove(attacker);
                }
                else
                {
                    Context.BattleGround.PlayerTwoCards.Remove(attacker);
                }
            }

            if (opponent.Health < 1)
            {
                killedCards.Add(opponent);

                if (opponent.Owner == PlayerType.PlayerOne)
                {
                    Context.BattleGround.PlayerOneCards.Remove(opponent);
                }
                else
                {
                    Context.BattleGround.PlayerTwoCards.Remove(opponent);
                }
            }

            return killedCards;
        }

        internal PlayerType GetWinner()
        {
            if (Context.GameState != GameStateType.Finished)
            {
                throw new GameNotFinishException();
            }

            return Context.Winner;
        }

        internal GameStateType Attack(Card attacker, Face opponent)
        {
            if (Context.GameState == GameStateType.Ready)
            {
                throw new NotStartedException();
            }

            if (Context.GameState == GameStateType.Finished)
            {
                throw new GameOverException();
            }

            if (attacker == null)
            {
                throw new CardNullException();
            }

            if(opponent == null)
            {
                throw new FaceNullException();
            }

            if (attacker.CardState != CardStateType.Ready)
            {
                throw new CardNotReadyException();
            }

            if (attacker.Owner == PlayerType.PlayerOne)
            {
                if (!Context.BattleGround.PlayerOneCards.Contains(attacker))
                {
                    throw new BattlegroundNotContainsThisCardException();
                }

                if (opponent.PlayerType == PlayerType.PlayerOne)
                {
                    throw new BattlegroundNotContainsThisCardException();
                }
            }
            else
            {
                if (!Context.BattleGround.PlayerTwoCards.Contains(attacker))
                {
                    throw new BattlegroundNotContainsThisCardException();
                }

                if (opponent.PlayerType == PlayerType.PlayerTwo)
                {
                    throw new BattlegroundNotContainsThisCardException();
                }
            }

            opponent.Health -= attacker.AttackValue;

            if(opponent.Health < 1)
            {
                Context.GameState = GameStateType.Finished;
                Context.Winner = attacker.Owner;
                return GameStateType.Finished;
            }

            Context.GameState = GameStateType.Continues;
            return GameStateType.Continues;
        }

        internal PlayerType Start(Face playerOne, Face playerTwo)
        {
            if(Context.GameState != GameStateType.Ready)
            {
                throw new GameAlreadyStartedException();
            }

            if(playerOne == null || playerTwo == null)
            {
                throw new CardNullException();
            }

            if(playerOne.CardCollection == null || playerTwo.CardCollection == null)
            {
                throw new PlayerCardCollectionNullException();
            }

            if (playerOne.CardCollection.Count < 10 || playerTwo.CardCollection.Count < 10)
            {
                throw new PlayerCardCollectionUnderflowException();
            }

            if (playerOne.CardCollection.Count > 15 || playerTwo.CardCollection.Count > 15)
            {
                throw new PlayerCardCollectionOverflowException();
            }

            if(playerOne.Health < 1 || playerTwo.Health < 1)
            {
                throw new GameOverException();
            }

            if (playerOne.Mana < 1 || playerTwo.Mana < 1)
            {
                throw new InsufficientManaException();
            }

            Context.Winner = PlayerType.NotSet;
            playerOne.PlayerType = PlayerType.PlayerOne;
            playerTwo.PlayerType = PlayerType.PlayerTwo;

            playerOne.CardCollection.ForEach(x => x.Owner = PlayerType.PlayerOne);
            playerTwo.CardCollection.ForEach(x => x.Owner = PlayerType.PlayerOne);

            PlayerCardCollectionCheck(playerOne.CardCollection);
            PlayerCardCollectionCheck(playerTwo.CardCollection);

            Context.PlayerOne = playerOne;
            Context.PlayerTwo = playerTwo;
            Context.GameState = GameStateType.Started;
            Context.NumberOfTurn = 0;

            Random rand = new Random();

            if (rand.NextDouble() >= 0.5) 
            {
                Context.NextTurn = PlayerType.PlayerOne;
                return PlayerType.PlayerOne;
            } 
            else 
            {
                Context.NextTurn = PlayerType.PlayerTwo;
                return PlayerType.PlayerTwo;
            }
        }

        internal int PlayToBattleGround(Face player, Card card)
        {
            if (Context.GameState == GameStateType.Ready)
            {
                throw new NotStartedException();
            }

            if (Context.GameState == GameStateType.Finished)
            {
                throw new GameOverException();
            }

            if (player == null)
            {
                throw new FaceNullException();
            }

            if (card == null)
            {
                throw new CardNullException();
            }

            if (Context.NextTurn != player.PlayerType)
            {
                throw new InvalidMoveException();
            }

            if (card.CardState != CardStateType.NotAvailable)
            {
                throw new CardNotReadyException();
            }

            if (!player.PickedCards.Contains(card))
            {
                throw new PickedCardsNotContainsThisCardException();
            }

            if (card.ManaValue > player.Mana)
            {
                throw new InsufficientManaException();
            }

            card.CardState = CardStateType.Waiting;
            if (player.PlayerType == PlayerType.PlayerOne)
            {
                Context.BattleGround.PlayerOneCards.Add(card);
            }
            else if (player.PlayerType == PlayerType.PlayerTwo)
            {
                Context.BattleGround.PlayerTwoCards.Add(card);
            }

            player.Mana -= card.ManaValue;

            return player.Mana;
        }

        internal List<Card> GetPickedCard(Face player)
        {
            if (Context.GameState == GameStateType.Ready)
            {
                throw new NotStartedException();
            }

            if (Context.GameState == GameStateType.Finished)
            {
                throw new GameOverException();
            }

            if (player == null)
            {
                throw new FaceNullException();
            }

            return player.PickedCards;
        }

        internal PlayerType NextTurn()
        {
            if (Context.GameState == GameStateType.Ready)
            {
                throw new NotStartedException();
            }

            if (Context.GameState == GameStateType.Finished)
            {
                throw new GameOverException();
            }

            Context.PlayerOne.Mana += 1;
            Context.PlayerTwo.Mana += 1;

            Context.NumberOfTurn += 1;
            if(Context.NumberOfTurn % 2 == 0)
            {
                var manaCount = Context.NumberOfTurn / 2;
                Context.PlayerOne.Mana = manaCount + 1;
                Context.PlayerTwo.Mana = manaCount + 1;
            }

            if (Context.NextTurn == PlayerType.PlayerOne)
            {
                Context.BattleGround.PlayerOneCards.ForEach(x => x.CardState = CardStateType.Ready);

                Context.NextTurn = PlayerType.PlayerTwo;
                return PlayerType.PlayerTwo;
            }
            else
            {
                Context.BattleGround.PlayerTwoCards.ForEach(x => x.CardState = CardStateType.Ready);

                Context.NextTurn = PlayerType.PlayerOne;
                return PlayerType.PlayerOne;
            }
        }

        internal Card PickCard(Face player)
        {
            if (Context.GameState == GameStateType.Ready)
            {
                throw new NotStartedException();
            }

            if (Context.GameState == GameStateType.Finished)
            {
                throw new GameOverException();
            }

            if (player == null)
            {
                throw new FaceNullException();
            }

            if (player.CardCollection == null)
            {
                throw new PlayerCardCollectionNullException();
            }

            if (player.PlayerType != Context.NextTurn)
            {
                throw new InvalidMoveException();
            }

            if (player.CardCollection.Count < 1)
            {
                throw new PlayerCardCollectionUnderflowException();
            }

            Random rand = new Random();
            var cardIndex = rand.Next(player.CardCollection.Count);

            var selectedCard = player.CardCollection[cardIndex];

            player.PickedCards.Add(selectedCard);
            player.CardCollection.Remove(selectedCard);

            return selectedCard;
        }

        private void PlayerCardCollectionCheck(List<Card> cardCollection)
        {
            foreach (var card in cardCollection)
            {
                if(card.AttackValue < 1)
                {
                    throw new Exception();
                }

                if(card.ManaValue < 1)
                {
                    throw new Exception();
                }

                if(card.Health < 0)
                {
                    throw new Exception();
                }
            }
        }
    }
}
