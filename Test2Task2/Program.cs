using System;
using System.Collections.Generic;
using System.Linq;


class Dish
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}


class Appetizer : Dish { }
class MainCourse : Dish { }
class Drink : Dish { }
class Dessert : Dish { }


class Order
{
    private List<Dish> dishes;

    public Order()
    {
        dishes = new List<Dish>();
    }


    public void AddDish(Dish dish)
    {
        dishes.Add(dish);
    }


    public decimal CalculateTotal()
    {
        decimal total = 0;
        foreach (var dish in dishes)
        {
            total += dish.Price;
        }
        return total;
    }


    public void ApplyDiscount()
    {
        if (dishes.Any(d => d is Dessert))
        {
            decimal discountAmount = CalculateTotal() * 0.1m;
            Console.WriteLine($"Применена скидка 10% (в заказе есть десерт): {discountAmount:C}");
        }
    }


    public void PrintOrder()
    {
        Console.WriteLine("Список блюд в заказе:");
        foreach (var dish in dishes)
        {
            Console.WriteLine($"{dish.Name} - {dish.Price:C}");
        }

        Console.WriteLine($"Итого: {CalculateTotal():C}");


        ApplyDiscount();
    }
}

class Program
{
    static void Main()
    {
        Order order = new Order();

        order.AddDish(new Appetizer { Name = "Салат", Price = 5.99m });
        order.AddDish(new MainCourse { Name = "Стейк", Price = 15.99m });
        order.AddDish(new Drink { Name = "Кола", Price = 2.49m });
        order.AddDish(new Dessert { Name = "Чизкейк", Price = 7.99m });


        order.PrintOrder();

        Console.ReadLine();
    }
}
