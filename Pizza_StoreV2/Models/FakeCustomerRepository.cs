using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using System.Collections.Generic;
using System.Linq;
namespace Pizza_StoreV2.Models
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        private List<Customer> Customers { get; }
        public FakeCustomerRepository() 
        {

        }
        public void AddCustomer(Customer customer) { Customers.Add(customer); }
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

        public List<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomer()
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            return Customers;
        }
    }
}
