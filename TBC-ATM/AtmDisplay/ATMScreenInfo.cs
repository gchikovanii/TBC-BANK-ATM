using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace TBC_ATM
{
    public class ATMScreenInfo
    {
        public static void screenInfo()
        {
            WriteLine("\n1 - Make your TBC Card if you don't have any yet!  \n" +
                "2 - Change Pin Code \n" +
                "3 - Get Full Info about your account \n" +
                "4 - Deposit Money \n" +
                "5 - Withdraw Money\n" +
                "6 - Quit \n");
            WriteLine(new string('-', 90));
        }

    }
}
