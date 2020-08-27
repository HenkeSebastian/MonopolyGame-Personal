using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Resources;
using MonopolyLibrary.Utility;
using MonopolyLibrary.Utility.Commands;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MonopolyLibrary.ViewModel
{
    public class PlayerCreationViewModel: BaseViewModel
    {
        private int avatarIndex;

        public int AvatarIndex
        {
            get { return avatarIndex; }
            set { avatarIndex = value; }
        }

        private int idIndex;

        public int IDIndex
        {
            get { return idIndex; }
            set { idIndex = value; }
        }


        private PlayerViewModel createdPlayer;

        public PlayerViewModel CreatedPlayer
        {
            get { return createdPlayer; }
            set 
            { 
                createdPlayer = value;
                OnPropertyChanged("CreatedPlayer");
            }
        }

        public ManagingPlayer ManagingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }

        private PlayerCreationCommands playerCreationCommands;

        public PlayerCreationCommands PlayerCreationCommands
        {
            get { return playerCreationCommands; }
            set { playerCreationCommands = value; }
        }




        public PlayerCreationViewModel()
        {
            ViewModelWindow = Windows.PlayerCreation;
        }

        public override void ViewModelAction()
        {
            PlayerCreationCommands.RandomName(this);
            CreatedPlayer.PlayerAvatar = PlayerCreationCommands.SetInitialPlayerCreationAvatar(0);
        }

        public void SetInitials()
        {
            SetReferences();
            SetAvatarIndex();
            SetIDIndex();
        }


        /// <summary>
        /// Initializes the Avatar index.
        /// </summary>
        private void SetAvatarIndex()
        {
            AvatarIndex = 0;
        }


        /// <summary>
        /// Initializes the ID index.
        /// </summary>
        private void SetIDIndex()
        {
            IDIndex = 0;
        }

        public void CreateNewPlayerSlate()
        {
            CreatedPlayer = new PlayerViewModel(new PlayerModel());
            ViewModelAction();
        }


        /// <summary>
        /// Sets needed references.
        /// </summary>
        private void SetReferences()
        {
            CreatedPlayer = new PlayerViewModel(new PlayerModel());
            PlayerCreationCommands = new PlayerCreationCommands();
        }






    }
}
