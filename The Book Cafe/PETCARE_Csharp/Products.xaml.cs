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

namespace PETCARE_Csharp
{
    /// <summary>
    /// Interaction logic for Products.xaml
    /// </summary>
    public partial class Products : Window
    {
        public Products()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");
        
        private void LoadGrid()
        {
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            SqlCommand cmd = new SqlCommand("select * from productdetails", Con);
            DataTable dt = new DataTable();
            Con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            Producttbl.ItemsSource = dt.DefaultView;
        }




        private void Save_click(object sender, EventArgs e)
        {
            if (Product_Name.Text == "" || Quantity.Text == "" || Price.Text == "")
            {
                MessageBox.Show("Some fields are empty", "Please Fill all the Information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into productdetails (Product_Name,Quantity,Price) values(@ENa,@EA,@ED)", Con);
                    cmd.Parameters.AddWithValue("@ENa", Product_Name.Text);
                    cmd.Parameters.AddWithValue("@EA", Quantity.Text);
                    cmd.Parameters.AddWithValue("@ED", Price.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been added Successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    Con.Close();
                    LoadGrid();

                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Clear()
        {
            Product_Name.Clear();
            Quantity.Clear();
            Price.Clear();
            Pro_Name1.Clear();

        }


        private void Displayresultdata()
        {
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            Con.Open();
            SqlCommand sc = new SqlCommand("Select * from productdetails where Product_ID=@EN", Con);
            sc.Parameters.AddWithValue("@EN", Int32.Parse(Pro_Name1.Text));
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Producttbl.ItemsSource = dt.DefaultView;
            Con.Close();
        }


        private void Search_click(object sender, EventArgs e)
        {
            if (Pro_Name1.Text == "")
            {
                LoadGrid();
            }
            else
            {
                Displayresultdata();

            }
        }



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


        private void Employeetbl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            SqlCommand cmd = new SqlCommand("delete from productdetails where Product_ID=@EN ", Con);
            cmd.Parameters.AddWithValue("@EN",Int32.Parse(Pro_Name1.Text) );
            Con.Open();
            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                Con.Close();

                Pro_Name1.Clear();
                LoadGrid();

                Con.Close();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Not Deleted!" + ex.Message);
            }
            finally
            {
                Con.Close();
            }

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("update productdetails set Product_Name ='" + Product_Name.Text + "',Quantity ='" + Quantity.Text + "',Price ='" + Price.Text + "'where Product_ID='"+Pro_Name1.Text+"'", Con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated Successfully!", "Updated!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
                Clear();
                LoadGrid();
            }
        }
        
        private void Home1_click(object sender, MouseButtonEventArgs e)
        {
            User us = new User();
            string uname=us.getusrnm();
            Home pg = new Home(uname);
            pg.Show();
            this.Hide();
        }

        private void Petspg(object sender, MouseButtonEventArgs e)
        {
            Pets pg = new Pets();
            pg.Show();
            this.Hide();
        }

        private void prodspg(object sender, MouseButtonEventArgs e)
        {
            this.Show();
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
        }
    }
}
