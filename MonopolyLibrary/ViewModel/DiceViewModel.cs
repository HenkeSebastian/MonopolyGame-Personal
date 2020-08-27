using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MonopolyLibrary.ViewModel
{
    public class DiceViewModel: BaseViewModel
    {

        Random rand = new Random();

        private static DiceModel diceModel;
        public static DiceModel DiceModel
        {
            get { return diceModel; }
        }

        public int DieOne
        {
            get { return DiceModel.DieOne; }
            set
            {
                DiceModel.DieOne = value;
                OnPropertyChanged("DieOne");
            }
        }

        public int DieTwo
        {
            get { return DiceModel.DieTwo; }
            set
            {
                DiceModel.DieTwo = value;
                OnPropertyChanged("DieTwo");
            }
        }

        public string DieOneImageSource
        {
            get { return DiceModel.DieOneImageSource; }
            set
            {
                DiceModel.DieOneImageSource = value;
                OnPropertyChanged("DieOneImageSource");
            }
        }

        public string DieTwoImageSource
        {
            get { return DiceModel.DieTwoImageSource; }
            set
            {
                DiceModel.DieTwoImageSource = value;
                OnPropertyChanged("DieTwoImageSource");
            }
        }

        public bool ButtonEnabled
        {
            get { return DiceModel.ButtonEnabled; }
            set
            {
                DiceModel.ButtonEnabled = value;
                OnPropertyChanged("ButtonEnabled");
            }
        }



        public DiceViewModel()
        {
            ViewModelWindow = Windows.Dice;
            diceModel = new DiceModel();
            ButtonEnabled = true;
            SetDiceImages(1, 1);
        }



        /// <summary>
        /// Enables the Button for the Dice
        /// </summary>
        /// <param name="dice">The Dice Model</param>
        public void EnableDice(bool diceState)
        {
            ButtonEnabled = diceState;
        }


        /// <summary>
        /// Rolls the Dice and sets two random Numbers between 1 and 6.
        /// </summary>
        /// <returns>Returns the facenumbers of the Dice as an Array with the lenght of two.</returns>
        public void RollDice()
        {
            SetDiceScore();
            SetDiceImages(DieOne, DieTwo);
        }

        private void SetDiceScore()
        {
            DieOne = rand.Next(1, 7);
            DieTwo = rand.Next(1, 7);
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
        private void SetDiceImages(int valueOne, int valueTwo)
        {
            DieOneImageSource = SetDieImage(valueOne);
            DieTwoImageSource = SetDieImage(valueTwo);
        }

        /// <summary>
        /// Returns true if the dice show doublets.
        /// </summary>
        /// <param name="dice"></param>
        /// <returns></returns>
        public bool getDoublets()
        {
            if (DieOne == DieTwo)
            {
                return true;
            }
            return false;
        }

    }
}
