using System.Collections.Generic;

public class Order
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

    public double CalculateTotal()
    {
        double total = 0;
        foreach (Product product in _products)
        {
            total += product.GetTotalCost();
        }

        // Add shipping cost
        if (_customer.IsInUSA())
        {
            total += 5.00;
        }
        else
        {
            total += 35.00;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string label = $"--- Packing Label ---\nCustomer: {_customer.GetName()}\nItems:\n";
        foreach (Product product in _products)
        {
            label += product.GetProductSummary() + "\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"--- Shipping Label ---\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}