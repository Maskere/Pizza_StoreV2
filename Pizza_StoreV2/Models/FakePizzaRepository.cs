using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_StoreV2.Models
{
    public class FakePizzaRepository
    {
        private List<Pizza> pizzas { get; }
        private static FakePizzaRepository _instance;
        public FakePizzaRepository() 
        {
            pizzas = new List<Pizza>();
            pizzas.Add(new Pizza() { Name = "Calzone", Price = 95, PizzaId = 1 });
            pizzas.Add(new Pizza() { Name = "Peperoni", Price = 75, PizzaId = 2 });
            pizzas.Add(new Pizza() { Name = "Vesuvio", Price = 95, PizzaId = 3 });
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
        public void AddPizza(Pizza pizza) { pizzas.Add(pizza); }
        public List<Pizza> GetAllPizzas() { return pizzas; }
    }

}
