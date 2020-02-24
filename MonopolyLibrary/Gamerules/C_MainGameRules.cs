using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Gamerules
{
    public class C_MainGameRules
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private ObservableCollection<PlayerViewModel> allPlayers;

        public ObservableCollection<PlayerViewModel> AllPlayers
        {
            get { return allPlayers; }
            set { allPlayers = value; }
        }


        public C_MainGameRules(WindowContent content)
        {
            Content = content;
        }


    }
}