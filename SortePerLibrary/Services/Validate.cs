using System;
using System.Collections.Generic;
using SortePerLibrary.Models;

namespace SortePerLibrary.Services
{
    public class Validate : IValidate
    {
        public event EventHandler<string> LoserHasBeenFound;

        /// <summary>
        /// This method validates on amount of players is between 3 and 7
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ValidateAmountOfPlayers(int amount)
        {
            if (amount < 3 || amount > 7)
            {
                return false;
            }

            return true;
        }


        /// <summary>
        /// This method checks for duplicates
        /// </summary>
        /// <param name="players"></param>
        /// <returns>Returns true if duplicates exists</returns>
        public bool AreTherePairsInHand(List<IPlayerModel> players)
        {
            foreach (var player in players)
            {
                for (int i = 0; i < player.Cards.Count; i++)
                {
                    for (int j = i + 1; j < player.Cards.Count; j++)
                    {
                        if (player.Cards[i].CardValue == player.Cards[j].CardValue)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public bool ValidateIsLoser(List<IPlayerModel> players)
        {
            if (players.Count == 1)
            {
                LoserHasBeenFound?.Invoke(this, $"{players[0].Name} Has lost The Game");
                return true;
            }

            return false;
        }
    }
}