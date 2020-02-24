using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary;
using MonopolyLibrary.Dice;
using Xunit;

namespace MonopolyLibrary.Tests.Dice
{
    public class C_DiceTests
    {
        C_Dice refDice = new C_Dice();

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void SetDiceImage_ShouldReturnSourceString(int value)
        {
            //Arrange
            string expected = $@"..\Resources\Die\{value}.png";
            //Act
            //string actual = refDice.SetDiceImage(value);
            //Assert
            //Assert.Equal(expected, actual);
        }

        [Fact]
        public void DiceRoll_ShouldReturnRandomNumbers()
        {
            int[] actual = refDice.RollDice();

            Assert.InRange(actual[0], 1, 6);
        }
    }
}
