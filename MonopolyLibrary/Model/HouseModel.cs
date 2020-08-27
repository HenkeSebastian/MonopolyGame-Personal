using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MonopolyLibrary;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Model
{
    public class HouseModel
    {
        private static int houseID;
        private static int hotelID;

        /// <summary>
        /// ID of this House.
        /// </summary>
        private int uniqueID;

        public int UniqueID
        {
            get { return uniqueID; }
        }

        private int uniqueHotelID;

        public int UniqueHotelID
        {
            get { return uniqueHotelID; }
        }


        /// <summary>
        /// Boolean if the Street is currently in use or in the pool.
        /// </summary>
        private bool inUse;

        public bool InUse
        {
            get { return inUse; }
            set { inUse = value; }
        }

        private SolidColorBrush houseColor;

        public SolidColorBrush HouseColor
        {
            get { return houseColor; }
            set { houseColor = value; }
        }



        /// <summary>
        /// Reference to the Street that uses this House
        /// </summary>
        private GameCardViewModel builtStreet;

        public GameCardViewModel BuiltStreet
        {
            get { return builtStreet; }
            set { builtStreet = value; }
        }

        public HouseModel(bool hotel = false)
        {
            if (hotel)
            {
                uniqueHotelID = hotelID;
                hotelID++;
            }
            else
            {
                uniqueID = houseID;
                houseID++;
            }

        }
    }
}
