using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Pizza_StoreV2.Models
{
    public class FakeOrderRepository : IOrderRepository
    {
        public List<Order> Orders { get; }
        public List<Pizza> Pizzas { get; }
        public List<Customer> Customers { get; }
        private int _totalPrice;
        private int NumberOfPizzasInOrder { get; set; }
        [BindProperty]
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
        string fileName = "C:\\Users\\mstac\\Documents\\Pizza_StoreV2 - kopi\\Pizza_StoreV2\\Data\\jsonOrder.json";
        public FakeOrderRepository()
        {
            Orders = new List<Order>();
            foreach (Order order in Orders) { order.CalculateTotalPrice(); }
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
        public List<Order> GetOrders()
        {
            return Helpers.jsonFileReaderOrder.ReadJson(fileName);
        }

        public List<Pizza> GetPizzas()
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Pizza GetPizza()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomer()
        {
            throw new System.NotImplementedException();
        }
    }
}
