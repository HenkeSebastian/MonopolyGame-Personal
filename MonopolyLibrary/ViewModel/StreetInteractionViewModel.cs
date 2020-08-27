using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class StreetInteractionViewModel: BaseViewModel, INotifyPropertyChanged
    {
        public Windows Window { get => Windows.StreetInteractionDetails; }


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

        private int cashAfterSelling;

        public int CashAfterSelling
        {
            get { return cashAfterSelling; }
            set
            {
                cashAfterSelling = value;
                OnPropertyChanged("CashAfterSelling");
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

        private bool enableSelling;

        public bool EnableSelling
        {
            get { return enableSelling; }
            set
            {
                enableSelling = value;
                OnPropertyChanged("EnableSelling");
            }
        }

        public StreetInteractionViewModel()
        {
        }

        public void SetInteractionGameCard(GameCardViewModel viewModel)
        {
            GameCard = viewModel;
        }

        public GameCardViewModel GetInteractionGameCard()
        {
            return GameCard;
        }

        public void SetGameCardInteraction(bool state)
        {
            GameCard.SetInteractionActive(state);
        }

        public void SetEnableBuying(bool state)
        {
            EnableBuying = state;
        }

        public void SetEnableSelling(bool state)
        {
            EnableSelling = state;
        }

        public void SetCashAfterBuying(int cash)
        {
            CashAfterBuying = cash;
        }

        public void SetCashAfterSelling(int cash)
        {
            CashAfterSelling = cash;
        }
    }
}
