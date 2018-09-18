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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Opret_Button_Click(object sender, RoutedEventArgs e)
        {
            string Password = Password_PasswordBox.Password;
            string GentagPassword = GentagPassword_PasswordBox.Password;

            List<SqlParameter> FindesBruger = new List<SqlParameter>
            {
                new SqlParameter("Brugernavn", Brugernavn_Textbox.Text)
            };

            List<SqlParameter> opretBruger = new List<SqlParameter>
            {
                new SqlParameter("Brugernavn", Brugernavn_Textbox.Text),
                new SqlParameter("Mail", Mail_Textbox.Text),
                new SqlParameter("Password", Password),
            };

            DataTable Findesbruger = DAL.ExecSP("FindesBruger", FindesBruger);

            if (Findesbruger.Rows.Count == 1)
            {
                MessageBox.Show("Bruger eksistere i forvejen!");
            }

            else if (Brugernavn_Textbox.Text == "" || Mail_Textbox.Text == "" || Password == "" || GentagPassword == "")
            {
                MessageBox.Show("Udfyld alle tomme felter");
            }

            else if (Password != GentagPassword)
            {
                MessageBox.Show("Passwordet skal være det samme");
            }

            else
            {
                DataTable OpretBruger = DAL.ExecSP("OpretBruger", opretBruger);
                MessageBox.Show("Din bruger er oprettet");
                NavigationService RegisterPage = NavigationService.GetNavigationService(this);
                RegisterPage.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService RegisterPage = NavigationService.GetNavigationService(this);
            RegisterPage.Navigate(new Uri("LoginPage.xaml", UriKind.Relative));
        }
    }
}
