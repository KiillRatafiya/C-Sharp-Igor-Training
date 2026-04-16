namespace OOP_task
{
    internal class Program
    {
        static void Main()
        {
            Person person = new Person();
            Console.WriteLine("Enter age");
            person.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Name");
            person.Name = Console.ReadLine();

            person.Introduce();
        }
    }
}
