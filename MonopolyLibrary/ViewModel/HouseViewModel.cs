using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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

        public int UniqueHotelID
        {
            get => House.UniqueHotelID;
        }

        public bool InUse {
            get { return House.InUse; }
            set
            {
                House.InUse = value;
                OnPropertyChanged("InUse");
            }
        }

        public SolidColorBrush HouseColor
        {
            get { return House.HouseColor; }
            set { House.HouseColor = value; }
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

        public HouseViewModel(bool hotel = false)
        {
            house = new HouseModel(hotel);
            InUse = false;
            BuiltStreet = null;
        }

        public int GetUniqueID()
        {
            return UniqueID;
        }

        public int GetUniqueHotelID()
        {
            return UniqueHotelID;
        }

        public bool IsHouseNull()
        {
            if (this == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHouseNotNull()
        {
            if (this != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHouseInUse()
        {
            bool state = InUse ? true : false;
            return state;
        }

        public bool IsHouseNotInUse()
        {
            bool state = InUse ? false : true;
            return state;
        }

        public void SetBuiltStreet(GameCardViewModel gameCard)
        {
            BuiltStreet = gameCard;
        }

        public void SetHouseColor(SolidColorBrush houseColor)
        {
            HouseColor = houseColor;
        }

        public void SetHouseInUse(bool state)
        {
            InUse = state;
        }

    }
}
