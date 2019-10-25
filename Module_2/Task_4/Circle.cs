using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    class Circle : Figure
    {
        public Circle(string parametersString):base(parametersString)
        {
            if (base._parameters.Length < 1)
            {
                throw new Exception("Недостаточно параметров");
            }
        }
        public override string GetMessage_FigureName()
        {
            return "круг";
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * base._parameters[0];
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(base._parameters[0], 2);
        }

        public override string[] GetAnotherFigure()
        {
            double area = GetArea();
            double perim = GetPerimeter();
            string[] otherFigureParams = new string[5];
            otherFigureParams[0] = ServiceClass.SquareSideByArea(area);
            otherFigureParams[1] = ServiceClass.SquareSideByPerimeter(perim);
            otherFigureParams[2] = ServiceClass.RhombSideByAreaAndPerim(area,perim);
            otherFigureParams[3] = ServiceClass.IsoscelesWith90TriangleSides(area);
            otherFigureParams[4] = ServiceClass.EquilateralTriangleSides(area);
            return otherFigureParams;
        }
    }
}
