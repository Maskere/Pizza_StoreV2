using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;

namespace Pizza_StoreV2.Models
{
    public class FakeOrderRepository
    {
        public List<Order> Orders { get; }
        public List<Pizza> Pizzas { get; }
        public List<Customer> Customers { get; }
        private static FakeOrderRepository _instance;
        private int _totalPrice;
        private Pizza Pizza { get; set; }
        private int NumberOfPizzasInOrder { get; set; }
        public FakeOrderRepository()
        {
            Orders = new List<Order>();
            Order order1 = new Order() { OrderID = 1, NumberOfPizzasInOrder = 1, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(1) };
            Orders.Add(order1);
            Order order2 = new Order() { OrderID = 2, NumberOfPizzasInOrder = 3, Pizza = PizzaCatalog.Instance.SearchForPizzaById(1), Customer = CustomerCatalog.Instance.SeachForCustomerById(2) };
            Orders.Add(order2);
            foreach (Order order in Orders) { order.CalculateTotalPrice(); }
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
        public void AddCustomerToOrder(int id,Customer customer) 
        {
            Orders[id].Customer = customer;
        }
        public void AddNewCustomerToOrder(Customer customer)
        {
            Orders.Add(new Order() { Customer=customer});
        }
        public void AddPizzaToOrder(int id, Pizza pizza) 
        {
            Orders[id].Pizza = pizza;
        }
        public void AddNewPizzaToOrder(Pizza pizza) 
        {
            Orders.Add(new Order() { Pizza=pizza});
        }
        public List<Order> GetAllOrders() { return Orders; }
        public Order SearchForOrderById(int orderId)
        {
            Order findOrder = Orders[orderId-1];
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
                _totalPrice = (int)Pizza.Price * order.NumberOfPizzasInOrder + 40;
            }
        }
    }
}
