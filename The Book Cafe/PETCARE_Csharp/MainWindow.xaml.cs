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
using System.Windows.Threading;

namespace PETCARE_Csharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dT = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();

            dT.Tick += new EventHandler(dt_Tick);
            dT.Interval= new TimeSpan(0,0,3);
            dT.Start(); 
        }
        private void dt_Tick(object sender, EventArgs e)
        {
            login sg = new login();
            sg.Show();

            dT.Stop();
            this.Close(); 

        }


    }
}
