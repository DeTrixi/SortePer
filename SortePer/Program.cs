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
            // Ask for how many players that wil participate
            int numbersOfPlayers = AskForNumberOfPlayers();


            // List of names that has entered the game from the console
            List<String> names = AskUsersForThereNames(numbersOfPlayers);


            // Creates a new game with players in
            IGameLogic game = GameFactory.CreateGameLogic(names);


            // TODO Subscribe to events START




            // TODO Subscribe to events END





            Console.ReadLine();
            // Getting Started


            // This Creates a game and puts a game bord in to it





            // END THE GAME
            // TODO display LOSER name and a picture of PER

            Console.WriteLine("Hello Teacher");
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
                    Console.WriteLine("This is not a number or it is not between 3-8");
                }
            } while (continueValue == true);

            return amountOfPlayers;
        }


    }
}