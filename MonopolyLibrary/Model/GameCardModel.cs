using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Model
{
    public class GameCardModel
    {

        private int streetBoardID;

        public int StreetBoardID
        {
            get { return streetBoardID; }
            set { streetBoardID = value; }
        }


        /// <summary>
        /// Saves the street that this card represents.
        /// </summary>
        private StreetName streetState;

        public StreetName StreetState
        {
            get { return streetState; }
            set
            {
                streetState = value;
            }
        }

        /// <summary>
        /// The street name as a string.
        /// </summary>
        private string streetName;

        public string StreetName
        {
            get { return streetName; }
            set
            {
                streetName = value;
            }
        }

        private bool cardInteractable;

        public bool CardInteractable
        {
            get { return cardInteractable; }
            set
            {
                cardInteractable = value;
            }
        }

        private bool interactionActive;

        public bool InteractionActive
        {
            get { return interactionActive; }
            set { interactionActive = value; }
        }



        /// <summary>
        /// Saves the card size.
        /// </summary>
        private GameCardSizes cardSize;

        public GameCardSizes CardSize
        {
            get { return cardSize; }
            set
            {
                cardSize = value;
            }
        }


        /// <summary>
        /// The card width.
        /// </summary>
        private int cardWidth;

        public int CardWidth
        {
            get { return cardWidth; }
            set
            {
                if (CardSize == GameCardSizes.Small && value < 75)
                {
                    cardWidth = 75;
                }
                if (CardSize == GameCardSizes.Big && value < 100)
                {
                    cardWidth = 100;
                }
                cardWidth = value;
            }
        }

        /// <summary>
        /// The card height.
        /// </summary>
        private int cardHeight;

        public int CardHeight
        {
            get { return cardHeight; }
            set
            {
                if (value < 100)
                {
                    cardHeight = 100;
                }
                cardHeight = value;
            }
        }


        /// <summary>
        /// The color value for the street.
        /// </summary>
        private SolidColorBrush streetColor;

        public SolidColorBrush StreetColor
        {
            get { return streetColor; }
            set
            {
                streetColor = value;
            }
        }

        /// <summary>
        /// The street buying price.
        /// </summary>
        private int streetPrice;

        public int StreetPrice
        {
            get { return streetPrice; }
            set
            {
                streetPrice = value;
                StreetPriceText = value.ToString();
            }
        }

        /// <summary>
        /// The street buying price as a string.
        /// </summary>
        private string streetPriceText;
        public string StreetPriceText
        {
            get { return streetPriceText; }
            set
            {
                if (value != "0")
                {
                    streetPriceText = value;
                }
                else
                {
                    streetPriceText = "";
                }
            }
        }

        /// <summary>
        /// An array for the different rent prices for all houses on the card.
        /// </summary>
        private int[] rentPrices;

        public int[] RentPrices
        {
            get { return rentPrices; }
            set
            {
                rentPrices = value;
            }
        }

        /// <summary>
        /// The price for a house on this street.
        /// </summary>
        private int housePrice;

        public int HousePrice
        {
            get { return housePrice; }
            set
            {
                housePrice = value;
            }
        }

        /// <summary>
        /// The money value you get if you take a mortgage on the street.
        /// </summary>
        private int[] mortgage;

        public int[] Mortgage
        {
            get { return mortgage; }
            set
            {
                mortgage = value;
            }
        }


        /// <summary>
        /// The amount of houses currently on the street/card.
        /// </summary>
        private int nrOfHouses;

        public int NrOfHouses
        {
            get { return nrOfHouses; }
            set
            {
                nrOfHouses = value;
            }
        }

        private ObservableCollection<HouseViewModel> houses;

        public ObservableCollection<HouseViewModel> Houses
        {
            get { return houses; }
            set { houses = value; }
        }


        /// <summary>
        /// Flag if the card currently holds a hotel.
        /// </summary>
        private bool hotel;

        public bool Hotel
        {
            get { return hotel; }
            set { hotel = value; }
        }

        private int maxMonopolyHouses;

        public int MaxMonopolyHouses
        {
            get { return maxMonopolyHouses; }
            set { maxMonopolyHouses = value; }
        }

        private int minMonopolyHouses;

        public int MinMonopolyHouses
        {
            get { return minMonopolyHouses; }
            set { minMonopolyHouses = value; }
        }

        /// <summary>
        /// The player that owns this street.
        /// </summary>
        private PlayerViewModel owningPlayer;

        public PlayerViewModel OwningPlayer
        {
            get { return owningPlayer; }
            set
            {
                owningPlayer = value;
            }
        }

        /// <summary>
        /// A collection of players that are currently on this game card in die running game.
        /// </summary>
        private ObservableCollection<PlayerViewModel> playerOnGameCard;

        public ObservableCollection<PlayerViewModel> PlayerOnGameCard
        {
            get { return playerOnGameCard; }
            set { playerOnGameCard = value; }
        }

        /// <summary>
        /// The static index this street takes in the players array of owned streets.
        /// </summary>
        private int ownerArrayID;

        public int OwnerArrayID
        {
            get { return ownerArrayID; }
            set { ownerArrayID = value; }
        }

        private int monopoliesID;

        public int MonopoliesID
        {
            get { return monopoliesID; }
            set
            {
                monopoliesID = value;
            }
        }

        /// <summary>
        /// Flag to play or stop the pulse animation around the GameCard.
        /// </summary>
        private bool playPulseAnimation;

        public bool PlayPulseAnimation
        {
            get { return playPulseAnimation; }
            set
            {
                playPulseAnimation = value;
            }
        }



        public GameCardModel()
        {
            InitializeCollection();
        }

        /// <summary>
        /// Initializes all Collections in this Model.
        /// </summary>
        void InitializeCollection()
        {
            PlayerOnGameCard = new ObservableCollection<PlayerViewModel>();
            Houses = new ObservableCollection<HouseViewModel>();
        }
    }
}
