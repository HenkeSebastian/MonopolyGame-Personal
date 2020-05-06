using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility
{
    /// <summary>
    /// Enum for every street in the game.
    /// </summary>
    public enum StreetName
    {
        LOS,
        Badstraße,
        Gemeinschaftsfeld,
        Turmstraße,
        Einkommenssteuer,
        Südbahnhof,
        Chausseestraße,
        Ereignisfeld,
        Elisenstraße,
        Poststraße,
        Gefängnis,
        Seestraße,
        EWerk,
        Hafenstraße,
        NeueStraße,
        Westbahnhof,
        MünchnerStraße,
        WienerStraße,
        BerlinerStraße,
        FreiParken,
        TheaterStraße,
        Museumstraße,
        Opernplatz,
        NordBahnhof,
        Lessingstraße,
        Schillerstraße,
        Wasserwerk,
        Goethestraße,
        InDasGefängnis,
        Rathausplatz,
        Hauptstraße,
        Bahnhofstraße,
        Hauptbahnhof,
        Parkstraße,
        Zusatzsteuer,
        Schlossallee
    }

    /// <summary>
    /// Enum for the different Colors of each GameCard. With this Colors need to be changed only once and not with every GameCard.
    /// </summary>
    public enum StreetColors
    {
        Transparent,
        Purple,
        LightBlue,
        Orchid,
        Orange,
        Red,
        Yellow,
        Green,
        RoyalBlue
    }

    /// <summary>
    /// Enum for the two different card sizes on the board.
    /// </summary>
    public enum GameCardSizes
    {
        Small,
        Big
    }

    /// <summary>
    /// Enum for the Dice.
    /// </summary>
    public enum Die
    {
        DieOne,
        DieTwo
    }

    /// <summary>
    /// Enum for the different Windows in the game.
    /// </summary>
    public enum Windows
    {
        StartScreen,
        PlayerCreation,
        GameWindow,
        GameOver,
        EndScreen,
        ClosingScreen,
        StartingRoll,
        GameBoardScreen,
        IdleDetails,
        GameCardDetails,
        GameCard,
        StreetInteractionDetails,
        StreetBuyingDetails,
        CommunityDetails
    }
}
