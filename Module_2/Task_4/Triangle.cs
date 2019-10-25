using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    class Triangle : Figure
    {

        public Triangle(string parametersString) : base(parametersString)
        {
            if (base._parameters.Length < 3)
            {
                throw new Exception("Недостаточно параметров");
            }
        }

        public override string GetMessage_FigureName()
        {
            return "треугольник";
        }

        public override double GetPerimeter()
        {
            double perimeter = 0;
            for(int i=0;i<3;i++)
            {
                perimeter += base._parameters[i];
            }
            return perimeter;
        }

        public override double GetArea()
        {
            double halfPerim = GetPerimeter()/2;
            return Math.Sqrt(halfPerim * (halfPerim - base._parameters[0]) * (halfPerim - base._parameters[1]) 
                * (halfPerim - base._parameters[2]));
        }

        public override string[] GetAnotherFigure()
        {
            double area = GetArea();
            double perim = GetPerimeter();
            string[] otherFigureParams = new string[5];
            otherFigureParams[0] = ServiceClass.CircleRadiusByArea(area);
            otherFigureParams[1] = ServiceClass.CircleRadiusByPerimeter(perim);
            otherFigureParams[2] = ServiceClass.SquareSideByArea(area);
            otherFigureParams[3] = ServiceClass.SquareSideByPerimeter(perim);
            otherFigureParams[4] = ServiceClass.RhombSideByAreaAndPerim(area, perim);
            return otherFigureParams;
        }
    }
}
