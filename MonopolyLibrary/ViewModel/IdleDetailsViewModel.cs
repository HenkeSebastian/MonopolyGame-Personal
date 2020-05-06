using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonopolyLibrary.Model;
using MonopolyLibrary.Utility;

namespace MonopolyLibrary.ViewModel
{
    public class IdleDetailsViewModel: BaseViewModel
    {
        public Windows Window
        {
            get { return Windows.IdleDetails; }
        }

        public IdleDetailsViewModel(WindowContent content)
        {
            Content = content;
        }
    }
}
