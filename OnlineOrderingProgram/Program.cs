public class Program
{
    public static void Main(string[] args)
    {
        // Creating addresses
        Address address1 = new Address("789 Pine St", "Los Angeles", "CA", "USA");
        Address address2 = new Address("321 Maple Ave", "Vancouver", "BC", "Canada");

        // Creating customers
        Customer customer1 = new Customer("Alice Johnson", address1);
        Customer customer2 = new Customer("Bob Green", address2);

        // Creating products
        Product product1 = new Product("Smartphone", 201, 599.99, 1);
        Product product2 = new Product("Bluetooth Speaker", 202, 45.50, 2);
        Product product3 = new Product("Gaming Headset", 203, 89.99, 1);

        // Creating orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product2);

        // Displaying order details
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice():F2}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice():F2}");
    }
}
