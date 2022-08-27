using Orders.Models;

namespace Orders.Services;

public static class PizzaService
{
    static List<Order> Orders { get; }
    static int nextId = 3;
    static OrderService()
    {
        Orders = new List<Order>
        {
            new Order {  },
            new Order {  }
        };
    }

    public static List<Order> GetAll() => Orders;

    public static Order? Get(int id) => Orders.FirstOrDefault(o => o.Id == id);

    public static void Add(Order order)
    {
        order.Id = nextId++;
        Orders.Add(order);
    }

    public static void Delete(int id)
    {
        var order = Get(id);
        if(order is null)
            return;

        Orders.Remove(order);
    }

    public static void Update(Order order)
    {
        var index = Orders.FindIndex(o => o.Id == order.Id);
        if(index == -1)
            return;

        Orders[index] = order;
    }
}