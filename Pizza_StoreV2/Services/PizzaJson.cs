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
        string fileName = @"C:\Users\mstac\Documents\Pizza_StoreV2 - kopi\Pizza_StoreV2\Data\jsonPizza.json";
        private List<Pizza> Pizzas;
        public void AddPizza(Pizza pizza)
        {
            //Helpers.jsonFileReader.ReadJson(fileName);
            //Helpers.jsonFileReader.ReadJson(fileName).Add(new Pizza { PizzaId=5,Name="Double cheese",Price=95});
            //Helpers.jsonFileWriter.WriteToJson(GetAllPizzas(),fileName);
            Pizzas = jsonFileReaderPizza.ReadJson(fileName);
            Pizzas.Add(pizza);
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
            throw new NotImplementedException();
        }
    }
}
