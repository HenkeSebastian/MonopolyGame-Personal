using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Model
{
    public class PlayerModel:BaseModel
    {

        /// <summary>
        /// Flag if the player is currently active.
        /// </summary>
        private bool isActive;

        public bool IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        /// <summary>
        /// Flag if the player is a NPC.
        /// </summary>
        private bool isNPC;

        public bool IsNPC
        {
            get { return isNPC; }
            set
            {
                isNPC = value;
                OnPropertyChanged("IsNPC");
            }
        }

        /// <summary>
        /// The player ID
        /// </summary>
        private int playerID;

        public int PlayerID
        {
            get { return playerID; }
            set
            {
                playerID = value;
                OnPropertyChanged("PlayerID");
            }
        }

        /// <summary>
        /// The player name.
        /// </summary>
        private string playerName;

        public string PlayerName
        {
            get { return playerName; }
            set
            {
                playerName = value;
                OnPropertyChanged("PlayerName");
            }
        }

        /// <summary>
        /// The source string for the player Avatar.
        /// </summary>
        private string playerAvatar;

        public string PlayerAvatar
        {
            get { return playerAvatar; }
            set
            {
                playerAvatar = value;
                OnPropertyChanged("PlayerAvatar");
            }
        }

        /// <summary>
        /// The players cash.
        /// </summary>
        private int playerCash;

        public int PlayerCash
        {
            get { return playerCash; }
            set
            {
                playerCash = value;
                OnPropertyChanged("PlayerCash");
            }
        }

        /// <summary>
        /// An array of IDs that correlate to each street in the game that the player owns.
        /// </summary>
        private int[] ownedStreetIDs;

        public int[] OwnedStreetIDs
        {
            get { return ownedStreetIDs; }
            set
            {
                ownedStreetIDs = value;
                OnPropertyChanged("OwnedStreetIDs");
            }
        }


        /// <summary>
        /// A collection of the objects of all streets the player owns.
        /// </summary>
        private ObservableCollection<GameCardViewModel> ownedSteets;

        public ObservableCollection<GameCardViewModel> OwnedStreets
        {
            get { return ownedSteets; }
            set
            {
                ownedSteets = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// The total amount of houses the player owns.
        /// </summary>
        private int amountHouses;

        public int AmountHouses
        {
            get { return amountHouses; }
            set { amountHouses = value; }
        }


        /// <summary>
        /// The total amount of hotels the player owns.
        /// </summary>
        private int amountHotels;

        public int AmountHotels
        {
            get { return amountHotels; }
            set { amountHotels = value; }
        }


        /// <summary>
        /// Flag to play or stop the pulse animation around the players avatar.
        /// </summary>
        private bool playPulseAnimation;

        public bool PlayPulseAnimation
        {
            get { return playPulseAnimation; }
            set
            {
                playPulseAnimation = value;
                OnPropertyChanged("PlayPulseAnimation");
            }
        }


        /// <summary>
        /// The score that the player achieved in the first throw mechanic. This determins the players starting "position".
        /// </summary>
        private int firstThrow;

        public int FirstThrow
        {
            get { return firstThrow; }
            set
            {
                firstThrow = value;
                OnPropertyChanged("FirstThrow");
            }
        }


        /// <summary>
        /// The current position of the character in the game. This spans between 0 (Go) and 39 (SchlossAllee).
        /// </summary>
        private int currentposition;

        public int CurrentPosition
        {
            get { return currentposition; }
            set
            {
                currentposition = value;
            }
        }


        /// <summary>
        /// Flag if the player is currently in prison.
        /// </summary>
        private bool inPrison;

        public bool InPrison
        {
            get { return inPrison; }
            set
            {
                inPrison = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// The amount of rolls the player does in a row. If he gets three doubles in a row he will go to prison.
        /// </summary>
        private int diceRoll;

        public int DiceRoll
        {
            get { return diceRoll; }
            set
            {
                if (diceRoll < 3)
                {
                diceRoll = value;
                    OnPropertyChanged();
                }
            }
        }




        public PlayerModel()
        {

        }

        public PlayerModel(PlayerModel passed)
        {
            IsActive = passed.IsActive;
            IsNPC = passed.IsNPC;
            PlayerName = passed.PlayerName;
            PlayerID = passed.PlayerID;
            PlayerAvatar = passed.PlayerAvatar;
            PlayerCash = passed.PlayerCash;
            OwnedStreetIDs = passed.OwnedStreetIDs;
            PlayPulseAnimation = passed.PlayPulseAnimation;
            FirstThrow = passed.FirstThrow;
            InPrison = passed.InPrison;
            DiceRoll = passed.DiceRoll;
            AmountHotels = passed.AmountHotels;
            AmountHouses = passed.AmountHouses;
            CurrentPosition = 0;
            OwnedStreets = new ObservableCollection<GameCardViewModel>();
            for (int i = 0; i < 27; i++)
            {
                OwnedStreets.Add(null);
            }
        }
    }
}
