using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Gamerules;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
using MonopolyLibrary.Model;
using Xunit;
using MonopolyLibrary.PlayerHandling;

namespace MonopolyLibrary.Tests.Gamerules
{
    public class CommunityChestTests
    {
        CommunityChest communityChestRef;
        WindowContent contentTest;
        PlayerViewModel testPlayer;

        public CommunityChestTests()
        {
            contentTest = WindowContent.GetWindowContent();
            communityChestRef = WindowContent.GetWindowContent().CommunityChest;
            testPlayer = new PlayerViewModel(new PlayerModel() { CurrentPosition = 0, AmountHotels = 0, AmountHouses = 0, FirstThrow = 0, PlayerCash = 2000, PlayerID = 0, PlayerName = "Test", PrisonRoll = 7 }) ;
            WindowContent.GetWindowContent().ManagingPlayer.AddPlayer(testPlayer);
            WindowContent.GetWindowContent().ManagingPlayer.SetAllPlayerCollection();
        }

        [Fact]
        public void GoToSeeStr_ShouldSetPlayerToID11()
        {
            //Arrange
            testPlayer.CurrentPosition = 0;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);
            int expected = 11;
            //Act
            communityChestRef.GoToSeeStr(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.CurrentPosition);
        }
        [Fact]
        public void KreuzwortGewonnen_ShouldAdd100Cash()
        {
            //Arrange
            int expected = 2100;
            //Act
            communityChestRef.KreuzwortGewonnen(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.PlayerCash);
        }

        [Fact]
        public void GetRent_ShouldAdd150Cash()
        {
            //Arrange
            int expected = 2150;
            //Act
            communityChestRef.GetRent(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.PlayerCash);
        }

        //TODO Add GetOutOfJail Unit test.
        [Fact]
        public void GetOutOfJail_ShouldAddGetOutOfJailCardToInventory()
        {
            //Arrange
            
            //Act
            
            //Assert
            //Assert.Equal(expected, testPlayer.Player.PlayerCash);
        }

        [Fact]
        public void GoToGo_ShouldSetPlayerToID0AndAdd200Cash()
        {
            //Arrange
            testPlayer.CurrentPosition = 10;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[10].AddPlayerOnCard(testPlayer);
            int expected = 0;
            int expectedTwo = 2200;
            //Act
            communityChestRef.GoToGo(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.CurrentPosition);
            Assert.Equal(expectedTwo, testPlayer.PlayerCash);
        }

        [Fact]
        public void GetDiv_ShouldAdd50Cash()
        {
            //Arrange
            int expected = 2050;
            //Act
            communityChestRef.GetDiv(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.PlayerCash);
        }

        [Fact]
        public void GoToSchlossAllee_ShouldSetPlayerToID39()
        {
            //Arrange
            testPlayer.CurrentPosition = 0;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);
            int expected = 39;
            //Act
            communityChestRef.GoToSchlossAllee(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.CurrentPosition);
        }

        [Fact]
        public void GoToOpernPlatz_ShouldSetPlayerToID24()
        {
            //Arrange
            testPlayer.CurrentPosition = 0;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[0].AddPlayerOnCard(testPlayer);
            int expected = 24;
            //Act
            communityChestRef.GoToOpernplatz(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.CurrentPosition);
        }

        [Fact]
        public void MoveBackThree_ShouldSetPlayerToIDBackBy3()
        {
            //Arrange
            testPlayer.CurrentPosition = 10;
            contentTest.GetViewModel<GameBoardViewModel>().GamePool.GameCards[10].AddPlayerOnCard(testPlayer);
            int expected = 7;
            //Act
            communityChestRef.MoveBackThree(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.CurrentPosition);
        }
    }
}
