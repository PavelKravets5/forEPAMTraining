using System;
using System.Collections.Generic;
using System.Text;

namespace Module_4_Task_7
{
    class MyComparer : IComparer<double>
    {
        public int Compare(double a, double b)
        {
            if (a > b)
            {
                return 1;
            }
            else
            {
                if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
