using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class PlayerViewModel: BaseViewModel
    {
        private PlayerModel player;

        public PlayerModel Player
        {
            get { return player; }
        }

        public bool IsActive
        {
            get { return Player.IsActive; }
            set
            {
                Player.IsActive = value;
                OnPropertyChanged("IsActive");
            }
        }

        public bool IsNPC
        {
            get { return Player.IsNPC; }
            set
            {
                Player.IsNPC = value;
                OnPropertyChanged("IsNPC");
            }
        }

        public int PlayerID
        {
            get { return Player.PlayerID; }
            set
            {
                Player.PlayerID = value;
                OnPropertyChanged("PlayerID");
            }
        }

        public string PlayerName
        {
            get { return Player.PlayerName; }
            set
            {
                Player.PlayerName = value;
                OnPropertyChanged("PlayerName");
            }
        }

        public string PlayerAvatar
        {
            get { return Player.PlayerAvatar; }
            set
            {
                Player.PlayerAvatar = value;
                OnPropertyChanged("PlayerAvatar");
            }
        }

        public int PlayerCash
        {
            get { return Player.PlayerCash; }
            set
            {
                Player.PlayerCash = value;
                OnPropertyChanged("PlayerCash");
            }
        }

        public bool[] OwnedStreetIDs
        {
            get { return Player.OwnedStreetIDs; }
            set
            {
                Player.OwnedStreetIDs = value;
                OnPropertyChanged("OwnedStreetIDs");
            }
        }

        public bool[] Monopolies
        {
            get { return Player.Monopolies; }
            set
            {
                Player.Monopolies = value;
                OnPropertyChanged("Monopolies");
            }
        }

        public ObservableCollection<GameCardViewModel> OwnedStreets
        {
            get { return Player.OwnedStreets; }
            set
            {
                Player.OwnedStreets = value;
                OnPropertyChanged("OwnedStreets");
            }
        }

        public int AmountHouses
        {
            get { return Player.AmountHouses; }
            set
            {
                Player.AmountHouses = value;
                OnPropertyChanged("AmountHouses");
            }
        }

        public int AmountHotels
        {
            get { return Player.AmountHotels; }
            set
            {
                Player.AmountHotels = value;
                OnPropertyChanged("AmountHotels");
            }
        }

        public bool PlayPulseAnimation
        {
            get { return Player.PlayPulseAnimation; }
            set
            {
                Player.PlayPulseAnimation = value;
                OnPropertyChanged("PlayPulseAnimation");
            }
        }

        public int FirstThrow
        {
            get { return Player.FirstThrow; }
            set
            {
                Player.FirstThrow = value;
                OnPropertyChanged("FirstThrow");
            }
        }

        public int CurrentPosition
        {
            get { return Player.CurrentPosition; }
            set
            {
                Player.CurrentPosition = value;
                OnPropertyChanged("CurrentPosition");
            }
        }

        public bool InPrison
        {
            get { return Player.InPrison; }
            set
            {
                Player.InPrison = value;
                OnPropertyChanged("InPrison");
            }
        }

        public int DiceRoll
        {
            get { return Player.DiceRoll; }
            set
            {
                Player.DiceRoll = value;
                OnPropertyChanged("DiceRoll");
            }
        }



        public PlayerViewModel(WindowContent content, PlayerModel passedModel)
        {
            Content = content;
            this.player = passedModel;
        }


        /// <summary>
        /// Moves a player by a certain amount of steps.
        /// </summary>
        /// <param name="amount">The amount of steps a player takes.</param>
        public void MovePlayer(int amount)
        {
            CurrentPosition += amount;

            if (CurrentPosition > 39)
            {
                CurrentPosition -= 40;
                if (CurrentPosition != 0)
                {
                    MovedOverGo();
                }
            }
        }


        /// <summary>
        /// Move a Player to a certain Position on the Board and he may get cash for going over Go!
        /// </summary>
        /// <param name="playerToMove">The player to move.</param>
        /// <param name="positionID">The position to move to.</param>
        /// <param name="overGo">Flag if the player is moving over GO!.</param>
        public void PlayerMoveToPosition(int positionID, bool overGo)
        {
            Content.GameBoardViewModel.GameCards[CurrentPosition].DeletePlayerOnCard(Content.GameBoardViewModel.GameCards[CurrentPosition].FindPlayerViewModelOnCard(this));
            CurrentPosition = positionID;
            if (overGo)
            {
                MovedOverGo();
            }
            Content.GameBoardViewModel.GameCards[positionID].AddPlayerOnCard(this);
        }


        /// <summary>
        /// If a Player goes over GO! he gets cash.
        /// </summary>
        public void MovedOverGo()
        {
            PlayerAddMoney(200);
        }


        /// <summary>
        /// Set fields for Prison Time.
        /// </summary>
        public void PlayerGoToPrison()
        {
            InPrison = true;
            DiceRoll = 0;
            PlayerMoveToPosition(10, false);
        }


        /// <summary>
        /// Player gets out of Prison.
        /// </summary>
        public void PlayerGetsOutOfPrison()
        {
            InPrison = false;
            DiceRoll = 0;
        }


        /// <summary>
        /// A certain amount of money is given to a player.
        /// </summary>
        /// <param name="playerToGiveMoney">The receiving player.</param>
        /// <param name="amount">The amount of money.</param>
        public void PlayerAddMoney(int amount)
        {
            PlayerCash += amount;
        }


        /// <summary>
        /// A certain amount of money is taken from a player.
        /// </summary>
        /// <param name="playerToRemoveMoney">The losing player.</param>
        /// <param name="amount">The amount of money.</param>
        public void PlayerRemoveMoney(int amount)
        {
            PlayerCash -= amount;
        }

        /// <summary>
        /// A player pays another player
        /// </summary>
        /// <param name="receivingPlayer">The player who receives money</param>
        /// <param name="givingPlayer">The player who gives money</param>
        /// <param name="amount">The amount of money</param>
        public void PlayerGivesPlayerMoney(PlayerViewModel receivingPlayer, int amount)
        {
            PlayerRemoveMoney(amount);
            receivingPlayer.PlayerAddMoney(amount);
        }

        /// <summary>
        /// A player receives a street card.
        /// </summary>
        /// <param name="player">The receiving player</param>
        /// <param name="gameCard">The street card</param>
        public void PlayerAddGameCard(GameCardViewModel gameCard)
        {
            OwnedStreets[gameCard.OwnerArrayID] = gameCard;
            OwnedStreetIDs[gameCard.OwnerArrayID] = true;
            PlayerSetMonopolies();
            gameCard.OwningPlayer = this;
        }

        /// <summary>
        /// A player loses a street card.
        /// </summary>
        /// <param name="player">The losing player</param>
        /// <param name="gameCard">The street card</param>
        public void PlayerRemoveGameCard(GameCardViewModel gameCard)
        {
            OwnedStreets[gameCard.OwnerArrayID] = null;
            OwnedStreetIDs[gameCard.OwnerArrayID] = false;
            gameCard.OwningPlayer = null;
            PlayerSetMonopolies();
        }

        /// <summary>
        /// A street card is being moved from one player to another.
        /// </summary>
        /// <param name="receivingPlayer">The receiving player</param>
        /// <param name="givingPlayer">The giving player</param>
        /// <param name="gameCard">The street card</param>
        public void MoveGameCardToAnotherPlayer(PlayerViewModel receivingPlayer, GameCardViewModel gameCard)
        {
            receivingPlayer.OwnedStreets[gameCard.OwnerArrayID] = gameCard;
            gameCard.OwningPlayer = receivingPlayer;
            OwnedStreets[gameCard.OwnerArrayID] = null;
            OwnedStreetIDs[gameCard.OwnerArrayID] = false;
            receivingPlayer.OwnedStreetIDs[gameCard.OwnerArrayID] = true;
            PlayerSetMonopolies();
        }

        /// <summary>
        /// A players balance is checked.
        /// </summary>
        /// <param name="playerToCheck">The checked player.</param>
        /// <param name="requiredAmount">The required amount of money.</param>
        /// <returns></returns>
        public bool PlayerCheckBalance(int requiredAmount)
        {
            if (PlayerCash >= requiredAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the player is in prison. Returns boolean.
        /// </summary>
        /// <returns></returns>
        public bool PlayerCheckInPrison()
        {
            if (InPrison == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Returns the amount of cash a player has after a potetial buying action.
        /// </summary>
        /// <param name="streetPrice"></param>
        /// <returns></returns>
        public int PlayerCashAfterBuying(GameCardViewModel streetPrice)
        {
            return PlayerCash - streetPrice.StreetPrice;
        }
        /// <summary>
        /// Returns the amount of cash a player has after a potetial buying action.
        /// </summary>
        /// <param name="streetPrice"></param>
        /// <returns></returns>
        public int PlayerCashAfterBuildingHouse(GameCardViewModel streetPrice)
        {
            return PlayerCash - streetPrice.HousePrice;
        }

        /// <summary>
        /// Returns the amount of cash a player has after a potetial selling action.
        /// </summary>
        /// <param name="streetPrice"></param>
        /// <returns></returns>
        public int PlayerCashAfterSellingHouse(GameCardViewModel streetPrice)
        {
            return PlayerCash + streetPrice.HousePrice/2;
        }

        /// <summary>
        /// Returns the amount of cash a player has after a potetial buying action.
        /// </summary>
        /// <param name="streetPrice"></param>
        /// <returns></returns>
        public int PlayerCashAfterPayingMortgage(GameCardViewModel streetPrice)
        {
            return PlayerCash - streetPrice.Mortgage[1];
        }

        /// <summary>
        /// Returns the amount of cash a player has after a potetial selling action.
        /// </summary>
        /// <param name="streetPrice"></param>
        /// <returns></returns>
        public int PlayerCashAfterTakingMortgage(GameCardViewModel streetPrice)
        {
            return PlayerCash + streetPrice.Mortgage[0];
        }

        /// <summary>
        /// Sets flags for owned Monopolies.
        /// </summary>
        public void PlayerSetMonopolies()
        {
            if (OwnedStreetIDs[0] && OwnedStreetIDs[1] == true)
            {
                Monopolies[0] = true;
            }
            if (OwnedStreetIDs[2] && OwnedStreetIDs[3] && OwnedStreetIDs[4] == true)
            {
                Monopolies[1] = true;
            }
            if (OwnedStreetIDs[5] && OwnedStreetIDs[6] && OwnedStreetIDs[7] == true)
            {
                Monopolies[2] = true;
            }
            if (OwnedStreetIDs[8] && OwnedStreetIDs[9] && OwnedStreetIDs[10] == true)
            {
                Monopolies[3] = true;
            }
            if (OwnedStreetIDs[11] && OwnedStreetIDs[12] && OwnedStreetIDs[13] == true)
            {
                Monopolies[4] = true;
            }
            if (OwnedStreetIDs[14] && OwnedStreetIDs[15] && OwnedStreetIDs[16] == true)
            {
                Monopolies[5] = true;
            }
            if (OwnedStreetIDs[17] && OwnedStreetIDs[18] && OwnedStreetIDs[19] == true)
            {
                Monopolies[6] = true;
            }
            if (OwnedStreetIDs[20] && OwnedStreetIDs[21] == true)
            {
                Monopolies[7] = true;
            }
        }
    }
}
