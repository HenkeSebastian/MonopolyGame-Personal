using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.Resources
{
    public class Avatars
    {
        private List<string> avatarSources;

        public List<string> AvatarSources
        {
            get { return avatarSources; }
            set { avatarSources = value; }
        }


        public Avatars()
        {

        }

        /// <summary>
        /// Creates a list and adds new avatar sourcestrings to it.
        /// </summary>
        public void SetAvatars()
        {
            AvatarSources = new List<string>();
            AvatarSources.Add("pack://application:,,,/MonopolyLibrary;Component/Resources/Die/1.png");
            AvatarSources.Add("pack://application:,,,/MonopolyLibrary;Component/Resources/Die/2.png");
            AvatarSources.Add("pack://application:,,,/MonopolyLibrary;Component/Resources/Die/3.png");
            AvatarSources.Add("pack://application:,,,/MonopolyLibrary;Component/Resources/Die/4.png");
            AvatarSources.Add("pack://application:,,,/MonopolyLibrary;Component/Resources/Die/5.png");
            AvatarSources.Add("pack://application:,,,/MonopolyLibrary;Component/Resources/Die/6.png");
        }
    }
}
