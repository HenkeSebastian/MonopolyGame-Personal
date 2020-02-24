using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Resources;
using MonopolyLibrary.Utility;
using System.Windows;
using System.Windows.Input;

namespace MonopolyLibrary.ViewModel
{
    public class PlayerCreationViewModel: BaseViewModel
    {

        public Windows Window
        {
            get { return Windows.PlayerCreation; }
        }


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


        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private PlayerModel createdPlayer;

        public PlayerModel CreatedPlayer
        {
            get { return createdPlayer; }
            set { createdPlayer = value; }
        }


        public PlayerCreationViewModel(WindowContent passedWindowContent)
        {
            Content = passedWindowContent;
            SetReferences();
            SetAvatarIndex();
            SetIDIndex();
        }


        /// <summary>
        /// Initializes the Avatar index.
        /// </summary>
        public void SetAvatarIndex()
        {
            AvatarIndex = 0;
        }


        /// <summary>
        /// Initializes the ID index.
        /// </summary>
        public void SetIDIndex()
        {
            IDIndex = 0;
        }


        /// <summary>
        /// Sets needed references.
        /// </summary>
        public void SetReferences()
        {
            CreatedPlayer = new PlayerModel();
            //AvatarIndex = new int();
        }






    }
}
