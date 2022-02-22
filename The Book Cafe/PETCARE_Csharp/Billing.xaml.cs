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
    /// Interaction logic for Billing.xaml
    /// </summary>
    public partial class Billing : Window
    {
        private string name;
        private int pid;
        private string price;
        private string billid;
        SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");
        public Billing()
        {
            InitializeComponent();
            LoadGrid();
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
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
            this.Show();
            
        }

        private void Lgut(object sender, MouseButtonEventArgs e)
        {
            login pg = new login();
            pg.Show();
            this.Hide();
        }
        private void LoadGrid()
        {

            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            SqlCommand cmd = new SqlCommand("select * from Petdetails", Con);
            DataTable dt = new DataTable();
            Con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            Con.Close();
            pets.ItemsSource = dt.DefaultView;


            Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
            SqlCommand cmd2 = new SqlCommand("select * from productdetails", Con);
            DataTable dt2 = new DataTable();
            Con.Open();
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            dt2.Load(sdr2);
            Con.Close();
            Products.ItemsSource = dt2.DefaultView;
        }

        private void Loadbilldetails()
        {
            try
            {            
               Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Billingtbl WHERE Bill_No=(select max(Bill_No) from Billingtbl)", Con);
                DataTable dt = new DataTable();
                Con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                Con.Close();
                Fullamt.ItemsSource = dt.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }//another one needed.

        private void Loadbilldetailsforpets()
        {
            try
            {
                Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Billingtbl WHERE Bill_No=(select max(Bill_No) from Billingtbl)", Con);
                DataTable dt = new DataTable();
                Con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                Con.Close();
                Fullamt.ItemsSource = dt.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void radProducts(object sender, RoutedEventArgs e)
        {
            Products.Visibility = Visibility.Visible;
            pets.Visibility = Visibility.Hidden;
        }

        private void radPets(object sender, RoutedEventArgs e)
        {
            Products.Visibility = Visibility.Hidden;
            pets.Visibility = Visibility.Visible;
        }

        private void selectrow(object sender, SelectionChangedEventArgs e)
        {
            Object rw = Products.SelectedItem;
            pid = Int32.Parse((Products.SelectedCells[0].Column.GetCellContent(rw) as TextBlock).Text);
            name = (Products.SelectedCells[1].Column.GetCellContent(rw) as TextBlock).Text;
            price = (Products.SelectedCells[3].Column.GetCellContent(rw) as TextBlock).Text;


           /* string testval2 = (Products.SelectedItem as ).ID;*/
            Console.WriteLine(pid+name+price);
            Item_Name1.Text = name;
            Item_price.Text = price;
            

        }

        private void petselect(object sender, SelectionChangedEventArgs e)
        {
            Object rw = pets.SelectedItem;
            pid = Int32.Parse((pets.SelectedCells[0].Column.GetCellContent(rw) as TextBlock).Text);
            name = (pets.SelectedCells[1].Column.GetCellContent(rw) as TextBlock).Text;
            price = (pets.SelectedCells[5].Column.GetCellContent(rw) as TextBlock).Text;


            /* string testval2 = (Products.SelectedItem as ).ID;*/
            Console.WriteLine(pid + name + price);
            Item_Name1.Text = name;
            Item_price.Text = price;

        }




        private void Addtobill_Click(object sender, RoutedEventArgs e)
        {

            if (Productcheck.IsChecked == true && petcheck.IsChecked == false)
            {
                if (Customer_ID.Text == "" || Customer_Name.Text == "" || Item_Name1.Text == "" || Item_price.Text == "" || Item_qty.Text == "")
                {
                    MessageBox.Show("Please fill all the input fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string Date;
                    User us = new User();
                    DateTime dt = DateTime.Now;
                    Date = dt.ToString();

                    bill bl = new bill(name, price, Item_qty.Text, Customer_ID.Text, Customer_Name.Text, us.getusrnm(), Date);

                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Billingtbl (Issued_Date,Customer_ID,Customer_Name,Emp_Name,Amount,Product_ID) values(@ISD,@CID,@CUN,@EMN,@AMT,@PID)", Con);
                        cmd.Parameters.AddWithValue("@ISD", Date);
                        cmd.Parameters.AddWithValue("@CID", bl.get_cusid());
                        cmd.Parameters.AddWithValue("@CUN", bl.get_cusname());
                        cmd.Parameters.AddWithValue("@EMN", bl.get_empname());
                        cmd.Parameters.AddWithValue("@AMT", bl.get_totalprice());
                        cmd.Parameters.AddWithValue("@PID", pid);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data has been added Successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                        Con.Close();
                        Loadbilldetails();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                if (Customer_ID.Text == "" || Customer_Name.Text == "" || Item_Name1.Text == "" || Item_price.Text == "" || Item_qty.Text == "")
                {
                    MessageBox.Show("Please fill all the input fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    string Date;
                    User us = new User();
                    DateTime dt = DateTime.Now;
                    Date = dt.ToString();

                    bill bl = new bill(name, price, Item_qty.Text, Customer_ID.Text, Customer_Name.Text, us.getusrnm(), Date);

                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Billingtbl (Issued_Date,Customer_ID,Customer_Name,Emp_Name,Amount,Product_ID) values(@ISD,@CID,@CUN,@EMN,@AMT,@PID)", Con);
                        cmd.Parameters.AddWithValue("@ISD", Date);
                        cmd.Parameters.AddWithValue("@CID", bl.get_cusid());
                        cmd.Parameters.AddWithValue("@CUN", bl.get_cusname());
                        cmd.Parameters.AddWithValue("@EMN", bl.get_empname());
                        cmd.Parameters.AddWithValue("@AMT", bl.get_totalprice());
                        cmd.Parameters.AddWithValue("@PID", pid);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data has been added Successfully!", "", MessageBoxButton.OK, MessageBoxImage.Information);

                        Con.Close();
                        Loadbilldetailsforpets();
                        Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void Clear()
        {
            Customer_ID.Clear();
            Customer_Name.Clear();
            Item_Name1.Clear();
            Item_qty.Clear();
            Item_price.Clear();

        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Fullamt.ItemsSource = null;
        }

        private void print(object sender, SelectionChangedEventArgs e)
        {
            string emp_name;
            string cus_name;
            string pid;
            string amount;
            string date;
            
             Object rw = Fullamt.SelectedItem;
            billid = (Fullamt.SelectedCells[0].Column.GetCellContent(rw) as TextBlock).Text;
            Con.Open();
            SqlCommand scm = new SqlCommand("SELECT * FROM Billingtbl WHERE Bill_No='"+billid+"'",Con);
            DataSet dt = new DataSet();
            SqlDataAdapter sdr = new SqlDataAdapter(scm);
            sdr.Fill(dt);
            date = dt.Tables[0].Rows[0][1].ToString();
            cus_name = dt.Tables[0].Rows[0][3].ToString();
            emp_name = dt.Tables[0].Rows[0][4].ToString();
            amount = dt.Tables[0].Rows[0][5].ToString();
            pid = dt.Tables[0].Rows[0][6].ToString();
            Console.WriteLine(date+" "+cus_name+" "+emp_name+" "+amount+" "+pid);
            Con.Close();
            string document;
            document = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
           
            string path;
            //path = System.IO.Path.Combine(document, "Bill\\"+ billid +".txt");
            path = "C:\\Users\\User\\Desktop\\"+billid+".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("========================Cute n Furry================================");
                    sw.WriteLine("Reciept No: - "+billid);
                    sw.WriteLine("Issued Date: - "+date);
                    sw.WriteLine("Customer: - "+cus_name);
                    sw.WriteLine("Employee in charge: - "+emp_name);
                    sw.WriteLine("Total Amount: - "+amount);
                    sw.WriteLine("Product ID: - "+pid);
                    sw.WriteLine("========================Cute n Furry================================");

                }
                MessageBox.Show("Find the reciept in documents","",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Reciept is already created","Oops!", MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void idChanged(object sender, TextChangedEventArgs e)
        {
            if (Customer_ID.Text != "")
            {
                Con.ConnectionString = ConfigurationManager.ConnectionStrings["CutenFurry"].ConnectionString;
                Con.Open();
                SqlCommand sc = new SqlCommand("Select * from Customertbl where Customer_ID=@EN", Con);
                sc.Parameters.AddWithValue("@EN", Int32.Parse(Customer_ID.Text));
                SqlDataReader sda = sc.ExecuteReader();
                //DataTable dt = new DataTable();
                //sda.Fill(dt);
                while (sda.Read())
                {
                    //if()
                    Customer_Name.Text = (String)sda["Customer_Name"];
                }
                Con.Close();
            }
            else
            {
                Customer_Name.Text = "";
            }
        }
    }
}
