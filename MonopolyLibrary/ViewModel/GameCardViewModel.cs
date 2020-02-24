using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class GameCardViewModel
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }


        private GameCardModel gameCard;

        public GameCardModel GameCard
        {
            get { return gameCard; }
            set { gameCard = value; }
        }

        /// <summary>
        /// Constructor for the Game Card View Model.
        /// </summary>
        public GameCardViewModel()
        {

        }

        /// <summary>
        /// Finds a player on the Game Card.
        /// </summary>
        /// <param name="playerToFind">The player to find</param>
        /// <returns>Returns the Collection Index of the player on the Card.</returns>
        public int FindPlayerViewModelOnCard(PlayerViewModel playerToFind)
        {
            return GameCard.PlayerOnGameCard.IndexOf(playerToFind);
        }

        /// <summary>
        /// Delets a player from the collection/card.
        /// </summary>
        /// <param name="index">Index of the player to delete</param>
        public void DeletePlayerOnCard(int index)
        {
            GameCard.PlayerOnGameCard.RemoveAt(index);
        }

        /// <summary>
        /// Adds a Player to the collection/card.
        /// </summary>
        /// <param name="playerToAdd">The player to add</param>
        public void AddPlayerOnCard(PlayerViewModel playerToAdd)
        {
            GameCard.PlayerOnGameCard.Add(playerToAdd);
        }

        /// <summary>
        /// A Player buying a Street. It will be added to the Players owned streets array.
        /// </summary>
        /// <param name="buyingPlayer">The buying player.</param>
        public void PlayerBuyingStreet(PlayerViewModel buyingPlayer)
        {
            buyingPlayer.Player.OwnedStreets[GameCard.OwnerArrayID] = this;
        }

        /// <summary>
        /// Adds an owner to the Street object.
        /// </summary>
        /// <param name="owningPlayer">The player to add as an owner</param>
        public void AddOwningPlayer(PlayerViewModel owningPlayer)
        {
            GameCard.OwningPlayer = owningPlayer;
        }

        /// <summary>
        /// Checks if the street already has an owner.
        /// </summary>
        /// <returns>Returns true if the street is owned by a player and false if it is still buyable.</returns>
        public bool CheckStreetOwner()
        {
            if (GameCard.OwningPlayer != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CardActionOld(PlayerViewModel playerOnCard)
        {
            switch (GameCard.StreetState)
            {
                case StreetName.LOS:
                    Content.ManagingPlayer.GivePlayerMoney(playerOnCard, 200);
                    break;
                case StreetName.Badstraße:
                    break;
                case StreetName.Gemeinschaftsfeld:
                    break;
                case StreetName.Turmstraße:
                    break;
                case StreetName.Einkommenssteuer:
                    break;
                case StreetName.Südbahnhof:
                    break;
                case StreetName.Chausseestraße:
                    break;
                case StreetName.Ereignisfeld:
                    break;
                case StreetName.Elisenstraße:
                    break;
                case StreetName.Poststraße:
                    break;
                case StreetName.Gefängnis:
                    break;
                case StreetName.Seestraße:
                    break;
                case StreetName.EWerk:
                    break;
                case StreetName.Hafenstraße:
                    break;
                case StreetName.NeueStraße:
                    break;
                case StreetName.Westbahnhof:
                    break;
                case StreetName.MünchnerStraße:
                    break;
                case StreetName.WienerStraße:
                    break;
                case StreetName.BerlinerStraße:
                    break;
                case StreetName.FreiParken:
                    break;
                case StreetName.TheaterStraße:
                    break;
                case StreetName.Museumstraße:
                    break;
                case StreetName.Opernplatz:
                    break;
                case StreetName.NordBahnhof:
                    break;
                case StreetName.Lessingstraße:
                    break;
                case StreetName.Schillerstraße:
                    break;
                case StreetName.Wasserwerk:
                    break;
                case StreetName.Goethestraße:
                    break;
                case StreetName.InDasGefängnis:
                    //Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].PlayerMoveToPosition(10, false);
                    Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].PlayerGoToPrison();
                    break;
                case StreetName.Rathausplatz:
                    break;
                case StreetName.Hauptstraße:
                    break;
                case StreetName.Bahnhofstraße:
                    break;
                case StreetName.Hauptbahnhof:
                    break;
                case StreetName.Parkstraße:
                    break;
                case StreetName.Zusatzsteuer:
                    break;
                case StreetName.Schlossallee:
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Actions that will be triggered if a player is landing on said card.
        /// </summary>
        /// <param name="playerOnCard">The player triggering the action</param>
        public void CardAction(PlayerViewModel playerOnCard)
        {
            switch (GameCard.StreetState)
            {
                case StreetName.LOS:
                    Content.ManagingPlayer.GivePlayerMoney(playerOnCard, 200);
                    break;
                case StreetName.Gemeinschaftsfeld:
                    break;
                case StreetName.Einkommenssteuer:
                    break;
                case StreetName.Südbahnhof:
                    break;
                case StreetName.Ereignisfeld:
                    break;
                case StreetName.Gefängnis:
                    break;
                case StreetName.EWerk:
                    break;
                case StreetName.Westbahnhof:
                    break;
                case StreetName.FreiParken:
                    break;
                case StreetName.NordBahnhof:
                    break;
                case StreetName.Wasserwerk:
                    break;
                case StreetName.InDasGefängnis:
                    Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].PlayerMoveToPosition(playerOnCard, 10, false);
                    Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].PlayerGoToPrison();
                    break;
                case StreetName.Hauptbahnhof:
                    break;
                case StreetName.Zusatzsteuer:
                    break;
                default:
                    if (Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].GameCard.OwningPlayer != null)
                    {
                        if (Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].GameCard.OwningPlayer != Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex])
                        {
                            Content.ManagingPlayer.PlayerGivesPlayerMoney(Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].GameCard.OwningPlayer, Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex], Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].GameCard.RentPrices[Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].GameCard.NrOfHouses]);
                        }
                    }
                    else
                    {
                        //Content.ButtonBindings.ButtonCommands.GameCardCommands.OpenStreetBuying(Content.ManagingPlayer.GetActivePlayer(), Content.GameViewViewModel.GetPlayerGameCard(Content.ManagingPlayer.GetActivePlayer()));
                    }
                    break;
            }
        }
    }
}
