using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;

namespace Pizza_StoreV2.Catalogs
{
    public class CustomerCatalog
    {
        List<Customer> Customers;
        private static CustomerCatalog _instance;
        public CustomerCatalog()
        {
            Customers = new List<Customer>();
            Customers.Add(new Customer() { CustomerName = "Miki", CustomerId = 1, PhoneNumber = "4053 7194" });
            Customers.Add(new Customer() { CustomerName = "Julie", CustomerId = 2, PhoneNumber = "4294 0853" });
            Customers.Add(new Customer() { CustomerName = "Jais", CustomerId = 3 });
        }
        public static CustomerCatalog Instance 
        {
            get 
            {
                if (_instance == null) 
                {
                    _instance = new CustomerCatalog();
                    
                }
                return _instance;
            }
        }
        public int Count
        {
            get { return Customers.Count; }
        }
        public Customer GetNewCustomer(string customerName, int customerId)
        {
            Customer customer = new Customer();
            customer.CustomerName = customerName;
            customer.CustomerId = customerId;
            if (Customers[customerId] != null) { return null; }
            return customer;
        }
        public void CreateACustomer(Customer customer)
        {
            Customers.Insert(customer.CustomerId, customer);
        }
        public void DeleteACustomer(int CustomerId)
        {
            Customers.Insert(CustomerId, new Customer() { CustomerName = "", CustomerId = CustomerId });
            Customers.RemoveAt(CustomerId + 1);
        }
        public Customer SeachForCustomerById(int customerId)
        {
            Customer findCustomer = Customers[customerId];
            return findCustomer;
        }
        public void UpdateCustomer(Customer updatedCustomer)
        {
            if (Customers.Contains(updatedCustomer))
            {
                updatedCustomer = null;
            }
            else
            {
                Customers.RemoveAt(updatedCustomer.CustomerId);
                Customers.Insert(updatedCustomer.CustomerId, updatedCustomer);
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
        public void Clear()
        {
            Customers.Clear();
            Customers = new List<Customer>(new Customer[10]);
        }
        public void RemoveAt(int removeAt)
        {
            Customers.RemoveAt(removeAt);
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
        public void AddCustomer(Customer customer) 
        {
            Customers.Add(customer);
        }
    }
}
