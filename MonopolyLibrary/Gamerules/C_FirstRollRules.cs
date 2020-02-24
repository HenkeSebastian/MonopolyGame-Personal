using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Gamerules
{
    public class C_FirstRollRules: INotifyPropertyChanged
    {
        #region Properties
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
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
        #endregion



        public C_FirstRollRules(WindowContent content)
        {
            Content = content;
            FirstThrowDone = false;
        }


        /// <summary>
        /// Cycles Through the players in the game. If all players are cycled through, it finishes the first throw mechanic.
        /// </summary>
        public void NextPlayer()
        {
            if (Content.ManagingPlayer.ActivePlayerIndex == Content.ManagingPlayer.AllPlayers.Count - 1)
            {
                Content.ManagingPlayer.AllPlayers = Content.ManagingPlayer.SortPlayersDescending(Content.ManagingPlayer.AllPlayers);
                Content.ManagingPlayer.ResetPlayerIDs();
                FirstRollDone();
                Content.ManagingPlayer.SetAllPlayerInactive();
            }
            else
            {
                Content.ManagingPlayer.NextPlayer();
            }
        }

        /// <summary>
        /// Sets the score of the currently active player.
        /// </summary>
        /// <param name="scoreOne">Score of the first die</param>
        /// <param name="scoreTwo">Score of the second die</param>
        public void SetScore(int scoreOne, int scoreTwo)
        {
            Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.FirstThrow = scoreOne + scoreTwo;
        }

        /// <summary>
        /// Sets the flag to finish the first throw mechanic.
        /// </summary>
        public void FirstRollDone()
        {
            Content.DiceViewModel.DisableDice();
            FirstThrowDone = true;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
