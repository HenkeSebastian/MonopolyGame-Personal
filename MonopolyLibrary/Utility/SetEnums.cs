using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Utility
{
    public class SetEnums
    {
        public SetEnums()
        {
            
        }

        /// <summary>
        /// A GameCard object is created an all the paramaeters are filled in depending on which street is given as a parameter.
        /// </summary>
        /// <param name="streetName">The desired street</param>
        /// <returns>The object of the created street GameCardModel.</returns>
        public static GameCardModel SetGameCard(StreetName streetName)
        {
            switch (streetName)
            {
                case StreetName.LOS:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Big,
                        CardWidth = SetGameCardSize(GameCardSizes.Big)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Big)[1],
                        StreetName = "LOS",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Badstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Badstraße",
                        StreetPrice = 60,
                        RentPrices = new int[6] { 2, 10, 30, 90, 160, 250 },
                        HousePrice = 50,
                        Mortgage = new int[2] { 30, 33 },
                        StreetColor = SetStreetColors(StreetColors.Purple),
                        OwnerArrayID = 0,
                        MonopoliesID = 0,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Gemeinschaftsfeld:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Gemeinschafts-\nfeld",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Turmstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Turmstraße",
                        StreetPrice = 60,
                        RentPrices = new int[6] {4,20,60,180,320,450},
                        HousePrice = 50,
                        Mortgage = new int[2] {30,33},
                        StreetColor = SetStreetColors(StreetColors.Purple),
                        OwnerArrayID = 1,
                        MonopoliesID = 0,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Einkommenssteuer:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Einkommens-\nsteuer",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Südbahnhof:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Südbahnhof",
                        StreetPrice = 200,
                        RentPrices = new int[4] { 25, 50, 100, 200 },
                        Mortgage = new int[2] { 100, 110 },
                        StreetColor = new SolidColorBrush(Colors.Black),
                        OwnerArrayID = 22,
                        MonopoliesID = -1
                    };
                case StreetName.Chausseestraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Chausseestraße",
                        StreetPrice = 100,
                        RentPrices = new int[6] {6,30,90,270,400,550},
                        HousePrice = 50,
                        Mortgage = new int[2] {50,55},
                        StreetColor = SetStreetColors(StreetColors.LightBlue),
                        OwnerArrayID = 2,
                        MonopoliesID = 1,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Ereignisfeld:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Ereignisfeld",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Elisenstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Elisenstraße",
                        StreetPrice = 100,
                        RentPrices = new int[6] {6,30,90,270,400,550},
                        HousePrice = 50,
                        Mortgage = new int[2] {50,55},
                        StreetColor = SetStreetColors(StreetColors.LightBlue),
                        OwnerArrayID = 3,
                        MonopoliesID = 1,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Poststraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Poststraße",
                        StreetPrice = 120,
                        RentPrices = new int[6] {8,40,100,300,450,600},
                        HousePrice = 50,
                        Mortgage = new int[2] {60,66},
                        StreetColor = SetStreetColors(StreetColors.LightBlue),
                        OwnerArrayID = 4,
                        MonopoliesID = 1,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Gefängnis:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Big,
                        CardWidth = SetGameCardSize(GameCardSizes.Big)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Big)[1],
                        StreetName = "Im Gefängnis /\n Nur zu Besuch",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Seestraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Seestraße",
                        StreetPrice = 140,
                        RentPrices = new int[6] {10,50,150,450,625,750},
                        HousePrice = 100,
                        Mortgage = new int[2] {70,77},
                        StreetColor = SetStreetColors(StreetColors.Orchid),
                        OwnerArrayID = 5,
                        MonopoliesID = 2,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.EWerk:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Elektrizitätswerk",
                        StreetPrice = 150,
                        StreetColor = SetStreetColors(StreetColors.Yellow),
                        OwnerArrayID = 26,
                        MonopoliesID = -1
                    };
                case StreetName.Hafenstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Hafenstraße",
                        StreetPrice = 140,
                        RentPrices = new int[6] { 10, 50, 150, 450, 625, 750 },
                        HousePrice = 100,
                        Mortgage = new int[2] { 70, 77 },
                        StreetColor = SetStreetColors(StreetColors.Orchid),
                        OwnerArrayID = 6,
                        MonopoliesID = 2,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.NeueStraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Neue Straße",
                        StreetPrice = 160,
                        RentPrices = new int[6] { 12, 60, 180, 500, 700, 900 },
                        HousePrice = 100,
                        Mortgage = new int[2] { 80, 88 },
                        StreetColor = SetStreetColors(StreetColors.Orchid),
                        OwnerArrayID = 7,
                        MonopoliesID = 2,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };

                case StreetName.Westbahnhof:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Westbahnhof",
                        StreetPrice = 200,
                        RentPrices = new int[4] { 25, 50, 100, 200 },
                        StreetColor = new SolidColorBrush(Colors.Black),
                        OwnerArrayID = 23,
                        MonopoliesID = -1
                    };
                case StreetName.MünchnerStraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Münchner\n Straße",
                        StreetPrice = 180,
                        RentPrices = new int[6] { 14, 70, 200, 550, 750, 950 },
                        HousePrice = 100,
                        Mortgage = new int[2] { 90, 99 },
                        StreetColor = SetStreetColors(StreetColors.Orange),
                        OwnerArrayID = 8,
                        MonopoliesID = 3,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.WienerStraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Wiener Straße",
                        StreetPrice = 180,
                        RentPrices = new int[6] { 14, 70, 200, 550, 750, 950 },
                        HousePrice = 100,
                        Mortgage = new int[2] { 90, 99 },
                        StreetColor = SetStreetColors(StreetColors.Orange),
                        OwnerArrayID = 9,
                        MonopoliesID = 3,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.BerlinerStraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Berliner Straße",
                        StreetPrice = 200,
                        RentPrices = new int[6] { 16, 80, 220, 600, 800, 1000 },
                        HousePrice = 100,
                        Mortgage = new int[2] { 100, 110 },
                        StreetColor = SetStreetColors(StreetColors.Orange),
                        OwnerArrayID = 10,
                        MonopoliesID = 3,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.FreiParken:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Big,
                        CardWidth = SetGameCardSize(GameCardSizes.Big)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Big)[1],
                        StreetName = "Frei Parken",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.TheaterStraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Theaterstraße",
                        StreetPrice = 220,
                        RentPrices = new int[6] { 18, 90, 250, 700, 875, 1050 },
                        HousePrice = 150,
                        Mortgage = new int[2] { 110, 121 },
                        StreetColor = SetStreetColors(StreetColors.Red),
                        OwnerArrayID = 11,
                        MonopoliesID = 4,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Museumstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Museumstraße",
                        StreetPrice = 220,
                        RentPrices = new int[6] { 18, 90, 250, 700, 875, 1050 },
                        HousePrice = 150,
                        Mortgage = new int[2] { 110, 121 },
                        StreetColor = SetStreetColors(StreetColors.Red),
                        OwnerArrayID = 12,
                        MonopoliesID = 4,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Opernplatz:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Opernplatz",
                        StreetPrice = 240,
                        RentPrices = new int[6] { 20, 100, 300, 750, 925, 1100 },
                        HousePrice = 150,
                        Mortgage = new int[2] { 120, 132 },
                        StreetColor = SetStreetColors(StreetColors.Red),
                        OwnerArrayID = 13,
                        MonopoliesID = 4,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.NordBahnhof:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Nordbahnhof",
                        StreetPrice = 200,
                        RentPrices = new int[4] { 25, 50, 100, 200 },
                        StreetColor = new SolidColorBrush(Colors.Black),
                        OwnerArrayID = 24,
                        MonopoliesID = -1
                    };
                case StreetName.Lessingstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Lessingstraße",
                        StreetPrice = 260,
                        RentPrices = new int[6] { 22, 110, 330, 800, 975, 1150 },
                        HousePrice = 150,
                        Mortgage = new int[2] { 130, 143 },
                        StreetColor = SetStreetColors(StreetColors.Yellow),
                        OwnerArrayID = 14,
                        MonopoliesID = 5,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Schillerstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Schillerstraße",
                        StreetPrice = 260,
                        RentPrices = new int[6] { 22, 110, 330, 800, 975, 1150 },
                        HousePrice = 150,
                        Mortgage = new int[2] { 130, 143 },
                        StreetColor = SetStreetColors(StreetColors.Yellow),
                        OwnerArrayID = 15,
                        MonopoliesID = 5,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Wasserwerk:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Wasserwerk",
                        StreetPrice = 150,
                        StreetColor = SetStreetColors(StreetColors.RoyalBlue),
                        OwnerArrayID = 27,
                        MonopoliesID = -1
                    };
                case StreetName.Goethestraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Goethestraße",
                        StreetPrice = 280,
                        RentPrices = new int[6] { 24, 120, 360, 850, 1025, 1200 },
                        HousePrice = 150,
                        Mortgage = new int[2] { 140, 154 },
                        StreetColor = SetStreetColors(StreetColors.Yellow),
                        OwnerArrayID = 16,
                        MonopoliesID = 5,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.InDasGefängnis:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Big,
                        CardWidth = SetGameCardSize(GameCardSizes.Big)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Big)[1],
                        StreetName = "Gehen Sie in \n das Gefängnis",
                        StreetPrice = 0,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Rathausplatz:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Rathausplatz",
                        StreetPrice = 300,
                        RentPrices = new int[6] { 26, 130, 390, 900, 1100, 1275 },
                        HousePrice = 200,
                        Mortgage = new int[2] { 150, 165 },
                        StreetColor = SetStreetColors(StreetColors.Green),
                        OwnerArrayID = 17,
                        MonopoliesID = 6,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Hauptstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Hauptstraße",
                        StreetPrice = 300,
                        RentPrices = new int[6] { 26, 130, 390, 900, 1100, 1275 },
                        HousePrice = 200,
                        Mortgage = new int[2] { 150, 165 },
                        StreetColor = SetStreetColors(StreetColors.Green),
                        OwnerArrayID = 18,
                        MonopoliesID = 6,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Bahnhofstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Bahnhofstraße",
                        StreetPrice = 320,
                        RentPrices = new int[6] { 28, 150, 450, 1000, 1200, 1400 },
                        HousePrice = 200,
                        Mortgage = new int[2] { 160, 176 },
                        StreetColor = SetStreetColors(StreetColors.Green),
                        OwnerArrayID = 19,
                        MonopoliesID = 6,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Hauptbahnhof:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Hauptbahnhof",
                        StreetPrice = 200,
                        RentPrices = new int[4] { 25, 50, 100, 200 },
                        StreetColor = new SolidColorBrush(Colors.Black),
                        OwnerArrayID = 25,
                        MonopoliesID = -1
                    };
                case StreetName.Parkstraße:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Parkstraße",
                        StreetPrice = 350,
                        RentPrices = new int[6] { 35, 175, 500, 1100, 1300, 1500 },
                        HousePrice = 200,
                        Mortgage = new int[2] { 175, 193 },
                        StreetColor = SetStreetColors(StreetColors.RoyalBlue),
                        OwnerArrayID = 20,
                        MonopoliesID = 7,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
                case StreetName.Zusatzsteuer:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = false,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Zusatzsteuer",
                        StreetPrice = 100,
                        StreetColor = SetStreetColors(StreetColors.Transparent),
                        MonopoliesID = -1
                    };
                case StreetName.Schlossallee:
                    return new GameCardModel
                    {
                        StreetState = streetName,
                        CardInteractable = true,
                        CardSize = GameCardSizes.Small,
                        CardWidth = SetGameCardSize(GameCardSizes.Small)[0],
                        CardHeight = SetGameCardSize(GameCardSizes.Small)[1],
                        StreetName = "Schlossallee",
                        StreetPrice = 400,
                        RentPrices = new int[6] { 50, 200, 600, 1400, 1700, 2000 },
                        HousePrice = 200,
                        Mortgage = new int[2] { 200, 220 },
                        StreetColor = SetStreetColors(StreetColors.RoyalBlue),
                        OwnerArrayID = 21,
                        MonopoliesID = 7,
                        MaxMonopolyHouses = 0,
                        MinMonopolyHouses = 0
                    };
            }
            return new GameCardModel
            {
                StreetState = streetName,
                CardInteractable = false,
                CardSize = GameCardSizes.Small,
                CardWidth = 0,
                CardHeight = 0,
                StreetName = "",
                StreetPrice = 0,
                StreetColor = SetStreetColors(StreetColors.Transparent)
            };
        }

        /// <summary>
        /// Creates different colors for all the different streetcolors in the game.
        /// </summary>
        /// <param name="streetColors">The desired color.</param>
        /// <returns>The SolidColorBrush used for the Rectangle</returns>
        public static SolidColorBrush SetStreetColors(StreetColors streetColors)
        {
            switch (streetColors)
            {
                case StreetColors.Transparent:
                    return new SolidColorBrush(Colors.Transparent);
                case StreetColors.Purple:
                    return new SolidColorBrush(Colors.Purple);
                case StreetColors.LightBlue:
                    return new SolidColorBrush(Colors.Teal);
                case StreetColors.Orchid:
                    return new SolidColorBrush(Colors.Orchid);
                case StreetColors.Orange:
                    return new SolidColorBrush(Colors.Orange);
                case StreetColors.Red:
                    return new SolidColorBrush(Colors.Red);
                case StreetColors.Yellow:
                    return new SolidColorBrush(Colors.Yellow);
                case StreetColors.Green:
                    return new SolidColorBrush(Colors.Green);
                case StreetColors.RoyalBlue:
                    return new SolidColorBrush(Colors.RoyalBlue);
                default:
                    return new SolidColorBrush(Colors.Transparent);
            }
        }


        /// <summary>
        /// Creates different sizes for the two different sized game cards on the board.
        /// </summary>
        /// <param name="gameCardSizes">The desired size.</param>
        /// <returns>Returns an array of ints with the width and height value.</returns>
        public static int[] SetGameCardSize(GameCardSizes gameCardSizes)
        {
            switch (gameCardSizes)
            {
                case GameCardSizes.Small:
                    return new int[]
                    {
                        75,
                        100
                        
                    };
                case GameCardSizes.Big:
                    return new int[]
                    {
                        100,
                        100
                    };
                default:
                    return new int[]
                    {
                        0,
                        0
                    };
            }
        }

    }
}
