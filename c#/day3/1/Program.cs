using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    class Animal
    {
        public virtual void sound()
        {
            Console.WriteLine("동물이 소리를 낸다.");
        }

    }
    class Dog : Animal
    {
        public override void sound()
        {
            Console.WriteLine("멍멍멍멍멍");
        }
    }
    class Cat : Animal
    {
        public override void sound()
        {
            Console.WriteLine("야옹");
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Animal animal = new Animal();
            Animal dog = new Dog();
            Animal cat = new Cat();
            animal.sound();
            dog.sound();
            cat.sound();
        }
    }
}