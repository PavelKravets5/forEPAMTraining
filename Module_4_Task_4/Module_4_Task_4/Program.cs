using System;
using System.Linq;
using System.Globalization;

namespace Module_4_Task_4
{
    class Program
    {
        private const int limit1 = 1;
        
        //Проверка показала, что кортежи не являются ссылочным типом
        static private void IncreaseBy10(ref(double a,double b,double c) tuple)
        {
            tuple.a += 10;
            tuple.b += 10;
            tuple.c += 10;
        }

        static private void GetCicleSquareAndPerim(double radius, 
            out (double square, double length) tuple)
        {
            tuple.square = Math.PI * Math.Pow(radius, 2);
            tuple.length = 2 * Math.PI * radius;
        }

        //Не придумал как назвать метод, где вычесляется мин., макс. эл., и сумма
        static private void MethodForArr(double[] arr,out (double max, double min, double sum) tuple)
        {
            tuple.max = arr.Max();
            tuple.min = arr.Min();
            tuple.sum = arr.Sum();
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
            bool check = false;
            Console.WriteLine("Вводим переменные для пункта A:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Вводите {i + 1}-ую из 3 перемнных");
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

            double[] arr = new double[arrSize];
            if (ans == "y")
            {
                Console.WriteLine("Заполняем рандомно");
                Random rnd = new Random();
                for (int i = 0; i < arrSize; i++)
                {
                    arr[i] = rnd.Next(-50, 50) + rnd.NextDouble();
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

            var tupleA = (arrParam[0], arrParam[1], arrParam[2]);
            IncreaseBy10(ref tupleA);

            GetCicleSquareAndPerim(radius, out var CircleProp);
            MethodForArr(arr, out var ArrProp);
            Console.WriteLine($"\n\nЗаполнено.\n\n" +
                $"Три введенных числа увеличены на 10: " +
                $"{tupleA.Item1:f2}, {tupleA.Item2:f2}, {tupleA.Item3:f2}\n" +
                $"По введенному радиусу найдена площадь: {CircleProp.square:f2} " +
                $"и длинна окружности: {CircleProp.length:f2}\n" +
                $"Для массива максимальный эл.: {ArrProp.max:f2}, " +
                $"минимальный эл.: {ArrProp.min:f2}, сумма эл.: {ArrProp.sum:f2}");
        }
    }
}
