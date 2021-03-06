﻿using System;
using System.Globalization;

namespace Module_4_Task_5
{
    class Program
    {
        private const int limit5 = 5;

        private const int limit12 = 12;

        private const int limit1 = 1;

        private enum Operations
        {
            add=1,
            subtract =2,
            multiply =3,
            divide =4,
            degree =5
        }

        private enum MonthNames
        {
            January=1,
            February =2,
            March =3,
            April =4,
            May =5,
            June =6,
            July =7,
            August =8,
            September=9,
            October =10,
            November =11,
            December =12
        }

        static private double ReadWithCheckDouble()
        {
            bool check = false;
            double result = 0;
            while (!check)
            {
                string str = Console.ReadLine();
                check = double.TryParse(str, NumberStyles.Float, new CultureInfo("en-US"), out result);
                if (!check)
                {
                    check = double.TryParse(str, NumberStyles.Float, new CultureInfo("ru-RU"), out result);
                    if (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");

                    }
                }
            }
            return result;
        }

        static private int ReadWithCheckInt(int lowerLimit,int upperLimit)
        {
            bool check = false;
            int result = 0;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if (check == false || result < lowerLimit|| result>upperLimit)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = false;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            double[] numbers = new double[2];
            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine($"Вводите {i + 1} из 2 чисел");
                numbers[i] = ReadWithCheckDouble();
            }

            Console.WriteLine("Выберите операцию:\n" +
                "нажмите 1 для сложения\n" +
                "нажмите 2 для разности (первое - второе)\n" +
                "нажмите 3 для умножения\n" +
                "нажмите 4 для деления (первое/второе)\n" +
                "нажмите 5 для возведения в степень (первое^второе)");
            int ans = ReadWithCheckInt(limit1,limit5);
            Operations op = (Operations)ans;
            Console.WriteLine($"Результат мат. операции {op} = {DoOperation(numbers[0], numbers[1], op):f2}");

            Console.WriteLine("Вводите номер или название месяца по английски полностью или сокращенно " +
                "- 3 буквы с которых начинается месяц (типа Dec, Nov, Sep)");
            bool check = false;
            string str = null;
            ans = 0;
            while (!check)
            {
                str = Console.ReadLine();
                check = int.TryParse(str, out ans);
                if (!check || ans < limit1 || ans > limit12)
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
                $"{((str == "y" && ans == 2) ? GetDaysInMonth(month) + 1 : GetDaysInMonth(month))}.");
        }

        static private double DoOperation(double a,double b, Operations op)
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

        static private int GetDaysInMonth(MonthNames name)
        {
            int result = 0;
            //Здесь всего 3 варианта ответа 31/30/28 дней. Так что я решил
            //использовать if c 3-1=2 вариантами, а не switch/case с 12-1=11 вариантами
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
