using System;
using System.Collections.Generic;
using SortePerLibrary.Models;

namespace SortePerLibrary.Services
{
    public class Validate : IValidate
    {
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
            CardValue TempValue;
            bool returnValue = false;
            foreach (var player in players)
            {
                for (int i = 0; i < player.Cards.Count; i++)
                {
                    TempValue = player.Cards[i].CardValue;
                    for (int j = i + 1; j < player.Cards.Count; j++)
                    {
                        if (player.Cards[i].CardValue == player.Cards[j].CardValue)
                        {
                            return true;
                        }
                    }
                }
            }

            return returnValue;
        }

        public bool ValidateIsLoser(List<IPlayerModel> players)
        {
            // TODO if list lenght is 1

            throw new Exception("Validate is loser are not yet implementet");
        }
    }
}