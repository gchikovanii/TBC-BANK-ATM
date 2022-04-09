using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Constants;
using TBC_ATM.Data;
using TBC_ATM.Models;
using static System.Console;

namespace TBC_ATM.Service.Implementation
{
    public class MakeCardService 
    {
        int id = 0;
        string firstName, lastName, cardNumber,cvc, pin, identityNumber,currency;
        double amount;
        DateTime validTrough,dob;
        Random random = new Random();
        public void CreateCard()
        {
            WriteLine("Enter Your First Name");
            firstName = ReadLine();
            WriteLine("Enter Your Last Name");
            lastName = ReadLine();
            WriteLine("Enter Identification Number");
            identityNumber = ReadLine();
            WriteLine("Enter Date Of birth like Month/Day/Year ex: 2/25/2001");
            dob = Convert.ToDateTime(ReadLine());
            int age = DateTime.Now.Year - dob.Year;
            //Card validation date
            validTrough = DateTime.Now.AddYears(3).AddMonths(2);

            //Randomly genereate Card Number
            for (int i = 0; i < 3; i++)
            {
                int randomNum = random.Next(0, 9);
                cardNumber += randomNum.ToString();
            }
            //Randomly genereate CVC
            for (int i = 0; i < 3; i++)
            {
                int randomCVC = random.Next(0, 9);
                cvc += randomCVC.ToString();
            }
            //Randomly genereate default PIN 
            for (int i = 0; i < 4; i++)
            {
                int randomCVC = random.Next(0, 9);
                pin += randomCVC.ToString();
            }
            if (identityNumber.Length == 11 && age >= 18)
            {
                id++;
                WriteLine(new string('-', 90));
                WriteLine("Make first deposit to activate Account! Choose which currency you want to pay\n" +
                    "GEL\n" +
                    "USD \n" +
                    "EUR");
                currency = ReadLine();
                WriteLine("Enter money");
                amount = Convert.ToDouble(ReadLine());
                if (currency.ToUpper() == "GEL" && amount > 1)
                {
                    ListData.fullBalance.Add(amount, Currency.GEL);
                    ListData.Customers.Add(new Customer
                    {
                        Id = id,
                        Name = firstName,
                        LastName = lastName,
                        IdentityNumber = identityNumber,
                        DOB = dob,
                        CardNumber = cardNumber,
                        Status = true,
                        CVC = Convert.ToInt32(cvc),
                        Pin = Convert.ToInt32(pin),
                        ValidThrough = validTrough,
                        Balance = ListData.fullBalance
                    });
                    WriteLine("Succesfuly Created!");
                    PrintOnCard();
                }
                else if (currency.ToUpper() == "USD" && amount > 1)
                {
                    ListData.fullBalance.Add(amount, Currency.USD);
                    ListData.Customers.Add(new Customer
                    {
                        Id = 1,
                        Name = firstName,
                        LastName = lastName,
                        IdentityNumber = identityNumber,
                        CardNumber = cardNumber,
                        Status = true,
                        CVC = Convert.ToInt32(cvc),
                        Pin = Convert.ToInt32(pin),
                        ValidThrough = validTrough,
                        Balance = ListData.fullBalance
                    });
                    WriteLine("Succesfuly Created!");
                    PrintOnCard();
                }
                else if (currency.ToUpper() == "EUR" && amount > 1)
                {
                    ListData.fullBalance.Add(amount, Currency.EUR);
                    ListData.Customers.Add(new Customer
                    {
                        Id = 1,
                        Name = firstName,
                        LastName = lastName,
                        IdentityNumber = identityNumber,
                        CardNumber = cardNumber,
                        Status = true,
                        CVC = Convert.ToInt32(cvc),
                        Pin = Convert.ToInt32(pin),
                        ValidThrough = validTrough,
                        Balance = ListData.fullBalance
                    });
                    WriteLine("Succesfuly Created!");
                    PrintOnCard();
                }
                else
                    Write("Error while this operation");
            }
            else if (age < 18)
                WriteLine("+18 Customers from only 18 year");
            else
            {
                WriteLine("Incorrect Identity Number");
            }
        }

        public void PrintOnCard()
        {
            WriteLine($"FullName {firstName} {lastName}\n" +
                $"Identity Number {identityNumber}\n" +
                $"Card Number {cardNumber}\n" +
                $"CVC: {cvc}\n" +
                $"Default Pin Code is: {pin}\n" +
                $"Card is valid through :{validTrough.Year}/{validTrough.Month}\n" +
                $"Blance is : {amount} {currency} " +
                $"We Recomend to change default pin code!");
        }
        


    }
}
