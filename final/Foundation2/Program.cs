using System;
using System.Collections.Generic;

public class Product
{
    public string Name { get; set; }
    public string ProductId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal GetTotalCost()
    {
        return Price * Quantity;
    }
}

public class Customer
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public bool IsUSA()
    {
        return Address.IsUSA();
    }
}

public class Address
{
    public string StreetAddress { get; set; }
    public string City { get; set; }
    public string StateProvince { get; set; }
    public string Country { get; set; }

    public bool IsUSA()
    {
        return Country == "USA";
    }

    public override string ToString()
    {
        return $"{StreetAddress}\n{City}, {StateProvince} {Country}";
    }
}

public class Order
{
    public List<Product> Products { get; set; }
    public Customer Customer { get; set; }

    public decimal GetTotalPrice()
    {
        decimal total = 0;
        foreach (var product in Products)
        {
            total += product.GetTotalCost();
        }
        return total + (IsUSA() ? 5 : 35);
    }

    private bool IsUSA()
    {
        return Customer.IsUSA();
    }

    public string GetPackingLabel()
    {
        string label = "";
        foreach (var product in Products)
        {
            label += $"{product.Name} ({product.ProductId})\n";
        }
        return label.Trim();
    }

    public string GetShippingLabel()
    {
        return $"{Customer.Name}\n{Customer.Address.ToString()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();

        Product product1 = new Product { Name = "Product 1", ProductId = "PID1", Price = 10.99m, Quantity = 2 };
        Product product2 = new Product { Name = "Product 2", ProductId = "PID2", Price = 20.99m, Quantity = 3 };
        Product product3 = new Product { Name = "Product 3", ProductId = "PID3", Price = 30.99m, Quantity = 1 };

        order.Products = new List<Product>();

        order.Products.Add(product1);
        order.Products.Add(product2);
        order.Products.Add(product3);

        Customer customer = new Customer { 
            Name = "John Doe", 
            Address = new Address { 
                StreetAddress = "123 Main St", 
                City = "Anytown", 
                StateProvince = "CA", 
                Country = "USA" 
            } 
        };
        order.Customer = customer;

        Console.WriteLine($"Total Price: ${order.GetTotalPrice():F2}");
        Console.WriteLine($"Packing Label:\n{order.GetPackingLabel()}");
        Console.WriteLine($"Shipping Label:\n{order.GetShippingLabel()}");
    }
}