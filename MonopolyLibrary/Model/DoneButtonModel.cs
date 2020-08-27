using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Model
{
    public class DoneButtonModel
    {
        private static bool doneButton;

        public bool DoneButton
        {
            get { return doneButton; }
            set { doneButton = value; }
        }

    }
}
