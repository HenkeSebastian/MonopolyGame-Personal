using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class HouseViewModel: BaseViewModel
    {
        private HouseModel house;

        public HouseModel House
        {
            get { return house; }
        }

        public int UniqueID
        {
            get => House.UniqueID;
        }

        public bool InUse {
            get { return House.InUse; }
            set
            {
                House.InUse = value;
                OnPropertyChanged("InUse");
            }
        }

        public GameCardViewModel BuiltStreet
        {
            get { return House.BuiltStreet; }
            set
            {
                House.BuiltStreet = value;
                OnPropertyChanged("BuiltStreet");
            }
        }

        public HouseViewModel(WindowContent content)
        {
            house = new HouseModel();
            Content = content;
            InUse = false;
            BuiltStreet = null;
        }
    }
}
