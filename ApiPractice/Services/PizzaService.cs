namespace ApiPractice.Services;

using ApiPractice.Models;

public class PizzaService
{
    public static List<Pizza>? Pizzas { get; } 
    static int nextId = 3;

    static PizzaService()
    {
        Pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Cheese", IsGlutenFree = false },
            new Pizza { Id = 2, Name = "Pepperoni", IsGlutenFree = true } 
        };
    }

    public static List<Pizza> GetAll() => Pizzas!;

    public static Pizza? Get(int id) => Pizzas!.FirstOrDefault(p => p.Id == id);

    public static void Add(Pizza pizza)
    {
        pizza.Id = nextId++;
        Pizzas!.Add(pizza);
    }

    public static void Remove(int id)
    {
        var pizza = Get(id);

        if (pizza is null) return;

        Pizzas!.Remove(pizza);
    }

    public static void Update(Pizza pizza)
    {
        var index = Pizzas!.FindIndex(p => p.Id == pizza.Id);

        if (index == -1) return;

        Pizzas[index] = pizza;
    }
}
