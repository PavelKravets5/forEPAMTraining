using System;
using System.Linq;

namespace Module_4_Task_8
{
    class Program
    {
        static double Function(double[] coef, double arg)
        {
            double func = 0;
            for (int i = coef.Length - 1; i >= 0; i--)
            {
                func += coef[coef.Length - 1 - i] * Math.Pow(arg, i);
            }
            return func;
        }

        static double[] CopyArr(double []arr)
        {
            return arr.Select(x => x).ToArray();
        }

        #region ByRecursion
        static void SolutionEqualizationRec(double[] coef, double[] interv, double acc)
        {
            //Все таки решил сделать одинарную точность
            if (acc >= Math.Abs(interv[1] - interv[0]))
            {
                return;
            }
            else
            {
                double middle = (interv[0] + interv[1]) / 2;
                if (Function(coef, interv[0]) * Function(coef, middle) < 0)
                {
                    interv[1] = middle;
                }
                else
                {
                    interv[0] = middle;
                }
                SolutionEqualizationRec(coef, interv, acc);
            }
        }

        static void SolutionEqualizationRec(double[] coef, double[] interv, double acc,out bool success)
        {
            success = false;
            //Я решил, что проверка правильности интервала должна быть первична
            if (Function(coef, interv[0]) * Function(coef, interv[1]) > 0)
            {
                return;
            }
            
            else
            {
                success = true;
                //Все таки решил сделать одинарную точность
                if (acc >= Math.Abs(interv[1] - interv[0]))
                {
                    
                    return;
                }
                else
                {
                    SolutionEqualizationRec(coef, interv, acc);
                    return;
                }
            }
        }
        #endregion ByRecursion

        #region ByCicle
        static void SolutionEqualizationCicle(double[] coef, double[] interv, double acc,out bool success)
        {
            success = false;
            
            if (Function(coef, interv[0]) * Function(coef, interv[1]) <= 0)
            {
                success = true;
                //Все таки решил сделать одинарную точность
                while (acc < Math.Abs(interv[1] - interv[0]))
                {
                    double middle = (interv[0] + interv[1]) / 2;
                    if (Function(coef, interv[0]) * Function(coef, middle) < 0)
                    {
                        interv[1] = middle;
                    }
                    else
                    {
                        interv[0] = middle;
                    }
                }
            }
        }
        #endregion ByCicle

        static void Main(string[] args)
        {
            //Я в Модуле_3_Задании_8 Уже сделал решение ур. делением по полам рекурсией
            //т.к. когда я делал Модуль_3, задание к Модулю_4 я не читал,
            //так что, я сделал методы и через рекурсию (отшлифованный вариант) и через циклы

            Console.WriteLine("Решаем многочлен с 1 неизвестным \n" +
                "Введите кол-во коэффициентов (равное n) при неизвестных x^n + ... + x^0");

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
            double[] coef = new double[n];
            double el = 0;
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

            bool success;
            double[] temp = CopyArr(interval);
            SolutionEqualizationRec(coef, temp, acc, out success);
            if(success)
            {
                Console.WriteLine($"Искомые корни находятся на интервале: [{temp[0]:f4}, {temp[1]:f4}] " +
                    $"- найдено через рекурсию");
            }
            else
            {
                Console.WriteLine("На д. интервале нет корней - найдено через рекурсию");
            }

            temp = CopyArr(interval);
            SolutionEqualizationCicle(coef, temp, acc,out success);
            if (success)
            {
                Console.WriteLine($"Искомые корни находятся на интервале: [{temp[0]:f4}, {temp[1]:f4}] " +
                    $"- найдено через цикл");
            }
            else
            {
                Console.WriteLine("На д. интервале нет корней - найдено через цикл");
            }
        }
    }
}
