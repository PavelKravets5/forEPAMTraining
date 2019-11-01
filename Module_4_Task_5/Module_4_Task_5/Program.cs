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

        const int lowerLimit = 1;
        const int upperLimit1 = 5;
        const int upperLimit2 = 12;

        static void Main(string[] args)
        {
            double[] nums = new double[2];
            bool check = false;
            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine($"Вводите {i + 1} из 2 чисел");
                check = double.TryParse(Console.ReadLine(), out double el);
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
            int ans = 0;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out ans);
                if (check == false || ans < lowerLimit|| ans > upperLimit1)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }
            Operations op = (Operations)ans;
            Console.WriteLine($"Результат мат. операции {op} = {Operation(nums[0],nums[1], op):f2}");

            Console.WriteLine("Вводите номер или название месяца по английски полностью или сокращенно " +
                "- 3 буквы с которых начинается месяц (типа Dec, Nov, Sep)");
            check = false;
            string str = null;
            ans = 0;
            while (!check)
            {
                str = Console.ReadLine();
                check = int.TryParse(str, out ans);
                if (!check || ans < lowerLimit || ans > upperLimit2)
                {
                    check = false;
                    if (str.Length >= 3)
                    {
                        check = GetMonthName(str, out ans);
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
            MonthNames month=(MonthNames)ans;
            
            Console.WriteLine($"В месяце {month} дней " +
                $"{((str == "y" && ans == 2) ? DaysInMonth(month) + 1 : DaysInMonth(month))}.");
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

        static private bool GetMonthName(string str,out int number)
        {
            number = 0;
            for(int i=1;i<=12;i++)
            {
                if(((MonthNames)i).ToString().ToUpper().StartsWith(str.ToUpper()))
                {
                    number = i;
                    return true;
                }
            }
            return false;
        }

        static private int DaysInMonth(MonthNames name)
        {
            int result = 0;
            //Здесь всего 3 варианта ответа 31/30/28 дней. Так что я решил
            //использовать if c 3-1 вариантами, а не switch/case с 12-1 вариантами
            if(name== MonthNames.January||name==MonthNames.March||name==MonthNames.May||
                name==MonthNames.July||name==MonthNames.August||name==MonthNames.October||
                name==MonthNames.December)
            {
                result = 31;
            }
            else
            {
                if(name!=MonthNames.February)
                {
                    result = 30;
                }
            }
            return result;
        }
    }
}
