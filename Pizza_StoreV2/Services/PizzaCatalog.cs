using Pizza_StoreV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Pizza_StoreV2.Services
{
    public class PizzaCatalog
    {
        public List<Pizza> Pizzas;
        public PizzaCatalog()
        {
            Pizzas = new List<Pizza>();
        }
        public int Count
        {
            get { return Pizzas.Count; }
        }
        public void UpdatePizza(Pizza pizza)
        {
            if (pizza != null)
            {
                foreach (var e in AllPizzas())
                {
                    if (e.PizzaId == pizza.PizzaId)
                    {
                        e.PizzaId = pizza.PizzaId;
                        e.Name = pizza.Name;
                        e.Price = pizza.Price;
                    }
                }
            }
        }
        public void PrintMenu()
        {
            foreach (Pizza pizza in Pizzas)
            {
                if (pizza != null)
                {
                    Console.WriteLine($"| {pizza} |");
                }
                else
                {
                    Console.WriteLine("   ...");
                }
            }
        }
        public List<Pizza> AllPizzas()
        {
            return Pizzas;
        }
        public void AddPizza(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }
    }
}
