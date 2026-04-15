namespace Task4_Inheritance_Animal
{
    class Program
    {
        static void Main()
        {
            Animal dog = new Dog();
            dog.MakeSound();

            Animal cat = new Cat();
            cat.MakeSound();
        }
    }
}
