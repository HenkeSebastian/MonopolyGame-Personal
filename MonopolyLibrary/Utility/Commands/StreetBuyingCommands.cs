using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MonopolyLibrary.Gamerules;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Utility.Commands
{
    public class StreetBuyingCommands
    {
        private GamePool gamePool = new GamePool();

        public static WindowContent Content { get => WindowContent.GetWindowContent(); }
        private ManagingPlayer ManagingPlayer
        {
            get => Content.GetManagingPlayer();
        }

        public StreetBuyingCommands()
        {

        }

        /// <summary>
        /// The currently active player buys a street. The money will be taken from the players cash pile and the ownership of the card will be registered.
        /// REVIEW Must be refactored for the new implementation of the street interactions.
        /// </summary>
        public void BuyStreet()
        {
            ManagingPlayer.GetActivePlayer().PlayerAddGameCard(gamePool.GetPlayerGameCard(ManagingPlayer.GetActivePlayer()));
            ManagingPlayer.GetActivePlayer().PlayerRemoveMoney(gamePool.GetPlayerGameCard(ManagingPlayer.GetActivePlayer()).StreetPrice);
            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
            Content.SetDetailsViewModelActive<IdleDetailsViewModel>();
        }
    }
}
