using System;
using System.Collections.Generic;
using SortePerLibrary.Factories;
using SortePerLibrary.Models;

namespace SortePerLibrary.Services
{
    /// <summary>
    /// This class is the primary Game Loop
    /// </summary>
    public class GameManager : IGameManager
    {
        // This is a private list of players
        private List<IPlayerModel> _players;

        // This is a private Validator
        private IValidate _validate;

        // RemoveCards Remove card from users and invokes a event
        private IRemoveCards _removeCards;


        public GameManager(List<IPlayerModel> players, IValidate validate, IRemoveCards removeCards)
        {
            _players = players;
            _validate = validate;
            _removeCards = removeCards;
            RunGame();
        }

        private void RunGame()
        {
            // CREATE GAME BOARD
            // TODO Look for if CardModel value is the same

            // Removes pair if eny
            RemovePairs();

            // TODO If card value is the same drop the cards to Used cards or gone send message to frontend witch cards i dropped
            // TODO Generate a random player to start the game

            Console.WriteLine("Game is running");


            // // Checks if there are a Loser!
            // if (_validate.ValidateIsLoser(_players))
            // {
            //    YouLostTheGame.Invoke(this , some username);
            // }
        }

        // Start The Game

        // TODO Let the player draw a card from the next in the list if player is last in list draw from the first
        // TODO add the card to players hand (list of cards)
        // TODO Look for if CardModel value is the same
        // TODO If card value is the same drop the cards to Used cards or gone send message to frontend witch cards i dropped
        // TODO if player hand is empty Remove player from the game
        // TODO if player is out of the game inform frontend
        // TODO Continue there are no more players
        private void RemovePairs()
        {
            if (_validate.AreTherePairsInHand(_players))
            {
                 _removeCards.RemoveCardFromPlayers( _players);
            }
        }
    }
}