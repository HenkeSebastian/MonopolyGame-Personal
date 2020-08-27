using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Model;

namespace MonopolyLibrary.ViewModel
{
    public class CommunityDetailsViewModel: BaseViewModel
    {
        public Windows Window { get => Windows.CommunityDetails; }

        private CommunityModel community;

        public CommunityModel Community
        {
            get { return community; }
        }

        public string IconSource
        {
            get { return Community.IconSource; }
            set
            {
                Community.IconSource = value;
                OnPropertyChanged("IconSource");
            }
        }

        public string CommunityText
        {
            get { return Community.CommunityText; }
            set
            {
                Community.CommunityText = value;
                OnPropertyChanged("CommunityText");
            }
        }


        public CommunityDetailsViewModel()
        {
            this.community = new CommunityModel();
        }
    }
}
