using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.ViewModel
{
    public class StartScreenViewModel: BaseViewModel
    {

        public StartScreenViewModel()
        {
            ViewModelWindow = Windows.StartScreen;
        }

        public override void ViewModelAction()
        {
        }
    }
}
