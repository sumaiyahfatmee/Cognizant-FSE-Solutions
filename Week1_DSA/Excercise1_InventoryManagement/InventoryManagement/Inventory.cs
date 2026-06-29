using System;
using System.Collections.Generic;

namespace InventoryManagement
{
    public class Inventory
    {
        // Dictionary to store products
        private Dictionary<int, Product> products;

        // Constructor
        public Inventory()
        {
            products = new Dictionary<int, Product>();
        }

        // Add Product
        public void AddProduct(Product product)
        {
            if (products.ContainsKey(product.ProductId))
            {
                Console.WriteLine("Product ID already exists.");
            }
            else
            {
                products.Add(product.ProductId, product);
                Console.WriteLine("Product added successfully.");
            }
        }

        // Update Product
        public void UpdateProduct(int id, int quantity, double price)
        {
            if (products.ContainsKey(id))
            {
                products[id].Quantity = quantity;
                products[id].Price = price;

                Console.WriteLine("Product updated successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Delete Product
        public void DeleteProduct(int id)
        {
            if (products.Remove(id))
            {
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }

        // Display All Products
        public void DisplayProducts()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("Inventory is empty.");
                return;
            }

            Console.WriteLine("\n===== Product List =====");

            foreach (Product product in products.Values)
            {
                product.Display();
            }
        }
    }
}