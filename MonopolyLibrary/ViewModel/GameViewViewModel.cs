using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Gamerules;
using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.ViewModel
{
    /// <summary>
    /// DEPRECATED! ViewModel for the no longer used  GameView.xaml View.
    /// </summary>
    public class GameViewViewModel:BaseViewModel, INotifyPropertyChanged
    {

        private MainGameRules mainGameRules;

        public MainGameRules MainGameRules
        {
            get { return mainGameRules; }
            set { mainGameRules = value; }
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
                OnPropertyChanged("GameCards1");
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

        private GameCardViewModel mouseOverGameCard;

        public GameCardViewModel MouseOverGameCard
        {
            get { return mouseOverGameCard; }
            set
            {
                mouseOverGameCard = value;
                OnPropertyChanged("MouseOverGameCard");
            }
        }





        public GameViewViewModel(WindowContent passedWindowContent)
        {
            Content = passedWindowContent;
            InitializeReferences();
            InitializeArray();
        }


        /// <summary>
        /// One array and 4 observable collections will be created.
        /// The array of gamecards correlate to every street on the game board.
        /// The other 4 collections are created for the visual representation of the board and keep references to the objects inside the first array.
        /// These 4 observable collections are the binding source for the UI.
        /// </summary>
        public void InitializeArray()
        {
            GameCards = new GameCardViewModel[]
            {
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.LOS)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Badstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Turmstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Einkommenssteuer)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Südbahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Chausseestraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Elisenstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Poststraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gefängnis)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Seestraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.EWerk)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Hafenstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.NeueStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Westbahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.MünchnerStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.WienerStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.BerlinerStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.FreiParken)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.TheaterStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Museumstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Opernplatz)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.NordBahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Lessingstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Schillerstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Wasserwerk)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Goethestraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.InDasGefängnis)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Rathausplatz)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Hauptstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Bahnhofstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Hauptbahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Parkstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Zusatzsteuer)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Schlossallee))
            };
            GameCards1 = new ObservableCollection<GameCardViewModel>();
            GameCards2 = new ObservableCollection<GameCardViewModel>();
            GameCards3 = new ObservableCollection<GameCardViewModel>();
            GameCards4 = new ObservableCollection<GameCardViewModel>();

            GameCards1 = TransferArrayToCollection(GameCards, 11, 0);
            GameCards2 = TransferArrayToCollectionReverse(GameCards, 9, 11);
            GameCards3 = TransferArrayToCollection(GameCards, 11, 20);
            GameCards4 = TransferArrayToCollection(GameCards, 9, 31);
        }


        public void InitializeReferences()
        {
            MainGameRules = new MainGameRules();
        }

        /// <summary>
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
                tempCollection.Insert(0,gameCards[start + i]);
            }
            return tempCollection;
        }



        /// <summary>
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

    }
}
