using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Resources;
using MonopolyLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MonopolyLibrary.Utility.Commands
{
    public class PlayerCreationCommands
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private Avatars avatarLib;

        public Avatars AvatarsLib
        {
            get { return avatarLib; }
            set { avatarLib = value; }
        }

        private Names namesLib;

        public Names NamesLib
        {
            get { return namesLib; }
            set { namesLib = value; }
        }



        public PlayerCreationCommands(WindowContent content)
        {
            Content = content;
            SetRefs();
            InitialSetup();
        }

        public void SetRefs()
        {
            AvatarsLib = new Avatars();
            NamesLib = new Names();
        }

        private void InitialSetup()
        {
            NamesLib.SetNames();
            AvatarsLib.SetAvatars();
        }


        /// <summary>
        /// Starts the First roll window.
        /// </summary>
        public void StartGame()
        {
            Content.SetWindowContent(Windows.StartingRoll);
        }

        /// <summary>
        /// REVIEW Make this function ubiquitous. Every window should call the same function for this.
        /// </summary>
        /// <param name="callingWindow"></param>
        public void CloseGame(Windows callingWindow)
        {
            Content.SetClosingWindowRevert(callingWindow);
            Content.SetWindowContent(Windows.ClosingScreen);
        }


        /// <summary>
        /// Cycles forward through the avatar pictures.
        /// </summary>
        /// <param name="pcvm">The player creation view model.</param>
        public void NextPicture(PlayerCreationViewModel pcvm)
        {
            if (pcvm.AvatarIndex < AvatarsLib.AvatarSources.Count - 1)
            {
                pcvm.AvatarIndex++;
                pcvm.CreatedPlayer.PlayerAvatar = AvatarsLib.AvatarSources[pcvm.AvatarIndex];
            }
            else
            {
                pcvm.AvatarIndex = 0;
                pcvm.CreatedPlayer.PlayerAvatar = AvatarsLib.AvatarSources[pcvm.AvatarIndex];
            }
        }


        /// <summary>
        /// Cycles backwards through the avatar pictures.
        /// </summary>
        /// <param name="pcvm">The player creation view model.</param>
        public void PreviousPicture(PlayerCreationViewModel pcvm)
        {
            if (pcvm.AvatarIndex == 0)
            {
                pcvm.AvatarIndex = AvatarsLib.AvatarSources.Count - 1;
                pcvm.CreatedPlayer.PlayerAvatar = AvatarsLib.AvatarSources[pcvm.AvatarIndex];
            }
            else
            {
                pcvm.AvatarIndex--;
                pcvm.CreatedPlayer.PlayerAvatar = AvatarsLib.AvatarSources[pcvm.AvatarIndex];
            }
        }


        /// <summary>
        /// Sets an initial player avatar from the list.
        /// </summary>
        public void SetInitialPlayerCreationAvatar()
        {
            Content.PlayerCreationViewModel.CreatedPlayer.PlayerAvatar = AvatarsLib.AvatarSources[Content.PlayerCreationViewModel.AvatarIndex];
        }


        /// <summary>
        /// Sets a random player name from the list of available predefined names.
        /// </summary>
        public void RandomName()
        {
            Content.PlayerCreationViewModel.CreatedPlayer.PlayerName = NamesLib.GetRandomName();
        }


        /// <summary>
        /// Adds a new player to the collection.
        /// </summary>
        public void AddPlayer()
        {
            Content.ManagingPlayer.AddPlayer(new PlayerViewModel(Content) { Player = new PlayerModel(Content.PlayerCreationViewModel.CreatedPlayer) });
        }
    }
}
