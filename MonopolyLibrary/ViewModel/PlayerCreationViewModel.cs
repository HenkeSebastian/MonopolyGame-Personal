﻿using MonopolyLibrary.Model;
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.Resources;
using MonopolyLibrary.Utility;
using System.Collections.ObjectModel;
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


        private PlayerViewModel createdPlayer;

        public PlayerViewModel CreatedPlayer
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
            CreatedPlayer = new PlayerViewModel(Content, new PlayerModel());

        }






    }
}
