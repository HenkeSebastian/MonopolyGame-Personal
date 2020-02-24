using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.Utility.Commands
{
    public class StreetBuyingCommands
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public StreetBuyingCommands(WindowContent content)
        {
            Content = content;
        }


        /// <summary>
        /// The currently active player buys a street. The money will be taken from the players cash pile and the ownership of the card will be registered.
        /// REVIEW Must be refactored for the new implementation of the street interactions.
        /// </summary>
        public void BuyStreet()
        {
            //Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].PlayerBuyingStreet(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);
            //Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].AddOwningPlayer(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);
            Content.ManagingPlayer.GivePlayerGameCard(Content.ManagingPlayer.GetActivePlayer(), Content.GameViewViewModel.GetPlayerGameCard(Content.ManagingPlayer.GetActivePlayer()));
            Content.ManagingPlayer.RemovePlayerMoney(Content.ManagingPlayer.GetActivePlayer(), Content.GameViewViewModel.GetPlayerGameCard(Content.ManagingPlayer.GetActivePlayer()).GameCard.StreetPrice);
            //Content.CloseSecondaryWindow();
        }
    }
}
