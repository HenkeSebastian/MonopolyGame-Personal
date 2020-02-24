using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;

namespace Monopoly.View
{
    /// <summary>
    /// Interaction logic for MonopolyMainWindow.xaml
    /// </summary>
    public partial class MonopolyMainWindow : Window
    {
        public MonopolyMainWindow()
        {
            MonopolyMainWindowViewModel mainWindowViewModel = new MonopolyMainWindowViewModel();
            this.DataContext = mainWindowViewModel;
            InitializeComponent();
        }
    }
}