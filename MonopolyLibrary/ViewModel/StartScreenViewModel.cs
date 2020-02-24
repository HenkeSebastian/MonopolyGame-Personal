using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.ViewModel
{
    public class StartScreenViewModel: BaseViewModel
    {

        public Windows Window
        {
            get { return Windows.StartScreen; }
        }

        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public StartScreenViewModel(WindowContent passedWindowContent)
        {
            Content = passedWindowContent;
        }


        
    }
}
