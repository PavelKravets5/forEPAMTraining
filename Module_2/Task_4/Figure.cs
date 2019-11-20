using System;
using System.Collections.Generic;
using System.Text;

namespace Task_4
{
    abstract class Figure
    {
        protected double[] _parameters = null;

        public Figure(string parametersString)
        {
            string[] parametersArr= parametersString.Split(' ');
            int length = parametersArr.Length;
            _parameters = new double[length];
            bool result = false;
            for (int i = 0; i < length; i++)
            {
                result = double.TryParse(parametersArr[i], out _parameters[i]);
               
                if (result == false)
                {
                    throw new ArgumentException("Некорректный ввод данных");
                }
            }
        }
        abstract public double GetArea();
        abstract public double GetPerimeter();
        abstract public string GetMessage_FigureName();
        abstract public string[] GetAnotherFigure();
    }
}
