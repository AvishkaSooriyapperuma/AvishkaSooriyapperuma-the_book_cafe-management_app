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
    /// Interaction logic for signup.xaml
    /// </summary>
    /// 
    public partial class signup : Window
          
    {
        public signup()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NLHM8LU;Initial Catalog=CutenFurry;Integrated Security=True");

        private void btnsignup_Click(object sender, RoutedEventArgs e)
        {
            if (Username.Text == "" || Email.Text == "" || Password.Password == "" || ConfirmPassword.Password == "")
            {
                MessageBox.Show("Some fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                if (Password.Password == ConfirmPassword.Password)
                {
                    try
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("insert into Signup (Username,Email,Password) values(@EN,@EA,@ED)", con);
                        cmd.Parameters.AddWithValue("@EN", Username.Text);
                        cmd.Parameters.AddWithValue("@EA", Email.Text);
                        cmd.Parameters.AddWithValue("@ED", Password.Password);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account has been Successfully Created", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                       

                        login lg = new login();
                        lg.Show();

                    }
                    catch (SqlException Ex)
                    {
                        if(Ex.Number==2627){
                            MessageBox.Show("The Username you entered is already taken!");
                        }
                        else
                        {
                            MessageBox.Show(Ex.Message);
                        }
                    }
                    catch(Exception Ex1)
                    {
                        MessageBox.Show("Some Error Occured"+Ex1);
                    }
                    finally
                    {
                        con.Close();
                        Username.Clear();
                        Password.Clear();
                        ConfirmPassword.Clear();
                        Email.Clear();
                    }
                    

                   

                  
                }
                else
                {
                    MessageBox.Show("Passwords does not match, Please Re-enter Password and try again", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    Password.Password = "";
                    ConfirmPassword.Password = "";
                    Password.Focus();
                }
            }    
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
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
