using MonopolyLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class DoneButtonViewModel: BaseViewModel
    {
        private DoneButtonModel doneButton;

        public DoneButtonModel DoneButton
        {
            get { return doneButton; }
        }

        public bool Done
        {
            get => doneButton.DoneButton;
            set 
            { 
                DoneButton.DoneButton = value;
                OnPropertyChanged("Done");
            }
        }
        public DoneButtonViewModel()
        {
            doneButton = new DoneButtonModel { DoneButton = false };
            SetDoneButton(false);
        }

        /// <summary>
        /// Toggels the "Done" button.
        /// </summary>
        /// <param name="state"></param>
        public void SetDoneButton(bool state)
        {
            Done = state;
        }

    }
}
