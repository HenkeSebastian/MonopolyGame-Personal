using MonopolyLibrary.Dice;
using MonopolyLibrary.ViewModel;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;

namespace MonopolyLibrary.Utility.Commands
{
    /// <summary>
    /// A class that contains all the functions that serve as commands for the Dice Button.
    /// </summary>
    public class DiceCommands
    {
        /// <summary>
        /// Property for the window content class to keep persistence and add accessability to the different classes.
        /// </summary>
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }


        /// <summary>
        /// Property for the Dice class.
        /// </summary>
        private C_Dice dice;

        public C_Dice Dice
        {
            get { return dice; }
            set { dice = value; }
        }


        public DiceCommands(WindowContent content)
        {
            Content = content;
            Dice = new C_Dice();
        }


        /// <summary>
        /// REVIEW Possibly redundant.
        /// </summary>
        /// <param name="window"></param>
        public void RollDice(Windows window)
        {
            int[] roll = Dice.RollDice();
            Dice.SetDiceImages(Content.DiceViewModel.DiceModel, roll[0], roll[1]);

            switch (window)
            {
                case Windows.StartScreen:
                    break;
                case Windows.PlayerCreation:
                    break;
                case Windows.GameWindow:
                    break;
                case Windows.GameOver:
                    break;
                case Windows.EndScreen:
                    break;
                case Windows.ClosingScreen:
                    break;
                case Windows.StartingRoll:
                    Dice.SetFirstThrow(Content.ManagingPlayer.AllPlayers, roll[0], roll[1]);
                    break;
                default:
                    break;
            }
            Content.ManagingPlayer.NextPlayer();
        }


        /// <summary>
        /// Dice roll for the first throw mechanic.
        /// </summary>
        public void FirstRoll()
        {
            //DiceLogic.Roll();
            int[] roll = Dice.RollDice();
            Dice.SetDiceImages(Content.DiceViewModel.DiceModel, roll[0], roll[1]);
            Content.StartingRollViewModel.C_FirstRollRules.SetScore(roll[0], roll[1]);
            Content.StartingRollViewModel.C_FirstRollRules.NextPlayer();
        }


        /// <summary>
        /// Dice roll for the main game.
        /// </summary>
        public void MainGameRoll()
        {
            int[] roll = Dice.RollDice();
            Dice.SetDiceImages(Content.DiceViewModel.DiceModel, roll[0], roll[1]);
            //Find Active Player on current Game Card and Delete it
            Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].DeletePlayerOnCard(Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].FindPlayerViewModelOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]));
            //Add rolled values to current Position
            //Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition = Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition + (diceRoll[0] + diceRoll[1]);
            Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].MovePlayer(roll[0] + roll[1]);
            //Add Player to the new Game Card
            Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].AddPlayerOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);

            Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].CardAction(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);
            //Disable Dice
            Content.DiceViewModel.DisableDice();
        }


        /// <summary>
        /// Finishes one players turn.
        /// </summary>
        public void EndTurn()
        {
            //Activate the next player.
            Content.ManagingPlayer.NextPlayer();
            //Enable the dice for the next player.
            Content.DiceViewModel.EnableDice();
        }


        /// <summary>
        /// Test Method that moves the currently active player one step forward.
        /// </summary>
        public void OneStep()
        {
            //Find Active Player on current Game Card and Delete it
            Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].DeletePlayerOnCard(Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].FindPlayerViewModelOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]));
            //Add rolled values to current Position
            //Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition = Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition + (diceRoll[0] + diceRoll[1]);
            Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].MovePlayer(1);
            //Add Player to the new Game Card
            Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].AddPlayerOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);

            Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].CardAction(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);
            Content.ManagingPlayer.NextPlayer();
        }
        /*
        public void MainGameRollSteps()
        {
            int[] diceRoll = DiceLogic.Roll();
            var thread = new Thread(
                () => baa(diceRoll));
            thread.Start();

            Content.ManagingPlayer.NextPlayer();
        }



        public void baa(int[] diceRoll)
        {
            for (int i = 0; i < diceRoll[0] + diceRoll[1]; i++)
            {
                //Find Active Player on current Game Card and Delete it
                Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].DeletePlayerOnCard(Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].FindPlayerViewModelOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]));
                //Add rolled values to current Position
                Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition = Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition + (1);
                //Add Player to the new Game Card
                Content.GameViewViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition].AddPlayerOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);

                Thread.Sleep(500);
            }
        }*/
    }
}
