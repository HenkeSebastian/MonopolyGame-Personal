using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MonopolyLibrary.PlayerHandling;

namespace MonopolyLibrary.ViewModel
{
    public class StreetBuyingViewModel: BaseViewModel
    {
        public Windows Window
        {
            get { return Windows.StreetBuyingDetails; }
        }

        private GameCardViewModel gameCard;

        public GameCardViewModel GameCard
        {
            get { return gameCard; }
            set
            {
                gameCard = value;
                OnPropertyChanged("GameCard");
            }
        }

        private int cashAfterBuying;

        public int CashAfterBuying
        {
            get { return cashAfterBuying; }
            set
            {
                cashAfterBuying = value;
                OnPropertyChanged("CashAfterBuying");
            }
        }


        private bool enableBuying;

        public bool EnableBuying
        {
            get { return enableBuying; }
            set
            {
                enableBuying = value;
                OnPropertyChanged("EnableBuying");
            }
        }

        public StreetBuyingViewModel()
        {
        }

        public void SetStreetBuyingGameCard(GameCardViewModel gameCard)
        {
            GameCard = gameCard;
        }

        public void SetEnableBuying(bool state)
        {
            EnableBuying = state;
        }

        public void SetCashAfterBuying(int cash)
        {
            CashAfterBuying = cash;
        }

        public void OpenStreetBuyingWindow(PlayerViewModel player, GameCardViewModel gameCard)
        {
            SetStreetBuyingGameCard(gameCard);
            SetEnableBuying(player.PlayerCheckBalance(gameCard.StreetPrice));
            SetCashAfterBuying(player.PlayerCashAfterBuying(gameCard));
            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(false);
            WindowContent.GetWindowContent().SetDetailsViewModelActive<StreetBuyingViewModel>();
        }
    }
}
