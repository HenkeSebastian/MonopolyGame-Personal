using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonopolyLibrary.Utility.Commands
{
    public class CloseGameCommands
    {
        public CloseGameCommands()
        {

        }

        /// <summary>
        /// REVIEW Make this function ubiquitous. Every window should call the same function for this.
        /// </summary>
        /// <param name="callingWindow"></param>
        public void CloseGame(Windows callingWindow)
        {
            SetClosingWindowRevert(callingWindow);
            WindowContent.GetWindowContent().SetViewModelActive(Windows.ClosingScreen);
        }


        /// <summary>
        /// Review Refactor closing window revert.
        /// </summary>
        public void Revert()
        {
            CloseGameViewModel closeGameViewModel = WindowContent.GetWindowContent().GetViewModel<CloseGameViewModel>();
            WindowContent.GetWindowContent().SetViewModelActive(closeGameViewModel.CalledWindow);
        }


        /// <summary>
        /// Closes the Programm.
        /// </summary>
        public void CloseGame()
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// Sets the revert target for the Closing window "cancel" button.
        /// </summary>
        /// <param name="passedRevert">The Window to revert to.</param>
        public void SetClosingWindowRevert(Windows passedRevert)
        {
            CloseGameViewModel vm = WindowContent.GetWindowContent().GetViewModel<CloseGameViewModel>();
            vm.CalledWindow = passedRevert;
        }
    }
}
