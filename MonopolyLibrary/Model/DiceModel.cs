using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Model
{
    public class DiceModel: BaseModel
    {
        /// <summary>
        /// Source string for the first die.
        /// </summary>
        private string dieOneImageSource;

        public string DieOneImageSource
        {
            get { return dieOneImageSource; }
            set
            {
                dieOneImageSource = value;
                OnPropertyChanged("DieOneImageSource");
            }
        }

        /// <summary>
        /// Source string for the second die.
        /// </summary>
        private string dieTwoImageSource;

        public string DieTwoImageSource
        {
            get { return dieTwoImageSource; }
            set
            {
                dieTwoImageSource = value;
                OnPropertyChanged("DieTwoImageSource");
            }
        }

        /// <summary>
        /// Flag to enable or disable the Button.
        /// </summary>
        private bool buttonEnabled;

        public bool ButtonEnabled
        {
            get { return buttonEnabled; }
            set
            {
                buttonEnabled = value;
                OnPropertyChanged();
            }
        }

        public DiceModel()
        {

        }
    }
}
