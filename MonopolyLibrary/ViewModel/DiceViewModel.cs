using MonopolyLibrary.Dice;
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
    public class DiceViewModel
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }



        private DiceModel diceModel;

        public DiceModel DiceModel
        {
            get { return diceModel; }
            set
            {
                diceModel = value;
            }
        }

        private C_Dice dice;

        public C_Dice Dice
        {
            get { return dice; }
            set { dice = value; }
        }




        public DiceViewModel(WindowContent content)
        {
            Content = content;
            DiceModel = new DiceModel() { ButtonEnabled = true } ;
            Dice = new C_Dice();
            Dice.SetDiceImages(DiceModel, 1, 1);
        }

        /// <summary>
        /// Enables the DiceButton.
        /// </summary>
        public void EnableDice()
        {
            DiceModel.ButtonEnabled = true;
        }

        /// <summary>
        /// Disables the DiceButton.
        /// </summary>
        public void DisableDice()
        {
            DiceModel.ButtonEnabled = false;
        }
    }
}
