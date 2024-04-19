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
                Pizzas.Add(new Pizza() { Name = "Calzone", Price = 95, PizzaId=1});
                Pizzas.Add(new Pizza() { Name = "Peperoni", Price = 75,PizzaId=2 });
                Pizzas.Add(new Pizza() { Name = "Vesuvio", Price = 95,PizzaId=3});
                Pizzas.Add(new Pizza() { Name = "Salad", Price = 75,PizzaId=4 });
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
        public void DeletePizzaById(int id) 
        {
            Pizzas.RemoveAt(id-1);
        }
        public Pizza SearchForPizzaById(int pizzaId)
        {
            Pizza findPizza = Pizzas[pizzaId-1];
            return findPizza;
        }
        public List<Pizza> FilterPizzas(string filter) 
        {
            List<Pizza> filteredList = new List<Pizza>();
            foreach (Pizza pizza in Pizzas)
            {
                if (pizza.Name.Contains(filter,System.StringComparison.OrdinalIgnoreCase)) 
                {
                    filteredList.Add(pizza);
                }
            }
            return filteredList;
        }
        public void UpdatePizza(Pizza pizza) 
        {
            if (pizza !=null) 
            {
                foreach (var e in GetAllPizzas()) 
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
    }

}
