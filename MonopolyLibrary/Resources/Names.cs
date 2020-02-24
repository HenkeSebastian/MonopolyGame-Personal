using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Resources
{
    public class Names
    {
        Random rand;

        private List<string> playerNames;

        public List<string> PlayerNames
        {
            get { return playerNames; }
            set { playerNames = value; }
        }

        public Names()
        {
            rand = new Random();
        }

        /// <summary>
        /// Creates a list of strings and adds new possible predefined names to the list.
        /// </summary>
        public void SetNames()
        {
            PlayerNames = new List<string>();
            PlayerNames.Add("Test1");
            PlayerNames.Add("Test2");
            PlayerNames.Add("Test3");
            PlayerNames.Add("Test4");
            PlayerNames.Add("Test5");
            PlayerNames.Add("Test6");
            PlayerNames.Add("Test7");
        }

        /// <summary>
        /// Choses a random name.
        /// </summary>
        /// <returns>Returns the string of the chosen random name.</returns>
        public string GetRandomName()
        {
            int i = rand.Next(PlayerNames.Count);
            return PlayerNames[i];
        }

    }
}
