using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonopolyLibrary.Gamerules
{
    public class FirstRollRules: BaseViewModel
    {
        ManagingPlayer ManagingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }

        public FirstRollRules()
        {
        }

        /// <summary>
        /// Cycles Through the players in the game. If all players are cycled through, it finishes the first throw mechanic.
        /// </summary>
        public void FirstThrowNextPlayer()
        {
            if (ManagingPlayer.ActivePlayerIndex == ManagingPlayer.AllPlayers.Count - 1)
            {
                FirstRollDone();
            }
            else
            {
                ManagingPlayer.NextPlayer();
            }
        }

        /// <summary>
        /// Sets the score of the currently active player.
        /// </summary>
        /// <param name="scoreOne">Score of the first die</param>
        /// <param name="scoreTwo">Score of the second die</param>
        public void SetScore(int scoreOne, int scoreTwo)
        {
            ManagingPlayer.AllPlayers[ManagingPlayer.ActivePlayerIndex].FirstThrow = scoreOne + scoreTwo;
        }

        /// <summary>
        /// Sets the flag to finish the first throw mechanic.
        /// </summary>
        public void FirstRollDone()
        {
            ManagingPlayer.AllPlayers = ManagingPlayer.SortPlayersDescending(ManagingPlayer.AllPlayers);
            ManagingPlayer.ResetPlayerIDs();
            WindowContent.GetWindowContent().GetViewModel<DiceViewModel>().EnableDice(false);
            WindowContent.GetWindowContent().GetViewModel<StartingRollViewModel>().SetFirstThrowDone(true);
            ManagingPlayer.SetAllPlayerInactive();
        }
    }
}
