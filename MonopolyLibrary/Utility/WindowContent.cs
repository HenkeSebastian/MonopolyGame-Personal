using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.ViewModel;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Gamerules;
using System.Windows;

namespace MonopolyLibrary.Utility
{
    /// <summary>
    /// A class to instantiate all needed ViewModels and passing a reference of itself to theses instances to keep persistance of objects.
    /// </summary>
    public class WindowContent: INotifyPropertyChanged
    {
        /// <summary>
        /// Width of the window.
        /// </summary>
        private int windowWidth;

        public int WindowWidth
        {
            get { return windowWidth; }
            set
            {
                windowWidth = value;
                OnPropertyChanged("WindowWidth");
            }
        }


        /// <summary>
        /// Height of the window
        /// </summary>
        private int windowHeight;

        public int WindowHeight
        {
            get { return windowHeight; }
            set
            {
                windowHeight = value;
                OnPropertyChanged("WindowHeight");
            }
        }

        private int minWindowWidth;

        public int MinWindowWidth
        {
            get { return minWindowWidth; }
            set
            {
                minWindowWidth = value;
                OnPropertyChanged("MinWindowWidth");
            }
        }


        private int minWindowHeight;

        public int MinWindowHeight
        {
            get { return minWindowHeight; }
            set
            {
                minWindowHeight = value;
                OnPropertyChanged("MinWindowHeight");
            }
        }



        /// <summary>
        /// ViewModel of the Startscreen.
        /// </summary>
        private StartScreenViewModel startScreenViewModel;

        public StartScreenViewModel StartScreenViewModel
        {
            get { return startScreenViewModel; }
            private set
            {
                startScreenViewModel = value;
            }
        }


        /// <summary>
        /// ViewModel of the Player Creation View.
        /// </summary>
        private PlayerCreationViewModel playerCreationViewModel;

        public PlayerCreationViewModel PlayerCreationViewModel
        {
            get { return playerCreationViewModel; }
            private set { playerCreationViewModel = value; }
        }


        /// <summary>
        /// ViewModel of the Game View.
        /// </summary>
        private GameViewViewModel gameViewViewModel;

        public GameViewViewModel GameViewViewModel
        {
            get { return gameViewViewModel; }
            private set { gameViewViewModel = value; }
        }


        private GameBoardViewModel gameBoardViewModel;

        public GameBoardViewModel GameBoardViewModel
        {
            get { return gameBoardViewModel; }
            private set { gameBoardViewModel = value; }
        }



        /// <summary>
        /// ViewModel of the Close Game View.
        /// </summary>
        private CloseGameViewModel closeGameViewModel;

        public CloseGameViewModel CloseGameViewModel
        {
            get { return closeGameViewModel; }
            private set { closeGameViewModel = value; }
        }


        /// <summary>
        /// ViewModel of the Dice View.
        /// </summary>
        private DiceViewModel diceViewModel;

        public DiceViewModel DiceViewModel
        {
            get { return diceViewModel; }
            set { diceViewModel = value; }
        }


        /// <summary>
        /// ViewModel of the Starting Roll View.
        /// </summary>
        private StartingRollViewModel startingRollViewModel;

        public StartingRollViewModel StartingRollViewModel
        {
            get { return startingRollViewModel; }
            set { startingRollViewModel = value; }
        }

        private IdleDetailsViewModel idleDetailsViewModel;

        public IdleDetailsViewModel IdleDetailsViewModel
        {
            get { return idleDetailsViewModel; }
            set { idleDetailsViewModel = value; }
        }



        /// <summary>
        /// The Property used for binding the content of the main window.
        /// </summary>
        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        private BaseViewModel selectedDetailsViewModel;

        public BaseViewModel SelectedDetailsViewModel
        {
            get { return selectedDetailsViewModel; }
            set
            {
                selectedDetailsViewModel = value;
                OnPropertyChanged("SelectedDetailsViewModel");
            }
        }



        /// <summary>
        /// Property for the instance of the button bindings class.
        /// </summary>
        private C_ButtonBindings buttonBindings;

        public C_ButtonBindings ButtonBindings
        {
            get { return buttonBindings; }
            set { buttonBindings = value; }
        }

        private C_CommunityChest communityChest;

        public C_CommunityChest CommunityChest
        {
            get { return communityChest; }
            set { communityChest = value; }
        }



        /// <summary>
        /// Property for the instance of the managing player class.
        /// </summary>
        private ManagingPlayer managingPlayer;

        public ManagingPlayer ManagingPlayer
        {
            get { return managingPlayer; }
            set { managingPlayer = value; }
        }

        private GamePool gamePool;

        public GamePool GamePool
        {
            get { return gamePool; }
            set { gamePool = value; }
        }



        /// <summary>
        /// Property for the instance of the street interaction view model.
        /// </summary>
        private StreetInteractionViewModel streetInteractionViewModel;

        public StreetInteractionViewModel StreetInteractionViewModel
        {
            get { return streetInteractionViewModel; }
            set { streetInteractionViewModel = value; }
        }


        /// <summary>
        /// Property for the instance of the street buying view model.
        /// </summary>
        private StreetBuyingViewModel streetBuyingViewModel;

        public StreetBuyingViewModel StreetBuyingViewModel
        {
            get { return streetBuyingViewModel; }
            set { streetBuyingViewModel = value; }
        }

        private CommunityDetailsViewModel communityDetailsViewModel;

        public CommunityDetailsViewModel CommunityDetailsViewModel
        {
            get { return communityDetailsViewModel; }
            set { communityDetailsViewModel = value; }
        }






        public WindowContent()
        {
            InitialWindowSetup();
            InitializeReferences();
            InitializeViewModels();
        }


