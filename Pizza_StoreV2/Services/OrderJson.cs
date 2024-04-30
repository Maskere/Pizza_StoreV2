using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Pages;
using Pizza_StoreV2.Helpers;
namespace Pizza_StoreV2.Services
{
    public class OrderJson : IOrderRepository
    {
        private List<Order> Orders;
        private List<Pizza> Pizza;
        private List<Customer> Customer;
        private Customer customer;
        private Pizza pizza;
        string customerFileName = @"C:\Users\mstac\Documents\Pizza_StoreV2 - kopi\Pizza_StoreV2\Data\jsonCustomer.json";
        string pizzaFileName = @"C:\Users\mstac\Documents\Pizza_StoreV2 - kopi\Pizza_StoreV2\Data\jsonPizza.json";
        string orderFileName = @"C:\Users\mstac\Documents\Pizza_StoreV2 - kopi\Pizza_StoreV2\Data\jsonOrder.json";
        public int OrderCount { get { return GetOrders().Count; } }
        public int CustomerCount { get { return GetCustomers().Count; } }
        public int PizzaCount { get { return GetPizzas().Count; } }
        public void AddOrder(Order order)
        {
            Orders = jsonFileReaderOrder.ReadJson(orderFileName);
            Orders.Add(order);
            order.Customer = customer;
            order.Pizza = pizza;
            Helpers.jsonFileWriterOrder.WriteToJson(Orders, orderFileName);
        }
        public void DeleteOrderById(int id)
        {
            Orders.RemoveAt(id - 1);
        }
        public Customer GetCustomer()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            return Helpers.jsonFileReaderCustomer.ReadJson(customerFileName);
        }

        public List<Order> GetOrders()
        {
            return Helpers.jsonFileReaderOrder.ReadJson(orderFileName);
        }

        public Pizza GetPizza()
        {
            throw new NotImplementedException();
        }

        public List<Pizza> GetPizzas()
        {
            return Helpers.jsonFileReaderPizza.ReadJson(pizzaFileName);
        }
    }
}
