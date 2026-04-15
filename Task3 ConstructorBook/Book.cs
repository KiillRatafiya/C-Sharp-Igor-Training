using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3ConstructorBook
{
    class Book
    {
        string Title { get; set; }
        string Author { get; set; }
        int Pages { get; set; }
        
        public Book()
        {
            Title = "Default - empty title";
            Author = "Default - empty author";
            Pages = 0;
        }
        
        public Book(string title, string author, int pages )
        {
            Title=title;
            Author=author;
            Pages=pages;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Book details: Title: {Title}, Author: {Author}, Pages: {Pages}");
        }
    }
}
