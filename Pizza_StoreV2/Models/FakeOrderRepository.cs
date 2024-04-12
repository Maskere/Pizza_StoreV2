using System.Collections.Generic;

namespace Pizza_StoreV2.Models
{
    public class FakeOrderRepository
    {
        private List<Order> orders { get; }
        private static FakeOrderRepository _instance;
        public FakeOrderRepository()
        {
            orders = new List<Order>();
            orders.Add(new Order());
            orders.Add(new Order());
            orders.Add(new Order());
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
        public void AddPizza(Order order) { orders.Add(order); }
        public List<Order> GetAllOrders() { return orders; }
    }
}
