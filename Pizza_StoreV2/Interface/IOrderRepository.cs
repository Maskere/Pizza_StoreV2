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
        //public IOrderRepository()
        //{
        //    Orders = new List<Order>();
        //    //Order order1 = new Order() { OrderID = 1, NumberOfPizzasInOrder = 1, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(1) };
        //    //Orders.Add(order1);
        //    //Order order2 = new Order() { OrderID = 2, NumberOfPizzasInOrder = 3, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(2) };
        //    //Orders.Add(order2);
        //    foreach (Order order in Orders) { order.CalculateTotalPrice(); }
        //}
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
        //public void CalculateTotalPrice()
        //{
        //    foreach (Order order in Orders)
        //    {
        //        _totalPrice = (int)Pizza.Price * order.NumberOfPizzasInOrder + 40;
        //    }
        //}
    }
}