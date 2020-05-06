using MonopolyLibrary.Model;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility.Commands
{
    public class StreetInteractionCommands
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public StreetInteractionCommands(WindowContent content)
        {
            Content = content;
        }

        /// <summary>
        /// The player takes on a mortgage
        /// </summary>
        /// <param name="gameCard"></param>
        public void TakeMortgage(GameCardViewModel gameCard)
        {
            if (gameCard.OwningPlayer == Content.ManagingPlayer.GetActivePlayer())
            {
                gameCard.NrOfHouses -= 1;
                gameCard.OwningPlayer.PlayerAddMoney(gameCard.Mortgage[0]);
            }
        }

        /// <summary>
        /// The player pays off a mortgage
        /// </summary>
        /// <param name="gameCard"></param>
        public void PayMortgage(GameCardViewModel gameCard)
        {
            if (gameCard.OwningPlayer == Content.ManagingPlayer.GetActivePlayer())
            {
                gameCard.NrOfHouses += 1;
                gameCard.OwningPlayer.PlayerRemoveMoney(gameCard.Mortgage[1]);
            }
        }

        /// <summary>
        /// The player buys a house.
        /// </summary>
        /// <param name="gameCard"></param>
        public void BuyHouse(GameCardViewModel gameCard)
        {
            if (gameCard.OwningPlayer == Content.ManagingPlayer.GetActivePlayer())
            {
                if (Content.ManagingPlayer.GetActivePlayer().Monopolies[gameCard.MonopoliesID] == true)
                {
                    gameCard.NrOfHouses += 1;
                    gameCard.OwningPlayer.PlayerRemoveMoney(gameCard.HousePrice);
                    gameCard.BuildHouse();
                }
            }
        }

        /// <summary>
        /// The player sells a house
        /// </summary>
        /// <param name="gameCard"></param>
        public void SellHouse(GameCardViewModel gameCard)
        {
            if (gameCard.OwningPlayer == Content.ManagingPlayer.GetActivePlayer())
            {
                if (Content.ManagingPlayer.GetActivePlayer().Monopolies[gameCard.MonopoliesID] == true)
                {
                    gameCard.NrOfHouses -= 1;
                    gameCard.OwningPlayer.PlayerAddMoney(gameCard.HousePrice / 2);
                    gameCard.SellHouse();
                }
            }
        }
    }
}
