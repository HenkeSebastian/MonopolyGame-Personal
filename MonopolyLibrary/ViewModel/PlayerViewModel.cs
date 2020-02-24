using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class PlayerViewModel
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }


        private PlayerModel player;

        public PlayerModel Player
        {
            get { return player; }
            set { player = value; }
        }


        public PlayerViewModel(WindowContent content)
        {
            Content = content;
        }


        /// <summary>
        /// Moves a player by a certain amount of steps.
        /// </summary>
        /// <param name="amount">The amount of steps a player takes.</param>
        public void MovePlayer(int amount)
        {
            Player.CurrentPosition += amount;

            if (Player.CurrentPosition > 39)
            {
                Player.CurrentPosition -= 40;
                if (Player.CurrentPosition != 0)
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
        public void PlayerMoveToPosition(PlayerViewModel playerToMove, int positionID, bool overGo)
        {
            Content.GameViewViewModel.GameCards[playerToMove.Player.CurrentPosition].DeletePlayerOnCard(Content.GameViewViewModel.GameCards[playerToMove.Player.CurrentPosition].FindPlayerViewModelOnCard(playerToMove));
            playerToMove.Player.CurrentPosition = positionID;
            if (overGo)
            {
                MovedOverGo();
            }
            Content.GameViewViewModel.GameCards[positionID].AddPlayerOnCard(playerToMove);
        }


        /// <summary>
        /// If a Player goes over GO! he gets cash.
        /// </summary>
        public void MovedOverGo()
        {
            Content.ManagingPlayer.GivePlayerMoney(this, 200);
        }


        /// <summary>
        /// Set fields for Prison Time.
        /// </summary>
        public void PlayerGoToPrison()
        {
            Player.InPrison = true;
            Player.DiceRoll = 0;
        }


        /// <summary>
        /// Player gets out of Prison.
        /// </summary>
        public void PlayerGetsOutOfPrison()
        {
            Player.InPrison = false;
            Player.DiceRoll = 0;
        }


        /// <summary>
        /// A certain amount of money is given to a player.
        /// </summary>
        /// <param name="playerToGiveMoney">The receiving player.</param>
        /// <param name="amount">The amount of money.</param>
        public void PlayerAddMoney(PlayerViewModel playerToGiveMoney, int amount)
        {
            playerToGiveMoney.player.PlayerCash += amount;
        }


        /// <summary>
        /// A certain amount of money is taken from a player.
        /// </summary>
        /// <param name="playerToRemoveMoney">The losing player.</param>
        /// <param name="amount">The amount of money.</param>
        public void PlayerRemoveMoney(PlayerViewModel playerToRemoveMoney, int amount)
        {
            playerToRemoveMoney.player.PlayerCash += amount;
        }


        /// <summary>
        /// A players balance is checked.
        /// </summary>
        /// <param name="playerToCheck">The checked player.</param>
        /// <param name="requiredAmount">The required amount of money.</param>
        /// <returns></returns>
        public bool PlayerCheckBalance(PlayerViewModel playerToCheck, int requiredAmount)
        {
            if (playerToCheck.Player.PlayerCash >= requiredAmount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
