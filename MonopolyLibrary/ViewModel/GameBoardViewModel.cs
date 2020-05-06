using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Gamerules;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.ViewModel
{
    public class GameBoardViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public Windows Window
        {
            get { return Windows.GameBoardScreen; }
        }

        private GameCardViewModel mouseOverGameCard;

        public GameCardViewModel MouseOverGameCard
        {
            get { return mouseOverGameCard; }
            set
            {
                mouseOverGameCard = value;
            }
        }

        private C_MainGameRules c_MainGameRules;

        public C_MainGameRules C_MainGameRules
        {
            get { return c_MainGameRules; }
            set { c_MainGameRules = value; }
        }



        private GameCardViewModel[] gameCards;

        public GameCardViewModel[] GameCards
        {
            get { return gameCards; }
            set { gameCards = value; }
        }

        private ObservableCollection<GameCardViewModel> gamecCards1;

        public ObservableCollection<GameCardViewModel> GameCards1
        {
            get { return gamecCards1; }
            set
            {
                gamecCards1 = value;
            }
        }
        private ObservableCollection<GameCardViewModel> gameCards2;

        public ObservableCollection<GameCardViewModel> GameCards2
        {
            get { return gameCards2; }
            set { gameCards2 = value; }
        }
        private ObservableCollection<GameCardViewModel> gameCards3;

        public ObservableCollection<GameCardViewModel> GameCards3
        {
            get { return gameCards3; }
            set { gameCards3 = value; }
        }
        private ObservableCollection<GameCardViewModel> gameCards4;

        public ObservableCollection<GameCardViewModel> GameCards4
        {
            get { return gameCards4; }
            set { gameCards4 = value; }
        }

        private bool doneButtonEnabled;

        public bool DoneButtonEnabled
        {
            get { return doneButtonEnabled; }
            set
            {
                doneButtonEnabled = value;
                OnPropertyChanged("DoneButtonEnabled");
            }
        }



        public GameBoardViewModel(WindowContent content)
        {
            Content = content;
            DoneButtonEnabled = false;
            InitializeReferences();
            InitializeArray();
        }



        /// <summary>
        /// One Array gets instaced and filled with game card view models.
        /// </summary>
        public void InitializeArray()
        {
            GameCards = new GameCardViewModel[40];
            GameCards = Content.GamePool.GameCards;
        }


        public void InitializeReferences()
        {
            C_MainGameRules = new C_MainGameRules(Content);
        }

        /// <summary>
        /// DEPRECATED! No longer needed!
        /// An array of game cards will be transfered to an observable collection in reversed order.
        /// This will be needed because a stackpanel in horizontal order can not be displayed in reversed order.
        /// </summary>
        /// <param name="gameCards">The array of game cards.</param>
        /// <param name="amount">The amount of objects that are being transfered.</param>
        /// <param name="start">The starting index of the array for the transfer.</param>
        /// <returns>Returns the observable collection of the transfered game cards.</returns>
        public ObservableCollection<GameCardViewModel> TransferArrayToCollectionReverse(GameCardViewModel[] gameCards, int amount, int start)
        {
            ObservableCollection<GameCardViewModel> tempCollection = new ObservableCollection<GameCardViewModel>();
            for (int i = 0; i < amount; i++)
            {
                tempCollection.Insert(0, gameCards[start + i]);
            }
            return tempCollection;
        }



        /// <summary>
        /// DEPRECATED! No longer needed.
        /// An array of game cards will be transfered to an observable collection.
        /// </summary>
        /// <param name="gameCards">The array of game cards.</param>
        /// <param name="amount">The amount of objects that are being transfered.</param>
        /// <param name="start">The starting index of the array for the transfer.</param>
        /// <returns>Returns the observable collection of the transfered game cards.</returns>
        public ObservableCollection<GameCardViewModel> TransferArrayToCollection(GameCardViewModel[] gameCards, int amount, int start)
        {
            ObservableCollection<GameCardViewModel> tempCollection = new ObservableCollection<GameCardViewModel>();
            for (int i = 0; i < amount; i++)
            {
                tempCollection.Add(gameCards[start + i]);
            }
            return tempCollection;
        }


        /// <summary>
        /// Gets the game card that a player is currently standing on.
        /// </summary>
        /// <param name="selectPlayer">The given player.</param>
        /// <returns>Returns the game card object that the given player is standing on.</returns>
        public GameCardViewModel GetPlayerGameCard(PlayerViewModel selectPlayer)
        {
            return GameCards[selectPlayer.CurrentPosition];
        }

        /// <summary>
        /// Toggels the "Done" button.
        /// </summary>
        /// <param name="state"></param>
        public void SetDoneButton(bool state)
        {
            DoneButtonEnabled = state;
        }


    }
}
