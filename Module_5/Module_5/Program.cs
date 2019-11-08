using System;

namespace Module_5
{
    class Program
    {
        static void Main(string[] args)
        {
            bool newGame = true;
            while(newGame)
            {
                Console.WriteLine("Чтобы начать с верхнего левого угла поля, введите 1,\n" +
                    "Чтобы начать с верхнего правого угла поля, введите 2,\n" +
                    "Чтобы начать с нижнего левого угла поля, введите 3,\n" +
                    "Чтобы начать с нижнего правого угла поля, введите 4,\n");
                int startPosNumber=0;
                //ServiceClass.Notification += ServiceClass.DisplayMessage;
                while (!ServiceClass.ReadWithCheck(Console.ReadLine(), ServiceClass.LIMIT_1,
                    ServiceClass.LIMIT_4, out startPosNumber))
                {
                    Console.WriteLine("Некорректно, еще раз");
                }

                Console.WriteLine("Введите длинну строны игрового поля, оно квадратное (>=2):");
                int fieldSize = 0;
                while(!ServiceClass.ReadWithCheck(Console.ReadLine(), ServiceClass.LIMIT_2,
                    out fieldSize))
                {
                    Console.WriteLine("Некорректно, еще раз");
                }

                int maxTrapsNumber = (int)Math.Pow(fieldSize, 2) - 2;

                Console.WriteLine($"Введите колличество ловушек, в пределах " +
                    $"от {ServiceClass.LIMIT_0} до ({maxTrapsNumber}):");

                int trapsNumber = 0;
                while(!ServiceClass.ReadWithCheck(Console.ReadLine(), ServiceClass.LIMIT_0,
                    maxTrapsNumber, out trapsNumber))
                {
                    Console.WriteLine("Некорректно, еще раз");
                }

                Game game = new Game(startPosNumber,fieldSize,trapsNumber);
                game.Notification += ServiceClass.DisplayMessage;

                do
                {
                    Console.Clear();
                    game.ConsolePrintField();
                    Console.WriteLine("Ходите. Ожидание ввода клавиши WASD или стрелки:");
                    while (!game.Move(Console.ReadKey()))
                    {
                        Console.WriteLine("\nНекорректно, еще раз");
                    }
                } while (!game.IsGameOver());


                Console.WriteLine("Еще партию?");
                newGame = ServiceClass.ReadYOrN() == "y" ? true : false;
            }
        }
    }
}
