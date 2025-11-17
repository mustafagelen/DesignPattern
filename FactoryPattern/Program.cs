


AnkaraPizzaStore ankaraStore = new();
IstanbulPizzaStore istStore = new();

IPizza cheesePizza = ankaraStore.OrderPizza("cheese");
Console.WriteLine("Cheese pizza orderen in Ankara store");

IPizza veggiePizza = istStore.OrderPizza("vegie");
Console.WriteLine("Cheese pizza orderen in İstanbul     store");



interface IPizza
{
    void Prapere();
    void Bake();
    void Cut();
}

class CheesePizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("Cheese Pizza Baked");
    }

    public void Cut()
    {
        Console.WriteLine("Cheese Pizza Cut");
    }

    public void Prapere()
    {
        Console.WriteLine("Cheese Pizza Prapered");
    }
}

class VegiePizza : IPizza
{
    public void Bake()
    {
        Console.WriteLine("Cheese Pizza Baked");
    }

    public void Cut()
    {
        Console.WriteLine("Cheese Pizza Cut");
    }

    public void Prapere()
    {
        Console.WriteLine("Cheese Pizza Prapered");
    }
}

abstract class PizzaStore
{
    protected abstract IPizza CreaterPizze(string type);
    public IPizza OrderPizza(string type)
    {
        IPizza pizza = CreaterPizze(type);
        pizza.Bake();
        pizza.Cut();
        pizza.Prapere();

        return pizza;
    }
}

class IstanbulPizzaStore : PizzaStore
{
    protected override IPizza CreaterPizze(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggie" => new VegiePizza(),
            _ => throw new ArgumentNullException("invalid pizza type", nameof(type)),

        };
    }
}

class AnkaraPizzaStore : PizzaStore
{
    protected override IPizza CreaterPizze(string type)
    {
        return type switch
        {
            "cheese" => new CheesePizza(),
            "veggie" => new VegiePizza(),
            _ => throw new ArgumentNullException("invalid pizza type", nameof(type)),

        };
    }
}