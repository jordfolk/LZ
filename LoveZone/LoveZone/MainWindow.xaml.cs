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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Forside(object sender, RoutedEventArgs e)
        {
            Main.Content = new Forside();
        }

        private void Find_match(object sender, RoutedEventArgs e)
        {
            Main.Content = new Find_match();
        }

        private void Profil(object sender, RoutedEventArgs e)
        {
            Main.Content = new Profil();
        }
    }
}
