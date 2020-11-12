using System.Collections.Generic;
using SortePerLibrary.Models;

namespace SortePerLibrary.Services
{
    public interface IValidate
    {
        bool ValidateAmountOfPlayers(int amount);

        public bool ValidateIsLoser(List<IPlayerModel> players);
        bool AreTherePairsInHand(List<IPlayerModel> players);
    }
}