using System;
using System.Collections.Generic;
using System.Text;

namespace Module_5
{
    class Player
    {
        // В соответствии со статьей на хабре, имя открытой переменной - в Pascal casing,
        // тогда оно совпадает с именем класса, и я его (имя класса) на всякий случай поменял на
        // PositionOnThePlane. 
        // Надеюсь, что не ошибаюсь.
        public PositionOnThePlane Position { get; set; } = null;
        private int _lifes = 10;
        
        public int Lifes
        {
            get
            {
                return _lifes;
            }
            set
            {
                if(value>=0)
                {
                    _lifes =value;
                }
                else
                {
                    _lifes = 0;
                }
            }
        }

        public Player(int starPosNumber,int fieldSize)
        {
            switch (starPosNumber)
            {
                case 1:
                    {
                        Position = new PositionOnThePlane(0, 0);
                    }
                    break;
                case 2:
                    {
                        Position = new PositionOnThePlane(0, fieldSize-1);
                    }
                    break;
                case 3:
                    {
                        Position = new PositionOnThePlane(fieldSize - 1, 0);
                    }
                    break;
                case 4:
                    {
                        Position = new PositionOnThePlane(fieldSize - 1, fieldSize - 1);
                    }
                    break;
            }
        }
    }
}
