using System;

namespace Module_4_Task_5
{
    class Program
    {
        enum Operations
        {
            add=1, subtract=2, multiply=3, divide=4, degree=5
        }
        enum MonthNames
        {
            January=1, February=2, March=3, April=4, May=5, June=6, July=7, August=8,
            September=9, October=10, November=11, December=12
        }
        
        static void Main(string[] args)
        {
            double[] nums = new double[2];
            double el = 0;
            bool check = false;
            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine($"Вводите {i + 1} из 2 чисел");
                check = double.TryParse(Console.ReadLine(), out el);
                while (!check)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = double.TryParse(Console.ReadLine(), out el);
                }
                nums[i] = el;
            }

            Console.WriteLine("Выберите операцию:\n" +
                "нажмите 1 для сложения\n" +
                "нажмите 2 для разности (первое - второе)\n" +
                "нажмите 3 для умножения\n" +
                "нажмите 4 для деления (первое/второе)\n" +
                "нажмите 5 для возведения в степень (первое^второе)");
            check = false;    
            int n = 0;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out n);
                if (check == false || n < 1|| n>5)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }
            Operations op = (Operations)n;
            Console.WriteLine($"Результат мат. операции {op} = {Operation(nums[0],nums[1], op):f2}");

            Console.WriteLine("Вводите номер или название месяца по английски полностью или сокращенно " +
                "- 3 буквы с которых начинается месяц (типа Dec, Nov, Sep)");
            check = false;
            string str = null;
            while (!check)
            {
                str = Console.ReadLine();
                check = int.TryParse(str, out n);
                if (!check || n<1 || n>12)
                {
                    check = false;
                    if (str.Length >= 3)
                    {
                        check = GetMonthName(str, out n);
                    }
                    if (!check)
                    {
                        Console.WriteLine("Что-то пошло не так, еще раз");
                    }
                }
            }

            Console.WriteLine("\nВисокосный год? Вводите y/n");
            check = false;
            str = null;
            while (!check)
            {
                //Т.к. я проверяю знач. ans, я решил, что могу использовать именно строковую ans
                //и не заменять её на булевую переменную (ошибки не будет)
                str = Console.ReadLine();
                if (str == "y" || str == "n")
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Некорректно, еще раз");
                }
            }
            MonthNames month=(MonthNames)n;
            
            Console.WriteLine($"В месяце {month} дней " +
                $"{((str == "y" && n == 2) ? DaysInMonth(month) + 1 : DaysInMonth(month))}.");
        }

        static private double Operation(double a,double b, Operations op)
        {
            double result = 0;
            switch (op)
            {
                case Operations.add:
                    {
                        result = a + b;
                    }
                    break;
                case Operations.subtract:
                    {
                        result = a - b;
                    }
                    break;
                case Operations.divide:
                    {
                        result = a / b;
                    }
                    break;
                case Operations.multiply:
                    {
                        result = a *b;
                    }
                    break;
                case Operations.degree:
                    {
                        result = Math.Pow(a,b);
                    }
                    break;
            }
            return result;
        }

        static private bool GetMonthName(string str,out int n)
        {
            n = 0;
            for(int i=1;i<=12;i++)
            {
                if(((MonthNames)i).ToString().ToUpper().StartsWith(str.ToUpper()))
                {
                    n = i;
                    return true;
                }
            }
            return false;
        }

        static private int DaysInMonth(MonthNames name)
        {
            int result = 0;
            switch (name)
            {
                case MonthNames.January:
                    {
                        result = 31;
                    }
                    break;
                case MonthNames.February:
                    {
                        result = 28;
                    }
                    break;
                case MonthNames.March:
                    {
                        result = 31;
                    }
                    break;
                case MonthNames.April:
                    {
                        result = 30;
                    }
                    break;
                case MonthNames.May:
                    {
                        result = 31;
                    }
                    break;
                case MonthNames.June:
                    {
                        result = 30;
                    }
                    break;
                case MonthNames.July:
                    {
                        result = 31;
                    }
                    break;
                case MonthNames.August:
                    {
                        result = 31;
                    }
                    break;
                case MonthNames.September:
                    {
                        result = 30;
                    }
                    break;
                case MonthNames.October:
                    {
                        result = 31;
                    }
                    break;
                case MonthNames.November:
                    {
                        result = 30;
                    }
                    break;
                case MonthNames.December:
                    {
                        result = 31;
                    }
                    break;
            }
            return result;
        }
    }
}
