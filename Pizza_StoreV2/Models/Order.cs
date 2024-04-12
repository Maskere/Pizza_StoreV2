namespace Pizza_StoreV2.Models
{
    public class Order
    {
        #region Instance Field
        private Pizza _pizzaName;
        private Customer _customerName;
        private int _numberOfPizzasInOrder;
        private int _orderID;
        private double _totalPrice;
        #endregion

        #region Constructor
        public Order()
        {
            _orderID = OrderID;
            _customerName = Customer;
            _pizzaName = Pizza;
            _numberOfPizzasInOrder = NumberOfPizzasInOrder;
            _totalPrice = TotalPrice;
        }
        #endregion

        #region Properties
        public Pizza Pizza
        {
            get { return _pizzaName; }
            set { _pizzaName = value; }
        }
        public Customer Customer
        {
            get { return _customerName; }
            set { _customerName = value; }
        }
        public int NumberOfPizzasInOrder
        {
            get { return _numberOfPizzasInOrder; }
            set { _numberOfPizzasInOrder = value; }
        }
        public double TotalPrice
        {
            get { return _totalPrice; }
        }
        public int OrderID
        {
            get { return _orderID; }
            set { _orderID = value; }
        }
        #endregion

        #region Methods
        public void CalculateTotalPrice()
        {
            _totalPrice = Pizza.Price * _numberOfPizzasInOrder + 40;
        }
        public override string ToString()
        {
            return $"Order {OrderID}: {NumberOfPizzasInOrder} x {Pizza.Name} for {Customer.CustomerName}";
        }
        #endregion
    }
}
