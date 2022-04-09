using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Data;
using static System.Console;


namespace TBC_ATM.Service
{
    public class AuthorizationService
    {
        
        public static void authorize(string cardNumber)
        {
            int tries = 0;
            var customer = ListData.Customers.FirstOrDefault(i => i.CardNumber == cardNumber);

            if (customer != null && customer.Status == true)
            {
                while(tries < 3)
                {
                    WriteLine("Enter Pin Code:");
                    int pin = Convert.ToInt32(ReadLine());
                    if (pin == customer.Pin)
                    {
                        WriteLine(new string('-', 30));
                        customer.Balance.ToList().ForEach(x => WriteLine(x.Key + " " + x.Value));
                        break;
                    }
                    else if (pin != customer.Pin && tries < 3)
                    {
                        tries++;
                        WriteLine("Incorrect Pin Number, Please Try Again!");
                    }
                    else
                        customer.Status = false;
                        WriteLine("Your card has been blocked");
                }
            }
            else
                WriteLine("Invalid Card!");


        }

        
    }
}
