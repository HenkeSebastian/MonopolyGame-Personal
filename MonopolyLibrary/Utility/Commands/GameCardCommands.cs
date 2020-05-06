
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonopolyLibrary.Utility.Commands
{
    public class GameCardCommands
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public GameCardCommands(WindowContent content)
        {
            Content = content;
        }


        /// <summary>
        /// The given game card will be slotted into the property in the game view view model.
        /// </summary>
        /// <param name="gcvm">The given game card view model.</param>
        public void SetMouseOverGameCard(GameCardViewModel gcvm)
        {

            Content.GameBoardViewModel.MouseOverGameCard = gcvm;
            if (Content.SelectedDetailsViewModel != Content.StreetBuyingViewModel && Content.SelectedDetailsViewModel != Content.StreetInteractionViewModel)
            {
            Content.ChangeDetailsView(Windows.GameCardDetails);
            }
        }

        /// <summary>
        /// The game card view model property in the game view view model will be cleared.
        /// </summary>
        public void ClearMouseOverGameCard()
        {
            Content.GameBoardViewModel.MouseOverGameCard = null;
            if (Content.SelectedDetailsViewModel != Content.StreetBuyingViewModel && Content.SelectedDetailsViewModel != Content.StreetInteractionViewModel)
            {
            Content.ChangeDetailsView(Windows.IdleDetails);
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="activePlayer">The active player.</param>
        /// <param name="gameCardViewModel">The game card that the active player is on.</param>
        public void OpenStreetBuying(PlayerViewModel activePlayer, GameCardViewModel gameCardViewModel)
        {
            Content.StreetBuyingViewModel.GameCard = gameCardViewModel;
            Content.StreetBuyingViewModel.EnableBuying = activePlayer.PlayerCheckBalance(gameCardViewModel.StreetPrice);
            Content.StreetBuyingViewModel.CashAfterBuying = activePlayer.PlayerCashAfterBuying(gameCardViewModel);
            Content.GameBoardViewModel.SetDoneButton(false);
            Content.ChangeDetailsView(Windows.StreetBuyingDetails);
        }

        /// <summary>
        /// Opens the Street Interaction View and sets all necessary flags.
        /// </summary>
        /// <param name="gameCardViewModel"></param>
        public void OpenStreetInteraction(GameCardViewModel gameCardViewModel)
        {
            if (gameCardViewModel.CardInteractable == true)
            {
                PlayerViewModel activePlayer = Content.ManagingPlayer.GetActivePlayer();
                if (Content.SelectedDetailsViewModel == Content.StreetInteractionViewModel && Content.StreetInteractionViewModel.GameCard == gameCardViewModel)
                {
                    Content.StreetInteractionViewModel.GameCard = null;
                    Content.ChangeDetailsView(Windows.IdleDetails, true);
                    return;
                }

                Content.StreetInteractionViewModel.GameCard = gameCardViewModel;

                if (gameCardViewModel.OwningPlayer == Content.ManagingPlayer.GetActivePlayer())
                {
                    if (Content.ManagingPlayer.GetActivePlayer().Monopolies[gameCardViewModel.MonopoliesID] == true)
                    {
                        switch (gameCardViewModel.NrOfHouses)
                        {
                            case -1:
                                Content.StreetInteractionViewModel.EnableBuying = activePlayer.PlayerCheckBalance(gameCardViewModel.Mortgage[1]);
                                Content.StreetInteractionViewModel.EnableSelling = false;
                                Content.StreetInteractionViewModel.CashAfterBuying = activePlayer.PlayerCashAfterPayingMortgage(gameCardViewModel);
                                break;
                            case 0:
                                Content.StreetInteractionViewModel.EnableBuying = activePlayer.PlayerCheckBalance(gameCardViewModel.Mortgage[1]);
                                Content.StreetInteractionViewModel.CashAfterBuying = activePlayer.PlayerCashAfterBuildingHouse(gameCardViewModel);
                                Content.StreetInteractionViewModel.EnableSelling = true;
                                Content.StreetInteractionViewModel.CashAfterSelling = activePlayer.PlayerCashAfterSellingHouse(gameCardViewModel);
                                break;
                            case 4:
                                Content.StreetInteractionViewModel.EnableBuying = false;
                                Content.StreetInteractionViewModel.EnableSelling = true;
                                Content.StreetInteractionViewModel.CashAfterSelling = activePlayer.PlayerCashAfterSellingHouse(gameCardViewModel);
                                break;
                            default:
                                Content.StreetInteractionViewModel.EnableBuying = activePlayer.PlayerCheckBalance(gameCardViewModel.HousePrice);
                                Content.StreetInteractionViewModel.EnableSelling = true;
                                Content.StreetInteractionViewModel.CashAfterBuying = activePlayer.PlayerCashAfterBuildingHouse(gameCardViewModel);
                                break;
                        }
                    }
                    else
                    {
                        switch (gameCardViewModel.NrOfHouses)
                        {
                            case -1:
                                Content.StreetInteractionViewModel.EnableBuying = activePlayer.PlayerCheckBalance(gameCardViewModel.Mortgage[1]);
                                Content.StreetInteractionViewModel.EnableSelling = false;
                                Content.StreetInteractionViewModel.CashAfterBuying = activePlayer.PlayerCashAfterPayingMortgage(gameCardViewModel);
                                break;
                            case 0:
                                Content.StreetInteractionViewModel.EnableBuying = false;
                                Content.StreetInteractionViewModel.EnableSelling = true;
                                Content.StreetInteractionViewModel.CashAfterSelling = activePlayer.PlayerCashAfterSellingHouse(gameCardViewModel);
                                break;
                            default:
                                Content.StreetInteractionViewModel.EnableBuying = false;
                                Content.StreetInteractionViewModel.EnableSelling = true;
                                Content.StreetInteractionViewModel.CashAfterBuying = activePlayer.PlayerCashAfterBuildingHouse(gameCardViewModel);
                                break;
                        }
                    }
                }
                else
                {
                    Content.StreetBuyingViewModel.EnableBuying = false;
                    Content.StreetInteractionViewModel.EnableSelling = false;
                }
                Content.GameBoardViewModel.SetDoneButton(true);
                Content.ChangeDetailsView(Windows.StreetInteractionDetails);
            }
        }
    }
}
