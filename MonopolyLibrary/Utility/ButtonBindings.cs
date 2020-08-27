using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Model;
using MonopolyLibrary.ViewModel;
using System.Windows.Input;
using MonopolyLibrary.Utility.Commands;

namespace MonopolyLibrary.Utility
{
    public class ButtonBindings
    {
        private static ButtonBindings _instance = new ButtonBindings();
        public static ButtonBindings Instance { get => _instance; }

        private PlayerCreationCommands playerCreationCommands = new PlayerCreationCommands();
        private StartingRollCommands startingRollCommands = new StartingRollCommands();
        private StartWindowCommands startWindowCommands = new StartWindowCommands();
        private CloseGameCommands closeGameCommands = new CloseGameCommands();
        private GameCardCommands gameCardCommands = new GameCardCommands();
        private DiceCommands diceCommands = new DiceCommands();
        private StreetBuyingCommands streetBuyingCommands = new StreetBuyingCommands();
        private StreetInteractionCommands streetInteractionCommands = new StreetInteractionCommands();


        private ButtonBindings()
        {
            SetCommands();
        }

        /// <summary>
        /// Sets a command for each ICommand defined in this class. All of theses Commands are sorted by the window that they are used for.
        /// </summary>
        public void SetCommands()
        {
            //Player Creation
            Com_AddCharacter = new RelayCommand<PlayerCreationViewModel>(playerCreationCommands.AddPlayer);
            
            Com_GameStart = new NonGenericRelayCommand(p => playerCreationCommands.StartGame());
            Com_NextPicture = new RelayCommand<PlayerCreationViewModel>(playerCreationCommands.NextPicture);
            Com_PreviousPicture = new RelayCommand<PlayerCreationViewModel>(playerCreationCommands.PreviousPicture);
            Com_RandomName = new RelayCommand<PlayerCreationViewModel>(playerCreationCommands.RandomName);

            //Starting Roll
            Com_GoToGameView = new NonGenericRelayCommand(p => startingRollCommands.GoToGameView());

            //Start Window
            Com_GoToCreation = new NonGenericRelayCommand(p => startWindowCommands.GoToCreationWindow());

            //Game Card
            Com_ClearMouseOverGameCard = new NonGenericRelayCommand(p => gameCardCommands.ClearMouseOverGameCard());
            Com_SetMouseOverGameCard = new RelayCommand<GameCardViewModel>(gameCardCommands.SetMouseOverGameCard);
            Com_OpenStreetInteraction = new RelayCommand<GameCardViewModel>(gameCardCommands.OpenStreetInteraction);

            //Dice
            Com_DiceCommand = new RelayCommand<Windows>(diceCommands.RollDice);
            Com_EndTurn = new NonGenericRelayCommand(P => diceCommands.EndTurn());
            Com_OneStep = new NonGenericRelayCommand(p => diceCommands.OneStep());

            //Buying Streets
            Com_BuyStreet = new NonGenericRelayCommand(p => streetBuyingCommands.BuyStreet());

            //Street Interaction
            Com_TakeMortgage = new RelayCommand<GameCardViewModel>(streetInteractionCommands.TakeMortgage);
            Com_PayMortgage = new RelayCommand<GameCardViewModel>(streetInteractionCommands.PayMortgage);
            Com_BuildHouse = new RelayCommand<GameCardViewModel>(streetInteractionCommands.BuyHouse);
            Com_BuildHotel = new RelayCommand<GameCardViewModel>(streetInteractionCommands.BuyHotel);
            Com_SellHouse = new RelayCommand<GameCardViewModel>(streetInteractionCommands.SellHouse);
            Com_SellHotel = new RelayCommand<GameCardViewModel>(streetInteractionCommands.SellHotel);

            //Close Game
            Com_ExitGame = new NonGenericRelayCommand(p => closeGameCommands.CloseGame());
            Com_Revert = new NonGenericRelayCommand(p => closeGameCommands.Revert());

            //Ubiquitous
            Com_CloseGame = new RelayCommand<Windows>(closeGameCommands.CloseGame);
        }


        //Start Window
        public ICommand Com_GoToCreation { get; set; }

        //Player Creation
        public ICommand Com_AddCharacter { get; set; }
        public ICommand Com_GameStart { get; set; }
        public ICommand Com_NextPicture { get; set; }
        public ICommand Com_PreviousPicture { get; set; }
        public ICommand Com_RandomName { get; set; }

        //Starting Roll
        public ICommand Com_GoToGameView { get; set; }

        //Game Card
        public ICommand Com_SetMouseOverGameCard { get; set; }
        public ICommand Com_ClearMouseOverGameCard { get; set; }
        public ICommand Com_OpenStreetInteraction { get; set; }

        //Dice
        public ICommand Com_DiceCommand { get; set; }
        public ICommand Com_EndTurn { get; set; }
        public ICommand Com_OneStep { get; set; }

        //Buying Streets
        public ICommand Com_BuyStreet { get; set; }
        public ICommand Com_AuctionStreet { get; set; }

        //Street interaction
        public ICommand Com_PayMortgage { get; set; }
        public ICommand Com_TakeMortgage { get; set; }
        public ICommand Com_BuildHouse { get; set; }
        public ICommand Com_BuildHotel { get; set; }
        public ICommand Com_SellHouse { get; set; }
        public ICommand Com_SellHotel { get; set; }

        //Close Game
        public ICommand Com_ExitGame { get; set; }
        public ICommand Com_Revert { get; set; }

        //Ubiquitous
        public ICommand Com_CloseGame { get; set; }
    }
}
