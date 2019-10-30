using System;

namespace Module_4_Task_6
{
    class Program
    {
        static void IncreaseBy5(double[]arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                arr[i] += 5;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер одномерного массива");
            int arrSize = 0;
            bool check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out arrSize);
                if (check == false || arrSize < 0 || arrSize == 0)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            Console.WriteLine("Заполнить массив рандомными числами от -50 до 51 " +
                "(не включая 51) типа double? Вводите y/n");
            check = false;
            string ans = null;
            while (!check)
            {
                //Т.к. я проверяю знач. ans, я решил, что могу использовать именно строковую ans
                //и не заменять её на булевую переменную (ошибки не будет)
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

            double[] arr = new double[arrSize];
            if (ans == "y")
            {
                Console.WriteLine("Заполняем рандомно");
                Random rnd = new Random();
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(-50, 50) + rnd.NextDouble();
                    Console.Write($"{arr[i]:f2} ");
                }
            }
            else
            {
                Console.WriteLine($"Заполняем вручную:");
                for (int i = 0; i < arrSize; i++)
                {
                    double el;
                    Console.WriteLine($"Вводите {i + 1} эл. массива");
                    check = double.TryParse(Console.ReadLine(), out el);
                    while (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");
                        check = double.TryParse(Console.ReadLine(), out el);
                    }
                    arr[i] = el;
                }
            }

            IncreaseBy5(arr);
            Console.WriteLine("\nВсе элементы массива увеличены на 5");

            foreach (double el in arr)
            {
                Console.Write($"{el:f2} ");
            }
            Console.WriteLine("\n\nЗавершено.");
        }
    }
}
