using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_StoreV2.Models
{
    public class FakePizzaRepository
    {
        private List<Pizza> Pizzas { get; }
        private static FakePizzaRepository _instance;
        public FakePizzaRepository() 
        {
            Pizzas = new List<Pizza>();
            Pizzas.Add(new Pizza() { Name = "Calzone", Price = 95, PizzaId = 1 });
            Pizzas.Add(new Pizza() { Name = "Peperoni", Price = 75, PizzaId = 2 });
            Pizzas.Add(new Pizza() { Name = "Vesuvio", Price = 95, PizzaId = 3 });
        }
        public static FakePizzaRepository Instance 
        {
            get 
            {
                if (_instance == null) 
                {
                    _instance = new FakePizzaRepository();
                }
                return _instance;
            }
        }
        public void AddPizza(Pizza pizza) { Pizzas.Add(pizza); }
        public List<Pizza> GetAllPizzas() { return Pizzas; }
        public Pizza SearchForPizzaById(int pizzaId)
        {
            Pizza findPizza = Pizzas[pizzaId];
            return findPizza;
        }
    }

}
