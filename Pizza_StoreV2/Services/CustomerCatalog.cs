using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;
using Pizza_StoreV2.Interface;

namespace Pizza_StoreV2.Services
{
    public class CustomerCatalog
    {
        List<Customer> Customers;
        public CustomerCatalog()
        {
            Customers = new List<Customer>();  
        }
        public int Count
        {
            get { return Customers.Count; }
        }
        public void UpdateCustomer(Customer customer)
        {
            if (customer != null)
            {
                foreach (var e in AllCustomers())
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
        public Customer SearchCustomerByName(string customerName)
        {

            foreach (Customer customer in Customers)
            {
                if (customer != null)
                {
                    if (string.Equals(customer.CustomerName, customerName)) return customer;
                }
            }
            return null;
        }
        public void PrintCustomerList()
        {
            foreach (Customer customer in Customers)
            {
                if (customer != null)
                {
                    Console.WriteLine($"| {customer} |");
                }
                else
                {
                    Console.WriteLine("   ...");
                }
            }
        }
        public List<Customer> AllCustomers()
        {
            return Customers;
        }
    }
}
