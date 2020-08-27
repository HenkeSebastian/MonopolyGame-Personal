using MonopolyLibrary.PlayerHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility.Commands
{
    public class StartingRollCommands
    {
        ManagingPlayer managingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }

        public StartingRollCommands()
        {
        }


        /// <summary>
        /// Opens the game view window.
        /// </summary>
        public void GoToGameView()
        {
            managingPlayer.SetPlayerIDActive(0);
            WindowContent.GetWindowContent().SetViewModelActive(Windows.GameBoardScreen);
        }
    }
}
