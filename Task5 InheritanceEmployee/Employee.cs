using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5_InheritanceEmployee
{
    class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public virtual void Work()
        {
            Console.WriteLine("Employee works");
        }
    }
    class Manager : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Manager - manages team");
        }
    }

    class Developer : Employee
    {
        public override void Work()
        {
            Console.WriteLine("Developer - writing code");
        }
    }
}
