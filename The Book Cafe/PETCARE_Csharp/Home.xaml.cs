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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xaml;
using System.IO;


namespace PETCARE_Csharp
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");
        public Home(String Username)
        {

            InitializeComponent();
            Usernamelbl.Content = Username;
           

        }
        //Navbar code
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            //set tooltip visibility
            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_Pets.Visibility = Visibility.Collapsed;
                tt_Products.Visibility = Visibility.Collapsed;
                tt_Employees.Visibility = Visibility.Collapsed;
                tt_Customers.Visibility = Visibility.Collapsed;
                tt_Billing.Visibility = Visibility.Collapsed;
                tt_logout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_Pets.Visibility = Visibility.Visible;
                tt_Products.Visibility = Visibility.Visible;
                tt_Employees.Visibility = Visibility.Visible;
                tt_Customers.Visibility = Visibility.Visible;
                tt_Billing.Visibility = Visibility.Visible;
                tt_logout.Visibility = Visibility.Visible;
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Home1_click(object sender, MouseButtonEventArgs e)
        {
            this.Show();
        }

        private void Petspg(object sender, MouseButtonEventArgs e)
        {
            Pets pg = new Pets();
            pg.Show();
            this.Hide();
        }

        private void prodspg(object sender, MouseButtonEventArgs e)
        {
            Products pg = new Products();
            pg.Show();
            this.Hide();
        }

        private void emppg(object sender, MouseButtonEventArgs e)
        {
            Employees pg = new Employees();
            pg.Show();
            this.Hide();
        }

        private void cuspg(object sender, MouseButtonEventArgs e)
        {
            Customer pg = new Customer();
            pg.Show();
            this.Hide();
        }

        private void billing_click(object sender, MouseButtonEventArgs e)
        {
            Billing pg = new Billing();
            pg.Show();
            this.Hide();
        }

        private void Lgut(object sender, MouseButtonEventArgs e)
        {
            login pg = new login();
            pg.Show();
            this.Hide();
        }//navbar end

    }
}
