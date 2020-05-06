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
            Dice.RollDice(Content.DiceViewModel);
            Dice.SetDiceImages(Content.DiceViewModel, Content.DiceViewModel.DieOne, Content.DiceViewModel.DieTwo);

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
                    Dice.SetFirstThrow(Content.ManagingPlayer.AllPlayers, Content.DiceViewModel.DieOne, Content.DiceViewModel.DieTwo);
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
            Dice.RollDice(Content.DiceViewModel);
            Dice.SetDiceImages(Content.DiceViewModel, Content.DiceViewModel.DieOne, Content.DiceViewModel.DieTwo);
            Content.StartingRollViewModel.C_FirstRollRules.SetScore(Content.DiceViewModel.DieOne, Content.DiceViewModel.DieTwo);
            Content.StartingRollViewModel.C_FirstRollRules.NextPlayer();
        }


        /// <summary>
        /// Dice roll for the main game.
        /// </summary>
        public void MainGameRoll()
        {
            if (Content.ManagingPlayer.GetActivePlayer().PlayerCheckInPrison())
            {
                PrisonRoll();
                return;
            }
            Dice.RollDice(Content.DiceViewModel);
            Dice.SetDiceImages(Content.DiceViewModel, Content.DiceViewModel.DieOne, Content.DiceViewModel.DieTwo);
            //Find Active Player on current Game Card and Delete it
            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].DeletePlayerOnCard(Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].FindPlayerViewModelOnCard(Content.ManagingPlayer.GetActivePlayer()));
            //Add rolled values to current Position
            //Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition = Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition + (diceRoll[0] + diceRoll[1]);
            Content.ManagingPlayer.GetActivePlayer().MovePlayer(Content.DiceViewModel.DieOne + Content.DiceViewModel.DieTwo);
            //Add Player to the new Game Card
            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].AddPlayerOnCard(Content.ManagingPlayer.GetActivePlayer());
            Content.GameBoardViewModel.SetDoneButton(true);
            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].CardAction(Content.ManagingPlayer.GetActivePlayer());
            //Disable Dice
            Content.DiceViewModel.Dice.DisableDice(Content.DiceViewModel);
        }

        /// <summary>
        /// Dice roll if the active player is currently in prison.
        /// Work in progress!
        /// </summary>
        public void PrisonRoll()
        {
            Dice.RollDice(Content.DiceViewModel);
            Dice.SetDiceImages(Content.DiceViewModel, Content.DiceViewModel.DieOne, Content.DiceViewModel.DieTwo);
            if (Dice.getDoublets(Content.DiceViewModel))
            {
                Content.ManagingPlayer.GetActivePlayer().PlayerGetsOutOfPrison();
                return;
            }
            Content.ManagingPlayer.GetActivePlayer().DiceRoll++;
            if (Content.ManagingPlayer.GetActivePlayer().DiceRoll == 3)
            {
                Content.ManagingPlayer.GetActivePlayer().PlayerGetsOutOfPrison();
            }
        }


        /// <summary>
        /// Finishes one players turn.
        /// </summary>
        public void EndTurn()
        {
            Content.GameBoardViewModel.SetDoneButton(false);
            //Activate the next player.
            Content.ManagingPlayer.NextPlayer();

            if(Content.SelectedDetailsViewModel != Content.IdleDetailsViewModel)
            {
                Content.SelectedDetailsViewModel = Content.IdleDetailsViewModel;
            }
            //Enable the dice for the next player.
            Content.DiceViewModel.Dice.EnableDice(Content.DiceViewModel);
        }


        /// <summary>
        /// Test Method that moves the currently active player one step forward.
        /// </summary>
        public void OneStep()
        {
            //Find Active Player on current Game Card and Delete it
            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].CurrentPosition].DeletePlayerOnCard(Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].CurrentPosition].FindPlayerViewModelOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]));
            //Add rolled values to current Position
            //Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].CurrentPosition = Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].Player.CurrentPosition + (diceRoll[0] + diceRoll[1]);
            Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].MovePlayer(1);
            //Add Player to the new Game Card
            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].CurrentPosition].AddPlayerOnCard(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);

            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex].CurrentPosition].CardAction(Content.ManagingPlayer.AllPlayers[Content.ManagingPlayer.ActivePlayerIndex]);
            Content.ManagingPlayer.NextPlayer();
        }
  
        /// <summary>
        /// Method for testing purposes. Not in use!
        /// </summary>
        public void MainGameRollSteps()
        {
            Content.DiceViewModel.Dice.DisableDice(Content.DiceViewModel);
            Dice.RollDice(Content.DiceViewModel);
            var thread = new Thread(
                () => MainSteps());
            thread.Start();

            Content.ManagingPlayer.NextPlayer();
        }

        public void MainSteps()
        {
            //Dice.RollDice(Content.DiceViewModel);
            for (int i = 0; i < Content.DiceViewModel.DieOne + Content.DiceViewModel.DieTwo; i++)
            {
                //Find Active Player on current Game Card and Delete it
                Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].DeletePlayerOnCard(Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].FindPlayerViewModelOnCard(Content.ManagingPlayer.GetActivePlayer()));
                //Add rolled values to current Position
                Content.ManagingPlayer.GetActivePlayer().CurrentPosition = Content.ManagingPlayer.GetActivePlayer().CurrentPosition + (1);
                //Add Player to the new Game Card
                Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].AddPlayerOnCard(Content.ManagingPlayer.GetActivePlayer());

                Thread.Sleep(500);
            }
            Content.GameBoardViewModel.GameCards[Content.ManagingPlayer.GetActivePlayer().CurrentPosition].CardAction(Content.ManagingPlayer.GetActivePlayer());
            Content.GameBoardViewModel.SetDoneButton(true);
        }
    }
}
