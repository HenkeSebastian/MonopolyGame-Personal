using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MonopolyLibrary.ViewModel
{
    public class GameCardViewModel: BaseViewModel
    {
        public Windows Window
        {
            get { return Windows.GameCard; }
        }

        private GameCardModel gameCard;

        public GameCardModel GameCard
        {
            get { return gameCard; }
        }

        public StreetName StreetState
        {
            get { return GameCard.StreetState; }
            set
            {
                GameCard.StreetState = value;
                OnPropertyChanged("StreetState");
            }
        }

        public bool CardInteractable
        {
            get { return GameCard.CardInteractable; }
            set
            {
                GameCard.CardInteractable = value;
                OnPropertyChanged("CardInteractable");
            }
        }

        public GameCardSizes CardSize
        {
            get { return GameCard.CardSize; }
            set
            {
                GameCard.CardSize = value;
                OnPropertyChanged("CardSize");
            }
        }

        public int CardWidth
        {
            get { return GameCard.CardWidth; }
            set
            {
                GameCard.CardWidth = value;
                OnPropertyChanged("CardWidth");
            }
        }

        public int CardHeight
        {
            get { return GameCard.CardHeight; }
            set
            {
                GameCard.CardHeight = value;
                OnPropertyChanged("CardHeight");
            }
        }

        public string StreetName
        {
            get { return GameCard.StreetName; }
            set
            {
                GameCard.StreetName = value;
                OnPropertyChanged("StreetName");
            }
        }

        public int StreetPrice
        {
            get { return GameCard.StreetPrice; }
            set
            {
                GameCard.StreetPrice = value;
                OnPropertyChanged("StreetPrice");
            }
        }

        public string StreetPriceText
        {
            get { return GameCard.StreetPriceText; }
            set
            {
                GameCard.StreetPriceText = value;
                OnPropertyChanged("StreetPriceText");
            }
        }

        public int[] RentPrices
        {
            get { return GameCard.RentPrices; }
            set
            {
                GameCard.RentPrices = value;
                OnPropertyChanged("RentPrices");
            }
        }

        public int HousePrice
        {
            get { return GameCard.HousePrice; }
            set
            {
                GameCard.HousePrice = value;
                OnPropertyChanged("HousePrice");
            }
        }

        public int[] Mortgage
        {
            get { return GameCard.Mortgage; }
            set
            {
                GameCard.Mortgage = value;
                OnPropertyChanged("Mortgage");
            }
        }

        public SolidColorBrush StreetColor
        {
            get { return GameCard.StreetColor; }
            set
            {
                GameCard.StreetColor = value;
                OnPropertyChanged("StreetColor");
            }
        }

        public int NrOfHouses
        {
            get { return GameCard.NrOfHouses; }
            set
            {
                GameCard.NrOfHouses = value;
                OnPropertyChanged("NrOfHouses");
            }
        }

        public ObservableCollection<HouseViewModel> Houses
        {
            get { return GameCard.Houses; }
            set
            {
                GameCard.Houses = value;
                OnPropertyChanged("Houses");
            }
        }

        public bool Hotel
        {
            get { return GameCard.Hotel; }
            set
            {
                GameCard.Hotel = value;
                OnPropertyChanged("Hotel");
            }
        }

        public PlayerViewModel OwningPlayer
        {
            get { return GameCard.OwningPlayer; }
            set
            {
                GameCard.OwningPlayer = value;
                OnPropertyChanged("OwningPlayer");
            }
        }

        public ObservableCollection<PlayerViewModel> PlayerOnGameCard
        {
            get { return GameCard.PlayerOnGameCard; }
            set
            {
                GameCard.PlayerOnGameCard = value;
                OnPropertyChanged("PlayerOnGameCard");
            }
        }

        public int OwnerArrayID
        {
            get { return GameCard.OwnerArrayID; }
            set
            {
                GameCard.OwnerArrayID = value;
                OnPropertyChanged("OwnerArrayID");
            }
        }

        public int MonopoliesID
        {
            get { return GameCard.MonopoliesID; }
            set
            {
                GameCard.MonopoliesID = value;
                OnPropertyChanged("MonopoliesID");
            }
        }

        public int MaxMonopolyHouses
        {
            get => GameCard.MaxMonopolyHouses;
            set
            {
                GameCard.MaxMonopolyHouses = value;
                OnPropertyChanged("MaxMonopolyHouses");
            }
        }

        public int MinMonopolyHouses
        {
            get => GameCard.MinMonopolyHouses;
            set
            {
                GameCard.MinMonopolyHouses = value;
                OnPropertyChanged("MinMonopolyHouses");
            }
        }



        /// <summary>
        /// Constructor for the Game Card View Model.
        /// </summary>
        public GameCardViewModel(WindowContent content, GameCardModel passedGameCard)
        {
            Content = content;
            gameCard = passedGameCard;
        }

        /// <summary>
        /// Returns the Player holding this Card.
        /// </summary>
        /// <returns></returns>
        public PlayerViewModel GetOwningPlayer()
        {
            return OwningPlayer;
        }

        /// <summary>
        /// Returns the amount of Rent a player gets due to the amount of houses on it.
        /// </summary>
        /// <returns></returns>
        public int GetRentPrice()
        {
            return RentPrices[GameCard.NrOfHouses];
        }


        /// <summary>
        /// Finds a player on the Game Card.
        /// </summary>
        /// <param name="playerToFind">The player to find</param>
        /// <returns>Returns the Collection Index of the player on the Card.</returns>
        public int FindPlayerViewModelOnCard(PlayerViewModel playerToFind)
        {
            return PlayerOnGameCard.IndexOf(playerToFind);
        }

        /// <summary>
        /// Delets a player from the collection/card.
        /// </summary>
        /// <param name="index">Index of the player to delete</param>
        public void DeletePlayerOnCard(int index)
        {
            PlayerOnGameCard.RemoveAt(index);
        }

        /// <summary>
        /// Adds a Player to the collection/card.
        /// </summary>
        /// <param name="playerToAdd">The player to add</param>
        public void AddPlayerOnCard(PlayerViewModel playerToAdd)
        {
            PlayerOnGameCard.Add(playerToAdd);
        }

        /// <summary>
        /// A Player buying a Street. It will be added to the Players owned streets array.
        /// </summary>
        /// <param name="buyingPlayer">The buying player.</param>
        public void PlayerBuyingStreet(PlayerViewModel buyingPlayer)
        {
            buyingPlayer.OwnedStreets[OwnerArrayID] = this;
        }

        /// <summary>
        /// Adds an owner to the Street object.
        /// </summary>
        /// <param name="owningPlayer">The player to add as an owner</param>
        public void AddOwningPlayer(PlayerViewModel owningPlayer)
        {
            OwningPlayer = owningPlayer;
        }

        /// <summary>
        /// Checks if the street already has an owner.
        /// </summary>
        /// <returns>Returns true if the street is owned by a player and false if it is still buyable.</returns>
        public bool CheckStreetOwner()
        {
            if (OwningPlayer != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Creates a house on this street.
        /// </summary>
        public void BuildHouse()
        {
            Houses.Add(Content.GamePool.BuildHouse(this));
        }

        /// <summary>
        /// Sells the last built house on this street.
        /// </summary>
        public void SellHouse()
        {
            Content.GamePool.AddHouseToPool(Houses[Houses.Count - 1]);
            Houses.RemoveAt(Houses.Count - 1);
        }

        public void SetMaxMonopolyHouses(GameCardViewModel passedStreet)
        {
            foreach (GameCardViewModel street in Content.GamePool.GameCards)
            {
                if (street.MonopoliesID == passedStreet.MonopoliesID)
                {
                    if (street.NrOfHouses != NrOfHouses)
                    {

                        return;
                    }
                    street.MaxMonopolyHouses += 1;
                }
            }
        }


        /// <summary>
        /// Actions that will be triggered if a player is landing on said card.
        /// </summary>
        /// <param name="playerOnCard">The player triggering the action</param>
        public void CardAction(PlayerViewModel playerOnCard)
        {
            switch (StreetState)
            {
                case Utility.StreetName.LOS:
                    playerOnCard.PlayerAddMoney(200);
                    break;
                case Utility.StreetName.Gemeinschaftsfeld:
                    Content.CommunityChest.ExecuteCommunityChest(playerOnCard);
                    Content.ChangeDetailsView(Windows.CommunityDetails);
                    Content.GameBoardViewModel.SetDoneButton(true);
                    break;
                case Utility.StreetName.Einkommenssteuer:
                    playerOnCard.PlayerRemoveMoney(200);
                    break;
                case Utility.StreetName.Ereignisfeld:
                    break;
                case Utility.StreetName.Gefängnis:
                    break;
                case Utility.StreetName.FreiParken:
                    break;
                case Utility.StreetName.InDasGefängnis:
                    playerOnCard.PlayerGoToPrison();
                    break;
                case Utility.StreetName.Zusatzsteuer:
                    playerOnCard.PlayerRemoveMoney(100);
                    break;
                default:
                    if (GetOwningPlayer() != null)
                    {
                        if (GetOwningPlayer() != Content.ManagingPlayer.GetActivePlayer())
                        {
                            Content.ManagingPlayer.GetActivePlayer().PlayerGivesPlayerMoney(GetOwningPlayer(), GetRentPrice());
                            Content.GameBoardViewModel.SetDoneButton(true);
                        }
                    }
                    else
                    {
                        Content.ButtonBindings.ButtonCommands.GameCardCommands.OpenStreetBuying(Content.ManagingPlayer.GetActivePlayer(), Content.GameBoardViewModel.GetPlayerGameCard(Content.ManagingPlayer.GetActivePlayer()));
                    }
                    break;
            }
        }
    }
}
