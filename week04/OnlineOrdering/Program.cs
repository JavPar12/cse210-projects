using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== ONLINE ORDERING SYSTEM ===\n");

        // ===== ORDER 1 (USA) =====
        Address a1 = new Address("Street 1", "New York", "NY", "USA");
        Customer c1 = new Customer("Luis", a1);

        Product p1 = new Product("Laptop", "A1", 1000, 1);
        Product p2 = new Product("Mouse", "B2", 50, 2);

        Order order1 = new Order(c1);
        order1.AddProduct(p1);
        order1.AddProduct(p2);

        Console.WriteLine("ORDER 1");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}");
        Console.WriteLine("\n------------------------\n");

        // ===== ORDER 2 (NON-USA) =====
        Address a2 = new Address("Street 2", "Toronto", "ON", "Canada");
        Customer c2 = new Customer("Ana", a2);

        Product p3 = new Product("Phone", "C3", 800, 1);
        Product p4 = new Product("Headphones", "D4", 100, 3);

        Order order2 = new Order(c2);
        order2.AddProduct(p3);
        order2.AddProduct(p4);

        Console.WriteLine("ORDER 2");
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());

        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}

class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    public string GetPackingInfo()
    {
        return $"{_name} (ID: {_productId})";
    }
}

class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    public bool IsUSA()
    {
        return _country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}

class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public bool LivesInUSA()
    {
        return _address.IsUSA();
    }

    public string GetCustomerInfo()
    {
        return $"{_name}\n{_address.GetFullAddress()}";
    }
}

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalCost()
    {
        double total = 0;

        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string result = "";

        foreach (Product p in _products)
        {
            result += p.GetPackingInfo() + "\n";
        }

        return result;
    }

    public string GetShippingLabel()
    {
        return _customer.GetCustomerInfo();
    }
}