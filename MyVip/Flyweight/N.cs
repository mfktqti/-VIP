using System;
using System.Collections.Generic;
using System.Text;

namespace Flyweight
{
    public class N : BaseWord
    {
        public N()
        {

            Console.WriteLine("构造N");
        }

        public override string Get()
        {
            return "N";
        }
    }
}
