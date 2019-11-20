using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    class ServiceClass
    {
        static public int ReadIntWithCheck(int[] optionArr)
        {
            int optionNum = 0;
            bool temp = false;
            while (temp == false)
            {
                temp = int.TryParse(Console.ReadLine(), out optionNum);
                if (temp == false || Array.IndexOf(optionArr, optionNum) ==-1)
                {
                    temp = false;
                    Console.WriteLine("Некоррекный ввод. Повторите");
                }
            }
            return optionNum;
        }

        static public string CircleRadiusByArea(double area)
        {
            return $"Радиус круга через вычисленную площадь = {Math.Sqrt(area / Math.PI):#.##}";
        }

        static public string CircleRadiusByPerimeter(double perim)
        {
            return $"Радиус круга через вычисленный периметр = {perim / Math.PI/2:#.##}";
        }

        static public string SquareSideByArea(double area)
        {
            return $"Длинна стороны квадрата через вычисленную площадь = {Math.Sqrt(area):#.##}";
        }

        static public string SquareSideByPerimeter(double perim)
        {
            return $"Длинна стороны квадрата через вычисленный периметр = {perim / 4:#.##}";
        }

        static public string RhombSideByAreaAndPerim(double area, double perim)
        {
            double corner = area / Math.Pow(perim / 4, 2);
            if (corner > -1 && corner < 1)
            {
                return $"Длинна стороны ромба через вычисленную площадь и периметр = {perim / 4:#.##}, острый угол ромба: {Math.Asin(corner):#.##}";
            }
            else
            {
                return $"Ромб с данными периметром и площадью не существует";
            }
        }

        static public string IsoscelesWith90TriangleSides(double area)
        {
            double side = Math.Sqrt(area * 2);
            return $"Катет равнобедренного прямоугольного треугольника (углы: 90, 45, 45) через вычисленную площадь = {side:#.##}, гипотенуза = {Math.Sqrt(2*Math.Pow(side,2)):#.##}";
        }

        static public string EquilateralTriangleSides(double area)
        {
            return $"Длинна стороны равностороннего треугольника через вычисленную площадь = {Math.Sqrt(area * 4 / Math.Sqrt(3)):#.##}";
        }
    }
}
