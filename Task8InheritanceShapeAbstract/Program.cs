namespace Task8InheritanceShapeAbstract
{
    abstract class Shape
    {
        protected double area;
        public abstract double GetArea();
        
    }
    class Rectangle : Shape
    {
        public override double GetArea()
        {
            Console.WriteLine("Your choice is Rectangle!");
            Console.WriteLine("Please define a width");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("Please define a height");
            double height = double.Parse(Console.ReadLine());
            return area = width * height;
        }
    }
    class Circle : Shape
    {
        public override double GetArea()
        {
            Console.WriteLine("Your choice is Circle!");
            Console.WriteLine("Please define a radius");
            double radius = double.Parse(Console.ReadLine());
            return area = 3.14 * radius * radius;
        }

    }


    class Program
    {
        static void Main()
        {
            Rectangle rectangle = new Rectangle();
            Circle circle = new Circle();


            while (true)
            {
                Console.WriteLine("Choose a figure: press '1' if Rectangle or press '2' if Circle");
                int number = int.Parse(Console.ReadLine());

                if (number != 1 && number != 2)
                {
                    Console.WriteLine("Wrong number");
                    continue;
                }

                else if (number == 1)
                {
                    double rectangleArea = rectangle.GetArea();
                    Console.WriteLine($"The area of your shape is {rectangleArea}");
                }
                else if (number == 2)
                {
                    double circleArea = circle.GetArea();
                    Console.WriteLine($"The area of your shape is {circleArea}");
                }
                break;
            }
        }
    }
}
