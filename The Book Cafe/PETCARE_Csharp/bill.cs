using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PETCARE_Csharp
{
    class bill
    {
        private static string Name;
        private static string Price;
        private static string Qty;
        private static string Cus_ID;
        private static string Cus_Name;
        private static string Emp_Name;
        private static string Date;
        private static string TOTPrice;
        public bill(string name, string price, string qty, string cus_id, string cus_name, string emp_name, string date)
        {
            Name = name;
            Price = price;
            Qty = qty;
            Cus_ID = cus_id;
            Cus_Name = cus_name;
            Emp_Name = emp_name;
            Date = date;

        }
        public string get_totalprice()
        {
            TOTPrice = (Int32.Parse(Price) * Int32.Parse(Qty)).ToString();
            return TOTPrice;
        }
        public string get_issueddate()
        {
            DateTime dt = DateTime.Now;
            Date = dt.ToString();
            return Date;
        }

        public string get_prname()
        {
            return Name;
        }

        public string get_cusid()
        {
            return Cus_ID;
        }

        public string get_cusname()
        {
            return Cus_Name;
        }

        public string get_empname()
        {
            return Emp_Name;
        }

        

    }
}
