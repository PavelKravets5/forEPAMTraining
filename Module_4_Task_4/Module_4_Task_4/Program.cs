using System;
using System.Linq;

namespace Module_4_Task_4
{
    class Program
    {
        //Проверка показала, что кортежи не являются ссылочным типом
        static void IncreaseBy10(ref(double a,double b,double c) tuple)
        {
            tuple.a += 10;
            tuple.b += 10;
            tuple.c += 10;
        }

        static void GetCicleSquareAndPerim(double radius, 
            out (double square, double length) tuple)
        {
            tuple.square = Math.PI * Math.Pow(radius, 2);
            tuple.length = 2 * Math.PI * radius;
        }

        static void MethodsForArr(double[] arr,out (double max, double min, double sum) tuple)
        {
            tuple.max = arr.Max();
            tuple.min = arr.Min();
            tuple.sum = arr.Sum();
        }

        static void Main(string[] args)
        {
            double[] arrParam = new double[3];
            bool check = false;
            Console.WriteLine("Вводим переменные для пункта A:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Вводите {i + 1} переменную.");
                check = double.TryParse(Console.ReadLine(), out double el);
                while (!check)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = double.TryParse(Console.ReadLine(), out el);
                }
                arrParam[i] = el;
            }

            Console.WriteLine("Вводите радиус для пункта Б:");
            check = double.TryParse(Console.ReadLine(), out double radius);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = double.TryParse(Console.ReadLine(), out radius);
            }

            Console.WriteLine("Введите размер одномерного массива для пункта С");
            int arrSize = 0;
            check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out arrSize);
                if (check == false || arrSize <= 0 )
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

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
                    double el;
                    Console.WriteLine($"Вводите {i + 1} эл. массива");
                    check = double.TryParse(Console.ReadLine(), out el);
                    while (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");
                        check = double.TryParse(Console.ReadLine(), out el);
                    }
                    arr[i] = el;
                }
            }

            var tupleA = (arrParam[0], arrParam[1], arrParam[2]);
            IncreaseBy10(ref tupleA);

            GetCicleSquareAndPerim(radius, out var CircleProp);
            MethodsForArr(arr, out var ArrProp);
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
