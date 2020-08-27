
using MonopolyLibrary.PlayerHandling;
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

        public static WindowContent Content { get => WindowContent.GetWindowContent(); }
        private ManagingPlayer ManagingPlayer
        {
            get => Content.GetManagingPlayer();
        }

        public GameCardCommands()
        {

        }


        /// <summary>
        /// The given game card will be slotted into the property in the game view view model.
        /// </summary>
        /// <param name="gcvm">The given game card view model.</param>
        public void SetMouseOverGameCard(GameCardViewModel gcvm)
        {

            Content.SetMouseOverGameCard(gcvm);
            if (Content.GetCurrentDetailsViewModel() != Content.GetDetailsViewModel<StreetBuyingViewModel>() && Content.GetCurrentDetailsViewModel() != Content.GetDetailsViewModel<StreetInteractionViewModel>())
            {
                Content.SetDetailsViewModelActive<GameCardViewModel>();
            }
        }

        /// <summary>
        /// The game card view model property in the game view view model will be cleared.
        /// </summary>
        public void ClearMouseOverGameCard()
        {
            Content.ClearMouseOverGameCard();
            if (Content.GetCurrentDetailsViewModel() != Content.GetDetailsViewModel<StreetBuyingViewModel>() && Content.GetCurrentDetailsViewModel() != Content.GetDetailsViewModel<StreetInteractionViewModel>())
            {
                Content.SetDetailsViewModelActive<IdleDetailsViewModel>();
            }
        }


        /// <summary>
        /// </summary>
        /// <param name="activePlayer">The active player.</param>
        /// <param name="gameCardViewModel">The game card that the active player is on.</param>
        public void OpenStreetBuying(PlayerViewModel activePlayer, GameCardViewModel gameCardViewModel)
        {
            Content.GetViewModel<StreetBuyingViewModel>().OpenStreetBuyingWindow(activePlayer, gameCardViewModel);
        }

        /// <summary>
        /// Opens the Street Interaction View and sets all necessary flags.
        /// </summary>
        /// <param name="gameCardViewModel"></param>
        public void OpenStreetInteraction(GameCardViewModel gameCardViewModel)
        {
            if (gameCardViewModel.IsGameCardInteractable())
            {
                PlayerViewModel activePlayer = ManagingPlayer.GetActivePlayer();
                if (Content.GetCurrentDetailsViewModel() == Content.GetDetailsViewModel<StreetInteractionViewModel>() && Content.GetDetailsViewModel<StreetInteractionViewModel>().GetInteractionGameCard() == gameCardViewModel)
                {
                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetGameCardInteraction(false);
                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetInteractionGameCard(null);
                    Content.SetDetailsViewModelActive<IdleDetailsViewModel>(true);
                    return;
                }
                if (Content.GetCurrentDetailsViewModel() != Content.GetDetailsViewModel<StreetBuyingViewModel>())
                {
                    if (Content.GetDetailsViewModel<StreetInteractionViewModel>().GameCard != null)
                    {
                        Content.GetDetailsViewModel<StreetInteractionViewModel>().SetGameCardInteraction(false);
                    }
                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetInteractionGameCard(gameCardViewModel);
                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetGameCardInteraction(true);

                    if (gameCardViewModel.GetOwningPlayer() == ManagingPlayer.GetActivePlayer())
                    {
                        if (ManagingPlayer.GetActivePlayer().IsMonopolyComplete(gameCardViewModel))
                        {
                            switch (gameCardViewModel.NrOfHouses)
                            {
                                case -1:
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableBuying(activePlayer.PlayerCheckBalance(gameCardViewModel.Mortgage[1]));
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(false);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterBuying(activePlayer.PlayerCashAfterPayingMortgage(gameCardViewModel));
                                    break;
                                case 5:
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableBuying(false);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(true);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterSelling(activePlayer.PlayerCashAfterSellingHouse(gameCardViewModel));
                                    break;
                                default:
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableBuying(activePlayer.PlayerCheckBalance(gameCardViewModel.HousePrice));
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(true);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterBuying(activePlayer.PlayerCashAfterBuildingHouse(gameCardViewModel));
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterSelling(activePlayer.PlayerCashAfterSellingHouse(gameCardViewModel));

                                    break;
                            }
                        }
                        else
                        {
                            switch (gameCardViewModel.NrOfHouses)
                            {
                                case -1:
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableBuying(activePlayer.PlayerCheckBalance(gameCardViewModel.Mortgage[1]));
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(false);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterBuying(activePlayer.PlayerCashAfterPayingMortgage(gameCardViewModel));
                                    break;
                                case 0:
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableBuying(false);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(true);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterSelling(activePlayer.PlayerCashAfterSellingHouse(gameCardViewModel));
                                    break;
                                default:
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableBuying(false);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(true);
                                    Content.GetDetailsViewModel<StreetInteractionViewModel>().SetCashAfterBuying(activePlayer.PlayerCashAfterBuildingHouse(gameCardViewModel));
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Content.GetDetailsViewModel<StreetBuyingViewModel>().SetEnableBuying(false);
                        Content.GetDetailsViewModel<StreetInteractionViewModel>().SetEnableSelling(false);
                    }
                    Content.GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
                    Content.SetDetailsViewModelActive<StreetInteractionViewModel>();
                }
            }
        }
    }
}
