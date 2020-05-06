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
        Random rand;

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
        /// Executes one of the possible community chest modifiers randomly.
        /// </summary>
        /// <param name="activePlayer"></param>
        public void ExecuteCommunityChest(PlayerViewModel activePlayer)
        {
            rand = new Random();
            int exec = rand.Next(15);

            switch (exec)
            {
                case 0:
                    GoToSeeStr(activePlayer);
                    break;
                case 1:
                    KreuzwortGewonnen(activePlayer);
                    break;
                case 2:
                    GetRent(activePlayer);
                    break;
                case 3:
                    GetOutOfJail(activePlayer);
                    break;
                case 4:
                    GoToGo(activePlayer);
                    break;
                case 5:
                    GetDiv(activePlayer);
                    break;
                case 6:
                    GoToSchlossAllee(activePlayer);
                    break;
                case 7:
                    GoToOpernplatz(activePlayer);
                    break;
                case 8:
                    MoveBackThree(activePlayer);
                    break;
                case 9:
                    RenovateHouses(activePlayer);
                    break;
                case 10:
                    RenovateStreets(activePlayer);
                    break;
                case 11:
                    Drunk(activePlayer);
                    break;
                case 12:
                    TooFast(activePlayer);
                    break;
                case 13:
                    GoToPrison(activePlayer);
                    break;
                case 14:
                    PaySchool(activePlayer);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Moves a player to "Seestraße".
        /// </summary>
        /// <param name="playerToMove">The player to move</param>
        public void GoToSeeStr(PlayerViewModel playerToMove)
        {
            if (playerToMove.CurrentPosition < 11)
            {
                playerToMove.PlayerMoveToPosition(11, false);
            }
            else
            {
                playerToMove.PlayerMoveToPosition(11, true);
            }
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Rücke vor bis zur Seestraße. Wenn du über Los kommst, ziehe M200 ein.";
            Content.GameBoardViewModel.GameCards[playerToMove.CurrentPosition].CardAction(playerToMove);
        }

        /// <summary>
        /// A player gets money for an event.
        /// </summary>
        /// <param name="playerWhoWon">The player to get money.</param>
        public void KreuzwortGewonnen(PlayerViewModel playerWhoWon)
        {
            playerWhoWon.PlayerAddMoney(100);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Du hast in einem Kreuzworträtselwettbewerb gewonnen. Ziehe M100 ein.";
        }

        /// <summary>
        /// An event where the player gets money as "rent".
        /// </summary>
        /// <param name="playerToGetPayed">The player to get money</param>
        public void GetRent(PlayerViewModel playerToGetPayed)
        {
            playerToGetPayed.PlayerAddMoney(150);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Miete und Anleihezinsen werden fällig. Die Bank zahlt Dir M150.";
        }

        /// <summary>
        /// An event where the player gets a "Get out of jail" card.
        /// </summary>
        /// <param name="playerToGetOut">The player to get the card</param>
        public void GetOutOfJail(PlayerViewModel playerToGetOut)
        {
            ///TODO Implement Get Out OF Jail Free Card.
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Du kommst aus dem Gefängnis frei.";
        }

        /// <summary>
        /// An event where the player gets moved to the "Go!" field.
        /// </summary>
        /// <param name="playerToMove">The player to move</param>
        public void GoToGo(PlayerViewModel playerToMove)
        {
            playerToMove.PlayerMoveToPosition(0, true);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Rücke bis auf Los vor.";
        }

        /// <summary>
        /// An event where the player gets money as "dividend".
        /// </summary>
        /// <param name="playerToGetDiv">The player to get money</param>
        public void GetDiv(PlayerViewModel playerToGetDiv)
        {
            playerToGetDiv.PlayerAddMoney(50);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Die Bank zahlt dir eine Dividende von M50.";
        }

        /// <summary>
        /// An event where the player gets moved to "SchlossAllee".
        /// </summary>
        /// <param name="playerToMove">The player to get moved</param>
        public void GoToSchlossAllee(PlayerViewModel playerToMove)
        {
            playerToMove.PlayerMoveToPosition(39, false);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Rücke vor bis zu Schlossallee.";
            Content.GameBoardViewModel.GameCards[playerToMove.CurrentPosition].CardAction(playerToMove);
        }

        /// <summary>
        /// An event where the player gets moved to "Opernplatz".
        /// </summary>
        /// <param name="playerToMove">The player to get moved</param>
        public void GoToOpernplatz(PlayerViewModel playerToMove)
        {
            if (playerToMove.CurrentPosition >= 24)
            {
                playerToMove.PlayerMoveToPosition(24, true);
            }
            else
            {
                playerToMove.PlayerMoveToPosition(24, false);
            }
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Rücke vor bis zum Opernplatz. Wenn Du über Los kommst, ziehe M200 ein.";
            Content.GameBoardViewModel.GameCards[playerToMove.CurrentPosition].CardAction(playerToMove);
        }

        /// <summary>
        /// An event where the player gets moved three steps back.
        /// </summary>
        /// <param name="playerToMove">The player to get moved</param>
        public void MoveBackThree(PlayerViewModel playerToMove)
        {
            if (playerToMove.CurrentPosition == 2)
            {
                playerToMove.PlayerMoveToPosition(Content.GameBoardViewModel.GameCards.Length , false);
            }
            playerToMove.PlayerMoveToPosition(playerToMove.CurrentPosition - 3, false);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Gehe 3 Felder zurück.";
        }

        /// <summary>
        /// An event where the player loses money by "renovating houses".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void RenovateHouses(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay.AmountHouses * 25);
            playerToPay.PlayerRemoveMoney(playerToPay.AmountHotels * 100);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Lasse alle Deine Häuser renovieren. Zahle an die Bank für jedes Haus M25, für jedes Hotel M100.";
        }

        /// <summary>
        /// An event where the player loses money by "renovating streets".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void RenovateStreets(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(playerToPay.AmountHouses * 40);
            playerToPay.PlayerRemoveMoney(playerToPay.AmountHotels * 115);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Du wirst zu Strassenausbesserungsarbeiten herangezogen. Zahle für deine Häuser und Hotels. M40 je Haus. M115 je Hotel an die Bank.";
        }

        /// <summary>
        /// An event where the player loses money by "being drunk".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void Drunk(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(20);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Betrunken im Dienst. Strafe M20.";
        }

        /// <summary>
        /// An event where the player loses money by "being too fast".
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void TooFast(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(15);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Strafe für zu schnelles Fahren M15.";
        }

        /// <summary>
        /// An event where the player is going to prison.
        /// </summary>
        /// <param name="playerToGo">The player to go to prison</param>
        public void GoToPrison(PlayerViewModel playerToGo)
        {
            playerToGo.PlayerGoToPrison();
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Gehe in das Gefängnis. Begib Dich direkt dorthin. Gehe nicht über Los. Ziehe nicht M200 ein.";
        }

        /// <summary>
        /// An event where the player loses money by paying the school.
        /// </summary>
        /// <param name="playerToPay">The player to lose money</param>
        public void PaySchool(PlayerViewModel playerToPay)
        {
            playerToPay.PlayerRemoveMoney(150);
            Content.CommunityDetailsViewModel.IconSource = "";
            Content.CommunityDetailsViewModel.CommunityText = "Zahle Schulgeld.";
        }
    }
}
