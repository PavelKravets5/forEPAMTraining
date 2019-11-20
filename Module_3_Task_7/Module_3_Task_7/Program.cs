using System;

namespace Module_3_Task_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите длинну массива");
            int n = 0;
            bool check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out n);
                if (check == false || n < 0)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }

            double[] arr = new double[n];
            double el = 0;

            for (int i = 0; i < n; i++)
            {

                Console.WriteLine($"Вводите {i + 1} эл. массива");
                check = double.TryParse(Console.ReadLine(), out el);
                while (!check)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = double.TryParse(Console.ReadLine(), out el);
                }
                arr[i] = el;
            }

            //В примере в задаче "дан массив [3, 9, 8, 4, 5, 1]. Следует вывести числа 9 и 5, 
            //так как перед ними стоят соответственно числа 3 и 4, которые меньше их."
            //В примере, первое число 3 выводить не предлагается, хотя последее число - 1(меньше).
            //Отсюда я делаю вывод, что первое число массива с последним (и вообще с чем-либо) сравнивать не надо
 
            for (int i=1; i<n;i++)
            {
                if (arr[i] > arr[i-1])
                {
                    Console.WriteLine($"{i+1}-ый эл. - {arr[i]} больше {i}-ого - {arr[i-1]}");
                }
            }
            Console.WriteLine("Завершено");
        }
    }
}
