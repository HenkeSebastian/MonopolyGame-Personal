using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Model;
using MonopolyLibrary.ViewModel;
using System.Windows.Input;

namespace MonopolyLibrary.Utility
{
    public class C_ButtonBindings
    {

        private C_ButtonCommands buttonCommands;

        public C_ButtonCommands ButtonCommands
        {
            get { return buttonCommands; }
            set { buttonCommands = value; }
        }



        public C_ButtonBindings(WindowContent passedWindowContent)
        {
            ButtonCommands = new C_ButtonCommands(passedWindowContent);
            SetCommands();
        }

        /// <summary>
        /// Sets a command for each ICommand defined in this class. All of theses Commands are sorted by the window that they are used for.
        /// </summary>
        public void SetCommands()
        {
            //Player Creation
            //Com_AddCharacter = new RelayCommand<PlayerCreationViewModel>(ButtonCommands.PlayerCreationCommands.AddPlayer);
            Com_AddCharacter = new NonGenericRelayCommand(p => ButtonCommands.PlayerCreationCommands.AddPlayer());
            Com_CloseGame = new RelayCommand<Windows>(ButtonCommands.PlayerCreationCommands.CloseGame);
            Com_GameStart = new NonGenericRelayCommand(p => ButtonCommands.PlayerCreationCommands.StartGame());
            Com_NextPicture = new RelayCommand<PlayerCreationViewModel>(ButtonCommands.PlayerCreationCommands.NextPicture);
            Com_PreviousPicture = new RelayCommand<PlayerCreationViewModel>(ButtonCommands.PlayerCreationCommands.PreviousPicture);
            Com_RandomName = new NonGenericRelayCommand(p => ButtonCommands.PlayerCreationCommands.RandomName());

            //Starting Roll
            Com_GoToGameView = new NonGenericRelayCommand(p => ButtonCommands.StartingRollCommands.GoToGameView());

            //Start Window
            Com_GoToCreation = new NonGenericRelayCommand(p => ButtonCommands.StartWindowCommands.GoToCreationWindow());

            //Game Card
            Com_ClearMouseOverGameCard = new NonGenericRelayCommand(p => ButtonCommands.GameCardCommands.ClearMouseOverGameCard());
            Com_SetMouseOverGameCard = new RelayCommand<GameCardViewModel>(ButtonCommands.GameCardCommands.SetMouseOverGameCard);
            Com_OpenStreetInteraction = new RelayCommand<GameCardViewModel>(ButtonCommands.GameCardCommands.OpenStreetInteraction);

            //Dice
            Com_DiceCommand = new RelayCommand<Windows>(ButtonCommands.DiceCommands.RollDice);
            Com_DiceMainGame = new NonGenericRelayCommand(p => ButtonCommands.DiceCommands.MainGameRoll());
            Com_EndTurn = new NonGenericRelayCommand(P => ButtonCommands.DiceCommands.EndTurn());
            Com_FirstRoll = new NonGenericRelayCommand(p => ButtonCommands.DiceCommands.FirstRoll());
            Com_OneStep = new NonGenericRelayCommand(p => ButtonCommands.DiceCommands.OneStep());

            //Buying Streets
            Com_BuyStreet = new NonGenericRelayCommand(p => ButtonCommands.StreetBuyingCommands.BuyStreet());

            //Street Interaction
            Com_TakeMortgage = new RelayCommand<GameCardViewModel>(ButtonCommands.StreetInteractionCommands.TakeMortgage);
            Com_PayMortgage = new RelayCommand<GameCardViewModel>(ButtonCommands.StreetInteractionCommands.PayMortgage);
            Com_BuildHouse = new RelayCommand<GameCardViewModel>(ButtonCommands.StreetInteractionCommands.BuyHouse);
            Com_SellHouse = new RelayCommand<GameCardViewModel>(ButtonCommands.StreetInteractionCommands.SellHouse);
        }


        //Start Window
        public ICommand Com_GoToCreation { get; set; }

        //Player Creation
        public ICommand Com_AddCharacter { get; set; }
        public ICommand Com_CloseGame { get; set; }
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
        public ICommand Com_DiceMainGame { get; set; }
        public ICommand Com_EndTurn { get; set; }
        public ICommand Com_FirstRoll { get; set; }
        public ICommand Com_OneStep { get; set; }

        //Buying Streets
        public ICommand Com_BuyStreet { get; set; }
        public ICommand Com_AuctionStreet { get; set; }

        //Street interaction
        public ICommand Com_PayMortgage { get; set; }
        public ICommand Com_TakeMortgage { get; set; }
        public ICommand Com_BuildHouse { get; set; }
        public ICommand Com_SellHouse { get; set; }
    }
}
