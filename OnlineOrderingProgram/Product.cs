public class Product
{
    private string _name;
    private int _productId;
    private double _price;
    private int _quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Method to calculate total cost for this product
    public double GetTotalCost()
    {
        return _price * _quantity;
    }

    // Getter for product details
    public string GetProductDetails()
    {
        return $"{_name} (ID: {_productId})";
    }
}
