using System;
using System.Collections.Generic;
using SortePerLibrary.Factories;
using SortePerLibrary.Models;

namespace SortePerLibrary.Services
{
    /// <summary>
    /// This class is the primary Game Loop
    /// </summary>
    public class GameLogic : IGameLogic
    {
        private List<IPlayerModel> _players;

        private IValidate _validate;
        //private ICardDeck _cardDeck;


        public event EventHandler<string> CardRemovedFromDeck;

        public GameLogic(List<IPlayerModel> players, IValidate validate)
        {
            _players = players;
            _validate = validate;
            RunGame();
        }

        private async void RunGame()
        {
            // Keeps the game running while there are other cards then black Per left
            bool OnlyBalckPer = false;


            do
            {
                Console.WriteLine("Game is running");
            } while (OnlyBalckPer == false);


            // CREATE GAME BOARD
            // TODO Look for if CardModel value is the same
            // TODO If card value is the same drop the cards to Used cards or gone send message to frontend witch cards i dropped
        }

        // Start The Game
        // TODO Generate a random player to start the game
        // TODO Let the player draw a card from the next in the list if player is last in list draw from the first
        // TODO add the card to players hand (list of cards)
        // TODO Look for if CardModel value is the same
        // TODO If card value is the same drop the cards to Used cards or gone send message to frontend witch cards i dropped
        // TODO if player hand is empty Remove player from the game
        // TODO if player is out of the game inform frontend
        // TODO Continue there are no more players
    }
}