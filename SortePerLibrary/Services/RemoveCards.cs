using System;
using System.Collections.Generic;
using System.Linq;
using SortePerLibrary.Models;

namespace SortePerLibrary.Services
{
    /// <summary>
    /// This method forwards single users to remove from hand
    public class RemoveCards : IRemoveCards
    {
        public event EventHandler<string> RemoveCardsFromPlayers;

        /// <summary>
        /// This method sends player to get removed pairs
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public List<IPlayerModel> RemoveCardFromPlayers(List<IPlayerModel> players)
        {
            List<IPlayerModel> newPlayerList = new List<IPlayerModel>();
            foreach (var player in players)
            {
                newPlayerList.Add(RemoveCardFromDeck(player));
            }

            return newPlayerList;
        }

        /// <summary>
        /// This method removes card from the stack
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public IPlayerModel RemoveCardFromDeck(IPlayerModel player)
        {
            for (int i = 0; i < player.Cards.Count; i++)
            {
                var cardValue = player.Cards[i].CardValue;
                for (int j = i + 1; j < player.Cards.Count; j++)
                {
                    if (player.Cards[i].CardValue == player.Cards[j].CardValue)
                    {
                        RemoveCardsFromPlayers?.Invoke(this, $"{cardValue} has been removed from {player.Name}");
                        player.Cards.Remove(player.Cards[i]);
                        player.Cards.Remove(player.Cards[j]);
                    }
                }
            }

            return player;
        }
    }
}