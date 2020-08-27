using MonopolyLibrary.Gamerules;
using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonopolyLibrary.Utility.Commands
{
    public class StreetInteractionCommands
    {

        private GamePool gamePool = new GamePool();

        public StreetInteractionCommands()
        {

        }

        /// <summary>
        /// The player takes on a mortgage
        /// </summary>
        /// <param name="gameCard"></param>
        public void TakeMortgage(GameCardViewModel gameCard)
        {
            if (gameCard.IsActivePlayerOwningPlayer())
            {
                gameCard.DecreaseHouseAmount();
                gameCard.GetOwningPlayer().PlayerAddMoney(gameCard.Mortgage[0]);
            }
        }

        /// <summary>
        /// The player pays off a mortgage
        /// </summary>
        /// <param name="gameCard"></param>
        public void PayMortgage(GameCardViewModel gameCard)
        {
            if (gameCard.IsActivePlayerOwningPlayer())
            {
                gameCard.IncreaseHouseAmount();
                gameCard.GetOwningPlayer().PlayerRemoveMoney(gameCard.Mortgage[1]);
            }
        }

        /// <summary>
        /// The player buys a house.
        /// </summary>
        /// <param name="gameCard"></param>
        public void BuyHouse(GameCardViewModel gameCard)
        {
            if (gameCard.IsActivePlayerOwningPlayer())
            {
                if (WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer().IsMonopolyComplete(gameCard))
                {
                    gameCard.SetMaxMonopolyHouses(gameCard);
                    if (gameCard.NrOfHousesLessThanMonopolyMax())
                    {
                        gameCard.IncreaseHouseAmount();
                        gameCard.GetOwningPlayer().PlayerRemoveMoney(gameCard.GetHousePrice());
                        gamePool.BuildHouse(gameCard);
                        gameCard.SetMinMonopolyHouses(gameCard);

                    }
                    else
                    {
                        WindowContent.GetWindowContent().OpenMessageBox("Bauen nicht möglich! Bauen Sie zunächst gleichmäßig viele Häuser auf diesem Monopol!");
                    }
                }
            }
        }

        /// <summary>
        /// The player buys a hotel.
        /// </summary>
        /// <param name="gameCard"></param>
        public void BuyHotel(GameCardViewModel gameCard)
        {
            if (gameCard.IsActivePlayerOwningPlayer())
            {
                if (WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer().IsMonopolyComplete(gameCard))
                {
                    gameCard.SetMaxMonopolyHouses(gameCard);
                    if (gameCard.NrOfHousesLessThanMonopolyMax())
                    {
                        gameCard.DecreaseHouseAmount();
                        gameCard.GetOwningPlayer().PlayerRemoveMoney(gameCard.GetHousePrice());
                        gamePool.BuildHotel(gameCard);
                        gameCard.SetMinMonopolyHouses(gameCard);

                    }
                    else
                    {
                        WindowContent.GetWindowContent().OpenMessageBox("Bauen nicht möglich! Bauen Sie zunächst gleichmäßig viele Häuser auf diesem Monopol!");
                    }
                }
            }
        }

        /// <summary>
        /// The player sells a house
        /// </summary>
        /// <param name="gameCard"></param>
        public void SellHouse(GameCardViewModel gameCard)
        {
            if (gameCard.IsActivePlayerOwningPlayer())
            {
                if (WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer().IsMonopolyComplete(gameCard))
                {
                    gameCard.SetMinMonopolyHouses(gameCard);
                    if (gameCard.NrOfHousesGreaterThanMonopolyMin())
                    {
                        gameCard.SetMaxMonopolyHouses(gameCard);
                        gameCard.DecreaseHouseAmount();
                        gameCard.GetOwningPlayer().PlayerAddMoney(gameCard.GetSellPrice());
                        gamePool.SellHouse(gameCard);
                    }
                    else
                    {
                        WindowContent.GetWindowContent().OpenMessageBox("Verkaufen nicht möglich! Um auf dieser Straße ein weiteres Haus verkaufen zu können müssen zunächst auf allen Straßen des Monopols gleich viele Häuser stehen!");
                    }
                }
            }
        }

        /// <summary>
        /// The player buys a hotel.
        /// </summary>
        /// <param name="gameCard"></param>
        public void SellHotel(GameCardViewModel gameCard)
        {
            if (gameCard.IsActivePlayerOwningPlayer())
            {
                if (WindowContent.GetWindowContent().GetManagingPlayer().GetActivePlayer().IsMonopolyComplete(gameCard))
                {
                    gameCard.SetMinMonopolyHouses(gameCard);
                    if (gameCard.NrOfHousesGreaterThanMonopolyMin())
                    {
                        gameCard.SetMaxMonopolyHouses(gameCard);
                        gameCard.DecreaseHouseAmount();
                        gameCard.GetOwningPlayer().PlayerAddMoney(gameCard.GetSellPrice());
                        gamePool.SellHotel(gameCard);
                    }
                    else
                    {
                        WindowContent.GetWindowContent().OpenMessageBox("Verkaufen nicht möglich! Um auf dieser Straße ein weiteres Haus verkaufen zu können müssen zunächst auf allen Straßen des Monopols gleich viele Häuser stehen!");
                    }
                }
            }
        }

    }
}
