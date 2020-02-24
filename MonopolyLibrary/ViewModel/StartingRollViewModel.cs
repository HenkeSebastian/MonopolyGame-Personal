using MonopolyLibrary.Gamerules;
using MonopolyLibrary.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyLibrary.ViewModel
{
    public class StartingRollViewModel:BaseViewModel, INotifyPropertyChanged
    {
        public Windows Window
        {
            get { return Windows.StartingRoll; }
        }

        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        private C_FirstRollRules c_firstRollRules;

        public C_FirstRollRules C_FirstRollRules
        {
            get { return c_firstRollRules; }
            set { c_firstRollRules = value; }
        }


        public StartingRollViewModel(WindowContent content)
        {
            Content = content;
            C_FirstRollRules = new C_FirstRollRules(Content);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
