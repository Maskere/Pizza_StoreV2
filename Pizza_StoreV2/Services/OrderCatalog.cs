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
        [BindProperty]
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public OrderCatalog()
        {
            Orders = new List<Order>();
            Customer = new Customer();
            Pizza = new Pizza();
            foreach (Order order in GetAllOrders()) { order.CalculateTotalPrice(); }
        }
        //public static OrderCatalog Instance {
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new OrderCatalog();

        //        }
        //        return _instance;
        //    }
        //}
        public int Count
        {
            get { return GetAllOrders().Count; }
        }
        public void AddOrder(Order order) { GetAllOrders().Add(order); }
        public void AddCustomerToOrder(int id, Customer customer)
        {
            GetAllOrders()[id].Customer = customer;
        }
        public void DeleteOrderById(int id)
        {
            GetAllOrders().RemoveAt(id - 1);
        }
        public void AddNewCustomerToOrder(Customer customer)
        {
            GetAllOrders().Add(new Order() { Customer = customer });
        }
        public void AddPizzaToOrder(int id, Pizza pizza)
        {
            GetAllOrders()[id].Pizza = pizza;
        }
        public void AddNewPizzaToOrder(Pizza pizza)
        {
            GetAllOrders().Add(new Order() { Pizza = pizza });
        }
        public List<Order> GetAllOrders() { return Orders; }
        public Order SearchForOrderById(int orderId)
        {
            Order findOrder = GetAllOrders()[orderId - 1];
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
