using System;

namespace Module_3_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите N");

            bool check = int.TryParse(Console.ReadLine(), out int n);

            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = int.TryParse(Console.ReadLine(), out n);
            }

            int i = 0, k = 0;
            Console.WriteLine($"Ввыводится {n} натуральных четных чисел");
            while(k<n)
            {
                i++;
                if(i%2==0)
                {
                    k++;
                    Console.WriteLine($"{k}-ое натуральное четное число: {i}");
                    //Массив использовать не стал, т.к. мог обойтись без него
                }
            }
            Console.WriteLine("Завершено");
        }
    }
}
