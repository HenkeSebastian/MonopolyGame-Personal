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

namespace MonopolyLibrary.Tests.Gamerules
{
    public class C_CommunityChestTests
    {
        C_CommunityChest communityChestRef = new C_CommunityChest();
        WindowContent contentTest = new WindowContent();
        PlayerViewModel testPlayer;

        public C_CommunityChestTests()
        {
            testPlayer = new PlayerViewModel(contentTest) { Player = new PlayerModel() { CurrentPosition = 0, AmountHotels = 0, AmountHouses = 0, FirstThrow = 0, PlayerCash = 2000, PlayerID = 0, PlayerName = "Test", DiceRoll = 7 } };
        }

        [Fact]
        public void GoToSeeStr_ShouldSetPlayerToID11()
        {
            //Arrange
            testPlayer.Player.CurrentPosition = 0;
            contentTest.GameViewViewModel.GameCards[0].AddPlayerOnCard(testPlayer);
            int expected = 11;
            //Act
            communityChestRef.GoToSeeStr(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.CurrentPosition);
        }
        [Fact]
        public void KreuzwortGewonnen_ShouldAdd100Cash()
        {
            //Arrange
            int expected = 2100;
            //Act
            communityChestRef.KreuzwortGewonnen(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.PlayerCash);
        }

        [Fact]
        public void GetRent_ShouldAdd150Cash()
        {
            //Arrange
            int expected = 2150;
            //Act
            communityChestRef.GetRent(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.PlayerCash);
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
            testPlayer.Player.CurrentPosition = 10;
            contentTest.GameViewViewModel.GameCards[10].AddPlayerOnCard(testPlayer);
            int expected = 0;
            int expectedTwo = 2200;
            //Act
            communityChestRef.GoToGo(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.CurrentPosition);
            Assert.Equal(expectedTwo, testPlayer.Player.PlayerCash);
        }

        [Fact]
        public void GetDic_ShouldAdd50Cash()
        {
            //Arrange
            int expected = 2050;
            //Act
            communityChestRef.GetDiv(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.PlayerCash);
        }

        [Fact]
        public void GoToSchlossAllee_ShouldSetPlayerToID39()
        {
            //Arrange
            testPlayer.Player.CurrentPosition = 0;
            contentTest.GameViewViewModel.GameCards[0].AddPlayerOnCard(testPlayer);
            int expected = 39;
            //Act
            communityChestRef.GoToSchlossAllee(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.CurrentPosition);
        }

        [Fact]
        public void GoToOpernPlatz_ShouldSetPlayerToID24()
        {
            //Arrange
            testPlayer.Player.CurrentPosition = 0;
            contentTest.GameViewViewModel.GameCards[0].AddPlayerOnCard(testPlayer);
            int expected = 24;
            //Act
            communityChestRef.GoToOpernplatz(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.CurrentPosition);
        }

        [Fact]
        public void MoveBackThree_ShouldSetPlayerToIDBackBy3()
        {
            //Arrange
            testPlayer.Player.CurrentPosition = 10;
            contentTest.GameViewViewModel.GameCards[10].AddPlayerOnCard(testPlayer);
            int expected = 7;
            //Act
            communityChestRef.MoveBackThree(testPlayer);
            //Assert
            Assert.Equal(expected, testPlayer.Player.CurrentPosition);
        }
    }
}
