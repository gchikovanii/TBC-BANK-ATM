using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBC_ATM.Models;
using TBC_ATM.Service;
using TBC_ATM.Service.Implementation;
using TBC_ATM.Services.Implementation;
using static System.Console;

namespace TBC_ATM
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            #region AllServices
            MakeCardService makeCardService = new MakeCardService();
            DepositService depositService = new DepositService();
            WithdrawService withdrawService = new WithdrawService();
            ChangePinCodeService pinCodeService = new ChangePinCodeService();
            #endregion

            WriteLine("Welcome to TBC Bank ATM");
            while (true)
            {
                ATMScreenInfo.screenInfo();
                WriteLine("Please select one of the following Actions");
                string actions = ReadLine();
                if (actions == "1")
                    makeCardService.CreateCard();
                else if (actions == "2")
                    pinCodeService.changePin();
                else if (actions == "3")
                    GetFullCustomerInfo.GetFullInfo();
                else if (actions == "4")
                    depositService.deposit();
                else if (actions == "5")
                    withdrawService.withdrawMoney();
                else if (actions == "6")
                    break;
                else
                    WriteLine("Invalid number of action!");

            }
            ReadLine();


        }
    }
}
