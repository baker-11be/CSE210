using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Product Ordering System");
        Console.WriteLine("=======================\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("9 plot", "Kampala", "East Africa", "Uganda");
        Address address3 = new Address("789 Pine Rd", "Los Angeles", "CA", "USA");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Baker Mfitundinda", address2);
        Customer customer3 = new Customer("Robert Johnson", address3);

        // Create products
        Product product1 = new Product("Laptop", "P1001", 899.99, 1);
        Product product2 = new Product("Wireless Mouse", "P1002", 24.99, 2);
        Product product3 = new Product("USB-C Cable", "P1003", 19.99, 3);
        Product product4 = new Product("Monitor", "P1004", 249.99, 1);
        Product product5 = new Product("Keyboard", "P1005", 79.99, 1);
        Product product6 = new Product("Webcam", "P1006", 49.99, 1);

        // Create first order (USA customer)
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        // Create second order (Non-USA customer)
        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Create third order (USA customer)
        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product6);
        order3.AddProduct(product3);
        order3.AddProduct(product2);

        // Display order information
        DisplayOrder(order1);
        DisplayOrder(order2);
        DisplayOrder(order3);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("ORDER SUMMARY");
        Console.WriteLine(new string('=', 50));
        
        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine(order.GetShippingLabel());
        
        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine(order.GetPackingLabel());
        
        Console.WriteLine($"\nTOTAL COST: ${order.GetTotalCost():F2}");
        Console.WriteLine(new string('=', 50));
    }
}