using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_StoreV2.Models
{
    public class FakeCustomerRepository
    {
        private List<Customer> customers { get; }
        private static FakeCustomerRepository _instance;
        public FakeCustomerRepository() 
        {
            customers = new List<Customer>();
            customers.Add(new Customer() { CustomerName = "Miki", CustomerId = 1, PhoneNumber = "4053 7194" });
            customers.Add(new Customer() { CustomerName = "Julie", CustomerId = 2, PhoneNumber = "4294 0853" });
            customers.Add(new Customer() { CustomerName = "Jais", CustomerId = 3 });
        }
        public static FakeCustomerRepository Instance 
        {
            get 
            {
                if (_instance == null) { _instance = new FakeCustomerRepository(); } return _instance;
            }
        }
        public void AddCustomer(Customer customer) { customers.Add(customer); }
        public List<Customer> GetAllCustomers() { return customers; }
    }
}
