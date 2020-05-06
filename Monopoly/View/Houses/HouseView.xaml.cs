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

namespace Monopoly.View.Houses
{
    /// <summary>
    /// Interaction logic for HouseView.xaml
    /// </summary>
    public partial class HouseView : UserControl
    {
        public HouseView()
        {
            InitializeComponent();
        }



        public SolidColorBrush HouseColor
        {
            get { return (SolidColorBrush)GetValue(HouseColorProperty); }
            set { SetValue(HouseColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HouseColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HouseColorProperty =
            DependencyProperty.Register("HouseColor", typeof(SolidColorBrush), typeof(HouseView));


    }
}
