using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_task
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int year;

        public string GetInfo()
        {
            return $"Brand: {Brand} Model: {Model} Year: {year}";
        }
    }
}