        /// <summary>
        /// REVIEW Delete.
        /// </summary>
        private void InitialWindowSetup()
        {
            WindowHeight = new int();
            WindowWidth = new int();
        }


        /// <summary>
        /// Instances needed classes and passes a reference to each of the instances for persistance.
        /// </summary>
        private void InitializeReferences()
        {
            ButtonBindings = new C_ButtonBindings(this);
            ManagingPlayer = new ManagingPlayer(this);
            CommunityChest = new C_CommunityChest(this);
            GamePool = new GamePool(this);
        }


        /// <summary>
        /// Instances all the needed view models and passes a reference to this class for persistance.
        /// </summary>
        private void InitializeViewModels()
        {
            StartScreenViewModel = new StartScreenViewModel(this);
            PlayerCreationViewModel = new PlayerCreationViewModel(this);
            GameViewViewModel = new GameViewViewModel(this);
            CloseGameViewModel = new CloseGameViewModel(this);
            DiceViewModel = new DiceViewModel(this);
            StartingRollViewModel = new StartingRollViewModel(this);
            StreetInteractionViewModel = new StreetInteractionViewModel(this);
            StreetBuyingViewModel = new StreetBuyingViewModel(this);
            GameBoardViewModel = new GameBoardViewModel(this);

            IdleDetailsViewModel = new IdleDetailsViewModel(this);
            CommunityDetailsViewModel = new CommunityDetailsViewModel(this);
        }


        /// <summary>
        /// Sets initial parameters for the main window.
        /// </summary>
        public void SetInitialContent()
        {
            SelectedViewModel = startScreenViewModel;
            SelectedDetailsViewModel = IdleDetailsViewModel;
            WindowWidth = 800;
            WindowHeight = 500;
            //SelectedViewModel = gameViewViewModel;
        }


        /// <summary>
        /// Sets the revert target for the Closing window "cancel" button.
        /// </summary>
        /// <param name="passedRevert">The Window to revert to.</param>
        public void SetClosingWindowRevert(Windows passedRevert)
        {
            closeGameViewModel.SetCalledWindow(passedRevert);
        }


        /// <summary>
        /// Sets the current window size.
        /// </summary>
        /// <param name="x">The window width.</param>
        /// <param name="y">The window height.</param>
        public void SetWindowSize(int x, int y)
        {
            WindowWidth = x;
            WindowHeight = y;
        }

        /// <summary>
        /// Sets the current minimum window size.
        /// </summary>
        /// <param name="x">The minimum window width.</param>
        /// <param name="y">The minimum window height.</param>
        public void SetMinWindowSize(int x, int y)
        {
            MinWindowWidth = x;
            MinWindowHeight = y;
        }


        /// <summary>
        /// Sets the window properties for each window to open. Executes initial needed functions.
        /// </summary>
        /// <param name="window">The window to open.</param>
        public void SetWindowContent(Windows window)
        {
            switch (window)
            {
                case Windows.StartScreen:
                    SelectedViewModel = StartScreenViewModel;
                    break;
                case Windows.PlayerCreation:
                    SelectedViewModel = PlayerCreationViewModel;
                    break;
                case Windows.GameWindow:
                    SelectedViewModel = GameViewViewModel;
                    ManagingPlayer.SetPlayerIDActive(0);
                    ManagingPlayer.SetAllPlayerInitialPosition(0);
                    ManagingPlayer.SetAllPlayerMoney(10000);
                    SetWindowSize(1200, 850);
                    DiceViewModel.Dice.EnableDice(DiceViewModel);
                    break;
                case Windows.GameOver:
                    break;
                case Windows.EndScreen:
                    break;
                case Windows.ClosingScreen:
                    SelectedViewModel = CloseGameViewModel;
                    break;
                case Windows.StartingRoll:
                    SelectedViewModel = StartingRollViewModel;
                    ManagingPlayer.SetAllPlayerCollection();
                    SetWindowSize(800, 800);
                    break;
                case Windows.GameBoardScreen:
                    SelectedViewModel = GameBoardViewModel;
                    ManagingPlayer.SetPlayerIDActive(0);
                    ManagingPlayer.SetAllPlayerInitialPosition(0);
                    ManagingPlayer.SetAllPlayerMoney(10000);
                    DiceViewModel.Dice.EnableDice(DiceViewModel);
                    SetWindowSize(1400, 1080);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Changes the Details View in the center of the Gameboard.
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="changeFromInteraction"></param>
        public void ChangeDetailsView(Windows viewModel, bool changeFromInteraction = false)
        {
            BaseViewModel selectedViewModel;

            if (changeFromInteraction == false && SelectedDetailsViewModel != StreetBuyingViewModel)
            {
                switch (viewModel)
                {
                    case Windows.IdleDetails:
                        selectedViewModel = IdleDetailsViewModel;
                        break;
                    case Windows.GameCardDetails:
                        selectedViewModel = GameBoardViewModel.MouseOverGameCard;
                        break;
                    case Windows.StreetInteractionDetails:
                        selectedViewModel = StreetInteractionViewModel;
                        break;
                    case Windows.StreetBuyingDetails:
                        selectedViewModel = StreetBuyingViewModel;
                        break;
                    case Windows.CommunityDetails:
                        selectedViewModel = CommunityDetailsViewModel;
                        break;
                    default:
                        selectedViewModel = null;
                        break;
                }
                SelectedDetailsViewModel = selectedViewModel;
            }
            else
            {
                SelectedDetailsViewModel = IdleDetailsViewModel;
            }
        }

        /// <summary>
        /// Message Box for player infromation. Might get exchanged with a nicer implementation.
        /// </summary>
        /// <param name="message"></param>
        public void OpenMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
