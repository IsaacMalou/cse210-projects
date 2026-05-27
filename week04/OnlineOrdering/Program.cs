using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address address1 = new Address("123 Juba Rd", "Juba", "Central Equatoria", "USA");
        Customer customer1 = new Customer("Deng Majak", address1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "LPT-01", 900.00, 1));
        order1.AddProduct(new Product("Mouse", "MOU-99", 25.00, 2));

        // Order 2: International Customer
        Address address2 = new Address("456 Unity Ave", "Nairobi", "Nairobi", "Kenya");
        Customer customer2 = new Customer("Kiden Lual", address2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Keyboard", "KEY-44", 50.00, 1));
        order2.AddProduct(new Product("Monitor", "MON-12", 200.00, 1));

        // Store in a list
        List<Order> orders = new List<Order> { order1, order2 };

        // Display results
        foreach (Order order in orders)
        {
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.CalculateTotal():F2}");
            Console.WriteLine("-----------------------------------\n");
        }
    }
}