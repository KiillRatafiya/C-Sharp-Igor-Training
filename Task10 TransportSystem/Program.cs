namespace Task10_TransportSystem
{
    class Transport
    {
        public string Name { get; set; }
        public int Speed { get; set; }

        public Transport()
        {
            Name = "By default";
            Speed = 0;
        }
        public Transport(string name, int speed)
        {
            Name = name;
            Speed = speed;
        }

    }


    class Car : Transport, ITransportActions
    {
        public Car() : base()
        {

        }
        public Car(string name, int speed) : base(name, speed)
        {

        }
        public void Start()
        {
            Console.WriteLine("Car's started movement");
        }
        public void Stop()
        {
            Console.WriteLine("Car's stopped");
        }
    }
    class Train : Transport, ITransportActions
    {
        public Train() : base()
        {

        }
        public Train(string name, int speed) : base(name, speed)
        {

        }
        public void Start()
        {
            Console.WriteLine("Train's started movement");
        }
        public void Stop()
        {
            Console.WriteLine("Train's stopped");
        }
    }

    class Plane : Transport, ITransportActions
    {
        public Plane() : base()
        {

        }
        public Plane(string name, int speed) : base(name, speed)
        {

        }
        public void Start()
        {
            Console.WriteLine("Plane's started movement");
        }
        public void Stop()
        {
            Console.WriteLine("Plane's landed");
        }
    }

    interface ITransportActions
    {
        public void Start();

        public void Stop();

    }


    class Program
    {
        static void Main()
        {

            ITransportActions[] details = { new Car("Ford", 180), new Train("Shtadler", 120), new Plane("Airbus", 350) };
            foreach (var i in details)
            {
                Transport t = (Transport)i;
                Console.WriteLine($"Transport: {t.Name}, speed: {t.Speed}");
                i.Start();
                i.Stop();
                Console.WriteLine();
            }
        }
    }
}
