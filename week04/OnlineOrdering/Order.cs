using System;
using System.Collections.Generic;

public class Order
{
    // Private fields
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate total cost
    public double GetTotalCost()
    {
        double total = 0;
        
        // Calculate sum of all products
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }
        
        // Add shipping cost based on customer location
        if (_customer.LivesInUSA())
        {
            total += 5; // USA shipping cost
        }
        else
        {
            total += 35; // International shipping cost
        }
        
        return total;
    }

    // Method to generate packing label
    public string GetPackingLabel()
    {
        string label = "";
        foreach (Product product in _products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    // Method to generate shipping label
    public string GetShippingLabel()
    {
        return $"{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}