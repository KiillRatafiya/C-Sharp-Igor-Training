namespace Task9_InterfacesIFlyableISwimmable
{
    interface IFlyable
    {
        public void Fly();
    }

    interface ISwimmable
    {
        public void Swim();
    }

    class Duck : IFlyable, ISwimmable
    {
        public void Fly()
        {
            Console.WriteLine("I'm Duck, I can fly");
        }
        public void Swim()
        {
            Console.WriteLine("I'm Duck, I can swim");
        }
    }
    class Fish : ISwimmable
    {
        public void  Swim()
        {
            Console.WriteLine("I'm Fish, I can only swim");
        }
    }
    class Bird : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("I'm Bird, I can fly");
        }
    }

    class Program
    {
        static void Main()
        {
            Duck duck = new Duck();
            IFlyable flyer = duck;
            ISwimmable swimmer = duck;
            duck.Swim();
            duck.Fly();

            IFlyable bird = new Bird();
            bird.Fly();

            ISwimmable fish = new Fish();
            fish.Swim();
        }
    }
}