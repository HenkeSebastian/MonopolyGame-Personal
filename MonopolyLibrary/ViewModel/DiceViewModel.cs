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
    public class DiceViewModel: BaseViewModel
    {

        private DiceModel diceModel;

        public DiceModel DiceModel
        {
            get { return diceModel; }
        }

        private C_Dice dice;

        public C_Dice Dice
        {
            get { return dice; }
            set { dice = value; }
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




        public DiceViewModel(WindowContent content)
        {
            Content = content;
            this.diceModel = new DiceModel();
            ButtonEnabled = true;
            Dice = new C_Dice();
            Dice.SetDiceImages(this, 1, 1);
        }

    }
}
