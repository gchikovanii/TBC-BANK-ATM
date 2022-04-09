using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Data;
using static System.Console;


namespace TBC_ATM.Services.Implementation
{
    public class ChangePinCodeService
    {
        public void changePin()
        {
            WriteLine("Enter your card (enter card number)");
            string cardNumber = ReadLine();
            WriteLine("Enter Pin");
            int pin = Convert.ToInt32(ReadLine());

            var currentCustomer = ListData.Customers.FirstOrDefault(x => x.CardNumber == cardNumber);
            string singOut = "";
            while (singOut.ToLower() != "quit")
            {
                if (currentCustomer != null && currentCustomer.Status == true && currentCustomer.Pin == pin)
                {
                    WriteLine("Changing pin! Please ennter new Pin");
                    int newPin = Convert.ToInt32(ReadLine());
                    WriteLine("Please repeat your pin");
                    int newPinRepeated = Convert.ToInt32(ReadLine());
                    if (newPin == newPinRepeated && newPin.ToString().Length == 4 && newPin != currentCustomer.Pin)
                    {
                        currentCustomer.Pin = newPin;
                        WriteLine("Pin Changed successfully!");
                        break;
                    }
                    else
                    {
                        WriteLine("Pin's aren't same! Please try again!");
                        WriteLine("If you want to exit please press quit");
                        singOut = ReadLine();
                    }
                        
                }
                else
                {
                    WriteLine("Not valid Card!");
                    break;
                }
            }
            
            

        }
    }
}
