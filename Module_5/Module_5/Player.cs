using System;
using System.Collections.Generic;
using System.Text;

namespace Module_5
{
    class Player
    {
        public Position _position { get; set; } = null;
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
                        _position = new Position(0, 0);
                    }
                    break;
                case 2:
                    {
                        _position = new Position(0, fieldSize-1);
                    }
                    break;
                case 3:
                    {
                        _position = new Position(fieldSize - 1, 0);
                    }
                    break;
                case 4:
                    {
                        _position = new Position(fieldSize - 1, fieldSize - 1);
                    }
                    break;
            }
        }
    }
}
