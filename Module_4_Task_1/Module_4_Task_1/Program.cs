using System;
using System.Linq;

namespace Module_4_Task_1
{
    class Program
    {
        static private int GetMaxEl(int[]arr)
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

        static private int GetMinEl(int[]arr)
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

        static private int GetSum(int[]arr)
        {
            int sum = 0;
            foreach(int el in arr)
            {
                sum += el;
            }
            return sum;
        }

        static private void TransformArr(int []arr)
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

        static private int DifferenceBetweenMinMax(int[]arr)
        {
            return GetMaxEl(arr) - GetMinEl(arr);
        }

        static private int GetSumByLinq(int[]arr)
        {
            return arr.Sum();
        }

        static private int GetMaxElByLinq(int[] arr)
        {
            return arr.Max();
        }

        static private int GetMinElByLinq(int[] arr)
        {
            return arr.Min();
        }

        static private int DifferenceBetweenMinMaxByLinq(int[]arr)
        {
            return arr.Max() - arr.Min();
        }

        static private int[] TransformArrByLinq(int []arr)
        {
            int max = arr.Max();
            int min = arr.Min();
            int[] temp = CopyArrByLinq(arr);
            return (from el in arr where el % 2 == 0 select el + max)
                .Concat(from el in temp where el % 2 != 0 select el - min).ToArray();
        }

        static private int[] CopyArrByLinq(int[]arr)
        {
            return arr.Select(el => el).ToArray();
        }

        private const int limit1 = 1;

        //Я долго думал как убрать или уменьшить длиннющие
        //полотнища кода, где ввожу данные, проверяю корректность ввода, корректность ограничений,
        //лишь бы не выносить Console.WriteLine(), Console.ReadLine() за пределы метода Main
        //Я так и не придумал, и сделал так (здесь и далее):
        static private int ReadWithCheckInt()
        {
            bool check = false;
            int result = 0;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out result);
                if (check == false)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = false;
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
            Console.WriteLine("Введите размер одномерного массива");
            int arrSize = ReadWithCheckInt(limit1);

           
            Console.WriteLine("Заполнить массив рандомными числами от -50 до 51 " +
                "(не включая 51) типа int? Вводите y/n");
            bool check = false;
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
                    arr[i] = ReadWithCheckInt();
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
