using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Catalogs;
using System.ComponentModel.DataAnnotations;

namespace Pizza_StoreV2.Models
{
    public class Order
    {
        #region Instance Field
        [BindProperty]
        public Pizza Pizza { get; set; }
        public Customer Customer { get; set; }
        private int _numberOfPizzasInOrder;
        private int _orderID;
        private double _totalPrice;
        #endregion

        #region Constructor
        public Order()
        {
            _orderID = OrderID;
            Customer = new Customer();
            Pizza = new Pizza();
            _numberOfPizzasInOrder = NumberOfPizzasInOrder;
            _totalPrice = TotalPrice;
        }
        #endregion

        #region Properties
        public int NumberOfPizzasInOrder
        {
            get { return _numberOfPizzasInOrder; }
            set { _numberOfPizzasInOrder = value; }
        }
        [DataType(DataType.Currency)]
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
            _totalPrice = (double)Pizza.Price * _numberOfPizzasInOrder + 40;
        }
        public override string ToString()
        {
            return $"Order {OrderID}: {NumberOfPizzasInOrder} x {Pizza.Name} for {Customer.CustomerName}";
        }
        #endregion
    }
}
