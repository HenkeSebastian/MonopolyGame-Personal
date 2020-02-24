using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class StreetInteractionViewModel
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private GameCardModel gameCard;

        public GameCardModel GameCard
        {
            get { return gameCard; }
            set { gameCard = value; }
        }


        public StreetInteractionViewModel(WindowContent content)
        {
            Content = content;
        }
    }
}
