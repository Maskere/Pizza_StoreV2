using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Models;
using System.Collections.Generic;

namespace Pizza_StoreV2.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetOrders();
        List<Pizza> GetPizzas();
        List<Customer> GetCustomers();
        Pizza GetPizza();
        Customer GetCustomer();
        public void AddOrder(Order order) { GetOrders().Add(order); }
        public void AddCustomerToOrder(int id, Customer customer)
        {
            GetOrders()[id].Customer = customer;
        }
        public void DeleteOrderById(int id)
        {
            GetOrders().RemoveAt(id - 1);
        }
        public void AddNewCustomerToOrder(Customer customer)
        {
            GetOrders().Add(new Order() { Customer = customer });
        }
        public void AddPizzaToOrder(int id, Pizza pizza)
        {
            GetOrders()[id].Pizza = pizza;
        }
        public void AddNewPizzaToOrder(Pizza pizza)
        {
            GetOrders().Add(new Order() { Pizza = pizza });
        }
        public List<Order> GetAllOrders() { return GetOrders(); }
        public Order SearchForOrderById(int orderId)
        {
            Order findOrder = GetOrders()[orderId - 1];
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