using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Pages;

namespace Pizza_StoreV2.Services
{
    public class OrderCatalog
    {
        List<Order> Orders;
        CustomerCatalog Customers;
        PizzaCatalog Pizzas;
        [BindProperty]
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public OrderCatalog()
        {
            Orders = new List<Order>();
            Customer = new Customer();
            Pizza = new Pizza();
            //Order order1 = new Order() { OrderID = 1, NumberOfPizzasInOrder = 1, Pizza = , Customer = CustomerCatalog.Instance.SeachForCustomerById(1) };
            //Orders.Add(order1); 
            //Order order2 = new Order() { OrderID = 2, NumberOfPizzasInOrder = 3, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(2) };
            //Orders.Add(order2);
            foreach (Order order in Orders) { order.CalculateTotalPrice(); }
        }
        public int Count
        {
            get { return Orders.Count; }
        }
        public void AddOrder(Order order) { Orders.Add(order); }
        public void AddCustomerToOrder(int id, Customer customer)
        {
            Orders[id].Customer = customer;
        }
        public void DeleteOrderById(int id)
        {
            Orders.RemoveAt(id - 1);
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
    }
}
