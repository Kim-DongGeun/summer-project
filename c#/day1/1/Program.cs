using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static void print(string A)
        {
            Console.WriteLine("hello, world! I'm " + A);
        }
        static void Main(string[] args)
        {
            string A;
            A = Console.ReadLine();
            print(A);
            
        }
    }
}
