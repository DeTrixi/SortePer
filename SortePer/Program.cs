using System;
using System.Collections.Generic;
using System.Threading.Channels;
using SortePerLibrary.Factories;
using SortePerLibrary.Models;
using SortePerLibrary.Services;

namespace SortePer
{
    class Program
    {
        static void Main(string[] args)
        {
            #region InitGame

            bool GameIsStillRunning = true;

            // Ask for how many players that wil participate
            int numbersOfPlayers = AskForNumberOfPlayers();
            // List of names that has entered the game from the console
            List<String> names = AskUsersForThereNames(numbersOfPlayers);
            // Generate the list with users
            List<IPlayerModel> players = GameFactory.CreateUsers(names);
            // Create a deck of cards
            ICardDeck cardDeck = GameFactory.CreateCardDeck();
            // Shuffle tha card in no order
            cardDeck = GameFactory.ShuffleCards(cardDeck);
            // Deals the card uot to all the players
            players = GameFactory.DealCards(players, cardDeck);

            IValidate validate = GameFactory.CreateValidator();

            IRemoveCards removeCards = GameFactory.RemoveCards();
            // Creates a new game with players in
            // And is access to game logic

            #endregion


            #region SubScribeToEvents

            // Event if invoked info of with pair and from who wil be displayed in console
            removeCards.RemoveCardsFromPlayers += (sender, s) => Console.WriteLine(s);
            // Event if invoked loser will be displayed to Console
            validate.LoserHasBeenFound += (sender, s) =>
            {
                Console.WriteLine(s);
                GameIsStillRunning = false;
                Console.ReadLine();

            };

            #endregion

            #region Game

            IGameManager game = GameFactory.CreateGameLogic(players, validate, removeCards);

            // subscribes to event next player to play the game
            game.CallNexPlayer += (sender, s) => Console.WriteLine($"{s}");
            // Subscribes to players has no more cards left an has left the game
            game.PlayerHasNoMoreCardsAndHasLeftTheGame += (sender, s) => Console.WriteLine(s);

            #endregion

            // This is the main game loop
            Console.WriteLine("\nPress any key to play the game");
            //Console.ReadLine();

            game.PlayerCallsTheGameFirstTime();
            do
            {



                Console.ReadLine();
                Console.Clear();
                game.Play();

                // Use take card method

            } while (GameIsStillRunning);


            Console.WriteLine("Create By Flemming Lyng");
            Console.ReadLine();
        }


        /// <summary>
        /// This method will get the names of all the players
        /// </summary>
        /// <returns>returns a list of names</returns>
        /// <exception cref="NotImplementedException"></exception>
        private static List<string> AskUsersForThereNames(int amountOfPlayers)
        {
            // Get names for all players
            // Add player to list
            bool continuValue = true;
            List<String> userNames = new List<string>();


            for (int i = 0; i < amountOfPlayers; i++)
            {
                do
                {
                    Console.Write($"Type in Player {i + 1} Name: ");
                    string name = Console.ReadLine();
                    if (userNames.Contains(name))
                    {
                        Console.WriteLine("this name is already taken try again");
                        continuValue = true;
                    }
                    else if (String.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Name cant be empty Try again");
                    }
                    else
                    {
                        userNames.Add(name);
                        continuValue = false;
                    }

                    if (userNames.Count == amountOfPlayers)
                    {
                        continuValue = false;
                    }
                } while (continuValue == true);
            }


            return userNames;
        }


        /// <summary>
        /// This method ask for amount of players
        /// </summary>
        /// <returns>return the amount of participants</returns>
        private static int AskForNumberOfPlayers()
        {
            bool continueValue = true;
            int amountOfPlayers = 0;
            do
            {
                // Ask for How many players and validates on the amount
                Console.WriteLine("How many players are you");

                if (int.TryParse(Console.ReadLine(), out amountOfPlayers) &&
                    GameFactory.CreateValidator().ValidateAmountOfPlayers(amountOfPlayers))
                {
                    continueValue = false;
                }
                else
                {
                    Console.WriteLine("This is not a number or it is not between 3-7");
                }
            } while (continueValue == true);

            return amountOfPlayers;
        }
    }
}