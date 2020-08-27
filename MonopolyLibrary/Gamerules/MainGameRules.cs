using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonopolyLibrary.Gamerules
{
    /// <summary>
    /// Main Game Rules Class placeholder. Work in Progress!
    /// </summary>
    public class MainGameRules
    {
        public ManagingPlayer ManagingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }



        public MainGameRules()
        {
        }

        /// <summary>
        /// Dice roll if the active player is currently in prison.
        /// Work in progress!
        /// </summary>
        public void PrisonRoll(DiceViewModel diceViewModel)
        {
            WindowContent.GetWindowContent().GetViewModel<DiceViewModel>().RollDice();
            if (WindowContent.GetWindowContent().GetViewModel<DiceViewModel>().getDoublets())
            {
                ManagingPlayer.GetActivePlayer().PlayerGetsOutOfPrison();
                return;
            }
            ManagingPlayer.GetActivePlayer().PrisonRoll++;
            if (ManagingPlayer.GetActivePlayer().PrisonRoll == 3)
            {
                ManagingPlayer.GetActivePlayer().PlayerGetsOutOfPrison();
            }
            ManagingPlayer.NextPlayer();
        }



    }
}