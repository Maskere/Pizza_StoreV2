using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;

namespace Pizza_StoreV2.Catalogs
{
    public class OrderCatalog
    {
        List<Order> Orders;
        private static OrderCatalog _instance;
        CustomerCatalog Customers;
        PizzaCatalog Pizzas;
        [BindProperty]
        public Customer Customer { get; set; }
        public Pizza Pizza {  get; set; }
        public OrderCatalog()
        {
            Orders = new List<Order>();
            Customer = new Customer();
            Pizza = new Pizza();
            Order order1 = new Order() { OrderID = 1, NumberOfPizzasInOrder = 1, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(1) };
            Orders.Add(order1); 
            Order order2 = new Order() { OrderID = 2, NumberOfPizzasInOrder = 3, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(2) };
            Orders.Add(order2);
            foreach (Order order in Orders) { order.CalculateTotalPrice(); }
        }
        public static OrderCatalog Instance {
            get
            {
                if (_instance == null)
                {
                    _instance = new OrderCatalog();

                }
                return _instance;
            }
        }
        public int Count
        {
            get { return Orders.Count; }
        }
        //public Order GetNewOrderFromExisting(Customer customer, Pizza pizza, int noOfPizzasInOrder, int orderId)
        //{
        //    Order order = new Order(customer, pizza, noOfPizzasInOrder, orderId);
        //    if (Orders.Contains(order))
        //    {
        //        return null;
        //    }
        //    return order;
        //}
        //public Order GetNewOrder(Customer customer, Pizza pizza, int noOfPizzasInOrder, int orderId)
        //{
        //    Order order = new Order(customer, pizza, noOfPizzasInOrder, orderId);
        //    return order;
        //}
        //public void AddAnOrderToTheList(Order order)
        //{
        //    if (Orders.Contains(order)) { Console.WriteLine($"An order with id:{order.OrderID} already exist"); return; }
        //    Orders.Insert(order.OrderID, order);
        //}
        //public void DeleteAnOrder(int OrderId)
        //{
        //    Orders.Insert(OrderId, new Order(new Customer() { CustomerName = "", CustomerId = 0 }, new Pizza(), 0, OrderId));
        //    Orders.RemoveAt(OrderId + 1);
        //}
        //public Order SeachForOrderById(int orderId)
        //{
        //    Order findOrder = Orders[orderId];
        //    return findOrder;
        //}
        //public void UpdateOrder(int orderId)
        //{
        //    Order updateOrder = new Order(Customers.GetNewCustomer("", 0), Pizzas.GetNewPizza("", 0, 0), 0, orderId);
        //    updateOrder.CustomerName = Customers.GetNewCustomer();
        //    if (Orders.Contains(updateOrder))
        //    {
        //        updateOrder = null;
        //    }
        //    else
        //    {
        //        Orders.RemoveAt(updateOrder.OrderID);
        //        Orders.Insert(updateOrder.OrderID, updateOrder);
        //    }
        //}
        //public Customer SearchCustomerByName(string customerName)
        //{
        //    foreach (Customer customer in Customers)
        //    {
        //        Console.WriteLine($"\nFind: customer by name \"{customerName}\":{0}", Customers.Find(x => x.CustomerName.Contains(customerName)));
        //    }
        //    return
        //}
        //public void Clear()
        //{
        //    Orders.Clear();
        //    Orders = new List<Order>(new Order[10]);
        //}
        //public void RemoveAt(int removeAt)
        //{
        //    Orders.RemoveAt(removeAt);
        //}
        //public void PrintOrderList()
        //{
        //    foreach (Order order in Orders)
        //    {
        //        if (order != null)
        //        {
        //            order.CalculateTotalPrice();
        //            Console.WriteLine($"| {order} | Total price: {order.TotalPrice} |");
        //        }
        //        else
        //        {
        //            Console.WriteLine("   ...");
        //        }
        //    }
        //}
        public List<Order> AllOrders()
        {
            return Orders;
        }
    }
}
