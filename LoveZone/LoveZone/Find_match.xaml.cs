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
using System.Data;
using System.Data.SqlClient;

namespace LoveZone
{
    /// <summary>
    /// Interaction logic for Find_match.xaml
    /// </summary>
    public partial class Find_match : Page
    {
        
        public Find_match()
        {
            InitializeComponent();
            BrugerOversigt();
        }
        private void BrugerOversigt()
        {
            string connectionString = @"Data Source=LoveZone.Database.Windows.Net;Initial Catalog=LoveZone;Persist Security Info=True;User ID=LoveZoneAdmin;Password=Passw0rd";
            //@"Data Source=DESKTOP-CM5VBFO\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Initial Catalog=BGBank";
            //String connectionString = @"Data source=(LocalDB)\LocalDB;Initial Catalog=BGBank;Persist Security Info=True;User ID=SQLAdmin;Password=Passw0rd";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from Bruger_oplysninger", con);
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Oversigt.IsReadOnly = true;
            Oversigt.ItemsSource = dt.DefaultView;
            //DV = dt.DefaultView;
            //DataContext = this;

            cmd.Dispose();
            con.Close();
        }
    }
}
