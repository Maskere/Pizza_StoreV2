using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_StoreV2.Models
{
    public class FakePizzaRepository : IPizzaRepository
    {
        [BindProperty]
        private List<Pizza> Pizzas { get; }
        public FakePizzaRepository()
        {
                
        }
        public void AddPizza(Pizza pizza) { Pizzas.Add(pizza); }
        public Pizza GetPizza(string name) 
        {
            foreach (Pizza pizza in Pizzas)
            {
                if (pizza != null)
                {
                    for (int i = 0; i < Pizzas.Count; i++) { Pizza findPizza = new Pizza(); ; if (string.Equals(pizza.Name, findPizza.Name)) return pizza; }
                }
            }
            return null;
        }
        public List<Pizza> GetAllPizzas() { return Pizzas; }
        public void DeletePizzaById(int id)
        {
            GetAllPizzas().RemoveAt(id - 1);
        }
        public void DeletePizza(Pizza pizza) { Pizzas.Remove(pizza); }
        public Pizza SearchForPizzaById(int pizzaId)
        {
            Pizza findPizza = Pizzas[pizzaId - 1];
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
            if (pizza != null)
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
        public List<Pizza> GetPizzas()
        {
            throw new System.NotImplementedException();
        }
        public Pizza GetPizza()
        {
            throw new System.NotImplementedException();
        }
    }
}