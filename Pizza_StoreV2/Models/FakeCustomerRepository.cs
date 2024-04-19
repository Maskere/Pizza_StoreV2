using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_StoreV2.Models
{
    public class FakeCustomerRepository
    {
        private List<Customer> Customers { get; }
        private static FakeCustomerRepository _instance;
        public FakeCustomerRepository() 
        {
            Customers = new List<Customer>();
            Customers.Add(new Customer() { CustomerName = "Miki", CustomerId = 1, PhoneNumber = "4053 7194" });
            Customers.Add(new Customer() { CustomerName = "Julie", CustomerId = 2, PhoneNumber = "4294 0853" });
            Customers.Add(new Customer() { CustomerName = "Jais", CustomerId = 3 });
        }
        public static FakeCustomerRepository Instance 
        {
            get 
            {
                if (_instance == null) { _instance = new FakeCustomerRepository(); } return _instance;
            }
        }
        public void AddCustomer(Customer customer) { Customers.Add(customer); }
        public List<Customer> GetAllCustomers() { return Customers; }
        public Customer SearchForCustomerById(int customerId)
        {
            Customer findCustomer = Customers[customerId - 1];
            return findCustomer;
        }
        public void RemoveCustomer(Customer customer, int id) 
        {
            if (customer != null)
                Customers.Remove(customer);
        }
        public void DeleteACustomerById(int CustomerId)
        {
            Customers.RemoveAt(CustomerId-1);
        }
        public List<Customer> FilterCustomers(string filter)
        {
            List<Customer> filteredList = new List<Customer>();
            foreach (Customer customer in Customers)
            {
                if (customer.CustomerName.Contains(filter, System.StringComparison.OrdinalIgnoreCase))
                {
                    filteredList.Add(customer);
                }
            }
            return filteredList;
        }
        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                foreach (var e in GetAllCustomers())
                {
                    if (e.CustomerId == customer.CustomerId)
                    {
                        e.CustomerId = customer.CustomerId;
                        e.CustomerName = customer.CustomerName;
                        e.PhoneNumber = customer.PhoneNumber;
                        e.Email = customer.Email;
                    }
                }
            }
        }
    }
}
