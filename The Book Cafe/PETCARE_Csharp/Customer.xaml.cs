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
    /// Interaction logic for Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
            LoadGrid();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");

        private void LoadGrid()
        {
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            SqlCommand cmd = new SqlCommand("select * from Customertbl", Con);
            DataTable dt = new DataTable();
            Con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            Customertbl.ItemsSource = dt.DefaultView;
        }
    /*    private void Cusselect(object sender, SelectionChangedEventArgs e)
        {
            string phn;
            string name;
            string add;
            
            Object rw = Customertbl.SelectedItem;
            name = (Customertbl.SelectedCells[1].Column.GetCellContent(rw) as TextBlock).Text;
            add = (Customertbl.SelectedCells[2].Column.GetCellContent(rw) as TextBlock).Text;
            phn = (Customertbl.SelectedCells[3].Column.GetCellContent(rw) as TextBlock).Text;


            /* string testval2 = (Products.SelectedItem as ).ID;
            Console.WriteLine( name + add + phn);
            Customer_Name.Text = name;
            Customer_Address.Text = add;
            Customer_Phone.Text = phn;

        }*/




        private void Save_click(object sender, EventArgs e)
        {
            if (Customer_Name.Text == "" || Customer_Address.Text == "" || Customer_Phone.Text == "")
            {
                MessageBox.Show("Some fields are empty", "Please Fill all the Information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Customertbl (Customer_Name,Customer_Address,Customer_Phone) values(@ENa,@EA,@ED)", Con);
                    cmd.Parameters.AddWithValue("@ENa", Customer_Name.Text);
                    cmd.Parameters.AddWithValue("@EA", Customer_Address.Text);
                    cmd.Parameters.AddWithValue("@ED", Customer_Phone.Text);
                    
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
            Customer_Name.Clear();
            Customer_Address.Clear();
            Customer_Phone.Clear();
            Cus_Name1.Clear();

        }


        private void Displayresultdata()
        {
            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            Con.Open();
            SqlCommand sc = new SqlCommand("Select * from Customertbl where Customer_ID=@EN", Con);
            sc.Parameters.AddWithValue("@EN", Int32.Parse(Cus_Name1.Text));
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Customertbl.ItemsSource = dt.DefaultView;
            Con.Close();
        }


        private void Search_click(object sender, EventArgs e)
        {
            if (Cus_Name1.Text == "")
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

        private void Home1_click(object sender, MouseButtonEventArgs e)
        {
            User us = new User();
            string uname = us.getusrnm();
            /*string cats = us.getcats().ToString();
            string dogs = us.getdogs().ToString();
            string fish = us.getfish().ToString();
            string birds = us.getbirds().ToString();*/
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
            this.Show();
            
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


        private void Employeetbl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            SqlCommand cmd = new SqlCommand("delete from Customertbl where Customer_ID=@EN ", Con);
            cmd.Parameters.AddWithValue("@EN", Int32.Parse(Cus_Name1.Text));
            Con.Open();
            try
            {

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                Con.Close();

                Cus_Name1.Clear();
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
            SqlCommand cmd = new SqlCommand("update Customertbl set Customer_Name ='" + Customer_Name.Text + "',Customer_Address ='" + Customer_Address.Text + "',Customer_Phone ='" + Customer_Phone.Text + "' where Customer_ID='"+ Cus_Name1.Text + "'", Con);
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
            login pg = new login();
            pg.Show();
            this.Hide();
        }
    }
}
