using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary;
using MonopolyLibrary.ViewModel;

namespace MonopolyLibrary.Model
{
    public class HouseModel
    {
        private static int houseID;

        /// <summary>
        /// ID of this House.
        /// </summary>
        private int uniqueID;

        public int UniqueID
        {
            get { return uniqueID; }
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


        /// <summary>
        /// Reference to the Street that uses this House
        /// </summary>
        private GameCardViewModel builtStreet;

        public GameCardViewModel BuiltStreet
        {
            get { return builtStreet; }
            set { builtStreet = value; }
        }

        public HouseModel()
        {
            uniqueID = houseID;
            houseID++;
        }
    }
}
