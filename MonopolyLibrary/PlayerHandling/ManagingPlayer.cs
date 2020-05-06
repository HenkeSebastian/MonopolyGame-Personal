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

namespace MonopolyLibrary.PlayerHandling
{
    public class ManagingPlayer: INotifyPropertyChanged
    {
        #region Properties
        private int amountOfPlayers;

        public int AmountOfPlayers
        {
            get { return amountOfPlayers; }
            set { amountOfPlayers = value; }
        }

        private int activePlayerIndex;

        public int ActivePlayerIndex
        {
            get { return activePlayerIndex; }
            set
            {
                activePlayerIndex = value;
            }
        }




        private ObservableCollection<PlayerViewModel> activePlayer;

        public ObservableCollection<PlayerViewModel> ActivePlayer
        {
            get { return activePlayer; }
            set
            {
                activePlayer = value;
                OnPropertyChanged("ActivePlayer");
            }
        }

        private ObservableCollection<PlayerViewModel> npcPlayer;

        public ObservableCollection<PlayerViewModel> NPCPlayer
        {
            get { return npcPlayer; }
            set
            {
                npcPlayer = value;
                OnPropertyChanged("NPCPlayer");
            }
        }

        private ObservableCollection<PlayerViewModel> allPlayers;

        public ObservableCollection<PlayerViewModel> AllPlayers
        {
            get { return allPlayers; }
            set
            {
                allPlayers = value;
                OnPropertyChanged();
            }
        }

        #endregion

        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public ManagingPlayer(WindowContent content)
        {
            Content = content;
            InitializeCollections();
            AmountOfPlayers = 0;
            ActivePlayerIndex = 0;
        }
        public void InitializeCollections()
        {
            ActivePlayer = new ObservableCollection<PlayerViewModel>();
            NPCPlayer = new ObservableCollection<PlayerViewModel>();
            AllPlayers = new ObservableCollection<PlayerViewModel>();
        }

        /// <summary>
        /// Adds a new Player to the active Player Array
        /// </summary>
        /// <param name="newPlayer">The new Player</param>
        public void AddPlayer(PlayerViewModel newPlayer)
        {
            if (AmountOfPlayers < 6)
            {
                newPlayer.PlayerID = AmountOfPlayers;
                ActivePlayer.Add(newPlayer);
                AmountOfPlayers++;
            }
        }

        /// <summary>
        /// Sets the next player in the active Player array active.
        /// </summary>
        public void NextPlayer()
        {
            if (ActivePlayerIndex < ActivePlayer.Count - 1)
            {
                ActivePlayerIndex++;
            }
            else
            {
                ActivePlayerIndex = 0;

            }
            SetActivePlayer();
        }

        /// <summary>
        /// Gets the currently active Player.
        /// </summary>
        /// <returns>The current active Player.</returns>
        public PlayerViewModel GetActivePlayer()
        {
            return AllPlayers[ActivePlayerIndex];
        }

        /// <summary>
        /// Sets the indexed player Active
        /// </summary>
        public void SetActivePlayer()
        {
            foreach(PlayerViewModel player in ActivePlayer)
            {
                if (player.PlayerID == ActivePlayerIndex)
                {
                    player.IsActive = true;
                }
                else
                {
                    player.IsActive = false;
                }
            }

            foreach (PlayerViewModel player in NPCPlayer)
            {
                if (player.PlayerID == ActivePlayerIndex)
                {
                    player.IsActive = true;
                }
                else
                {
                    player.IsActive = false;
                }
            }
        }

        /// <summary>
        /// Sets a Player with a certain ID active.
        /// </summary>
        /// <param name="ID">The Player ID</param>
        public void SetPlayerIDActive(int ID)
        {
            ActivePlayerIndex = ID;
            SetActivePlayer();
        }

        /// <summary>
        /// Sets every Player in the game inactive.
        /// </summary>
        public void SetAllPlayerInactive()
        {
            foreach (PlayerViewModel player in ActivePlayer)
            {
                player.IsActive = false;
            }

            foreach (PlayerViewModel player in NPCPlayer)
            {
                player.IsActive = false;
            }
        }


        /// <summary>
        /// Adds all active and npc player to a combined Array.
        /// </summary>
        public void SetAllPlayerCollection()
        {
            foreach (PlayerViewModel item in ActivePlayer)
            {
                AllPlayers.Add(item);
            }
            foreach (PlayerViewModel item in NPCPlayer)
            {
                AllPlayers.Add(item);
            }
        }

        /// <summary>
        /// Sets the initial position of all Players
        /// </summary>
        /// <param name="positionID">The position ID</param>
        public void SetAllPlayerInitialPosition(int positionID)
        {
            foreach (PlayerViewModel player in AllPlayers)
            {
                player.CurrentPosition = 0;
                Content.GameBoardViewModel.GameCards[positionID].AddPlayerOnCard(player);
            }
        }

        /// <summary>
        /// Sets the amount of money/cash for every player in the game.
        /// </summary>
        /// <param name="amount">The amount of money/cash</param>
        public void SetAllPlayerMoney(int amount)
        {
            foreach (PlayerViewModel player in AllPlayers)
            {
                player.PlayerAddMoney(amount);
            }
        }


        /// <summary>
        /// Sorts an array by the first throw of all players.
        /// </summary>
        /// <param name="inputCollection">The array to sort</param>
        /// <returns></returns>
        public ObservableCollection<PlayerViewModel> SortPlayersDescending(ObservableCollection<PlayerViewModel> inputCollection)
        {
            IEnumerable<PlayerViewModel> query = inputCollection.OrderByDescending(players => players.FirstThrow);
            return new ObservableCollection<PlayerViewModel>(query);
        }

        /// <summary>
        /// Resets the player IDs to their position in the complete player Array.
        /// </summary>
        public void ResetPlayerIDs()
        {
            foreach (PlayerViewModel item in AllPlayers)
            {
                item.PlayerID = AllPlayers.IndexOf(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
