using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class L : BaseWord
    {
        public L()
        {
            Console.WriteLine("构造L");
        }

        public override string Get()
        {
            return "L";
        }
    }
}
