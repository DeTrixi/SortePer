using System;

namespace SortePerLibrary.Services
{
    public interface IValidate
    {
        /// <summary>
        ///  // This method validates the string for correct values
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true or false</returns>
        bool ValidatePlayerName(string name);

        bool ValidateAmountOfPlayers(int amount);

    }

    public class Validate : IValidate
    {
        /// <summary>
        ///  // This method validates the string for correct values
        /// </summary>
        /// <param name="name"></param>
        /// <returns>true or false</returns>
        public bool ValidatePlayerName(string name)
        {
            return String.IsNullOrEmpty(name);
        }

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



    }
}