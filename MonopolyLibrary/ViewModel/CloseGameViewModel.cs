using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MonopolyLibrary.ViewModel
{
    public class CloseGameViewModel:BaseViewModel
    {

        /// <summary>
        /// Property that saves the window, that has called the closing window. Used for reverting to the calling window.
        /// </summary>
        private Windows calledWindow;

        public Windows CalledWindow
        {
            get { return calledWindow; }
            set { calledWindow = value; }
        }



        public CloseGameViewModel()
        {
            ViewModelWindow = Windows.ClosingScreen;
        }

        public override void ViewModelAction()
        {
            
        }

    }
}
