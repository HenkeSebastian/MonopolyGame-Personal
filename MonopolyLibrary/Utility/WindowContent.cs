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
using MonopolyLibrary.Utility.Commands;
using System.Collections.ObjectModel;
using MonopolyLibrary.Model;

namespace MonopolyLibrary.Utility
{
    /// <summary>
    /// A class to instantiate all needed ViewModels and passing a reference of itself to theses instances to keep persistance of objects.
    /// </summary>
    public class WindowContent: INotifyPropertyChanged
    {
        private static WindowContent _instance = new WindowContent();

        public static WindowContent ViewModel
        {
            get { return _instance; }
        }

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

        private ObservableCollection<BaseViewModel> viewModels;

        public ObservableCollection<BaseViewModel> ViewModels
        {
            get { return viewModels; }
            set 
            { 
                viewModels = value;
                OnPropertyChanged("ViewModels");
            }
        }

        private ObservableCollection<BaseViewModel> detailsViewModels;

        public ObservableCollection<BaseViewModel> DetailsViewModels
        {
            get { return detailsViewModels; }
            set 
            { 
                detailsViewModels = value;
                OnPropertyChanged("DetailsViewModel");
            }
        }

        private ObservableCollection<BaseViewModel> additionalViewModels;

        public ObservableCollection<BaseViewModel> AdditionalViewModels
        {
            get { return additionalViewModels; }
            set 
            { 
                additionalViewModels = value;
                OnPropertyChanged("AdditionalViewModel");
            }
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
        private ButtonBindings buttonBindings;

        public ButtonBindings ButtonBindings
        {
            get { return buttonBindings; }
            set { buttonBindings = value; }
        }

        private CommunityChest communityChest;

        public CommunityChest CommunityChest
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


        private PlayerCreationCommands playerCreationCommands = new PlayerCreationCommands();
        private StartingRollCommands startingRollCommands = new StartingRollCommands();
        private StartWindowCommands startWindowCommands = new StartWindowCommands();
        private CloseGameCommands closeGameCommands = new CloseGameCommands();
        private GameCardCommands gameCardCommands = new GameCardCommands();
        private DiceCommands diceCommands = new DiceCommands();
        private StreetBuyingCommands streetBuyingCommands = new StreetBuyingCommands();
        private StreetInteractionCommands streetInteractionCommands = new StreetInteractionCommands();


        private WindowContent()
        {
            InitialWindowSetup();
            InitializeCollections();
            AddViewModelsToCollection();
            InitializeReferences();
            AddDetailsViewModelsToCollection();
            AddAdditionalViewModelsToCollection();
            //OpenMessageBox(GetViewModel<GameBoardViewModel>().ToString());
        }

        public static WindowContent GetWindowContent()
        {
            return _instance;
        }

        private void InitialWindowSetup()
        {
            WindowHeight = new int();
            WindowWidth = new int();
        }

        /// <summary>
        /// Sets initial parameters for the main window.
        /// </summary>
        public void SetInitialContent()
        {
            SetViewModelActive(Windows.StartScreen);
            SetDetailsViewModelActive<IdleDetailsViewModel>();
            WindowWidth = 800;
            WindowHeight = 500;
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
        /// Instances needed classes and passes a reference to each of the instances for persistance.
        /// </summary>
        private void InitializeReferences()
        {
            ManagingPlayer = new ManagingPlayer();
            ManagingPlayer.InitializeCollections();
            ButtonBindings = ButtonBindings.Instance;
            CommunityChest = new CommunityChest();

        }

        private void InitializeCollections()
        {
            ViewModels = new ObservableCollection<BaseViewModel>();
            DetailsViewModels = new ObservableCollection<BaseViewModel>();
            AdditionalViewModels = new ObservableCollection<BaseViewModel>();

        }

        private void AddViewModelsToCollection()
        {
            ViewModels.Add(new CloseGameViewModel());
            ViewModels.Add(new DiceViewModel());
            ViewModels.Add(new GameBoardViewModel());
            ViewModels.Add(new PlayerCreationViewModel());
            GetViewModel<PlayerCreationViewModel>().SetInitials();
            ViewModels.Add(new StartingRollViewModel());
            ViewModels.Add(new StartScreenViewModel());
        }

        private void AddDetailsViewModelsToCollection()
        {
            DetailsViewModels.Add(new GameCardViewModel(new GameCardModel()));
            DetailsViewModels.Add(new CommunityDetailsViewModel());
            DetailsViewModels.Add(new IdleDetailsViewModel());
            DetailsViewModels.Add(new StreetBuyingViewModel());
            DetailsViewModels.Add(new StreetInteractionViewModel());
        }

        private void AddAdditionalViewModelsToCollection()
        {
            AdditionalViewModels.Add(new DoneButtonViewModel());
        }

        #region MainViewModel
        public T GetViewModel<T>()
        {
            foreach (BaseViewModel viewModel in ViewModels)
            {
                if (viewModel is T)
                {
                    return (T)Convert.ChangeType(viewModel, typeof(T));
                }
            }

            return default(T);
        }

        public void SetViewModelActive(Windows window)
        {
            foreach (BaseViewModel viewModel in ViewModels)
            {
                if (viewModel.ViewModelWindow == window)
                {
                    SetMainViewModel(viewModel);
                    viewModel.ViewModelAction();
                }
            }
        }

        private void SetMainViewModel(BaseViewModel viewModel)
        {
            SelectedViewModel = viewModel;
        }

        public BaseViewModel GetCurrentMainViewModel()
        {
            return SelectedViewModel;
        }
        #endregion

        #region DetailsViewModel
        public T GetDetailsViewModel<T>()
        {
            foreach (BaseViewModel viewModel in DetailsViewModels)
            {
                if (viewModel is T)
                {
                    return (T)Convert.ChangeType(viewModel, typeof(T));
                }
            }

            return default(T);
        }

        public void SetDetailsViewModelActive<T>(bool changeFromInteraction = false)
        {
            if (changeFromInteraction == false && SelectedDetailsViewModel != GetDetailsViewModel<StreetBuyingViewModel>())
            {
                SetDetailsViewModel(GetDetailsViewModel<T>());
            }
            else
            {
                SetDetailsViewModel(GetDetailsViewModel<IdleDetailsViewModel>());
            }
        }

        private void SetDetailsViewModel<T>(T viewModel)
        {
            SelectedDetailsViewModel = (BaseViewModel)Convert.ChangeType(viewModel, typeof(T));
        }

        public BaseViewModel GetCurrentDetailsViewModel()
        {
            return SelectedDetailsViewModel;
        } 
        #endregion

        public T GetAdditionalViewModel<T>()
        {
            foreach (BaseViewModel viewModel in AdditionalViewModels)
            {
                if (viewModel is T)
                {
                    return (T)Convert.ChangeType(viewModel, typeof(T));
                }
            }

            return default(T);
        }

        public ManagingPlayer GetManagingPlayer()
        {
            return ManagingPlayer;
        }

        #region MouseOver
        public void SetMouseOverGameCard(GameCardViewModel gameCardViewModel)
        {
            DetailsViewModels[0] = gameCardViewModel;
        }

        public void ClearMouseOverGameCard()
        {
            DetailsViewModels[0] = null;
        } 
        #endregion

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
