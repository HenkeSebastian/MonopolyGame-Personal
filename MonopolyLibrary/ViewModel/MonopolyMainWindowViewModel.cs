using MonopolyLibrary.Utility;
using System.Dynamic;
using System.Windows;

namespace MonopolyLibrary.ViewModel
{
    public class MonopolyMainWindowViewModel: BaseViewModel
    {
        private WindowContent windowContent = WindowContent.GetWindowContent();
        public MonopolyMainWindowViewModel()
        {
            windowContent.SetInitialContent();
        }

    }
}
