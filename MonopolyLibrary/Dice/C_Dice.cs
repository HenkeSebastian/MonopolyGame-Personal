using MonopolyLibrary.Model;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Dice
{
    public class C_Dice
    {
        Random rand;
        public C_Dice()
        {
            rand = new Random();
        }

        /// <summary>
        /// Enables the Button for the Dice
        /// </summary>
        /// <param name="dice">The Dice Model</param>
        public void EnableDice(DiceModel dice)
        {
            dice.ButtonEnabled = true;
        }

        /// <summary>
        /// Disables the Button for the Dice
        /// </summary>
        /// <param name="dice">The Dice Model</param>
        public void DisableDice(DiceModel dice)
        {
            dice.ButtonEnabled = false;
        }

        /// <summary>
        /// Rolls the Dice and sets two random Numbers between 1 and 6.
        /// </summary>
        /// <returns>Returns the facenumbers of the Dice as an Array with the lenght of two.</returns>
        public int[] RollDice()
        {
            int firstRoll = rand.Next(1, 7);
            int secondRoll = rand.Next(1, 7);
            return new int[2] { firstRoll, secondRoll };
        }

        /// <summary>
        /// Sets the Image for one of the Dice
        /// </summary>
        /// <param name="value">The facenumber as a value</param>
        /// <returns></returns>
        private string SetDieImage(int value)
        {
            return $"pack://application:,,,/MonopolyLibrary;Component/Resources/Die/{value}.png";
        }

        /// <summary>
        /// Sets the images for the Dice View.
        /// </summary>
        /// <param name="dice">The Dice Model</param>
        /// <param name="valueOne">The first value</param>
        /// <param name="valueTwo">The second value</param>
        public void SetDiceImages(DiceModel dice, int valueOne, int valueTwo)
        {
            dice.DieOneImageSource = SetDieImage(valueOne);
            dice.DieTwoImageSource = SetDieImage(valueTwo);
        }

        /// <summary>
        /// Sets the first throw value for the first throw mechanic.
        /// </summary>
        /// <param name="collection">The collection of players</param>
        /// <param name="valueDieOne">The first value</param>
        /// <param name="valueDieTwo">The second value</param>
        public void SetFirstThrow(ObservableCollection<PlayerViewModel> collection, int valueDieOne, int valueDieTwo)
        {
            foreach (PlayerViewModel player in collection)
            {
                if (player.Player.IsActive == true)
                {
                    player.Player.FirstThrow = valueDieOne + valueDieTwo;
                }
            }
        }
    }
}
