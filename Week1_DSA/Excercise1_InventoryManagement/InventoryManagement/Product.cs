using System;

namespace InventoryManagement
{
    public class Product
    {
        // Properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        // Constructor
        public Product(int productId, string productName, int quantity, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
        }

        // Display Product Details
        public void Display()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Product ID   : {ProductId}");
            Console.WriteLine($"Product Name : {ProductName}");
            Console.WriteLine($"Quantity     : {Quantity}");
            Console.WriteLine($"Price        : ₹{Price}");
            Console.WriteLine("--------------------------------");
        }
    }
}