using MonopolyLibrary.Gamerules;
using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Utility.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MonopolyLibrary.ViewModel
{
    public class GameCardViewModel: BaseViewModel
    {
        private GameCardCommands gameCardCommands = new GameCardCommands();

        private GameCardModel gameCard;

        public GameCardModel GameCard
        {
            get { return gameCard; }
            set
            {
                gameCard = value;
                OnPropertyChanged("GameCard");
            }
        }

        public int StreetBoardID
        {
            get => GameCard.StreetBoardID;
            set
            {
                GameCard.StreetBoardID = value;
                OnPropertyChanged("StreetBoardID");
            }
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

        public string StreetName
        {
            get { return GameCard.StreetName; }
            set
            {
                GameCard.StreetName = value;
                OnPropertyChanged("StreetName");
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

        public bool InteractionActive
        {
            get => GameCard.InteractionActive;
            set
            {
                GameCard.InteractionActive = value;
                OnPropertyChanged("InteractionActive");
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

        public SolidColorBrush StreetColor
        {
            get { return GameCard.StreetColor; }
            set
            {
                GameCard.StreetColor = value;
                OnPropertyChanged("StreetColor");
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
        public bool PlayPulseAnimation
        {
            get { return GameCard.PlayPulseAnimation; }
            set
            {
                GameCard.PlayPulseAnimation = value;
                OnPropertyChanged("PlayPulseAnimation");
            }
        }




        /// <summary>
        /// Constructor for the Game Card View Model.
        /// </summary>
        public GameCardViewModel(GameCardModel passedGameCard)
        {
            ViewModelWindow = Windows.GameCard;
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

        public bool IsGameCardInteractable()
        {
            return CardInteractable;
        }

        public void SetInteractionActive(bool state)
        {
            InteractionActive = state;
        }

        public bool IsActivePlayerOwningPlayer()
        {
            if (GetOwningPlayer() == WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddHouseToStreet(HouseViewModel house)
        {
            Houses.Add(house);
        }

        public void RemoveHouseAtID(int iD)
        {
            Houses.RemoveAt(iD);
        }

        /// <summary>
        /// Returns the amount of Rent a player gets due to the amount of houses on it.
        /// </summary>
        /// <returns></returns>
        public int GetRentPrice()
        {
            return RentPrices[GameCard.NrOfHouses];
        }

        public int GetHousePrice()
        {
            return HousePrice;
        }

        public int GetSellPrice()
        {
            return HousePrice / 2;
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

        public void IncreaseHouseAmount(int amount = 1)
        {
            NrOfHouses += amount;
        }

        public void DecreaseHouseAmount(int amount = 1)
        {
            NrOfHouses -= amount;
        }


        public List<GameCardViewModel> GetMonopolyGameCards(GameCardViewModel passedGameCard)
        {
            List<GameCardViewModel> foundStreets = new List<GameCardViewModel>();
            foreach (GameCardViewModel street in GamePool.GetGameCards())
            {
                if (street.MonopoliesID == passedGameCard.MonopoliesID)
                {
                    foundStreets.Add(street);
                }
            }
            return foundStreets;
        }

        public int FindMonopolyMaximumHouses(List<GameCardViewModel> inputStreets)
        {
            switch (inputStreets.Count)
            {
                case 2:
                    return Math.Max(inputStreets[0].NrOfHouses, inputStreets[1].NrOfHouses);
                case 3:
                    return MathAdvanced.Max(inputStreets[0].NrOfHouses, inputStreets[1].NrOfHouses, inputStreets[2].NrOfHouses);
                default:
                    return 0;
            }
        }
        public int FindMonopolyMinimumHouses(List<GameCardViewModel> inputStreets)
        {
            switch (inputStreets.Count)
            {
                case 2:
                    return Math.Min(inputStreets[0].NrOfHouses, inputStreets[1].NrOfHouses);
                case 3:
                    return MathAdvanced.Min(inputStreets[0].NrOfHouses, inputStreets[1].NrOfHouses, inputStreets[2].NrOfHouses);
                default:
                    return 0;
            }
        }

        public void SetMaxMonopolyHouses(GameCardViewModel passedStreet)
        {
            List<GameCardViewModel> listOfStreetsInMonopoly = GetMonopolyGameCards(passedStreet);
            int maximumOfHousesInMonopoly = FindMonopolyMaximumHouses(listOfStreetsInMonopoly);
            switch (listOfStreetsInMonopoly.Count)
            {
                case 2:
                    if (listOfStreetsInMonopoly[0].NrOfHouses == listOfStreetsInMonopoly[1].NrOfHouses)
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            if (street.MaxMonopolyHouses < 5)
                            {
                                street.MaxMonopolyHouses = maximumOfHousesInMonopoly + 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            street.MaxMonopolyHouses = maximumOfHousesInMonopoly;
                        }
                    }
                    break;
                case 3:
                    if (listOfStreetsInMonopoly[0].NrOfHouses == listOfStreetsInMonopoly[1].NrOfHouses && listOfStreetsInMonopoly[1].NrOfHouses == listOfStreetsInMonopoly[2].NrOfHouses)
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            if (street.MaxMonopolyHouses < 5)
                            {
                            street.MaxMonopolyHouses = maximumOfHousesInMonopoly + 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            street.MaxMonopolyHouses = maximumOfHousesInMonopoly;
                        }
                    }
                    break;
                default:
                    break;
            }
        }



        public void SetMinMonopolyHouses(GameCardViewModel passedStreet)
        {
            List<GameCardViewModel> listOfStreetsInMonopoly = GetMonopolyGameCards(passedStreet);
            int minimumOfHousesInMonopoly = FindMonopolyMinimumHouses(listOfStreetsInMonopoly);
            switch (listOfStreetsInMonopoly.Count)
            {
                case 2:
                    if (listOfStreetsInMonopoly[0].NrOfHouses == listOfStreetsInMonopoly[1].NrOfHouses)
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            if (street.MinMonopolyHouses > -1)
                            {
                                street.MinMonopolyHouses = minimumOfHousesInMonopoly - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            street.MinMonopolyHouses = minimumOfHousesInMonopoly;
                        }
                    }
                    break;
                case 3:
                    if (listOfStreetsInMonopoly[0].NrOfHouses == listOfStreetsInMonopoly[1].NrOfHouses && listOfStreetsInMonopoly[1].NrOfHouses == listOfStreetsInMonopoly[2].NrOfHouses)
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            if (street.MinMonopolyHouses > -1)
                            {
                                street.MinMonopolyHouses = minimumOfHousesInMonopoly - 1;
                            }
                        }
                    }
                    else
                    {
                        foreach (GameCardViewModel street in listOfStreetsInMonopoly)
                        {
                            street.MinMonopolyHouses = minimumOfHousesInMonopoly;
                        }
                    }
                    break;
                default:
                    break;
            }
        }


        public bool NrOfHousesGreaterThanMonopolyMin()
        {
            if (NrOfHouses > MinMonopolyHouses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NrOfHousesLessThanMonopolyMax()
        {
            if (NrOfHouses < MaxMonopolyHouses)
            {
                return true;
            }
            else
            {
                return false;
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
                    WindowContent.GetWindowContent().CommunityChest.ExecuteCommunityChest(playerOnCard);
                    WindowContent.GetWindowContent().SetDetailsViewModelActive<CommunityDetailsViewModel>();
                    WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
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
                        if ( ! IsActivePlayerOwningPlayer())
                        {
                            WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer().PlayerGivesPlayerMoney(GetOwningPlayer(), GetRentPrice());
                            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
                        }
                    }
                    else
                    {
                        WindowContent.GetWindowContent().GetDetailsViewModel<StreetBuyingViewModel>().OpenStreetBuyingWindow(WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer(), WindowContent.GetWindowContent().GetViewModel<GameBoardViewModel>().GamePool.GetPlayerGameCard(WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer()));
                    }
                    break;
            }
        }
    }
}
