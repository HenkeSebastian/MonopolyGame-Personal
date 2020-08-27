using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary;
using MonopolyLibrary.ViewModel;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Model;
using Xunit;

namespace MonopolyLibrary.Tests.Dice
{
    public class DiceFunctionalityTests
    {
        WindowContent testContent = WindowContent.GetWindowContent();
        DiceViewModel diceVM = WindowContent.GetWindowContent().GetViewModel<DiceViewModel>();

        public DiceFunctionalityTests()
        {
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void SetDiceImage_ShouldReturnSourceString(int value)
        {
            //Arrange
            string expected = $"pack://application:,,,/MonopolyLibrary;Component/Resources/Die/{value}.png";
            //Act
            //string actual = diceVM.SetDieImage(value);
            //Assert
            //Assert.Equal(expected, actual);
        }

        [Fact]
        public void DiceRoll_ShouldReturnRandomNumbers()
        {
            //Arrange

            //Act
            diceVM.RollDice();

            //Assert
            Assert.InRange(diceVM.DieOne, 1, 6);
            Assert.InRange(diceVM.DieTwo, 1, 6);
        }
    }
}
