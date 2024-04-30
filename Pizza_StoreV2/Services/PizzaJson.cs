using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Pages;
using Pizza_StoreV2.Helpers;
namespace Pizza_StoreV2.Services
{
    public class PizzaJson : IPizzaRepository
    {
        string fileName = @"C:\Users\Mus\source\repos\Pizza_StoreV2-kopi\Pizza_StoreV2\Data\jsonPizza.json";
        private List<Pizza> Pizzas;
        public void AddPizza(Pizza pizza)
        {
            Pizzas = jsonFileReaderPizza.ReadJson(fileName);
            Pizzas.Add(pizza);
            Helpers.jsonFileWriter.WriteToJson(Pizzas,fileName);
        }
        public void DeletePizzaById(int id) 
        {
            Pizzas = jsonFileReaderPizza.ReadJson(fileName);
            Pizzas.RemoveAt(id-1);
            Helpers.jsonFileWriter.WriteToJson(Pizzas,fileName);
        }
        public List<Pizza> GetAllPizzas()
        {
            return Helpers.jsonFileReaderPizza.ReadJson(fileName);
        }
        public List<Pizza> FilterPizzas(string filter)
        {
            List<Pizza> filteredList = new List<Pizza>();
            foreach (Pizza pizza in GetAllPizzas())
            {
                if (pizza.Name.Contains(filter, System.StringComparison.OrdinalIgnoreCase))
                {
                    filteredList.Add(pizza);
                }
            }
            return filteredList;
        }
        public Pizza GetPizza()
        {
            throw new NotImplementedException();
        }
        public List<Pizza> GetPizzas()
        {
            return Helpers.jsonFileReaderPizza.ReadJson(fileName);
        }
    }
}
