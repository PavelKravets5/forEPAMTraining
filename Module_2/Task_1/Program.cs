using System;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n - кол-во компаний:");
            bool result = false;
            int n = 0;
            while(!result)
            {
                result = int.TryParse(Console.ReadLine(), out n);
                if(!result)
                {
                    Console.WriteLine("Некорректно");
                }
            }

            Console.WriteLine("Введите m - налог на прибыль - число без знака %:");
            result = false;
            double m = 0;
            while (!result)
            {
                result = double.TryParse(Console.ReadLine(), out m);
                if (!result)
                {
                    Console.WriteLine("Некорректно");
                }
            }
            Console.WriteLine($"Введено m={m}%");

            Console.WriteLine($"Результат = {5*m*n}");
            Console.ReadKey();
        }
    }
}
