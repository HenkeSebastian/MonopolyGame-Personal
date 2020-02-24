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
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public StartWindowCommands(WindowContent content)
        {
            Content = content;
        }


        /// <summary>
        /// Opens the creation view window.
        /// </summary>
        public void GoToCreationWindow()
        {
            Content.SetWindowContent(Windows.PlayerCreation);
            Content.ButtonBindings.ButtonCommands.PlayerCreationCommands.RandomName();
            Content.ButtonBindings.ButtonCommands.PlayerCreationCommands.SetInitialPlayerCreationAvatar();
        }

    }
}
