using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class E : BaseWord
    {
        public E()
        {
            Console.WriteLine("构造E");
        }
        public override string Get()
        {
            return "E";
        }
    }
}
