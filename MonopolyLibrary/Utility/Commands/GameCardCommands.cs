
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

            Content.GameViewViewModel.MouseOverGameCard = gcvm;
        }

        /// <summary>
        /// The game card view model property in the game view view model will be cleared.
        /// </summary>
        public void ClearMouseOverGameCard()
        {
            Content.GameViewViewModel.MouseOverGameCard = null;
        }


        /// <summary>
        /// TODO Create a new way to display the street interactions inside the main game view.
        /// </summary>
        /// <param name="activePlayer">The active player.</param>
        /// <param name="gameCardViewModel">The game card that the active player is on.</param>
        public void OpenStreetBuying(PlayerViewModel activePlayer, GameCardViewModel gameCardViewModel)
        {
            //StreetBuyingView streetBuyingView = new StreetBuyingView();
            //Content.SecondaryWindow.Content = streetBuyingView;
            //Content.SecondaryWindow.DataContext = Content.StreetBuyingViewModel;
            //Content.StreetBuyingViewModel.GameCard = gameCardViewModel.GameCard;
            //Content.StreetBuyingViewModel.EnableBuying = activePlayer.PlayerCheckBalance(activePlayer, gameCardViewModel.GameCard.StreetPrice);
            //Content.SecondaryWindow.Show();
        }

        public void OpenStreetInteraction()
        {
            //StreetInteractionView streetInteractionView = new StreetInteractionView();
            //Content.SecondaryWindow.Content = streetInteractionView;
            //Content.SecondaryWindow.DataContext = Content.StreetInteractionViewModel;
            //Content.StreetInteractionViewModel.GameCard = Content.GameViewViewModel.MouseOverGameCard.GameCard;
            //Content.SecondaryWindow.Show();
        }
    }
}
