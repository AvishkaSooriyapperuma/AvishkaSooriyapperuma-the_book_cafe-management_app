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
    /// Interaction logic for Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        public Employees()
        {
            InitializeComponent();
            
            LoadGrid();
            
        }

        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-FLH7QV8;Initial Catalog=thebookcafe;Integrated Security=True");

        private void LoadGrid()
        {
            
            SqlCommand cmd = new SqlCommand("select * from employee", Con);
            DataTable dt = new DataTable();
            Con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            Employeetbl.ItemsSource = dt.DefaultView;
        }




        private void Save_click(object sender,EventArgs e)
        {
            if(Emp_Name.Text == "" || Emp_Address.Text == "" || Emp_Cno.Text == "")
            {
                MessageBox.Show("Some fields are empty", "Please Fill all the Information!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into employee (emp_name,emp_add,emp_dob,emp_no) values(@ENa,@EA,@ED,@EC)",Con);
                    cmd.Parameters.AddWithValue("@ENa",Emp_Name.Text);
                    cmd.Parameters.AddWithValue("@EA", Emp_Address.Text);
                    cmd.Parameters.AddWithValue("@ED", Emp_DOB.Text);
                    cmd.Parameters.AddWithValue("@EC", Emp_Cno.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been added Successfully!","", MessageBoxButton.OK, MessageBoxImage.Information);
                    Con.Close();
                    LoadGrid();
                    
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Clear()
        {
            Emp_Name.Clear();
            Emp_Address.Clear();
            Emp_Cno.Clear();
            Emp_DOB.Clear();
            Emp_Name1.Clear();

        }

       
        private void Displayresultdata()
        {
            
            Con.Open();
            SqlCommand sc = new SqlCommand("Select * from Employee where emp_id=@EN",Con);           
            sc.Parameters.AddWithValue("@EN",Int32.Parse(Emp_Name1.Text));         
            SqlDataAdapter sda = new SqlDataAdapter(sc);
            DataTable dt = new DataTable( );
            sda.Fill(dt);
            Employeetbl.ItemsSource = dt.DefaultView;
            Con.Close();
        }


        private void Search_click(object sender, EventArgs e)
        {
            if (Emp_Name1.Text == "")
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
                
                tt_Products.Visibility = Visibility.Collapsed;
                tt_Employees.Visibility = Visibility.Collapsed;
                tt_Customers.Visibility = Visibility.Collapsed;
                tt_Billing.Visibility = Visibility.Collapsed;
                tt_logout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                
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

            Home pg = new Home(uname);
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
            this.Show();
            
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

       
        private void Employeetbl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }
        
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            
            SqlCommand cmd = new SqlCommand("delete from employee where emp_id=@EN ",Con );
            cmd.Parameters.AddWithValue("@EN", Int32.Parse(Emp_Name1.Text));
            Con.Open();
            try
            {
               
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been deleted", "Deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                Con.Close();
                
                Emp_Name1.Clear();
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
            SqlCommand cmd = new SqlCommand("update employee set emp_name ='"+Emp_Name.Text+"',emp_add ='"+Emp_Address.Text+"',emp_dob ='"+Emp_DOB.Text+"',emp_no ='"+Emp_Cno.Text+"' where emp_id='"+Emp_Name1.Text+"'",Con);
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record has been updated Successfully!","Updated!",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            catch(SqlException ex)
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

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
