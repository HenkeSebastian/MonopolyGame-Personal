using MonopolyLibrary.Gamerules;
using MonopolyLibrary.PlayerHandling;
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
    public class StartingRollViewModel:BaseViewModel
    {
        private ManagingPlayer managingPlayer;

        public ManagingPlayer ManagingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }

        private FirstRollRules firstRollRules;

        public FirstRollRules FirstRollRules
        {
            get { return firstRollRules; }
            set { firstRollRules = value; }
        }


        private bool firstThrowDone;

        public bool FirstThrowDone
        {
            get { return firstThrowDone; }
            set
            {
                firstThrowDone = value;
                OnPropertyChanged("FirstThrowDone");
            }
        }


        public StartingRollViewModel()
        {
            ViewModelWindow = Windows.StartingRoll;
            FirstRollRules = new FirstRollRules();
            SetFirstThrowDone(false);
        }

        public override void ViewModelAction()
        {
            if (ManagingPlayer.AllPlayers.Count == 0)
            {
                ManagingPlayer.SetPlayerIDActive(0);
                ManagingPlayer.SetAllPlayerCollection();
            }
            WindowContent.GetWindowContent().SetWindowSize(800, 800);
        }

        public void SetFirstThrowDone(bool done)
        {
            FirstThrowDone = done;
        }

    }
}
