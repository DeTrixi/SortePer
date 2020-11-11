using System.Collections.Generic;

namespace SortePerLibrary.Models
{
    public interface IGameBoard
    {
        List<IPlayerModel> PlayerModel { get; set; }
    }
}