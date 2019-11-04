using System;
using System.Linq;

namespace Module_4_Task_8
{
    class Program
    {
        static double GetFunction(double[] coef, double arg)
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
        static private void SolutionEqualizationRec(double[] coef, double[] interv, double acc)
        {
            //Все таки решил сделать одинарную точность
            if (acc >= Math.Abs(interv[1] - interv[0]))
            {
                return;
            }
            else
            {
                double middle = (interv[0] + interv[1]) / 2;
                if (GetFunction(coef, interv[0]) * GetFunction(coef, middle) < 0)
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

        static private void SolutionEqualizationRec(double[] coef, double[] interv, double acc,out bool success)
        {
            success = false;
            //Я решил, что проверка правильности интервала должна быть первична
            if (GetFunction(coef, interv[0]) * GetFunction(coef, interv[1]) > 0)
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
        static private void SolutionEqualizationCicle(double[] coef, double[] interv, double acc,out bool success)
        {
            success = false;
            
            if (GetFunction(coef, interv[0]) * GetFunction(coef, interv[1]) <= 0)
            {
                success = true;
                //Все таки решил сделать одинарную точность
                while (acc < Math.Abs(interv[1] - interv[0]))
                {
                    double middle = (interv[0] + interv[1]) / 2;
                    if (GetFunction(coef, interv[0]) * GetFunction(coef, middle) < 0)
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

        private const int lowerLimit1 = 1;

        static private double ReadWithCheckDouble()
        {
            bool check = double.TryParse(Console.ReadLine(), out double el);
            while (!check)
            {
                Console.WriteLine("Некорректно, еще раз");
                check = double.TryParse(Console.ReadLine(), out el);
            }
            return el;
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
            //Я в Модуле_3_Задании_8 Уже сделал решение ур. делением по полам рекурсией
            //т.к. когда я делал Модуль_3, задание к Модулю_4 я не читал,
            //так что, я сделал методы и через рекурсию (отшлифованный вариант) и через циклы

            Console.WriteLine("Решаем многочлен с 1 неизвестным \n" +
                "Введите кол-во коэффициентов (равное n) при неизвестных x^n + ... + x^0");

            int arrSize = ReadWithCheckInt(lowerLimit1);
            double[] coef = new double[arrSize];
            for (int i = 0; i < arrSize; i++)
            {

                Console.WriteLine($"Вводите {i + 1} коэффициент, от старшей степени к нулевой");
                coef[i] = ReadWithCheckDouble();
            }

            double[] interval = new double[2];
            for (int i = 0; i < 2; i++)
            {

                Console.WriteLine($"Вводите {i + 1} из 2 значений интервала");
                interval[i] = ReadWithCheckDouble();
            }

            Console.WriteLine("Введите точность");
            double acc = ReadWithCheckDouble();

            double[] temp = CopyArr(interval);
            SolutionEqualizationRec(coef, temp, acc, out bool success);
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
