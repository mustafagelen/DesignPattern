
var apple = new Product("iPhone", 1500);

var amazon = new Amazon();

var observer = new Observer("Mustafa GELEN");

amazon.Register(observer, apple);

amazon.NofitfyForProductName("iPhone");

class Amazon
{
    private Dictionary<IObserver, Product> observers = new();
    public void Register(IObserver observer, Product product)
    {
        observers.TryAdd(observer, product);
    }
    public void Unregister(IObserver observer)
    {
        observers.Remove(observer);
    }
    public void NotifyAll()
    {
        foreach (var observer in observers)
        {
            observer.Key.Notify(observer.Value);
        }
    }
    public void NofitfyForProductName(string productName)
    {
        foreach (var observer in observers)
        {
            if (observer.Value.Name == productName)
                observer.Key.Notify(observer.Value);
        }
    }
}

interface IObserver
{
    void Notify(Product product);
}

class Observer : IObserver
{
    public string FullName { get; set; }
    public Observer(string fullName)
    {
        FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
    }
    public void Notify(Product product)
    {
        Console.WriteLine($"{FullName} Product updated: {product.Name} - Price: {product.Price}");
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}