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
    /// Interaction logic for Pets.xaml
    /// </summary>
    public partial class Pets : Window
    {
        public Pets()
        {
            InitializeComponent();
            LoadGrid();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");

        private void LoadGrid()
        {
           
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            SqlCommand cmd = new SqlCommand("select * from Petdetails", Con);
            DataTable dt = new DataTable();
            Con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            Pettbl.ItemsSource = dt.DefaultView;//load to data grid
        }




        private void Save_click(object sender, EventArgs e)
        {
            if (Pet_Name.Text == "" || Pet_Category.SelectedIndex == -1 || Quantity.Text == "" || Pet_DOB.Text=="" || Unit_Price.Text=="" )
            {
                MessageBox.Show("Some fields are empty", "Please Fill all the Information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Petdetails (Pet_Name,Pet_category,Quantity,Pet_DOB,Unit_Price) values(@EN,@EA,@ED,@PD,@UP)", Con);
                    cmd.Parameters.AddWithValue("@EN", Pet_Name.Text);
                    cmd.Parameters.AddWithValue("@EA", Pet_Category.SelectedItem.ToString().Split(new Char[] {' '})[1]);
                    cmd.Parameters.AddWithValue("@ED", Int32.Parse(Quantity.Text));
                    cmd.Parameters.AddWithValue("@PD", Pet_DOB.SelectedDate);
                    cmd.Parameters.AddWithValue("@UP", Int32.Parse(Unit_Price.Text));

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
            Pet_Name.Clear();
            Quantity.Clear();
            Pet_Category.SelectedIndex=0;
            Pet_DOB.Text="";
            Unit_Price.Clear();

            Pet_Name1.Clear();

        }


        private void Displayresultdata()
        {
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            Con.Open();
            SqlCommand sc = new SqlCommand("Select * from Petdetails where PET_ID=@EN", Con);
            sc.Parameters.AddWithValue("@EN",Int32.Parse(Pet_Name1.Text));
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Pettbl.ItemsSource = dt.DefaultView;
            Con.Close();
        }


        private void Search_click(object sender, EventArgs e)
        {
            if (Pet_Name1.Text == "")
            {
                LoadGrid();
            }
            else
            {
                Displayresultdata();

            }
        }

        //Navbarprocess

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

        private void Home1_click(object sender, MouseButtonEventArgs e)
        {
            User us = new User();
            string uname = us.getusrnm();
            Home pg = new Home(uname);
            pg.Show();
            this.Hide();
        }

        private void Petspg(object sender, MouseButtonEventArgs e)
        {
            this.Show();
            
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

   
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }


   
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            SqlCommand cmd = new SqlCommand("delete from Petdetails where Pet_ID=@EN ", Con);
            cmd.Parameters.AddWithValue("@EN", Int32.Parse(Pet_Name1.Text));
            Con.Open();
            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                Con.Close();

                Pet_Name1.Clear();
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
            SqlCommand cmd = new SqlCommand("update Petdetails set Pet_Name=@EN, Pet_Category=@EA ,Quantity=@ED ,Pet_DOB =@PD,Unit_Price=@UP where Pet_ID='"+Pet_Name1.Text+"'", Con);
            cmd.Parameters.AddWithValue("@EN", Pet_Name.Text);
            cmd.Parameters.AddWithValue("@EA", Pet_Category.SelectedItem.ToString().Split(new Char[] { ' ' })[1]);
            cmd.Parameters.AddWithValue("@ED", Int32.Parse(Quantity.Text));
            cmd.Parameters.AddWithValue("@PD", Pet_DOB.SelectedDate);
            cmd.Parameters.AddWithValue("@UP", Int32.Parse(Unit_Price.Text));
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

        private void Lgut(object sender, MouseButtonEventArgs e)
        {
            login lg = new login();
            lg.Show();
            this.Hide();
        }

      
    }
}
