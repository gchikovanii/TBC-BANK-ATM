using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Data;
using TBC_ATM.Service;
using TBC_ATM.Service.Implementation;
using static System.Console;

namespace TBC_ATM.Services.Implementation
{
    public class GetFullCustomerInfo
    {
        public static void GetFullInfo()
        {
            WriteLine("Enter your Card Number");
            string cardNumber = ReadLine();
            AuthorizationService.authorize(cardNumber);
            var currentCustomer = ListData.Customers.FirstOrDefault(x => x.CardNumber == cardNumber);
            if (currentCustomer != null && currentCustomer.Status == true)
            {
                WriteLine($"\nCard Holder is: {currentCustomer.Name} {currentCustomer.LastName}\n" +
                    $"Identity Number is {currentCustomer.IdentityNumber}\n" +
                    $"Date of Birth: {currentCustomer.DOB}" +
                    $"Card Humber is: {currentCustomer.CardNumber}\n" +
                    $"Card is Valid Through: {currentCustomer.ValidThrough}\n" +
                    $"Pin Code is: {currentCustomer.Pin}\n" +
                    $"CVC: {currentCustomer.CVC}\n" +
                    $"Valid: {currentCustomer.ValidThrough}\n");
                    DepositService.getTotalBalance();
            }
                
        } 

    }
}
