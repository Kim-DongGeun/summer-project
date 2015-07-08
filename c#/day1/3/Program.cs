using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Program
    {
        class dog
        {
            public void sound()
            {
                Console.WriteLine("멍멍멍멍멍멍멍멍멍멍~~~~~");
            }
        }
        class cat
        {
            public void sound()
            {
                Console.WriteLine("야옹~~~");
            }
        }
        static void Main(string[] args)
        {
            dog Dog = new dog();
            cat Cat = new cat();
            string A = Console.ReadLine();
            if (A == "dog")
            {
                Dog.sound();
            }
            else if (A == "cat")
            {
                Cat.sound();
            }
        }
    }
}
