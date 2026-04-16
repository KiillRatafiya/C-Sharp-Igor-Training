namespace Task7_InterfaceIMovable
{
    interface IMovable
    {
        void Move();
    }

    class Car : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Car is driving");
        }
    }
    class Bicycle : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Bicycle is riding");
        }

    }
    class Person : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Person is going");
        }
    }

    class Program
    {
        static void Main()
        {
            IMovable[] movable = {new Car(), new Bicycle(), new Person()};
            foreach (var i in movable)
            {
                i.Move();
            }
        }
    }
}
