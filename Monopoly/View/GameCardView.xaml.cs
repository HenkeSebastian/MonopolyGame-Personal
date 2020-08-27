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
    /// Interaction logic for GameCardView.xaml
    /// </summary>
    public partial class GameCardView : UserControl
    {
        public int BigGameCardTextRotation
        {
            get { return (int)GetValue(BigGameCardTextRotationProperty); }
            set { SetValue(BigGameCardTextRotationProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BigGameCardTextRotation.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BigGameCardTextRotationProperty =
            DependencyProperty.Register("BigGameCardTextRotation", typeof(int), typeof(GameCardView));

        public GameCardView()
        {
            InitializeComponent();
        }




    }
}
