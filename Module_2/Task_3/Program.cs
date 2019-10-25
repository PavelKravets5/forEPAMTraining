using System;
using System.Globalization;

namespace Task_3
{
    class Program
    {
        private static double ReadWithChange()
        {
            bool result = false;
            double num = 0;
            string str = null;
            while (!result)
            {
                str = Console.ReadLine();

                result = double.TryParse(str,NumberStyles.Float,new CultureInfo("en-US"),out num);
                if (!result)
                {
                    result = double.TryParse(str, NumberStyles.Float, new CultureInfo("ru-RU"), out num);
                    if (!result)
                    {
                        Console.WriteLine("Некорректно");
                    }
                }
            }
            return num;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число:");

            double firstNum = ReadWithChange();

            Console.WriteLine("Введите второе число:");

            double secondNum = ReadWithChange();

            Console.WriteLine($"Первое число = {firstNum}, второе число = {secondNum}");

            double temp = firstNum;
            firstNum = secondNum;
            secondNum = temp;

            Console.WriteLine($"Переставлено местами\nПервое число = {firstNum}, второе число = {secondNum}");
            Console.ReadKey();
        }
    }
}
