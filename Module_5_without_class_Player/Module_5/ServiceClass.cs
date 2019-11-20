using System;
using System.Collections.Generic;
using System.Text;

namespace Module_5
{
    class ServiceClass
    {
        public const int LIMIT_4 = 4;
        public const int LIMIT_1 = 1;
        public const int LIMIT_2 = 2;
        public const int LIMIT_0 = 0;

        public static bool ReadWithCheck(string str,int lowerLimit,out int result)
        {
            bool check = true;
            check = int.TryParse(str, out result);
            if ( result < lowerLimit)
            {               
                check = false;
            }
            return check;
        }

        public static bool ReadWithCheck(string str, int lowerLimit, int upperLimit,
            out int result)
        {
            bool check = true;
            check = int.TryParse(str, out result);
            if ( result < lowerLimit||result>upperLimit)
            {
                check = false;;
            }
            return check;
        }

        public static string ReadYOrN()
        {
            bool check = false;
            string ans = null;
            while (!check)
            {
                ans = Console.ReadLine();
                if (ans == "y" || ans == "n")
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Некорректно, еще раз");
                }
            }
            return ans;
        }

        public static void DisplayMessage(string message)
        {
            Console.Write(message);
        }
    }
}
