using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Constants;
using TBC_ATM.Models;

namespace TBC_ATM.Data
{
    public class ListData
    {
        public static List<Customer> Customers = new List<Customer>();
        public static List<Currency> Currencies = new List<Currency>();
        public static Dictionary<double, Currency> fullBalance = new Dictionary<double, Currency>();

    }
}
