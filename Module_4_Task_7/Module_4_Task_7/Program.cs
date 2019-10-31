using System;
using System.Linq;

namespace Module_4_Task_7
{
    class Program
    {
        static private double[] CopyArr(double[]arr)
        {
            return arr.Select(x => x).ToArray();
        }

        static private double[] MySortByLinq(double[]arr,bool direction)
        {
            if(direction)
            {
                return (from el in arr orderby el ascending select el).ToArray();
            }
            else
            {
                return (from el in arr orderby el descending select el).ToArray();
            }
        }

        static private double[] MySortByComparer(double[]arr,bool direction)
        {
            Array.Sort(arr, new MyComparer());
            if (!direction)
            {
                arr = arr.Reverse().ToArray();
            }
            return arr;
        }

        static private void Swap(ref double a,ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }

        static private int Partition(double[] arr,bool direction, int startIndex, int endIndex)
        {
            int marker = startIndex;
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (arr[i] <= arr[endIndex]&&direction==true)
                {
                    Swap(ref arr[marker], ref arr[i]);
                    marker ++;
                }
                if (arr[i] >= arr[endIndex] && direction == false)
                {
                    Swap(ref arr[marker], ref arr[i]);
                    marker++;
                }
            }
            return marker - 1;
        }

        static private void MyQuickSort(double[] arr, bool direction,int startIndex, int endIndex)
        {
            if (startIndex >= endIndex)
            {
                return ;
            }
            int marker= Partition(arr, direction, startIndex, endIndex);
            MyQuickSort(arr, direction,startIndex, marker - 1);
            MyQuickSort(arr, direction,marker + 1, endIndex);
            return ;
        }

        static private void MyQuickSort(double[] arr,bool direction)
        {
            MyQuickSort(arr, direction,0, arr.Length - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер одномерного массива");
            int arrSize = 0;
            bool check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out arrSize);
                if (check == false || arrSize < 0 || arrSize == 0)
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
                ans = Console.ReadLine();
                //Т.к. я проверяю знач. ans, я решил, что могу использовать именно строковую ans
                //и не заменять её на булевую переменную (ошибки не будет)
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
                    Console.WriteLine($"Вводите {i + 1} эл. массива");
                    check = double.TryParse(Console.ReadLine(), out double el);
                    while (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");
                        check = double.TryParse(Console.ReadLine(), out el);
                    }
                    arr[i] = el;
                }
            }

            Console.WriteLine("\n\nОтсортировать по возрастанию? Вводите y/n");
            check = false;
            ans = null;
            while (!check)
            {
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
            //На трансляции по модулю 4, особо обсудили, что направление сортировки
            //в метод должно передоваться как bool. Хотя там даже со строкой будет работать 
            //т.к. я контролирую знач. b ошибок не будет,
            //но на трансляции сказоно было - именно bool
            bool direction=(ans=="y")?true:false;

            double[] temp = CopyArr(arr);
            temp=MySortByLinq(temp,direction);
            Console.WriteLine("\nОтсортировано через Linq");

            foreach (double el in temp)
            {
                Console.Write($"{el:f2} ");
            }

            temp = CopyArr(arr);
            temp=MySortByComparer(temp, direction);
            Console.WriteLine("\n\nОтсортировано через с помощью IComparer<double> и Reverse()");

            foreach (double el in temp)
            {
                Console.Write($"{el:f2} ");
            }

            temp = CopyArr(arr);
            MyQuickSort(temp, direction);
            Console.WriteLine("\n\nОтсортировано через с помощью QuickSort()");

            foreach (double el in temp)
            {
                Console.Write($"{el:f2} ");
            }
            Console.WriteLine("\n\nЗавершено.");
        }
    }
}
