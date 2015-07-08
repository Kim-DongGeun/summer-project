using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        class MyClass
        {
            public MyClass()
            {
                Console.WriteLine("Hello world");
            }
            public MyClass(string name)
            {
                Console.WriteLine("Hello " + name);
            }
        }
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            MyClass x = new MyClass(name);
            MyClass x1 = new MyClass();
        }
    }
}