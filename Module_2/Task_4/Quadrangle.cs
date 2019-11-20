using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    class Quadrangle : Figure
    {
        public Quadrangle(string parametersString):base(parametersString)
        {
            if(base._parameters.Length<4)
            {
                throw new Exception("Недостаточно параметров");
            }
        }

        public override string GetMessage_FigureName()
        {
            return "четырехугольник";
        }

        public override double GetPerimeter()
        {
            double perimeter=0;
            for(int i=0; i<4; i++)
            {
                perimeter += base._parameters[i];
            }
            return perimeter;
        }

        public override double GetArea()
        {
            double halfPerim = GetPerimeter() / 2;
            return Math.Sqrt((halfPerim - base._parameters[0]) * (halfPerim - base._parameters[1])
                * (halfPerim - base._parameters[2]) * (halfPerim - base._parameters[3]));
        }

        public override string[] GetAnotherFigure()
        {
            double area = GetArea();
            double perim = GetPerimeter();
            string[] otherFigureParams = new string[4];
            otherFigureParams[0] = ServiceClass.CircleRadiusByArea(area);
            otherFigureParams[1] = ServiceClass.CircleRadiusByPerimeter(perim);
            otherFigureParams[2] = ServiceClass.IsoscelesWith90TriangleSides(area);
            otherFigureParams[3] = ServiceClass.EquilateralTriangleSides(area);
            return otherFigureParams;
        }
    }
}
