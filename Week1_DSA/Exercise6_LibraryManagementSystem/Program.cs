using System;

namespace Exercise6_LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Book[] books =
            {
                new Book(101,"C Programming","Dennis Ritchie"),
                new Book(102,"Data Structures","Seymour Lipschutz"),
                new Book(103,"Java Programming","Herbert Schildt"),
                new Book(104,"Operating Systems","Galvin"),
                new Book(105,"Python Basics","Guido van Rossum")
            };

            Console.Write("Enter Book Title: ");
            string title = Console.ReadLine();

            Book linearResult = SearchLibrary.LinearSearch(books, title);

            Console.WriteLine("\n----- Linear Search -----");

            if (linearResult != null)
            {
                Console.WriteLine($"Book ID : {linearResult.BookId}");
                Console.WriteLine($"Title   : {linearResult.Title}");
                Console.WriteLine($"Author  : {linearResult.Author}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            Array.Sort(books, (b1, b2) =>
                string.Compare(b1.Title, b2.Title, StringComparison.OrdinalIgnoreCase));

            Book binaryResult = SearchLibrary.BinarySearch(books, title);

            Console.WriteLine("\n----- Binary Search -----");

            if (binaryResult != null)
            {
                Console.WriteLine($"Book ID : {binaryResult.BookId}");
                Console.WriteLine($"Title   : {binaryResult.Title}");
                Console.WriteLine($"Author  : {binaryResult.Author}");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
