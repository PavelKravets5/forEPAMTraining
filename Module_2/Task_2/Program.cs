using System;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите число:");
            bool result = false;
            int n = 0;
            while (!result)
            {
                result = int.TryParse(Console.ReadLine(), out n);
                if (!result)
                {
                    Console.WriteLine("Некорректно");
                }
            }

            //Поправил в соответствии с советами с трансляции 
            //Текст задачи: "Если N нечетное и МЕНЬШЕ 18 но БОЛЬШЕ 13 – программа поздравляет с переходом в старшую школу." 
            //Если введено 13 - с переходом в старшую школу не поздравлять
            if (n % 2 == 0 && n > 18)
            {
                Console.WriteLine("Поздравляю с 18-летием");
            }
            else
            {
                if (n == 18)
                {
                    Console.WriteLine("Вам РОВНО 18!!!");
                }
                else
                {
                    if (n % 2 != 0 && n < 18 && n > 13)
                    {
                        Console.WriteLine("Вы в старшей школе!");
                    }
                    else
                    {
                        Console.WriteLine("Введенное число не подпадает под первые два условия.");
                    }
                }
            }
            
            Console.WriteLine("Завершено");
            Console.ReadKey();
        }
    }
}
