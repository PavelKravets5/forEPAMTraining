using System;

namespace Module_3_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите длинну массива");

            int n = 0 ;// компилятор требует чтобы n было проинициализировано
            bool check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out n);
                if (check == false || n < 0)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            double[] arr = new double[n];

            for (int i=0;i<n;i++)
            {
                Console.WriteLine($"Вводите {i+1} эл. массива");
                check = double.TryParse(Console.ReadLine(), out double el);

                while (!check)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = double.TryParse(Console.ReadLine(), out el);
                }
                arr[i] = el;
            }
            Console.WriteLine("Массив заполнен, инвертируем знаки в отдельном цикле");

            for(int i=0; i<n; i++)
            {
                arr[i] = -arr[i];
            }            

            for(int i=0;i<n;i++)
            {
                Console.Write($"{i + 1}) {arr[i]} ");
            }
            Console.WriteLine();
        }
    }
}
