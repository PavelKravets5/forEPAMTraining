using System;
using System.Globalization;


namespace Module_3_Task_4
{
    class Program
    {
        static double ReversePartByCicle(double num)
        {
            //Метод работае, но иногда при умножении на 10 накапливается погрешность, хотя кажется я все такие
            //варианты выловил и исправил/убрал
            //так что я не стал его стирать
            double reverseNum = 0;

            if (num != 0)
            {
                bool sign = true;
                if (num < 0)
                {
                    sign = false;
                    num = Math.Abs(num);
                }

                int fracPart = 0;

                
                while (Math.Floor(num*Math.Pow(10,fracPart)) != num*Math.Pow(10, fracPart))
                {
                    fracPart++;
                }

                int intPart = 0;
                double temp = 0;
                num*= Math.Pow(10, fracPart);
                while (num > 0)
                {
                    temp = Math.Floor(num / 10);
                    reverseNum += num - temp * 10;
                    reverseNum *= 10;
                    num = temp;
                    intPart++;
                }

                reverseNum /= Math.Pow(10, (fracPart == 0) ? 1 : intPart - fracPart + 1);

                if (sign == false)
                {
                    reverseNum = 0-reverseNum;
                }
            }
            return reverseNum;
        }

        static double ReverseNumByArrAndString(double num)
        {
            bool sign = true;
            if(num<0)
            {
                sign = false;
                num = Math.Abs(num);
            }

            string str = num.ToString();
            char[] mystr = str.ToCharArray();
            str = null;

            for (int i = mystr.Length-1; i >= 0; i--)
            {
                str += mystr[i];
            }

            if (sign==false)
            {
                str = "-" + str;
            }
            return double.Parse(str);
        }

        static void Main(string[] args)
        {
            double num;
            bool check = false;
            Console.WriteLine("Вводите число");
            do
            {
                string str = Console.ReadLine();
                check = double.TryParse(str, NumberStyles.Float, new CultureInfo("en-US"), out num);
                if(!check)
                {
                    check = double.TryParse(str, NumberStyles.Float, new CultureInfo("ru-RU"), out num);
                    if (!check)
                    {
                        Console.WriteLine("Некорректно, еще раз");
                    }
                }
            } while (!check);

            Console.WriteLine($"Введено число {num}");

            

            Console.WriteLine($"Результат с помощью циклов (метод1): {ReversePartByCicle(num)} " +
                $"\nРезультат с помощью цикла, строк и массива символов (метод2): {ReverseNumByArrAndString(num)}" +
                $"\nЗавершено");


           //Можно было просто инвертровать строку с пом. Reverse(),
           //но я сделал вывод, что нужны непременно использовать строки и/или массивы.
            //Также можно было бы использовть метод Split() на строке, получить массив символов, и инвертировать его
            //с помощью метода Reverse, и превратить в строку с помощью Join
        }
    }
}
