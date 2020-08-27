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
        public IdleDetailsViewModel()
        {
            ViewModelWindow = Windows.IdleDetails;
        }
    }
}
