using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Gamerules;
using MonopolyLibrary.ViewModel;
using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using Xunit;

namespace MonopolyLibrary.Tests.ViewModel
{
    public class PlayerViewModelTests
    {
        WindowContent contentTest = WindowContent.GetWindowContent();
        PlayerViewModel testPlayer;
        GameCardViewModel testGameCard;
        public PlayerViewModelTests()
        {
            testPlayer = new PlayerViewModel(new PlayerModel() { CurrentPosition = 0, AmountHotels = 0, AmountHouses = 0, FirstThrow = 0, PlayerCash = 2000, PlayerID = 0, PlayerName = "Test", PrisonRoll = 3 });
            contentTest.ManagingPlayer.AddPlayer(testPlayer);
            contentTest.ManagingPlayer.SetAllPlayerCollection();
            testGameCard = new GameCardViewModel(SetEnums.SetGameCard(StreetName.Schlossallee));
        }

        [Fact]
        public void MovePlayer_ShouldMovePlayerToAnotherPosition()
        {
            //Arrange
            int expected = 20;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);

            //Act
            testPlayer.MovePlayer(20);

            //Assert
            Assert.Equal(expected, testPlayer.CurrentPosition);
        }

        [Fact]
        public void MovePlayer_ShouldMovePlayerToAnotherPositionAndAdd200Cash()
        {
            //Arrange
            int expectedPosition = 1;
            int expectedCash = 2200;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);

            //Act
            testPlayer.MovePlayer(41);

