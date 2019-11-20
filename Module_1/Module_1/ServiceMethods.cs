using System;
using System.Collections.Generic;
using System.Text;

namespace Module1
{
    class ServiceMethods
    {
        static public void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
