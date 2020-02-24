using MonopolyLibrary.Utility;


namespace MonopolyLibrary.ViewModel
{
    public class MonopolyMainWindowViewModel
    {
        private WindowContent windowContent;

        public WindowContent WindowContent
        {
            get { return windowContent; }
            set
            {
                windowContent = value;
            }
        }


        public MonopolyMainWindowViewModel()
        {
            WindowContent = new WindowContent();
            WindowContent.SetInitialContent();
        }

    }
}
