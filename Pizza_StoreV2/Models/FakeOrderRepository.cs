﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_StoreV2.Models
{
    public class FakeOrderRepository
    {
        public List<Order> Orders { get; }
        public List<Pizza> Pizzas { get; }
        public List<Customer> Customers { get; }
        [BindProperty]
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public int TotalPrice { get; set; }
        private static FakeOrderRepository _instance;
        public FakePizzaRepository pizzaRepo { get; }
        public FakeCustomerRepository customerRepo { get; }

        public FakeOrderRepository()
        {
            Orders = new List<Order>();
            Pizzas = new List<Pizza>();
            Customers = new List<Customer>();
            Order order1 = new Order() { OrderID = 1, NumberOfPizzasInOrder = 1, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(1) };
            Orders.Add(order1);
            Order order2 = new Order() { OrderID = 2, NumberOfPizzasInOrder = 3, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(2) };
            Orders.Add(order2);
            Order order3 = new Order() { OrderID=3, NumberOfPizzasInOrder=2, Pizza = new Pizza() { PizzaId=5,Name="Ananas",Price=85} };
            Orders.Add(order3);
            foreach (Order order in Orders) 
            { 
                order.CalculateTotalPrice();
                if (order.Pizza.PizzaId > PizzaCatalog.Instance.Count) 
                {
                    PizzaCatalog.Instance.AddPizza(order.Pizza);
                    FakePizzaRepository.Instance.AddPizza(order.Pizza);
                }
            }
        }
        public static FakeOrderRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FakeOrderRepository();
                }
                return _instance;
            }
        }
        public void AddOrder(Order order) { Orders.Add(order); }
        public void AddCustomerToOrder(int id, Customer customer)
        {
            Orders[id].Customer = customer;
        }
        public void DeleteOrderById(int id) 
        {
            Orders.RemoveAt(id-1);
        }
        public void AddNewCustomerToOrder(Customer customer)
        {
            Orders.Add(new Order() { Customer = customer });
        }
        public void AddPizzaToOrder(int id, Pizza pizza)
        {
            Orders[id].Pizza = pizza;
        }
        public void AddNewPizzaToOrder(Pizza pizza)
        {
            Orders.Add(new Order() { Pizza = pizza });
        }
        public List<Order> GetAllOrders() { return Orders; }
        public Order SearchForOrderById(int orderId)
        {
            Order findOrder = Orders[orderId - 1];
            return findOrder;
        }
        public void UpdateOrder(Order order)
        {
            if (order != null)
            {
                foreach (var e in GetAllOrders())
                {
                    if (e.OrderID == order.OrderID)
                    {
                        e.OrderID = order.OrderID;
                        e.Customer = order.Customer;
                        e.Pizza = order.Pizza;
                        e.NumberOfPizzasInOrder = order.NumberOfPizzasInOrder;
                    }
                }
            }
        }
        public void CalculateTotalPrice()
        {
            foreach (Order order in Orders)
            {
                TotalPrice = (int)Pizza.Price * order.NumberOfPizzasInOrder + 40;
            }
        }
    }
}
