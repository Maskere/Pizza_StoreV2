using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pizza_StoreV2.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer();
        public void AddCustomer(Customer customer);
        public List<Customer> GetAllCustomers();
        public Customer SearchForCustomerById(int customerId)
        {
            Customer findCustomer = GetCustomers()[customerId - 1];
            return findCustomer;
        }
        public void RemoveCustomer(Customer customer, int id)
        {
            if (customer != null)
                GetCustomers().Remove(customer);
        }
        public void DeleteACustomerById(int CustomerId)
        {
            GetCustomers().RemoveAt(CustomerId - 1);
        }
        public List<Customer> FilterCustomers(string filter)
        {
            List<Customer> filteredList = new List<Customer>();
            foreach (Customer customer in GetCustomers())
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
