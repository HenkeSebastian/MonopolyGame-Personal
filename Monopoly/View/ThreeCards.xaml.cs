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
    /// Interaction logic for CardTest.xaml
    /// </summary>
    public partial class ThreeCards : UserControl
    {
        public ThreeCards()
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
            DependencyProperty.Register("StreetColor1", typeof(SolidColorBrush), typeof(ThreeCards), new PropertyMetadata());



        public SolidColorBrush StreetColor2
        {
            get { return (SolidColorBrush)GetValue(StreetColor2Property); }
            set { SetValue(StreetColor2Property, value); }
        }

        // Using a DependencyProperty as the backing store for StreetColor2.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetColor2Property =
            DependencyProperty.Register("StreetColor2", typeof(SolidColorBrush), typeof(ThreeCards), new PropertyMetadata());



        public SolidColorBrush StreetColor3
        {
            get { return (SolidColorBrush)GetValue(StreetColor3Property); }
            set { SetValue(StreetColor3Property, value); }
        }

        // Using a DependencyProperty as the backing store for StreetColor3.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StreetColor3Property =
            DependencyProperty.Register("StreetColor3", typeof(SolidColorBrush), typeof(ThreeCards), new PropertyMetadata());
    }
}
