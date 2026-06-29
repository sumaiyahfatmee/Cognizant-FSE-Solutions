using System;

namespace InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();

            while (true)
            {
                Console.WriteLine("\n===== Inventory Management System =====");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. Display Products");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Console.Write("Enter Product ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Product Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Quantity: ");
                        int quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter Price: ");
                        double price = Convert.ToDouble(Console.ReadLine());

                        Product product = new Product(id, name, quantity, price);

                        inventory.AddProduct(product);

                        break;

                    case 2:

                        Console.Write("Enter Product ID: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Quantity: ");
                        quantity = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Enter New Price: ");
                        price = Convert.ToDouble(Console.ReadLine());

                        inventory.UpdateProduct(id, quantity, price);

                        break;

                    case 3:

                        Console.Write("Enter Product ID: ");
                        id = Convert.ToInt32(Console.ReadLine());

                        inventory.DeleteProduct(id);

                        break;

                    case 4:

                        inventory.DisplayProducts();

                        break;

                    case 5:

                        Console.WriteLine("Thank You!");
                        return;

                    default:

                        Console.WriteLine("Invalid Choice");

                        break;
                }
            }
        }
    }
}
