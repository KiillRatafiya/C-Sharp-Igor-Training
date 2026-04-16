using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_task
{
    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public void Introduce()
        {
            Console.WriteLine($"Hi, my name is {Name}, I'm {Age} years old");
        }
    }
}
