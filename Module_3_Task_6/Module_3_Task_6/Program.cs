using System;

namespace Module_3_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите длинну массива");
            int n = 0;
            bool check = int.TryParse(Console.ReadLine(), out n); 
            while(!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = int.TryParse(Console.ReadLine(), out n);
            }

            double[] arr = new double[n];
            double el=0;

            for (int i=0;i<n;i++)
            {
                
                Console.WriteLine($"Вводите {i+1} эл. массива");
                check = double.TryParse(Console.ReadLine(), out el);
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
