using System;

namespace Module_3_Task_8
{
    class Program
    {
        static int ReadWithCheckIntPoss()
        {
            int num = 0;

            bool check = false;
            while (!check)
            {
                check = int.TryParse(Console.ReadLine(), out num);
                if (check == false || num < 0)
                {
                    check = false;
                    Console.WriteLine("Некорректно, еще раз");
                }
            }
            return num;
        }

        static int[,] MakeArr(int n)
        {

            int[,] arr = new int[n, n];
            int num = 1;
            for (int varVal = 0; varVal < n / 2; varVal++)
            {
                for (int i = varVal; i < n - varVal - 1; i++)
                {
                    arr[varVal, i] = num;
                    num++;
                }
                for (int i = varVal; i < n - varVal - 1; i++)
                {
                    arr[i, n - varVal - 1] = num;
                    num++;
                }
                for (int i = n - varVal - 1; i > varVal; i--)
                {
                    arr[n - varVal - 1, i] = num;
                    num++;
                }
                for (int i = n - varVal - 1; i > varVal; i--)
                {
                    arr[i, varVal] = num;
                    num++;
                }
            }
            if (n % 2 != 0)
            {
                arr[n / 2, n / 2] = num;
            }
            return arr;
        }

        static double Function(double[]coef,double arg)
        {
            double func = 0;
            for(int i= coef.Length-1; i>=0;i--)
            {
                func += coef[coef.Length - 1-i] * Math.Pow(arg, i);
            }
            return func;
        }


        static string MakeEqualizationRec(double[] coef, double[] interv,double acc)
        {
            
            if (2*acc >= Math.Abs(interv[1] - interv[0]))
            {
                return $"Решение найдено интервал [{interv[0]},{interv[1]}]";
            }
            else
            {
                double middle = (interv[0]+interv[1])/2;
                if (Function(coef, interv[0]) * Function(coef, middle) < 0)
                {
                    interv[1] = middle;
                }
                else
                {
                    interv[0] = middle;
                }
                return MakeEqualizationRec(coef, interv, acc);
            }
        }

        static string MakeEqualizationFirstStep(double[]coef,double[]interv,double acc)
        {
            //Согластно учебнику, сравнивается именно двойная точность
            if (2*acc>=Math.Abs(interv[1]-interv[0]))
            {
                return $"Решение найдено интервал [{interv[0]},{interv[1]}]";
            }
            else
            {
                if (Function(coef, interv[0]) * Function(coef, interv[1]) > 0)
                {
                    return "Невозможно найти корни";
                }
                else
                {
                    return MakeEqualizationRec(coef, interv,acc);
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Решаем многочлен с 1 неизвестным \n" +
                "Введите кол-во коэффициентов (равное n) при неизвестных x^n + ... + x^0");

            int n = ReadWithCheckIntPoss();
            double[] coef = new double[n];
            double el = 0;
            bool check;
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine($"Вводите {i + 1} коэффициент, от старшей степени к нулевой");
                check = double.TryParse(Console.ReadLine(), out el);
                while (!check)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = double.TryParse(Console.ReadLine(), out el);
                }
                coef[i] = el;
            }

            double[] interval = new double[2];
            el = 0;
            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine($"Вводите {i + 1} из 2 значений интервала");
                check = double.TryParse(Console.ReadLine(), out el);
                while (!check)
                {
                    Console.WriteLine("Некорректно, еще раз");
                    check = double.TryParse(Console.ReadLine(), out el);
                }
                interval[i] = el;
            }

            Console.WriteLine("Введите точность");
            double acc;
            check = double.TryParse(Console.ReadLine(), out acc);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = double.TryParse(Console.ReadLine(), out acc);
            }

            Console.Write($"Искомый интервал с данной точностью: {MakeEqualizationFirstStep(coef, interval,acc)}");




            Console.WriteLine("\nС уравнением все. Теперь массив \nВводите n:");
            n = ReadWithCheckIntPoss();
            int [,]arr = MakeArr(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
