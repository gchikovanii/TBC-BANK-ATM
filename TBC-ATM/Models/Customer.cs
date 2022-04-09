using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Constants;

namespace TBC_ATM.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public Dictionary<double, Currency> Balance { get; set; }
        public int Pin { get; set; }
        public string CardNumber { get; set; }
        public string IdentityNumber { get; set; }
        public DateTimeOffset ValidThrough { get; set; }
        public int CVC { get; set; }
        public bool Status { get; set; } = true;

    }
}
