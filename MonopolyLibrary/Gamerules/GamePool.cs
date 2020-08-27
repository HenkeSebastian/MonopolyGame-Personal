using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Gamerules
{
    /// <summary>
    /// Game pool class that holds every Gameobject reference that is instanced.
    /// </summary>
    public class GamePool:BaseViewModel
    {

        private static HouseViewModel[] houses;

        public HouseViewModel[] Houses
        {
            get { return houses; }
            set 
            {
                houses = value;
                OnPropertyChanged("Houses");
            }
        }

        private static HouseViewModel[] unavailableHouses;

        public HouseViewModel[] UnavailableHouses
        {
            get { return unavailableHouses; }
            set { unavailableHouses = value; }
        }

        private static HouseViewModel[] hotels;

        public HouseViewModel[] Hotels
        {
            get { return hotels; }
            set { hotels = value; }
        }

        private static HouseViewModel[] unavailableHotels;

        public HouseViewModel[] UnavailableHotels
        {
            get { return unavailableHotels; }
            set { unavailableHotels = value; }
        }


        private static GameCardViewModel[] gameCards;

        public GameCardViewModel[] GameCards
        {
            get { return gameCards; }
            set { gameCards = value; }
        }

        private static int availableHouses;

        public int AvailableHouses
        {
            get { return availableHouses; }
            set 
            { 
                availableHouses = value;
                OnPropertyChanged("AvailableHouses");
            }
        }


        public GamePool()
        {
        }

        public void InitializePool()
        {
            InitializeHouses();
            InitializeHotels();
            InitializeUnavailableHouses();
            InitializeUnavailableHotels();
            InitializeStreets();
        }

        /// <summary>
        /// Initializes every House in the game.
        /// </summary>
        private void InitializeHouses()
        {
            Houses = new HouseViewModel[32];
            for (int i = 0; i < 32; i++)
            {
                Houses[i] = new HouseViewModel(false);
                Houses[i].HouseColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
            }
        }


        /// <summary>
        /// Initializes an array for unavailable houses in the game.
        /// </summary>
        private void InitializeUnavailableHouses()
        {
            UnavailableHouses = new HouseViewModel[32];
            for (int i = 0; i < 32; i++)
            {
                UnavailableHouses[i] = null;
            }
        }

        /// <summary>
        /// Initializes every Hotel in the game.
        /// </summary>
        private void InitializeHotels()
        {
            Hotels = new HouseViewModel[12];
            for (int i = 0; i < 12; i++)
            {
                Hotels[i] = new HouseViewModel(true);
                Hotels[i].HouseColor = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            }
        }

        /// <summary>
        /// Initializes an array for unavailable houses in the game.
        /// </summary>
        private void InitializeUnavailableHotels()
        {
            UnavailableHotels = new HouseViewModel[12];
            for (int i = 0; i < 12; i++)
            {
                UnavailableHotels[i] = null;
            }
        }

        /// <summary>
        /// Initializes every Street in the game.
        /// </summary>
        private void InitializeStreets()
        {
            GameCards = new GameCardViewModel[]
            {
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.LOS)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Badstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Turmstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Einkommenssteuer)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Südbahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Chausseestraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Elisenstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Poststraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gefängnis)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Seestraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.EWerk)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Hafenstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.NeueStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Westbahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.MünchnerStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.WienerStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.BerlinerStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.FreiParken)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.TheaterStraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Museumstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Opernplatz)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.NordBahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Lessingstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Schillerstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Wasserwerk)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Goethestraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.InDasGefängnis)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Rathausplatz)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Hauptstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Bahnhofstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Hauptbahnhof)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Parkstraße)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Zusatzsteuer)),
                new GameCardViewModel(SetEnums.SetGameCard(Utility.StreetName.Schlossallee))
            };
        }

        /// <summary>
        /// Initializes both Get Out Of Jail cards in the game.
        /// </summary>
        private void InitializeOutOfJail()
        {

        }

        private void UpdateAvailableHouses()
        {
            int i = 0;
            foreach (HouseViewModel item in Houses)
            {
                if (item != null)
                {
                    i++;
                }
            }
            AvailableHouses = i;
        }

        public static GameCardViewModel[] GetGameCards()
        {
            return gameCards;
        }

        /// <summary>
        /// Gets the game card that a player is currently standing on.
        /// </summary>
        /// <param name="selectPlayer">The given player.</param>
        /// <returns>Returns the game card object that the given player is standing on.</returns>
        public GameCardViewModel GetPlayerGameCard(PlayerViewModel selectPlayer)
        {
            return gameCards[selectPlayer.CurrentPosition];
        }

        public GameCardViewModel GetGameCard(int gameCardID)
        {
            return gameCards[gameCardID];
        }

        /// <summary>
        /// Returns a HouseViewModel reference of a house that is not yet in use.
        /// If no house is available it returns nothing and shows a MessageBox with information regarding this case.
        /// Sets all neccessary fields in the HouseViewModel.
        /// </summary>
        /// <param name="street"></param>
        /// <returns></returns>
        public HouseViewModel BuildHouse(GameCardViewModel street)
        {
            foreach (HouseViewModel house in Houses)
            {
                if (house.IsHouseNotNull() && house.IsHouseNotInUse())
                {
                    UnavailableHouses[house.GetUniqueID()] = house;
                    Houses[house.GetUniqueID()] = null;
                    house.SetBuiltStreet(street);
                    house.SetHouseInUse(true);
                    UpdateAvailableHouses();
                    street.AddHouseToStreet(house);
                    WindowContent.GetWindowContent().OpenMessageBox(String.Format("{0} Häuser übrig", AvailableHouses));
                    return house;
                }
            }
            WindowContent.GetWindowContent().OpenMessageBox("Keine Häuser mehr verfügbar!");
            return null;
        }

        public HouseViewModel BuildHotel(GameCardViewModel street)
        {
            AddHousesToPool(street);
            street.Houses.Clear();
            foreach (HouseViewModel hotel in Hotels)
            {
                if (hotel.IsHouseNotNull() && hotel.IsHouseNotInUse())
                {
                    UnavailableHotels[hotel.GetUniqueHotelID()] = hotel;
                    Hotels[hotel.GetUniqueHotelID()] = null;
                    hotel.SetBuiltStreet(street);
                    hotel.SetHouseInUse(true);
                    UpdateAvailableHouses();
                    street.AddHouseToStreet(hotel);
                    return hotel;
                }
            }
            WindowContent.GetWindowContent().OpenMessageBox("Keine Hotels mehr verfügbar!");
            return null;
        }

        public void SellHouse(GameCardViewModel street)
        {
            AddHouseToPool(street.Houses[street.Houses.Count-1]);
            street.RemoveHouseAtID(street.Houses.Count - 1);
        }

        public void SellHotel(GameCardViewModel street)
        {
            if (CheckSellHotel())
            {
                AddHotelToPool(street.Houses[0]);
                street.RemoveHouseAtID(0);
                for (int i = 0; i < 4; i++)
                {
                    BuildHouse(street);
                }
            }
        }

        private void AddHousesToPool(GameCardViewModel street)
        {
            foreach (HouseViewModel item in street.Houses)
            {
                AddHouseToPool(item);
            }
        }

        /// <summary>
        /// Adds a House / HouseViewModel back into the available pool.
        /// </summary>
        /// <param name="house"></param>
        public void AddHouseToPool(HouseViewModel house)
        {
            UnavailableHouses[house.GetUniqueID()] = null;
            Houses[house.GetUniqueID()] = house;
            house.SetHouseInUse(false);
            house.SetBuiltStreet(null);
            UpdateAvailableHouses();
        }

        /// <summary>
        /// Adds a Hotel / HouseViewModel back into the available pool.
        /// </summary>
        /// <param name="house"></param>
        public void AddHotelToPool(HouseViewModel hotel)
        {
            UnavailableHotels[hotel.GetUniqueHotelID()] = null;
            Hotels[hotel.GetUniqueHotelID()] = hotel;
            hotel.SetHouseInUse(false);
            hotel.SetBuiltStreet(null);
            UpdateAvailableHouses();
        }

        public bool CheckSellHotel()
        {
            int amount = 0;
            foreach (HouseViewModel house in Houses)
            {
                if (house != null)
                {
                    amount++;
                }
            }
            if (amount >= 4)
            {
                return true;
            }
            else
            {
                WindowContent.GetWindowContent().OpenMessageBox("Das Hotel kann nicht verkauft werden, da nicht genügend Häuser zur verfügung stehen.");
                return false;
            }
        }
    }
}
