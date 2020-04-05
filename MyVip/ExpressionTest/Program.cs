using System;

namespace ExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<int, int, int> fuc = (x, xx) => x * xx + 3;
          
            Console.WriteLine("Hello World!");
        }
    }
}
