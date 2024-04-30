using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
namespace Pizza_StoreV2.Interface
{
    public interface IPizzaRepository
    {
        List<Pizza> GetPizzas();
        Pizza GetPizza();
        //public IPizzaRepository()
        //{
        //    Pizzas = new List<Pizza>();
        //    Pizzas.Add(new Pizza() { Name = "Calzone", Price = 95, PizzaId = 1 });
        //    Pizzas.Add(new Pizza() { Name = "Peperoni", Price = 75, PizzaId = 2 });
        //    Pizzas.Add(new Pizza() { Name = "Vesuvio", Price = 95, PizzaId = 3 });
        //    Pizzas.Add(new Pizza() { Name = "Salad", Price = 75, PizzaId = 4 });
        //}
        public void AddPizza(Pizza pizza);
        public List<Pizza> GetAllPizzas();
        public void DeletePizzaById(int id)
        {
            GetPizzas().RemoveAt(id - 1);
        }
        public Pizza SearchForPizzaById(int pizzaId)
        {
            Pizza findPizza = GetPizzas()[pizzaId - 1];
            return findPizza;
        }
        public List<Pizza> FilterPizzas(string filter)
        {
            List<Pizza> filteredList = new List<Pizza>();
            foreach (Pizza pizza in GetPizzas())
            {
                if (pizza.Name.Contains(filter, System.StringComparison.OrdinalIgnoreCase))
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
    }

}