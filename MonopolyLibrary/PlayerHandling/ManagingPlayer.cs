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
                newPlayer.Player.PlayerID = AmountOfPlayers;
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
                if (player.Player.PlayerID == ActivePlayerIndex)
                {
                    player.Player.IsActive = true;
                }
                else
                {
                    player.Player.IsActive = false;
                }
            }

            foreach (PlayerViewModel player in NPCPlayer)
            {
                if (player.Player.PlayerID == ActivePlayerIndex)
                {
                    player.Player.IsActive = true;
                }
                else
                {
                    player.Player.IsActive = false;
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
                player.Player.IsActive = false;
            }

            foreach (PlayerViewModel player in NPCPlayer)
            {
                player.Player.IsActive = false;
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
                player.Player.CurrentPosition = 0;
                Content.GameViewViewModel.GameCards[positionID].AddPlayerOnCard(player);
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
                player.Player.PlayerCash = amount;
            }
        }

        /// <summary>
        /// Gives a certain player money.
        /// </summary>
        /// <param name="player">The receiving player</param>
        /// <param name="amount">The amount of money</param>
        public void GivePlayerMoney(PlayerViewModel player, int amount)
        {
            player.Player.PlayerCash += amount;
        }

        /// <summary>
        /// Removes money from a player.
        /// </summary>
        /// <param name="player">The player who loses money</param>
        /// <param name="amount">The amount of money.</param>
        public void RemovePlayerMoney(PlayerViewModel player, int amount)
        {
            player.Player.PlayerCash -= amount;
        }

        /// <summary>
        /// A player pays another player
        /// </summary>
        /// <param name="receivingPlayer">The player who receives money</param>
        /// <param name="givingPlayer">The player who gives money</param>
        /// <param name="amount">The amount of money</param>
        public void PlayerGivesPlayerMoney(PlayerViewModel receivingPlayer, PlayerViewModel givingPlayer, int amount)
        {
            RemovePlayerMoney(givingPlayer, amount);
            GivePlayerMoney(receivingPlayer, amount);
        }

        /// <summary>
        /// A player receives a street card.
        /// </summary>
        /// <param name="player">The receiving player</param>
        /// <param name="gameCard">The street card</param>
        public void GivePlayerGameCard(PlayerViewModel player, GameCardViewModel gameCard)
        {
            player.Player.OwnedStreets[gameCard.GameCard.OwnerArrayID] = gameCard;
            gameCard.GameCard.OwningPlayer = player;
        }

        /// <summary>
        /// A player loses a street card.
        /// </summary>
        /// <param name="player">The losing player</param>
        /// <param name="gameCard">The street card</param>
        public void RemovePlayerGameCard(PlayerViewModel player, GameCardViewModel gameCard)
        {
            player.Player.OwnedStreets[gameCard.GameCard.OwnerArrayID] = null;
            gameCard.GameCard.OwningPlayer = null;
        }

        /// <summary>
        /// A street card is being moved from one player to another.
        /// </summary>
        /// <param name="receivingPlayer">The receiving player</param>
        /// <param name="givingPlayer">The giving player</param>
        /// <param name="gameCard">The street card</param>
        public void MoveGameCardToAnotherPlayer(PlayerViewModel receivingPlayer, PlayerViewModel givingPlayer, GameCardViewModel gameCard)
        {
            receivingPlayer.Player.OwnedStreets[gameCard.GameCard.OwnerArrayID] = gameCard;
            gameCard.GameCard.OwningPlayer = receivingPlayer;
            givingPlayer.Player.OwnedStreets[gameCard.GameCard.OwnerArrayID] = null;
        }

        /// <summary>
        /// Sorts an array by the first throw of all players.
        /// </summary>
        /// <param name="inputCollection">The array to sort</param>
        /// <returns></returns>
        public ObservableCollection<PlayerViewModel> SortPlayersDescending(ObservableCollection<PlayerViewModel> inputCollection)
        {
            IEnumerable<PlayerViewModel> query = inputCollection.OrderByDescending(players => players.Player.FirstThrow);
            return new ObservableCollection<PlayerViewModel>(query);
        }

        /// <summary>
        /// Resets the player IDs to their position in the complete player Array.
        /// </summary>
        public void ResetPlayerIDs()
        {
            foreach (PlayerViewModel item in AllPlayers)
            {
                item.Player.PlayerID = AllPlayers.IndexOf(item);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
