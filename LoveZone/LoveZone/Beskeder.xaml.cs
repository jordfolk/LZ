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

namespace LoveZone
{
    /// <summary>
    /// Interaction logic for Beskeder.xaml
    /// </summary>
    public partial class Beskeder : Page
    {
        public Beskeder()
        {
            InitializeComponent();
        }

        private void Skriv_Besked(object sender, RoutedEventArgs e)
        {
            Nybesked nb = new Nybesked();
            nb.Show();
        }
    }
}
