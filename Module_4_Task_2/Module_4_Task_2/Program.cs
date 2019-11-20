using System;
using System.Globalization;

namespace Module_4_Task_2
{
    class Program
    {
        private enum Types
        {
            intNums=1,
            doubleNums=2,
            two_strings=3
        }

        private const int limit1 = 1;

        static private int GetSumm(int a, int b)
        {
            return a + b;
        }

        static private int GetSumm(int a, int b,int c)
        {
            return a + b+c;
        }

        static private double GetSumm(double a, double b,double c)
        {
            return a + b+c;
        }

        static private string GetSumm(string a, string b)
        {
            return a + b;
        }

        static private double[] GetSumm(double[]a, double[]b)
        {
            double[] c = null;
            if (a.Length < b.Length)
            {
                c = a;
                a = b;
                b = c;
            }
            c = new double[a.Length];
            for (int i=0;i<b.Length;i++)
            {
                c[i] = a[i] + b[i];
            }
            for(int i=b.Length;i<a.Length;i++)
            {
                c[i] = a[i];
            }
            return c;
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

        static private int ReadWithCheckInt()
        {
            bool check = int.TryParse(Console.ReadLine(), out int result);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = int.TryParse(Console.ReadLine(), out result);
            }
            return result;
        }

        static private int ReadWithCheckInt(int lowerLimit)
        {
            bool check = false;
            int result = 0;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if (check == false || result < lowerLimit)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = false;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            int[] arrInt = new int[3];
            Console.WriteLine("Пункт A.");
            for (int i=0;i<3;i++)
            {
                Console.WriteLine($"Вводите {i+1} целое число из 3");
                arrInt[i] = ReadWithCheckInt();
            }
            Console.WriteLine($"Пункт А. Суммирование = {GetSumm(arrInt[0], arrInt[1], arrInt[2])}");

            arrInt = new int[2];
            Console.WriteLine("Пункт Б.");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Вводите {i + 1} целое число из 2");
                arrInt[i] = ReadWithCheckInt();
            }
            Console.WriteLine($"Пункт Б. Суммирование = {GetSumm(arrInt[0], arrInt[1])}");

            double []arrDouble = new double[3];
            Console.WriteLine("Пункт В.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Вводите {i + 1} дробное число из 3");
                arrDouble[i] = ReadWithCheckDouble();
            }
            Console.WriteLine($"Пункт В. Суммирование = {GetSumm(arrDouble[0], arrDouble[1], arrDouble[2]):f2}");

            string[] arrStr = new string[2];
            Console.WriteLine("Пункт Г.");
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine($"Вводите {i + 1} строку из 2");
                arrStr[i] = Console.ReadLine();
            }
            Console.WriteLine($"Пункт Г. Суммирование = {GetSumm(arrStr[0], arrStr[1])}");

            Console.WriteLine("Пункт Д.");
            double[][] twoArr = new double[2][];
            for(int j=0; j<2;j++)
            {
                Console.WriteLine($"Ввелите длинну {j+1} массива:");
                int arrSize = ReadWithCheckInt(limit1);
                twoArr[j] = new double[arrSize];
                for (int i = 0; i < arrSize; i++)
                {
                    Console.WriteLine($"Вводите {i + 1} число в массиве {j+1} из {arrSize}");
                    twoArr[j][i] = ReadWithCheckDouble();
                }
            }
            Console.WriteLine("Пункт Д. Суммирование:");
            double[] arrResult = GetSumm(twoArr[0], twoArr[1]);
            for(int i=0;i<arrResult.Length;i++)
            {
                Console.Write($"{arrResult[i]:f2}, ");
            }
        }
    }
}
