using System;

namespace Module_3_Task_5
{
    class Program
    {
        static int ReadWithCheckInt()
        {
            int num = 0;
            bool check = int.TryParse(Console.ReadLine(), out num);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = int.TryParse(Console.ReadLine(), out num);
            }
            return num;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вводите число:");
            int num;
            bool check = int.TryParse(Console.ReadLine(), out num);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = int.TryParse(Console.ReadLine(), out num);
            }

            Console.WriteLine("Вводите удаляемую одну цифру:");
            int x = -1; check = false;
            while (!check)
            { 
                check = int.TryParse(Console.ReadLine(), out x);
                if(check==false || x<0 || x>9)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            int reverseNum = 0 ;
            bool sign = true;
            if(num<0)
            {
                num = Math.Abs(num);
                sign = false;
            }

            while(num>0)
            {
                int temp = num % 10;
                num /= 10;
                if (temp!=x)
                {
                    reverseNum += temp;
                    reverseNum *= 10;
                }
            }

            while(reverseNum > 0)
            {
                num += reverseNum % 10;
                num *= 10;
                reverseNum /= 10;
            }
            num /= 10;

            if(sign==false)
            {
                num = 0 - num;
            }
            Console.WriteLine($"Результат, удалены все вхождения заданной литеры, : {num} \nЗавершено");
        }
    }
}
