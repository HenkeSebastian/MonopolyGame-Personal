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

        public ManagingPlayer managingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
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

        public PlayerCreationCommands()
        {
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
            WindowContent.GetWindowContent().SetViewModelActive(Windows.StartingRoll);
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
        public string SetInitialPlayerCreationAvatar(int avatarID)
        {
            return AvatarsLib.AvatarSources[avatarID];
        }


        /// <summary>
        /// Sets a random player name from the list of available predefined names.
        /// </summary>
        public void RandomName(PlayerCreationViewModel pcvm)
        {
            pcvm.CreatedPlayer.PlayerName = NamesLib.GetRandomName();
        }

        /*
        public PlayerModel createPlayerModel()
        {
            PlayerModel model = new PlayerModel()
            {
                AmountHotels = CreatedPlayer.AmountHotels,
                AmountHouses = CreatedPlayer.AmountHouses,
                CurrentPosition = CreatedPlayer.CurrentPosition,
                PrisonRoll = CreatedPlayer.PrisonRoll,
                FirstThrow = CreatedPlayer.FirstThrow,
                InPrison = CreatedPlayer.InPrison,
                IsActive = CreatedPlayer.IsActive,
                IsNPC = CreatedPlayer.IsNPC,
                Monopolies = new bool[8],
                OwnedStreetIDs = new bool[28],
                OwnedStreets = new System.Collections.ObjectModel.ObservableCollection<GameCardViewModel>(),
                PlayerAvatar = CreatedPlayer.PlayerAvatar,
                PlayerCash = CreatedPlayer.PlayerCash,
                PlayerID = CreatedPlayer.PlayerID,
                PlayerName = CreatedPlayer.PlayerName,
                PlayPulseAnimation = CreatedPlayer.PlayPulseAnimation
            };
            for (int i = 0; i < 28; i++)
            {
                model.OwnedStreets.Add(null);
            }

            return model;
        }
        */
        /// <summary>
        /// Adds a new player to the collection.
        /// </summary>
        public void AddPlayer(PlayerCreationViewModel pcvm)
        {
            managingPlayer.AddPlayer(pcvm.CreatedPlayer);
            pcvm.CreateNewPlayerSlate();
        }
    }
}
