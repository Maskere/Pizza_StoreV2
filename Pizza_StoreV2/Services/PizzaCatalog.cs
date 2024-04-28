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
        //private static PizzaCatalog _instance;
        public PizzaCatalog()
        {
            Pizzas = new List<Pizza>();
            Pizzas.Add(new Pizza() { Name = "Calzone", Price = 95, PizzaId = 1 });
            Pizzas.Add(new Pizza() { Name = "Peperoni", Price = 75, PizzaId = 2 });
            Pizzas.Add(new Pizza() { Name = "Vesuvio", Price = 95, PizzaId = 3 });
            Pizzas.Add(new Pizza() { Name = "Salad", Price = 75 });
        }
        public int Count
        {
            get { return Pizzas.Count; }
        }
        //public static PizzaCatalog Instance 
        //{
        //    get
        //    {
        //        if (_instance == null) { _instance = new PizzaCatalog(); }
        //        return _instance;
        //    }
        //}
        public Pizza GetNewPizza(string pizzaName, int pizzaPrice, int pizzaId)
        {
            Pizza pizza = new Pizza();
            pizza.Name = pizzaName;
            pizza.Price = pizzaPrice;
            pizza.PizzaId = pizzaId;
            if (Pizzas[pizzaId] != null)
                return null;
            return pizza;
        }
        //public void UpdatePizza(Pizza updatePizza)
        //{
        //    if (Pizzas.Contains(updatePizza))
        //    {
        //        updatePizza = null;
        //    }
        //    else
        //    {
        //        Pizzas.RemoveAt((int)updatePizza.PizzaId);
        //        Pizzas.Insert((int)updatePizza.PizzaId, updatePizza);
        //    }
        //}
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
        public void CreateAPizza(Pizza pizza)
        {
            Pizzas.Insert(pizza.PizzaId, pizza);
        }
        public void DeleteAPizza(int pizzaId)
        {
            Pizzas.Insert(pizzaId, new Pizza());
            Pizzas.RemoveAt(pizzaId + 1);
        }
        public Pizza SearchForPizzaById(int pizzaId)
        {
            Pizza findPizza = Pizzas[pizzaId];
            return findPizza;
        }
        public void Clear()
        {
            Pizzas.Clear();
            Pizzas = new List<Pizza>(new Pizza[10]);
        }
        public void RemoveAt(int removeAt)
        {
            Pizzas.RemoveAt(removeAt);
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
