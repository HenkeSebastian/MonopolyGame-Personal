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
    public class BaseViewModel: INotifyPropertyChanged
    {
        Windows Window
        {
            get;
        }

        private WindowContent content;

        public WindowContent Content
        {
            get { return content; }
            set { content = value; }
        }

        public BaseViewModel()
        {
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
