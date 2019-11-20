using System;

namespace Task_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1, чтобы обсчитывать четырехугольник;");
            Console.WriteLine("Введите 2, чтобы обсчитывать круг;");
            Console.WriteLine("Введите 3, чтобы обсчитывать треугольник;");

            int optionNum=ServiceClass.ReadIntWithCheck(new int[3] { 1,2,3});

            Figure figure = null;

            switch(optionNum)
            {
                case 1:
                    {
                        Console.WriteLine("Введите длинны сторон четырехугольника: 4 числа");
                        figure = new Quadrangle(Console.ReadLine());
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Введите радиус круга: 1 число");
                        figure = new Circle(Console.ReadLine());
                    }
                    break;
                case 3:
                    {
                        Console.WriteLine("Введите размерности треугольника: три числа через пробел");
                        figure = new Triangle(Console.ReadLine());
                    }
                    break;
            }
            Console.WriteLine("Введите 1, чтобы найти площадь;");
            Console.WriteLine("Введите 2, чтобы найти периметр;");

            optionNum = ServiceClass.ReadIntWithCheck(new int[2] { 1, 2 });

            switch (optionNum)
            {
                case 1:
                    {
                        Console.WriteLine($"Результат вычисления площади фигуры " +
                            $"{figure.GetMessage_FigureName()} = {figure.GetArea():#.##}");
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine($"Результат вычисления периметра фигуры " +
                            $"{figure.GetMessage_FigureName()} = {figure.GetPerimeter():#.##}");
                    }
                    break;
            }

            Console.WriteLine("Другие фигуры могли бы быть на основании полученных данных:");
            string[]otherFigure = figure.GetAnotherFigure();
            foreach(string s in otherFigure)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Завершено");
            Console.ReadKey();

        }
    }
}
