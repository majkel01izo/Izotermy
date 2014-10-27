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

namespace Izotermy.Typy_zabudowy
{
    /// <summary>
    /// Interaction logic for NSP.xaml
    /// </summary>
    public partial class NSP : UserControl
    {
        public NSP()
        {
            InitializeComponent();
            //MessageBox.Show("ala");
        }
        public void NSP_Visible(bool val)
        {
            if (val)
                Opis_NSP.Visibility = Visibility.Visible;
            else
            Opis_NSP.Visibility = Visibility.Hidden;
            //NSP_burty_600.Visibility = Visibility.Hidden;

            //return 
        }
    }
}
