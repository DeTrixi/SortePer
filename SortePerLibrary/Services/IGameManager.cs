using System;
using System.Collections.Generic;

namespace SortePerLibrary.Services
{
    public interface IGameManager
    {
        public event EventHandler<string> CallNexPlayer;

        public void Play();

        public void PlayerCallsTheGameFirstTime();

        public event EventHandler<String> PlayerHasNoMoreCardsAndHasLeftTheGame;

    }
}