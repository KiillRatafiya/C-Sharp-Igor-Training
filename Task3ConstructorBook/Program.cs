namespace Task3ConstructorBook
{
    class Program
    {
        static void Main()
        {
            Book defaultBook = new Book();       
            Book book = new Book("Crime and Punishment", "Dostoevsky", 258);
            defaultBook.PrintInfo();
            book.PrintInfo();
        }
    }
}
