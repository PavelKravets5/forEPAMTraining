using System;
using System.Collections.Generic;
using System.Text;

namespace Module_5
{
        // Это класс я удалять не стал, потому что тема - классы,
        // хотя весь функционал из него переехал в класс Game, и то что осталось можно было бы
        // также перенести туда.
    class Player
    {
        // В соответствии со статьей на хабре, имя открытой переменной - в Pascal casing,
        // тогда оно совпадает с именем класса, и я его (имя класса) на всякий случай поменял на
        // PositionOnThePlane. 
        // Надеюсь, что не ошибаюсь.
        // В той же статье сказано "не используйте публичных или защищенных полей, 
        // вместо этого используйте свойства; используйте автоматические свойства;"
        // поэтому я использую пример с metanit.
        public PositionOnThePlane Position { get; set; } = null;
        public int Lifes { get; set; } = 10;
        
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
