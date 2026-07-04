using System;

namespace Exercise3_SortingCustomerOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Order[] orders =
            {
                new Order(101, "Rahul", 4500),
                new Order(102, "Priya", 2500),
                new Order(103, "Aman", 6700),
                new Order(104, "Sneha", 3200),
                new Order(105, "Rohit", 5100)
            };

            Console.WriteLine("===== Original Orders =====");
            DisplayOrders(orders);

            Order[] bubbleOrders = (Order[])orders.Clone();
            SortingAlgorithms.BubbleSort(bubbleOrders);

            Console.WriteLine("\n===== Orders after Bubble Sort =====");
            DisplayOrders(bubbleOrders);

            Order[] quickOrders = (Order[])orders.Clone();
            SortingAlgorithms.QuickSort(quickOrders, 0, quickOrders.Length - 1);

            Console.WriteLine("\n===== Orders after Quick Sort =====");
            DisplayOrders(quickOrders);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayOrders(Order[] orders)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerName}, Total Price: {order.TotalPrice}");
            }
        }
    }
}