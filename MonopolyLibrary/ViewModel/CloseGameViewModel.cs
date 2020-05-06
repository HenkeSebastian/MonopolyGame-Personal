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
        /// Property for which window this is.
        /// </summary>
        public Windows Window
        {
            get { return Windows.ClosingScreen; }
        }


        /// <summary>
        /// Property that saves the window, that has called the closing window. Used for reverting to the calling window.
        /// </summary>
        private Windows calledWindow;

        public Windows CalledWindow
        {
            get { return calledWindow; }
            set { calledWindow = value; }
        }



        public CloseGameViewModel(WindowContent passedWindowContent)
        {
            Content = passedWindowContent;
            SetCommands();
        }


        /// <summary>
        /// Sets the Window that has called the closing window.
        /// </summary>
        /// <param name="passedWindow">The calling window.</param>
        public void SetCalledWindow(Windows passedWindow)
        {
            CalledWindow = passedWindow;
        }


        /// <summary>
        /// TODO: Move to buttonbindings
        /// </summary>
        private void SetCommands()
        {
            C_CloseGame = new NonGenericRelayCommand(param => CloseGame());
            C_Revert = new NonGenericRelayCommand(param => Revert());
        }

        /// <summary>
        /// Review Refactor closing window revert.
        /// </summary>
        private void Revert()
        {
            Content.SetWindowContent(CalledWindow);
        }


        /// <summary>
        /// Closes the Programm.
        /// </summary>
        private void CloseGame()
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// TODO: Move to button bindings.
        /// </summary>
        public ICommand C_CloseGame { get; set; }
        public ICommand C_Revert { get; set; }
    }
}
