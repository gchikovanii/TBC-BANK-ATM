using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Data;
using static System.Console;



namespace TBC_ATM.Service
{
    public class WithdrawService
    {
        public void withdrawMoney()
        {
            double totalBalanceInGel, totalBalanceInUsd, totalBalanceInEur;
            double newBalanceInGel, newBalanceInUsd, newBalanceInEur;
            WriteLine("Enter your Card Number");
            string cardNumber = ReadLine();
            AuthorizationService.authorize(cardNumber);
            var verifiedUser = ListData.Customers.FirstOrDefault(i => i.CardNumber == cardNumber);
            if (verifiedUser != null)
            {
                WriteLine("Which currency you want to withDraw");
                string currency = ReadLine();
                WriteLine("Enter Amount of money that you want to Withdraw");
                double amount = Convert.ToDouble(ReadLine());
                totalBalanceInGel = verifiedUser.Balance.FirstOrDefault(i => i.Value == Constants.Currency.GEL).Key;
                totalBalanceInUsd = verifiedUser.Balance.FirstOrDefault(i => i.Value == Constants.Currency.USD).Key;
                totalBalanceInEur = verifiedUser.Balance.FirstOrDefault(i => i.Value == Constants.Currency.EUR).Key;

                if (currency.ToUpper() == "GEL" && totalBalanceInGel >= amount)
                {
                    newBalanceInGel = totalBalanceInGel - amount;
                    ListData.fullBalance.Remove(totalBalanceInGel);
                    ListData.fullBalance.Add(newBalanceInGel, Constants.Currency.GEL);
                    WriteLine("Do you want a chek? Yes or No");
                    string checkNeeded = ReadLine();
                    if (checkNeeded.ToLower() == "yes")
                    {
                        WriteLine($"Card Holder: {verifiedUser.Name} {verifiedUser.LastName}\n" +
                            $"Withdrawed money: {amount}GEL\n" +
                            $"Time: {DateTime.Now}\n");
                    }
                    else
                    {
                        WriteLine("Withdrawd successfully!");
                    }
                }
                else if (currency.ToUpper() == "USD" && totalBalanceInUsd >= amount)
                {
                    newBalanceInUsd = totalBalanceInUsd - amount;
                    ListData.fullBalance.Remove(totalBalanceInUsd);
                    ListData.fullBalance.Add(newBalanceInUsd, Constants.Currency.USD);
                    WriteLine("Do you want a chek? Yes or No");
                    string checkNeeded = ReadLine();
                    if (checkNeeded.ToLower() == "yes")
                    {
                        WriteLine($"Card Holder: {verifiedUser.Name} {verifiedUser.LastName}\n" +
                            $"Withdrawed money: {amount}USD\n" +
                            $"Time: {DateTime.Now}\n");
                    }
                    else
                    {
                        WriteLine("Withdrawd successfully!");
                    }
                }
                else if (currency.ToUpper() == "EUR" && totalBalanceInEur >= amount)
                {
                    newBalanceInEur = totalBalanceInEur - amount;
                    ListData.fullBalance.Remove(totalBalanceInEur);
                    ListData.fullBalance.Add(newBalanceInEur, Constants.Currency.EUR);
                    WriteLine("Do you want a chek? Yes or No");
                    string checkNeeded = ReadLine();
                    if (checkNeeded.ToLower() == "yes")
                    {
                        WriteLine($"Card Holder: {verifiedUser.Name} {verifiedUser.LastName}\n" +
                            $"Withdrawed money: {amount}EUR\n" +
                            $"Time: {DateTime.Now}\n");
                    }
                    else
                    {
                        WriteLine("Withdrawd successfully!");
                    }
                }
                else
                {
                    WriteLine($"Error While operation!\n" +
                        $"Card Holder: {verifiedUser.Name} {verifiedUser.LastName}\n" +
                           $"Withdrawed money: ERROR \n" +
                           $"Time: {DateTime.Now}\n" +
                           $"Not Enough Money on card!");
                }

            }
            else
            {
                WriteLine("Incorrect Pin , Please try again!");
            }



        }

    }
}
