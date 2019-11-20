using System;
namespace Module_3_Task_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите n");
            int n;
            bool check = int.TryParse(Console.ReadLine(), out n);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = int.TryParse(Console.ReadLine(), out n);
            }


            if (n >= 1)
            {
                Console.WriteLine("1-ое число Фибоначи: 0");
            }
            if(n>=2)
            {
                Console.WriteLine("2-ое число Фибоначи: 1");

                uint first = 0, second = 1, temp=0, i = 2;
                while (i < n)
                {
                    i++;
                    temp = second;
                    second = first + second;
                    first = temp;
                    Console.WriteLine($"{i}-ое число Фибоначи: {second}");
                    
                }

            }
            Console.WriteLine("Завершено");
            
        }
    }
}
