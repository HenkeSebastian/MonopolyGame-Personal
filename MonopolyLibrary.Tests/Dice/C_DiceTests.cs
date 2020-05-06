using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary;
using MonopolyLibrary.Dice;
using MonopolyLibrary.ViewModel;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Model;
using Xunit;

namespace MonopolyLibrary.Tests.Dice
{
    public class C_DiceTests
    {
        WindowContent testContent;
        C_Dice refDice;
        DiceViewModel diceVM;

        public C_DiceTests()
        {
            refDice = new C_Dice();
            testContent = new WindowContent();
            diceVM = new DiceViewModel(testContent);
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
            string actual = refDice.SetDieImage(value);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DiceRoll_ShouldReturnRandomNumbers()
        {
            //Arrange

            //Act
            refDice.RollDice(diceVM);

            //Assert
            Assert.InRange(diceVM.DieOne, 1, 6);
            Assert.InRange(diceVM.DieTwo, 1, 6);
        }
    }
}
