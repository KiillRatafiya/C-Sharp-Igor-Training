namespace Task5_InheritanceEmployee
{
    internal class Program
    {
        static void Main()
        {
            Employee employee = new Employee();
            employee.Work();
            Employee manager = new Manager();
            manager.Work();
            Employee developer = new Developer();
            developer.Work();
        }
    }
}
