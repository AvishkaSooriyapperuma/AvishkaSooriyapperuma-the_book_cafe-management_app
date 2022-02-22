using System;
using System.Collections.Generic;
using System.Data.OleDb;
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
    /// Interaction logic for login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Signup where Username='"+ txtUsername.Text + "'AND Password='"+ txtPassword.Password+ "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count==1){
                    
                    User us = new User();
                    us.setusrnm(txtUsername.Text);                 
                    Home pg = new Home(txtUsername.Text);
                    pg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The username or password you entered is incorrect!","Error!",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                con.Close();
            }
            catch(Exception Ex)
            {
                MessageBox.Show("The username or password you entered is incorrect!"+Ex);
            }
            finally
            {
                txtUsername.Clear();
                txtPassword.Clear();
            }
            

         
        }
        private void btntosignup_Click(object sender, RoutedEventArgs e)
        {
            signup sg = new signup();
            sg.Show();
            this.Hide();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
