using MonopolyLibrary.PlayerHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility.Commands
{
    public class StartWindowCommands
    {

        public StartWindowCommands()
        {
        }

        /// <summary>
        /// Opens the creation view window.
        /// </summary>
        public void GoToCreationWindow()
        {
            WindowContent.GetWindowContent().SetViewModelActive(Windows.PlayerCreation);
        }

    }
}
