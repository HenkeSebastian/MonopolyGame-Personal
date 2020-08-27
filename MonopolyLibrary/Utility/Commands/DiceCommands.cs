
using MonopolyLibrary.PlayerHandling;
using MonopolyLibrary.ViewModel;
using MonopolyLibrary.Utility;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using MonopolyLibrary.Gamerules;
using System.Threading.Tasks;

namespace MonopolyLibrary.Utility.Commands
{
    /// <summary>
    /// A class that contains all the functions that serve as commands for the Dice Button.
    /// </summary>
    public class DiceCommands
    {

        ManagingPlayer managingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }
        GamePool gamePool= new GamePool();
        FirstRollRules firstRollRules = new FirstRollRules();

        public ManagingPlayer ManagingPlayer
        {
            get => WindowContent.GetWindowContent().GetManagingPlayer();
        }

        public DiceViewModel DiceViewModel
        {
            get => WindowContent.GetWindowContent().GetViewModel<DiceViewModel>();
        }

        public DiceCommands()
        {
        }


        /// <summary>
        /// REVIEW Possibly redundant.
        /// </summary>
        /// <param name="window"></param>
        public void RollDice(Windows window)
        {
            switch (window)
            {
                case Windows.GameBoardScreen:
                    MainGameRoll();
                    break;
                case Windows.StartingRoll:
                    FirstRoll();
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Dice roll for the first throw mechanic.
        /// </summary>
        public void FirstRoll()
        {
            DiceViewModel.RollDice();
            firstRollRules.SetScore(DiceViewModel.DieOne, DiceViewModel.DieTwo);
            firstRollRules.FirstThrowNextPlayer();
        }


        /// <summary>
        /// Dice roll for the main game.
        /// </summary>
        public void MainGameRoll()
        {
            if (ManagingPlayer.GetActivePlayer().PlayerCheckInPrison())
            {
                PrisonRoll();
                return;
            }
            DiceViewModel.RollDice();
            //Find Active Player on current Game Card and Delete it
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].DeletePlayerOnCard(gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].FindPlayerViewModelOnCard(ManagingPlayer.GetActivePlayer()));
            //Add rolled values to current Position
            ManagingPlayer.GetActivePlayer().MovePlayer(DiceViewModel.DieOne + DiceViewModel.DieTwo);
            //Add Player to the new Game Card
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].AddPlayerOnCard(ManagingPlayer.GetActivePlayer());
            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].CardAction(ManagingPlayer.GetActivePlayer());
            //Disable Dice
            DiceViewModel.EnableDice(false);
        }




        public void MainGameRollAlt()
        {
            if (ManagingPlayer.GetActivePlayer().PlayerCheckInPrison())
            {
                PrisonRoll();
                return;
            }
            DiceViewModel.RollDice();
            //Find Active Player on current Game Card and Delete it
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].DeletePlayerOnCard(gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].FindPlayerViewModelOnCard(ManagingPlayer.GetActivePlayer()));
            //Add rolled values to current Position
            ManagingPlayer.GetActivePlayer().MovePlayer(DiceViewModel.DieOne + DiceViewModel.DieTwo);
            //Add Player to the new Game Card
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].AddPlayerOnCard(ManagingPlayer.GetActivePlayer());
            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].CardAction(ManagingPlayer.GetActivePlayer());
            //Disable Dice
            DiceViewModel.EnableDice(false);
        }





        /// <summary>
        /// Dice roll if the active player is currently in prison.
        /// Work in progress!
        /// </summary>
        public void PrisonRoll()
        {
            DiceViewModel.RollDice();
            if (DiceViewModel.getDoublets())
            {
                ManagingPlayer.GetActivePlayer().PlayerGetsOutOfPrison();
                return;
            }
            ManagingPlayer.GetActivePlayer().PrisonRoll++;
            if (ManagingPlayer.GetActivePlayer().PrisonRoll == 3)
            {
                ManagingPlayer.GetActivePlayer().PlayerGetsOutOfPrison();
                ManagingPlayer.GetActivePlayer().PlayerRemoveMoney(50);
                return;
            }
            managingPlayer.NextPlayer();
        }


        /// <summary>
        /// Finishes one players turn.
        /// </summary>
        public void EndTurn()
        {
            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(false);
            //Activate the next player.
            managingPlayer.NextPlayer();

            if(WindowContent.GetWindowContent().GetCurrentDetailsViewModel() != WindowContent.GetWindowContent().GetDetailsViewModel<IdleDetailsViewModel>())
            {
                WindowContent.GetWindowContent().SetDetailsViewModelActive<IdleDetailsViewModel>();
            }
            //Enable the dice for the next player.
            DiceViewModel.EnableDice(true);
        }


        /// <summary>
        /// Test Method that moves the currently active player one step forward.
        /// </summary>
        public void OneStep()
        {
            //Find Active Player on current Game Card and Delete it
            gamePool.GameCards[managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].CurrentPosition].DeletePlayerOnCard(gamePool.GameCards[managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].CurrentPosition].FindPlayerViewModelOnCard(managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex]));
            //Add rolled values to current Position
            //managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].CurrentPosition = managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].Player.CurrentPosition + (diceRoll[0] + diceRoll[1]);
            managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].MovePlayer(1);
            //Add Player to the new Game Card
            gamePool.GameCards[managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].CurrentPosition].AddPlayerOnCard(managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex]);

            gamePool.GameCards[managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex].CurrentPosition].CardAction(managingPlayer.AllPlayers[managingPlayer.ActivePlayerIndex]);
            managingPlayer.NextPlayer();
        }
  
        /// <summary>
        /// Method for testing purposes. Not in use!
        /// </summary>
        public void MainGameRollSteps()
        {
            var thread = new Thread(
                () => MainSteps());
            thread.Start();

        }

        public async void MainSteps()
        {
            DiceViewModel.EnableDice(true);
            DiceViewModel.RollDice();
            await Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < DiceViewModel.DieOne + DiceViewModel.DieTwo; i++)
                {
                    //Find Active Player on current Game Card and Delete it
                    gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].DeletePlayerOnCard(gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].FindPlayerViewModelOnCard(ManagingPlayer.GetActivePlayer()));
                    //Add rolled values to current Position
                    ManagingPlayer.GetActivePlayer().CurrentPosition = ManagingPlayer.GetActivePlayer().CurrentPosition + (1);
                    //Add Player to the new Game Card
                    gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].AddPlayerOnCard(ManagingPlayer.GetActivePlayer());

                    Thread.Sleep(500);
                }
            });
            gamePool.GameCards[ManagingPlayer.GetActivePlayer().CurrentPosition].CardAction(ManagingPlayer.GetActivePlayer());
            WindowContent.GetWindowContent().GetAdditionalViewModel<DoneButtonViewModel>().SetDoneButton(true);
            managingPlayer.NextPlayer();
        }
    }
}
