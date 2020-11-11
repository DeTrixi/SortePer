using System.Collections.Generic;

namespace SortePerLibrary.Models
{
    public class GameBoard : IGameBoard
    {
        // This list contains all the players and their cards
        public List<IPlayerModel> PlayerModel { get; set; } = new List<IPlayerModel>();
    }
}