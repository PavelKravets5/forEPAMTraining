using System;
using System.Collections.Generic;
using System.Text;

namespace Module_5
{
    class Position
    {
        public int _x { get; set; } = 0;
        public int _y { get; set; } = 0;

        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public static bool operator ==(Position position1,Position position2)
        {
            return (position1._x == position2._x && position1._y == position2._y) ? true : false;

        }

        public static bool operator !=(Position position1, Position position2)
        {
            return (position1._x == position2._x && position1._y == position2._y) ? false : true;

        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            Position position = (Position)obj;
            return (this._x == position._x && this._y==position._y);
        }

        public override int GetHashCode()
        {
            return _x.GetHashCode() + _y.GetHashCode();
        }
    }
}
