using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_CSharpConstructorCallOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            new Extended(30);
            Console.ReadKey();
        }
    }

    public class Base
    {
        private int a;

        protected Base()
        {
            a = 20;
            tostr(); // C# call extended class method, C++ call base class method
        }

        public virtual void tostr()
        {
            Console.WriteLine("Base class a: " + a);
        }
    }

    public class Extended : Base
    {
        private int a;

        public Extended(int _a)
        {
            a = _a;
            tostr();
        }

        public override void tostr()
        {
            Console.WriteLine("Extended class a: " + a);
        }
    }
}
