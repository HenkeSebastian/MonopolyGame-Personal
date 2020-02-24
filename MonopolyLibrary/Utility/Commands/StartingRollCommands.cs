using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility.Commands
{
    public class StartingRollCommands
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public StartingRollCommands(WindowContent content)
        {
            Content = content;
        }


        /// <summary>
        /// Opens the game view window.
        /// </summary>
        public void GoToGameView()
        {
            Content.ManagingPlayer.SetPlayerIDActive(0);
            Content.SetWindowContent(Windows.GameWindow);
        }
    }
}
