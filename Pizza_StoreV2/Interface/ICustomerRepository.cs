﻿using Pizza_StoreV2.Models;
using System.Collections.Generic;

namespace Pizza_StoreV2.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer();
        //private static FakeCustomerRepository _instance;
        //public ICustomerRepository()
        //{
        //    Customers = new List<Customer>();
        //    Customers.Add(new Customer() { CustomerName = "Miki", CustomerId = 1, PhoneNumber = "4053 7194" });
        //    Customers.Add(new Customer() { CustomerName = "Julie", CustomerId = 2, PhoneNumber = "4294 0853" });
        //    Customers.Add(new Customer() { CustomerName = "Jais", CustomerId = 3 });
        //}
        //public static FakeCustomerRepository Instance
        //{
        //    get
        //    {
        //        if (_instance == null) { _instance = new FakeCustomerRepository(); }
        //        return _instance;
        //    }
        //}
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
