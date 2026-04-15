using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_Inheritance_Animal
{
    class Animal
    {
        string Name { get; set; }
        public virtual void MakeSound()
        {
            Console.WriteLine("This animal produces sound");
           
        }
    }

    class Dog : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("It's dog, it's barking");
        }
    }
    class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("It's cat, it's meawing");
        }

    }
}
