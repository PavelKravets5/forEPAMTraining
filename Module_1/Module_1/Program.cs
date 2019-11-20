using System;

namespace Module1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            Console.WriteLine($"Before Swap(a,b): a = {a}, b= {b}");
            ServiceMethods.Swap(ref a, ref b);

            Console.WriteLine($"After Swap(a,b): a = {a}, b= {b}");
        }

    }
}
