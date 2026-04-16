namespace Task6_InterfacePrintable
{
    interface IPrintable
    {
        void Print();
    }
    class Book : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Print book");
        }
    }

    class Document : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Print document");
        }
    }

    class Photo : IPrintable
    {
        public void Print()
        {
            Console.WriteLine("Print photo");
        }
    }

    class Program
    {
        static void Main()
        {
            //Calling method for each object
            Book book = new Book();
            book.Print();

            Document document = new Document();
            document.Print();

            Photo photo = new Photo();
            photo.Print();

            //Calling method for each object via loop
            IPrintable[] items = { new Book(), new Document(), new Photo()};
            foreach(var i in items)
            {
                i.Print();                
            }   
        }
    }
}
