using MonopolyLibrary.Utility;
using MonopolyLibrary.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly.View
{
    /// <summary>
    /// Interaction logic for DiceView.xaml
    /// </summary>
    public partial class DiceView : UserControl
    {

        public Windows WindowsParam
        {
            get { return (Windows)GetValue(WindowsParamProperty); }
            set { SetValue(WindowsParamProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WindowsParam.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WindowsParamProperty =
            DependencyProperty.Register("WindowsParam", typeof(Windows), typeof(DiceView));



        public ICommand CommandTarget
        {
            get { return (ICommand)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CommandTarget.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register("CommandTarget", typeof(ICommand), typeof(DiceView));




        public DiceView()
        {
            InitializeComponent();
        }
    }
}
