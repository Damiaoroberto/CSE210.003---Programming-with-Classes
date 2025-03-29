public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Method to check if the customer is from the USA
    public bool IsFromUSA()
    {
        return _address.IsInUSA();
    }

    // Getter for customer name
    public string GetName()
    {
        return _name;
    }

    // Getter for customer address
    public Address GetAddress()
    {
        return _address;
    }
}
