using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Gamerules
{
    /// <summary>
    /// Game pool class that holds every Gameobject reference that is instanced.
    /// </summary>
    public class GamePool
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private HouseViewModel[] houses;

        public HouseViewModel[] Houses
        {
            get { return houses; }
            set { houses = value; }
        }

        private GameCardViewModel[] gameCards;

        public GameCardViewModel[] GameCards
        {
            get { return gameCards; }
            set { gameCards = value; }
        }



        public GamePool(WindowContent content)
        {
            Content = content;
            InitializeHouses();
            InitializeStreets();
        }

        /// <summary>
        /// Initializes every House in the game.
        /// </summary>
        public void InitializeHouses()
        {
            Houses = new HouseViewModel[24];
            for (int i = 0; i < 24; i++)
            {
                Houses[i] = new HouseViewModel(Content);
            }
        }

        /// <summary>
        /// Initializes every Hotel in the game.
        /// </summary>
        public void InitializeHotels()
        {

        }

        /// <summary>
        /// Initializes every Street in the game.
        /// </summary>
        public void InitializeStreets()
        {
            GameCards = new GameCardViewModel[]
            {
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.LOS)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Badstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Turmstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Einkommenssteuer)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Südbahnhof)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Chausseestraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Elisenstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Poststraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Gefängnis)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Seestraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.EWerk)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Hafenstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.NeueStraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Westbahnhof)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.MünchnerStraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.WienerStraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.BerlinerStraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.FreiParken)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.TheaterStraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Museumstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Opernplatz)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.NordBahnhof)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Lessingstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Schillerstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Wasserwerk)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Goethestraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.InDasGefängnis)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Rathausplatz)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Hauptstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Gemeinschaftsfeld)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Bahnhofstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Hauptbahnhof)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Ereignisfeld)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Parkstraße)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Zusatzsteuer)),
                new GameCardViewModel(Content, SetEnums.SetGameCard(Utility.StreetName.Schlossallee))
            };
        }

        /// <summary>
        /// Initializes both Get Out Of Jail cards in the game.
        /// </summary>
        public void InitializeOutOfJail()
        {

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
                if (house.InUse == false)
                {
                    house.BuiltStreet = street;
                    house.InUse = true;
                    return house;
                }
                return null;
            }
            Content.OpenMessageBox("Keine Häuser mehr verfügbar!");
            return null;
        }


        /// <summary>
        /// Adds a House / HouseViewModel back into the available pool.
        /// </summary>
        /// <param name="house"></param>
        public void AddHouseToPool(HouseViewModel house)
        {
            house.InUse = false;
            house.BuiltStreet = null;
        }
    }
}
