using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonopolyLibrary.ViewModel
{
    public class StreetBuyingViewModel: BaseViewModel, INotifyPropertyChanged
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
                OnPropertyChanged();
            }
        }



        public StreetBuyingViewModel(WindowContent content)
        {
            Content = content;
        }

    }
}
