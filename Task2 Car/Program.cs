using OOP_task;

namespace Task2_Car
{
    internal class Program
    {
        static void Main()
        {
            Car car = new Car();
            car.Brand = "Opel";
            car.Model = "Astra";
            car.year = 2010;
            Console.WriteLine(car.GetInfo());

            Car anotherCar = new Car();
            anotherCar.Brand = "Audi";
            anotherCar.Model = "A6";
            anotherCar.year = 2020;
            Console.WriteLine(anotherCar.GetInfo());
        }
    }
}
