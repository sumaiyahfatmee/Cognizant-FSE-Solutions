
using System;

namespace Exercise2_ECommerceSearchFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(101, "Headphones", "Electronics"),
                new Product(102, "Keyboard", "Accessories"),
                new Product(103, "Laptop", "Electronics"),
                new Product(104, "Mouse", "Accessories"),
                new Product(105, "Smartphone", "Electronics")
            };

            Console.Write("Enter Product Name to Search: ");
            string searchName = Console.ReadLine();

            // Linear Search
            Product linearResult = SearchFunctions.LinearSearch(products, searchName);

            Console.WriteLine("\n----- Linear Search -----");

            if (linearResult != null)
            {
                Console.WriteLine($"Product ID   : {linearResult.ProductId}");
                Console.WriteLine($"Product Name : {linearResult.ProductName}");
                Console.WriteLine($"Category     : {linearResult.Category}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            // Sort array before Binary Search
            Array.Sort(products, (p1, p2) =>
                string.Compare(p1.ProductName, p2.ProductName, StringComparison.OrdinalIgnoreCase));

            // Binary Search
            Product binaryResult = SearchFunctions.BinarySearch(products, searchName);

            Console.WriteLine("\n----- Binary Search -----");

            if (binaryResult != null)
            {
                Console.WriteLine($"Product ID   : {binaryResult.ProductId}");
                Console.WriteLine($"Product Name : {binaryResult.ProductName}");
                Console.WriteLine($"Category     : {binaryResult.Category}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}