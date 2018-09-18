using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            string Password = Password_PasswordBox.Password;

            List<SqlParameter> sqlParams = new List<SqlParameter>
            {
                new SqlParameter("Brugernavn", Brugernavn_Textbox.Text),
                new SqlParameter("Password", Password)
            };

            DataTable dtLoginResultsAdmin = DAL.ExecSP("ValidateLogin", sqlParams);

            if (dtLoginResultsAdmin.Rows.Count == 1)
            {
                LoveZone.MainWindow win2 = new LoveZone.MainWindow();
                win2.Show();
                Window parentWindow = Window.GetWindow(this);
                parentWindow.Close();
            }
            else
            {
                MessageBox.Show("Dit brugernavn eller password er forkert");
            }
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService RegisterPage = NavigationService.GetNavigationService(this);
            RegisterPage.Navigate(new Uri("RegisterPage.xaml", UriKind.Relative));
        }
    }
}