            //Assert
            Assert.Equal(expectedPosition, testPlayer.CurrentPosition);
            Assert.Equal(expectedCash, testPlayer.PlayerCash);
        }

        [Fact]
        public void PlayerMoveToPosition_ShouldMovePlayerToAnotherPosition()
        {
            //Arrange
            int expectedPosition = 22;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);

            //Act
            testPlayer.PlayerMoveToPosition(22,false);

            //Assert
            Assert.Equal(expectedPosition, testPlayer.CurrentPosition);
        }

        [Fact]
        public void PlayerMoveToPosition_ShouldMovePlayerToAnotherPositionAndAdd200Cash()
        {
            //Arrange
            int expectedPosition = 22;
            int expectedCash = 2200;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);

            //Act
            testPlayer.PlayerMoveToPosition(22, true);

            //Assert
            Assert.Equal(expectedPosition, testPlayer.CurrentPosition);
            Assert.Equal(expectedCash, testPlayer.PlayerCash);
        }

        [Fact]
        public void MovedOverGo_ShouldAdd200Cash()
        {
            //Arrange
            int expectedCash = 2200;
            //Act
            testPlayer.MovedOverGo();
            //Assert
            Assert.Equal(expectedCash, testPlayer.PlayerCash);
        }

        [Fact]
        public void PlayerGoToPrison_ShouldSetPrisonFlags()
        {
            //Arrange
            bool expectedInPrinson = true;
            int expectedDiceRoll = 0;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[testPlayer.CurrentPosition].AddPlayerOnCard(testPlayer);
            //Act
            testPlayer.PlayerGoToPrison();
            //Assert
            Assert.Equal(expectedInPrinson, testPlayer.InPrison);
            Assert.Equal(expectedDiceRoll, testPlayer.PrisonRoll);
        }

        [Fact]
        public void PlayerGetsOutOfPrison_ShouldSetPrisonFlags()
        {
            //Arrange
            bool expectedInPrinson = false;
            int expectedDiceRoll = 0;
            //Act
            testPlayer.PlayerGetsOutOfPrison();
            //Assert
            Assert.Equal(expectedInPrinson, testPlayer.InPrison);
            Assert.Equal(expectedDiceRoll, testPlayer.PrisonRoll);
        }

        [Fact]
        public void PlayerAddMoney_ShouldAddAmountOfMoneyToPlayer()
        {
            //Arrange
            int expectedCash = 3000;
            //Act
            testPlayer.PlayerAddMoney(1000);
            //Assert
            Assert.Equal(expectedCash, testPlayer.PlayerCash);
        }

        [Fact]
        public void PlayerRemoveMoney_ShouldRemoveAmountOfMoneyFromPlayer()
        {
            //Arrange
            int expectedCash = 1000;
            //Act
            testPlayer.PlayerRemoveMoney(1000);
            //Assert
            Assert.Equal(expectedCash, testPlayer.PlayerCash);
        }

        [Fact]
        public void PlayerGivesPlayerMoney_ShouldRemoveAmountOfMoneyFromPlayerAndAddAmountOfMoneyToAnotherPlayer()
        {
            //Arrange
            int expectedCashPlayerOne = 1000;
            int expectedCashPlayerTwo = 3000;
            PlayerViewModel testPlayerTwo = new PlayerViewModel(new PlayerModel() { CurrentPosition = 0, AmountHotels = 0, AmountHouses = 0, FirstThrow = 0, PlayerCash = 2000, PlayerID = 0, PlayerName = "Test", PrisonRoll = 3 });
            //Act
            testPlayer.PlayerGivesPlayerMoney(testPlayerTwo, 1000);
            //Assert
            Assert.Equal(expectedCashPlayerOne, testPlayer.PlayerCash);
            Assert.Equal(expectedCashPlayerTwo, testPlayerTwo.PlayerCash);
        }

        [Fact]
        public void PlayerAddGameCard_ShouldAddGameCardToPlayerInventory()
        {
            //Arrange
            bool expectedCardOwnership = true;
            //Act
            testPlayer.PlayerAddGameCard(testGameCard);
            //Assert
            Assert.Equal(testGameCard, testPlayer.OwnedStreets[testGameCard.OwnerArrayID]);
            Assert.Equal(expectedCardOwnership, testPlayer.OwnedStreetIDs[testGameCard.OwnerArrayID]);
        }

        [Fact]
        public void PlayerRemoveGameCard_ShouldRemoveGameCardFromPlayerInventory()
        {
            //Arrange
            bool expectedCardOwnership = false;
            testPlayer.PlayerAddGameCard(testGameCard);
            //Act
            testPlayer.PlayerRemoveGameCard(testGameCard);
            //Assert
            Assert.Null(testPlayer.OwnedStreets[testGameCard.OwnerArrayID]);
            Assert.Equal(expectedCardOwnership, testPlayer.OwnedStreetIDs[testGameCard.OwnerArrayID]);
        }

        [Fact]
        public void MoveGameCardToAnotherPlayer_ShouldRemoveGameCardFromPlayerInventoryAndAddItToAnotherPlayerInventory()
        {
            //Arrange
            bool expectedPlayerOneCardOwnership = false;
            bool expectedPlayerTwoCardOwnership = true;
            PlayerViewModel testPlayerTwo = new PlayerViewModel(new PlayerModel() { CurrentPosition = 0, AmountHotels = 0, AmountHouses = 0, FirstThrow = 0, PlayerCash = 2000, PlayerID = 0, PlayerName = "Test", PrisonRoll = 3 });
            testPlayer.PlayerAddGameCard(testGameCard);
            //Act
            testPlayer.MoveGameCardToAnotherPlayer(testPlayerTwo, testPlayer.OwnedStreets[testGameCard.OwnerArrayID]);
            //Assert
            Assert.Null(testPlayer.OwnedStreets[testGameCard.OwnerArrayID]);
            Assert.Equal(testGameCard, testPlayerTwo.OwnedStreets[testGameCard.OwnerArrayID]);
            Assert.Equal(expectedPlayerOneCardOwnership, testPlayer.OwnedStreetIDs[testGameCard.OwnerArrayID]);
            Assert.Equal(expectedPlayerTwoCardOwnership, testPlayerTwo.OwnedStreetIDs[testGameCard.OwnerArrayID]);
        }

        [Fact]
        public void PlayerCheckBalance_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            //Act
            bool actual = testPlayer.PlayerCheckBalance(100);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerCheckBalance_ShouldReturnFalse()
        {
            //Arrange
            bool expected = false;
            //Act
            bool actual = testPlayer.PlayerCheckBalance(100000000);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerCashAfterBuying_ShouldReturnInteger()
        {
            //Arrange
            int expected = testPlayer.PlayerCash - testGameCard.StreetPrice;
            //Act
            int actual = testPlayer.PlayerCashAfterBuying(testGameCard);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerCashAfterBuildingHouse_ShouldReturnInteger()
        {
            //Arrange
            int expected = testPlayer.PlayerCash - testGameCard.HousePrice;
            //Act
            int actual = testPlayer.PlayerCashAfterBuildingHouse(testGameCard);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerCashAfterSellingHouse_ShouldReturnInteger()
        {
            //Arrange
            int expected = testPlayer.PlayerCash + testGameCard.HousePrice/2;
            //Act
            int actual = testPlayer.PlayerCashAfterSellingHouse(testGameCard);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerCashAfterPayingMortgage_ShouldReturnInteger()
        {
            //Arrange
            int expected = testPlayer.PlayerCash - testGameCard.Mortgage[1];
            //Act
            int actual = testPlayer.PlayerCashAfterPayingMortgage(testGameCard);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerCashTakingMortgage_ShouldReturnInteger()
        {
            //Arrange
            int expected = testPlayer.PlayerCash + testGameCard.Mortgage[0];
            //Act
            int actual = testPlayer.PlayerCashAfterTakingMortgage(testGameCard);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlayerSetMonopolies_ShouldReturnTrue()
        {
            //Arrange
            bool expected = true;
            testPlayer.OwnedStreetIDs[2] = true;
            testPlayer.OwnedStreetIDs[3] = true;
            testPlayer.OwnedStreetIDs[4] = true;
            //Act
            testPlayer.PlayerSetMonopolies();
            //Assert
            Assert.Equal(expected, testPlayer.Monopolies[1]);
        }

        [Fact]
        public void PlayerSetMonopolies_ShouldReturnFalse()
        {
            //Arrange
            bool expected = false;
            testPlayer.OwnedStreetIDs[2] = true;
            testPlayer.OwnedStreetIDs[3] = true;
            //Act
            testPlayer.PlayerSetMonopolies();
            //Assert
            Assert.Equal(expected, testPlayer.Monopolies[1]);
        }
    }

}
