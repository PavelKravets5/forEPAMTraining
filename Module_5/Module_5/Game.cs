using System;
using System.Collections.Generic;
using System.Text;

namespace Module_5
{
    class Game
    {
        // Версия с классом Player
        private const int MIN_NUMBERS_OF_POSSIBILITIES = 2;

        public delegate void GameHandler(string message);
        public event GameHandler Notification =null;

        private int _trapsNumber = 0;
        private PositionOnThePlane _finishPosition = null;

        private int[,] _field = null;
        private int _fieldSize =0;
        private Player _player = null;
        
        public Game(int starPosNumber, int fieldSize, int trapsNumber)
        {
            _fieldSize = fieldSize;
            _trapsNumber = trapsNumber;
            int count = 0;
            Random rnd = new Random();
            _field = new int[_fieldSize, _fieldSize];
            _player = new Player(starPosNumber,_fieldSize);
            _finishPosition = new PositionOnThePlane(fieldSize-1-_player.Position.X, fieldSize-1-_player.Position.Y);

            for(int i=0;i<fieldSize;i++)
            {
                for(int j=0;j<fieldSize;j++)
                {
                    PositionOnThePlane temp = new PositionOnThePlane(i, j);
                    if (count < _trapsNumber && _player.Position != temp & _finishPosition != temp)
                    {
                        _field[i, j] = rnd.Next(0, 11);
                        if (_field[i, j] > 0)
                        {
                            count++;
                        }
                    }
                    else
                    {
                        _field[i, j] = 0;
                    }
                }
            }
        }

        public void ConsolePrintField()
        {         
            Notification?.Invoke($"Цель: достич позиции отмеченной как \"fin\", " +
                $"игрок на позиции отмеченной как \"you\", поля, где Вы уже побывали " +
                $"будут помечены как \"sfl\" (от \"safely\"), " +
                $"на стартовой и финишной клетках - безопастно\n" +
               $"Осталось {_trapsNumber} рабочих ловушек.\n");

            Notification?.Invoke("\n");
            if (_field[_player.Position.X, _player.Position.Y] > 0)
            {
                Notification?.Invoke($"Произошел взрыв с силой: " +
                    $"{_field[_player.Position.X, _player.Position.Y]}\n");
                _field[_player.Position.X, _player.Position.Y] = -1;
            }
            Notification?.Invoke($"Колл-во жизней: {_player.Lifes}\n");

            for (int i=0;i<_fieldSize;i++)
            {
                for (int j = 0; j < _fieldSize; j++)
                {

                    if (i == _player.Position.X && j == _player.Position.Y)
                    {
                        Notification?.Invoke("you ");
                        _field[i, j] = -1;
                    }
                    else
                    {
                        if (i == _finishPosition.X && j == _finishPosition.Y)
                        {
                            Notification?.Invoke("fin ");
                        }
                        else
                        {
                            if (_field[i, j] == -1)
                            {
                                Notification?.Invoke("sfl ");
                            }
                            else
                            {
                                Notification?.Invoke("___ ");
                            }
                        }
                    }
                }
                Notification?.Invoke("\n");
            }
            Notification?.Invoke("\n");
        }

        public bool Move(ConsoleKeyInfo consoleKeyInfo)
        {
            bool success = false;
            switch(consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        if(_player.Position.X > 0)
                        {
                            success = true;
                            _player.Position.X -= 1;
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    {
                        if (_player.Position.X < _fieldSize-1)
                        {
                            success = true;
                            _player.Position.X += 1;
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    {
                        if (_player.Position.Y > 0)
                        {
                            success = true;
                            _player.Position.Y -= 1;
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    {
                        if (_player.Position.Y < _fieldSize-1)
                        {
                            success = true;
                            _player.Position.Y += 1;
                        }
                    }
                    break;
                case ConsoleKey.W:
                    {
                        goto case ConsoleKey.UpArrow;
                    }
                case ConsoleKey.S:
                    {
                        goto case ConsoleKey.DownArrow;
                    }
                case ConsoleKey.A:
                    {
                        goto case ConsoleKey.LeftArrow;
                    }
                case ConsoleKey.D:
                    {
                        goto case ConsoleKey.RightArrow;
                    }
            }
            if(_field[_player.Position.X, _player.Position.Y] >0)
            {
                _player.Lifes -= _field[_player.Position.X, _player.Position.Y];
                _trapsNumber--;
            }
            return success;
        }

        public bool IsGameOver()
        {
            if (_player.Lifes > 0 && _player.Position != _finishPosition)
            {
                return false;
            }
            else
            {
                ConsolePrintField();
                if (_player.Lifes <= 0)
                {
                    Notification?.Invoke("\nВы проиграли\n");
                }
                else
                {
                    Notification?.Invoke("\nВЫ ВЫИГРАЛИ!!!\n");                    
                }
                return true;
            }

        }


    }
}
