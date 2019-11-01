using System;
using System.Linq;

namespace Module_4_Task_1
{
    class Program
    {
        static int GetMaxEl(int[]arr)
        {
            int max = arr[0];
            foreach (int el in arr)
            {
                if(max<el)
                {
                    max = el;
                }
            }
            return max;
        }

        static int GetMinEl(int[]arr)
        {
            int min = arr[0];
            foreach(int el in arr)
            {
                if (min > el)
                {
                    min = el;
                }
            }
            return min;
        }

        static int GetSum(int[]arr)
        {
            int sum = 0;
            foreach(int el in arr)
            {
                sum += el;
            }
            return sum;
        }

        static void TransformArr(int []arr)
        {
            int max = GetMaxEl(arr);
            int min = GetMinEl(arr);
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]%2==0)
                {
                    arr[i] += max;
                }
                else
                {
                    arr[i] -= min;
                }
            }
        }

        static int DifferenceBetweenMinMax(int[]arr)
        {
            return GetMaxEl(arr) - GetMinEl(arr);
        }

        static int GetSumByLinq(int[]arr)
        {
            return arr.Sum();
        }

        static int GetMaxElByLinq(int[] arr)
        {
            return arr.Max();
        }

        static int GetMinElByLinq(int[] arr)
        {
            return arr.Min();
        }

        static int DifferenceBetweenMinMaxByLinq(int[]arr)
        {
            return arr.Max() - arr.Min();
        }

        static int[] TransformArrByLinq(int []arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int[] temp = CopyArrByLinq(arr);
            return (from el in arr where el % 2 == 0 select el + max)
                .Concat(from el in temp where el % 2 != 0 select el - min).ToArray();
        }

        static int[] CopyArrByLinq(int[]arr)
        {
            return arr.Select(el => el).ToArray();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер одномерного массива");
            int arrSize = 0;
            bool check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out arrSize);
                if (check == false || arrSize <= 0)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            //пункт Д: создать метод чтобы 
            //"Увеличить четные элементы массива на максимальный элемент, 
            //нечётные уменьшить на минимальный элемент.", 
            //я , что раз речь идет о четности/ нечетности, массив заполнен только целыми числами?
            Console.WriteLine("Заполнить массив рандомными числами от -50 до 51 " +
                "(не включая 51) типа int? Вводите y/n");
            check = false;
            string ans = null;
            while (!check)
            {
                //Т.к. я проверяю знач. ans, я решил, что могу использовать именно строковую ans
                //и не заменять её на булевую переменную (ошибки не будет)
                ans = Console.ReadLine();
                if(ans=="y"||ans=="n")
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            int[] arr = new int[arrSize];
            if(ans=="y")
            {
                Console.WriteLine("Заполняем рандомно");
                Random rnd = new Random();
                for(int i=0;i<arrSize;i++)
                {
                    arr[i] = rnd.Next(-50, 51);
                    Console.Write($"{arr[i]} ");
                }
            }
            else
            {
                Console.WriteLine($"Заполняем вручную:");
                for (int i = 0; i < arrSize; i++)
                {
                    Console.WriteLine($"Вводите {i + 1} эл. массива");
                    check = int.TryParse(Console.ReadLine(), out int el);
                    while (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");
                        check = int.TryParse(Console.ReadLine(), out el);
                    }
                    arr[i] = el;
                }
            }

            Console.WriteLine($"\n\nЗаполнено.\n\n" +
                $"Через циклы\n\n" +
                $"Макс. эл. массива: {GetMaxEl(arr)}, мин. эл. массива: {GetMinEl(arr)}\n" +
                $"Разность между макс. и мин. эл.: {DifferenceBetweenMinMax(arr)}, " +
                $"сумма эл. массива: {GetSum(arr)}.\n" +
                $"По итогам увеличения четных эл. массива на макс. эл. массива и " +
                $"уменьшения нечетных на мин. эл." +
                $"массив выглядит так:");

            int[] copyArr = CopyArrByLinq(arr);
            TransformArr(arr);

            for(int i=0;i<arr.Length;i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.WriteLine($"\n\nТеперь тоже самое через Linq:\n\n" +
                $"Макс. эл. массива: {GetMaxElByLinq(copyArr)}, " +
                $"мин. эл. массива: {GetMinElByLinq(copyArr)}\n" +
                $"Разность между макс. и мин. эл.: {DifferenceBetweenMinMaxByLinq(copyArr)}, " +
                $"сумма эл. массива: {GetSumByLinq(copyArr)}.\n" +
                $"По итогам увеличения четных эл. массива на макс. эл. массива и " +
                $"уменьшения нечетных на мин. эл." +
                $"массив выглядит так:");

            copyArr=TransformArrByLinq(copyArr);
            foreach(int el in copyArr)
            {
                Console.Write($"{el} ");
            }
            Console.WriteLine("\n\nЗавершено.");



        }
    }
}
