using MonopolyLibrary.Resources;
using MonopolyLibrary.Utility.Commands;


namespace MonopolyLibrary.Utility
{
    public class C_ButtonCommands
    {
        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private DiceCommands diceCommand;

        public DiceCommands DiceCommands
        {
            get { return diceCommand; }
            set { diceCommand = value; }
        }

        private GameCardCommands gameCardCommands;

        public GameCardCommands GameCardCommands
        {
            get { return gameCardCommands; }
            set { gameCardCommands = value; }
        }

        private PlayerCreationCommands playerCreationCommands;

        public PlayerCreationCommands PlayerCreationCommands
        {
            get { return playerCreationCommands; }
            set { playerCreationCommands = value; }
        }

        private StartWindowCommands startWindowCommands;

        public StartWindowCommands StartWindowCommands
        {
            get { return startWindowCommands; }
            set { startWindowCommands = value; }
        }

        private StartingRollCommands startingRollCommands;

        public StartingRollCommands StartingRollCommands
        {
            get { return startingRollCommands; }
            set { startingRollCommands = value; }
        }

        private StreetBuyingCommands streetBuyingCommands;

        public StreetBuyingCommands StreetBuyingCommands
        {
            get { return streetBuyingCommands; }
            set { streetBuyingCommands = value; }
        }




        public C_ButtonCommands(WindowContent passedWindowContent)
        {
            Content = passedWindowContent;
            SetReferences();
        }


        private void SetReferences()
        {
            DiceCommands = new DiceCommands(Content);
            PlayerCreationCommands = new PlayerCreationCommands(Content);
            StartWindowCommands = new StartWindowCommands(Content);
            GameCardCommands = new GameCardCommands(Content);
            StartingRollCommands = new StartingRollCommands(Content);
            StreetBuyingCommands = new StreetBuyingCommands(Content);
        }



    }
}
