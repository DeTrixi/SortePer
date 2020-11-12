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

            IRemoveCards removeCards = GameFactory.RemoveCards();
            // Creates a new game with players in
            // And is access to game logic

            if (removeCards is RemoveCards rem)
            {
                rem.RemoveCardsFromPlayers += (sender, s) => Console.WriteLine(s);
            }

            IGameManager game = GameFactory.CreateGameLogic(players, GameFactory.CreateValidator(), removeCards);

            #endregion


            #region SubScribeToEvents



            #endregion

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

                    // TODO if list already contains name try again
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