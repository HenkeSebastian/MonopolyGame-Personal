using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Model
{
    public class CommunityModel
    {
        private string iconSource;

        public string IconSource
        {
            get { return iconSource; }
            set { iconSource = value; }
        }

        private string communityText;

        public string CommunityText
        {
            get { return communityText; }
            set { communityText = value; }
        }

        public CommunityModel()
        {

        }

    }
}
