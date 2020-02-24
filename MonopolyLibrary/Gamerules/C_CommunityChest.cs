using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Gamerules
{
    public class C_CommunityChest
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public C_CommunityChest(WindowContent content)
        {
            Content = content;
        }

        public C_CommunityChest()
        {

        }

        /// <summary>
        /// Moves a player to "Seestraße".
        /// </summary>
        /// <param name="playerToMove">The player to move</param>
        public void GoToSeeStr(PlayerViewModel playerToMove)
        {
            if (playerToMove.Player.CurrentPosition < 11)
            {
                playerToMove.PlayerMoveToPosition(playerToMove, 11, false);
            }
            else
            {
                playerToMove.PlayerMoveToPosition(playerToMove, 11, true);
            }
        }

        /// <summary>
        /// A player gets money for an event.
        /// </summary>
        /// <param name="playerWhoWon">The player to get money.</param>
        public void KreuzwortGewonnen(PlayerViewModel playerWhoWon)
        {
            playerWhoWon.PlayerAddMoney(playerWhoWon, 100);
        }

        /// <summary>
        /// An event where the player gets money as "rent".
        /// </summary>
        /// <param name="playerToGetPayed">The player to get money</param>
        public void GetRent(PlayerViewModel playerToGetPayed)
        {
            playerToGetPayed.PlayerAddMoney(playerToGetPayed, 150);
        }

        /// <summary>
        /// An event where the player gets a "Get out of jail" card.
        /// </summary>
        /// <param name="playerToGetOut">The player to get the card</param>
        public void GetOutOfJail(PlayerViewModel playerToGetOut)
        {

        }

        /// <summary>
        /// An event where the player gets moved to the "Go!" field.
        /// </summary>
        /// <param name="playerToMove">The player to move</param>
        public void GoToGo(PlayerViewModel playerToMove)
        {
            playerToMove.PlayerMoveToPosition(playerToMove, 0, true);
        }

        /// <summary>
        /// An event where the player gets money as "dividend".
        /// </summary>
        /// <param name="playerToGetDiv">The player to get money</param>
        public void GetDiv(PlayerViewModel playerToGetDiv)
        {
            playerToGetDiv.PlayerAddMoney(playerToGetDiv, 50);
        }

        /// <summary>
        /// An event where the player gets moved to "SchlossAllee".
        /// </summary>
        /// <param name="playerToMove">The player to get moved</param>
        public void GoToSchlossAllee(PlayerViewModel playerToMove)
        {
            playerToMove.PlayerMoveToPosition(playerToMove, 39, false);
        }

        /// <summary>
        /// An event where the player gets moved to "Opernplatz".
        /// </summary>
        /// <param name="playerToMove">The player to get moved</param>
        public void GoToOpernplatz(PlayerViewModel playerToMove)
        {
            if (playerToMove.Player.CurrentPosition >= 24)
            {
                playerToMove.PlayerMoveToPosition(playerToMove, 24, true);
            }
            else
            {
                playerToMove.PlayerMoveToPosition(playerToMove, 24, false);
            }
        }

        /// <summary>
        /// An event where the player gets moved three steps back.
        /// </summary>
        /// <param name="playerToMove">The player to get moved</param>
        public void MoveBackThree(PlayerViewModel playerToMove)
        {
            playerToMove.PlayerMoveToPosition(playerToMove, playerToMove.Player.CurrentPosition - 3, false);
        }

        /// <summary>
        /// An event where the player loses money by "renovating houses".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void RenovateHouses(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay, playerToPay.Player.AmountHouses * 25);
            playerToPay.PlayerRemoveMoney(playerToPay, playerToPay.Player.AmountHotels * 100);
        }

        /// <summary>
        /// An event where the player loses money by "renovating streets".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void RenovateStreets(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay, playerToPay.Player.AmountHouses * 40);
            playerToPay.PlayerRemoveMoney(playerToPay, playerToPay.Player.AmountHotels * 115);
        }

        /// <summary>
        /// An event where the player loses money by "being drunk".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void Drunk(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay, 20);
        }

        /// <summary>
        /// An event where the player loses money by "being too fast".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void TooFast(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay, 15);
        }

        /// <summary>
        /// An event where the player is going to prison.
        /// </summary>
        /// <param name="playerToGo">The player to go to prison</param>
        public void GoToPrison(PlayerViewModel playerToGo)
        {
            playerToGo.PlayerGoToPrison();
        }

        /// <summary>
        /// An event where the player loses money by paying the school.
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void PaySchool(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay, 150);
        }
    }
}
