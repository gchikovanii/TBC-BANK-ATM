using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Data;
using static System.Console;

namespace TBC_ATM.Service.Implementation
{
    public class DepositService
    {
        public void deposit()
        {
            double fullAmountGel = 0;
            double fullAmountUsd = 0;
            double fullAmountEur = 0;
            WriteLine("Enter your Card Number");
            string cardNumber = ReadLine();
            AuthorizationService.authorize(cardNumber);

            WriteLine("Which currency do you Enter? GEL | USD | EUR ");
            string currency = ReadLine();
            WriteLine("Enter amount of money");
            double amount = Convert.ToDouble(ReadLine());

            var currentCustomer = ListData.Customers.FirstOrDefault(i => i.CardNumber == cardNumber);
            
            if (currentCustomer != null)
            {
                if (currency.ToUpper() == "GEL")
                {
                    var currentAmountGel = ListData.fullBalance.FirstOrDefault(i => i.Value == Constants.Currency.GEL).Key;
                    fullAmountGel = currentAmountGel + amount;
                    ListData.fullBalance.Remove(currentAmountGel);
                    ListData.fullBalance.Add(fullAmountGel, Constants.Currency.GEL);
                    WriteLine("Do you want a chek? Yes or No");
                    string checkNeeded = ReadLine();
                    if (checkNeeded.ToLower() == "yes")
                    {
                        WriteLine($"Card Holder: {currentCustomer.Name} {currentCustomer.LastName}\n" +
                            $"{amount}GEL transfered successfully!\n" +
                            $"Time: {DateTime.Now}\n");
                    }
                    else
                    {
                        WriteLine("Money transfered successfully");
                    }

                }
                else if (currency.ToUpper() == "USD")
                {
                    var currentAmountUSD = ListData.fullBalance.FirstOrDefault(i => i.Value == Constants.Currency.USD).Key;
                    fullAmountUsd = currentAmountUSD + amount;
                    ListData.fullBalance.Remove(currentAmountUSD);
                    ListData.fullBalance.Add(fullAmountUsd, Constants.Currency.USD); WriteLine("Do you want a chek? Yes or No");
                    string checkNeeded = ReadLine();
                    if (checkNeeded.ToLower() == "yes")
                    {
                        WriteLine($"Card Holder: {currentCustomer.Name} {currentCustomer.LastName}\n" +
                            $"{amount}USD transfered successfully!\n" +
                            $"Time: {DateTime.Now}\n");
                    }
                    else
                    {
                        WriteLine("Money transfered successfully");
                    }

                }
                    
                else if (currency.ToUpper() == "EUR")
                {
                    var currentAmountEur = ListData.fullBalance.FirstOrDefault(i => i.Value == Constants.Currency.EUR).Key;
                    fullAmountEur = currentAmountEur + amount;
                    ListData.fullBalance.Remove(currentAmountEur);
                    ListData.fullBalance.Add(fullAmountEur, Constants.Currency.EUR);

                    WriteLine("Do you want a chek? Yes or No");
                    string checkNeeded = ReadLine();
                    if (checkNeeded.ToLower() == "yes")
                    {
                        WriteLine($"Card Holder: {currentCustomer.Name} {currentCustomer.LastName}\n" +
                            $"{amount}EUR transfered successfully!\n" +
                            $"Time: {DateTime.Now}\n");
                    }
                    else
                    {
                        WriteLine("Money transfered successfully");
                    }
                }
                else
                    WriteLine("Invalid currency");
            }
            else
                WriteLine("Invalid Card!");
        }
        public static void getTotalBalance()
        {
            ListData.fullBalance.ToList().ForEach(i => WriteLine(i.Key + "" + i.Value));
        }

    }
}
