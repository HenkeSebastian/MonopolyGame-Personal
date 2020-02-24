using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for CardTest.xaml
    /// </summary>
    public partial class TwoCards : UserControl
    {
        public TwoCards()
        {
            InitializeComponent();
        }






        public SolidColorBrush StreetColor1
        {
            get { return (SolidColorBrush)GetValue(StreetColor1Property); }
            set { SetValue(StreetColor1Property, value); }
        }

        // Using a DependencyProperty as the backing store for StreetColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetColor1Property =
            DependencyProperty.Register("StreetColor1", typeof(SolidColorBrush), typeof(TwoCards));



        public SolidColorBrush StreetColor2
        {
            get { return (SolidColorBrush)GetValue(StreetColor2Property); }
            set { SetValue(StreetColor2Property, value); }
        }

        // Using a DependencyProperty as the backing store for StreetColor2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetColor2Property =
            DependencyProperty.Register("StreetColor2", typeof(SolidColorBrush), typeof(TwoCards));






    }
}
