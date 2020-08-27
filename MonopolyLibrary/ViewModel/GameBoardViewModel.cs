using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Gamerules;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.ViewModel
{
    public class GameBoardViewModel : BaseViewModel, INotifyPropertyChanged
    {
        

        private GamePool gamePool;

        public GamePool GamePool
        {
            get { return gamePool; }
            set { gamePool = value; }
        }

        private ManagingPlayer managingPlayer;

        public ManagingPlayer ManagingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
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

        private MainGameRules mainGameRules;

        public MainGameRules MainGameRules
        {
            get { return mainGameRules; }
            set { mainGameRules = value; }
        }

        public GameBoardViewModel()
        {
            ViewModelWindow = Windows.GameBoardScreen;
            InitializeReferences();
            InitializeArray();
        }

        /// <summary>
        /// One Array gets instaced and filled with game card view models.
        /// </summary>
        public void InitializeArray()
        {
            gamePool.InitializePool();
        }

        public override void ViewModelAction()
        {
            ManagingPlayer.SetPlayerIDActive(0);
            ManagingPlayer.SetAllPlayerInitialPosition(0);
            ManagingPlayer.SetAllPlayerMoney(10000);
            WindowContent.GetWindowContent().GetViewModel<DiceViewModel>().EnableDice(true);
            WindowContent.GetWindowContent().SetWindowSize(1400, 1080);
        }


        public void InitializeReferences()
        {
            GamePool = new GamePool();
            MainGameRules = new MainGameRules();
        }



    }
}
