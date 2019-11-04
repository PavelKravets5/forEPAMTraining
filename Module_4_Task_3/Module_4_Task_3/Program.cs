using System;
using System.Linq;
using System.Globalization;

namespace Module_4_Task_3
{
    class Program
    {
        static private void IncreaseBy10(ref double a,ref double b,ref double c)
        {
            a += 10;
            b += 10;
            c += 10;
        }

        static private void GetCicleSquareAndPerim(double radius,out double square,out double length)
        {
            square = Math.PI * Math.Pow(radius, 2);
            length = 2 * Math.PI * radius;
        }

        static private void MethodsForArr(double[]arr,out double max,out double min,out double sum)
        {
            max = arr.Max();
            min = arr.Min();
            sum = arr.Sum();
        }

        private const int limit1 = 1;

        static private double ReadWithCheckDouble()
        {
            bool check = false;
            double num = 0;
            while (!check)
            {
                string str = Console.ReadLine();
                check = double.TryParse(str, NumberStyles.Float, new CultureInfo("en-US"), out num);
                if (!check)
                {
                    check = double.TryParse(str, NumberStyles.Float, new CultureInfo("ru-RU"), out num);
                    if (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");

                    }
                }
            }
            return num;
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
            double[] arrParam = new double[3];
            bool check=false;
            Console.WriteLine("Вводим переменные для пункта A:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Вводите {i + 1}-ую из 3 перменных");
                arrParam[i] = ReadWithCheckDouble();
            }


            Console.WriteLine("Вводите радиус для пункта Б:");
            double radius = ReadWithCheckDouble();

            Console.WriteLine("Введите размер одномерного массива для пункта С");
            int arrSize = ReadWithCheckInt(limit1);

            Console.WriteLine("Заполнить массив рандомными числами от -50 до 51 " +
                "(не включая 51) типа double? Вводите y/n");
            check = false;
            string ans = null;
            while (!check)
            {
                //Т.к. я проверяю знач. ans, я решил, что могу использовать именно строковую ans
                //и не заменять её на булевую переменную
                ans = Console.ReadLine();
                if (ans == "y" || ans == "n")
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            double[]arr = new double[arrSize];
            if (ans == "y")
            {
                Console.WriteLine("Заполняем рандомно");
                Random rnd = new Random();
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(-50, 50)+rnd.NextDouble();
                    Console.Write($"{arr[i]:f2} ");
                }
            }
            else
            {
                Console.WriteLine($"Заполняем вручную:");
                for (int i = 0; i < arrSize; i++)
                {
                    Console.WriteLine($"Вводите {i + 1} эл. масива");
                    arr[i] = ReadWithCheckDouble();
                }
            }

            IncreaseBy10(ref arrParam[0], ref arrParam[1], ref arrParam[2]);
            GetCicleSquareAndPerim(radius, out double square, out double length);
            MethodsForArr(arr, out double max, out double min, out double sum);
            Console.WriteLine($"\n\nЗаполнено.\n\n" +
                $"Три введенных числа увеличены на 10: " +
                $"{arrParam[0]:f2}, {arrParam[1]:f2}, {arrParam[2]:f2}\n" +
                $"По введенному радиусу найдена площадь: {square:f2} " +
                $"и длинна окружности: {length:f2}\n" +
                $"Для массива максимальный эл.: {max:f2}, " +
                $"минимальный эл.: {min:f2}, сумма эл.: {sum:f2}");
        }
    }
}
