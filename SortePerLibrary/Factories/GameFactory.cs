using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using SortePerLibrary.Models;
using SortePerLibrary.Services;

namespace SortePerLibrary.Factories
{
    public class GameFactory
    {
        /// <summary>
        /// Private constructor THE CAN BE ONLY ONE
        /// </summary>
        private GameFactory()
        {
        }


        /// <summary>
        /// This method initializes the game ready to play
        /// </summary>
        /// <param name="names"></param>
        /// <param name="players"></param>
        /// <param name="validate"></param>
        // public static List<IPlayerModel> InitializeGame(List<String> names)
        // {
        //     // Generate the list with users
        //     List<IPlayerModel> players = CreateUsers(names);
        //     // Create a deck of cards
        //     ICardDeck cardDeck = CreateCardDeck();
        //     // Shuffle tha card in no order
        //     cardDeck = GameFactory.ShuffleCards(cardDeck);
        //     // Deals the card uot to all the players
        //     players = GameFactory.DealCards(players, cardDeck);
        //     return players;
        // }

        // /// <summary>
        // /// This Method creates a IGameManager Instance
        // /// </summary>
        // /// <returns>Returns a IGameManager instance </returns>
        public static IGameManager CreateGameLogic(List<IPlayerModel> players, IValidate validate, IRemoveCards removeCards)
        {
            return new GameManager(players, validate, removeCards);
        }


        /// <summary>
        /// This method Create a user
        /// </summary>
        /// <returns> Returns a list of user </returns>
        public static List<IPlayerModel> CreateUsers(List<string> names)
        {
            List<IPlayerModel> players = new List<IPlayerModel>();
            foreach (var name in names)
            {
                players.Add(new PlayerModel(name));
            }

            return players;
        }

        /// <summary>
        /// This method creates class for validating values
        /// </summary>
        /// <returns>A IValidate</returns>
        public static IValidate CreateValidator()
        {
            return new Validate();
        }


        /// <summary>
        /// This method create the card deck
        /// </summary>
        /// <returns>Returns a complete card deck</returns>
        public static ICardDeck CreateCardDeck()
        {
            ICardDeck cardDeck = new CardDeck();
            List<ICardModel> cards = new List<ICardModel>();
            foreach (CardValue value in Enum.GetValues(typeof(CardValue)))
            {
                // Ads two cards to the card deck
                if (value == CardValue.Cat)
                {
                    cards.Add(new CardModel {CardValue = value});
                }
                else
                {
                    cards.Add(new CardModel {CardValue = value});
                    cards.Add(new CardModel {CardValue = value});
                }
            }

            cardDeck.Cards = cards;

            return cardDeck;
        }

        /// <summary>
        /// This method shuffles the card deck
        /// </summary>
        /// <param name="cardDeck">Takes in a ICardDeck</param>
        /// <returns>Returns a shuffled card deck</returns>
        public static ICardDeck ShuffleCards(ICardDeck cardDeck)
        {
            var shuffled = cardDeck.Cards.OrderBy(x => Guid.NewGuid()).ToList();
            return new CardDeck {Cards = shuffled};
        }

        /// <summary>
        /// This Message Deals the card to all the players
        /// </summary>
        /// <param name="players">Takes a list of IPlayer</param>
        /// <param name="cardDeck">Takes the card deck</param>
        /// <returns>Returns List of IPlayerModel whit there card hands</returns>
        public static List<IPlayerModel> DealCards(List<IPlayerModel> players, ICardDeck cardDeck)
        {
            do
            {
                foreach (var player in players)
                {
                    // Breaks the loop if last card have been given out
                    if (cardDeck.Cards.Count == 0)
                    {
                        break;
                    }

                    player.Cards.Add(cardDeck.Cards[0]);
                    cardDeck.Cards.Remove(cardDeck.Cards[0]);
                }
            } while (cardDeck.Cards.Count >= 1);

            return players;
        }

        /// <summary>
        /// Creates an instance of IRemoveCards
        /// </summary>
        /// <returns></returns>
        public static IRemoveCards RemoveCards()
        {
            return new RemoveCards();
        }
    }
}