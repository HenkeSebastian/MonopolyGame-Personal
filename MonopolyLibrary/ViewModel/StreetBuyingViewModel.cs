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
        private Windows window;

        public Windows Window
        {
            get { return window; }
            set { window = value; }
        }

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


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
