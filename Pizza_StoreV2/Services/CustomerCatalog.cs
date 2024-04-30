using Pizza_StoreV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public void RemoveCustomer(Customer customer)
        {
            if (customer != null)
                Customers.Remove(customer);
        }
        public Customer SeachForCustomerById(int customerId)
        {
            Customer findCustomer = Customers[customerId];
            return findCustomer;
        }
        //public void UpdateCustomer(Customer updatedCustomer)
        //{
        //    if (Customers.Contains(updatedCustomer))
        //    {
        //        updatedCustomer = null;
        //    }
        //    else
        //    {
        //        Customers.RemoveAt(updatedCustomer.CustomerId);
        //        Customers.Insert(updatedCustomer.CustomerId, updatedCustomer);
        //    }
        //}
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

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer()
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetAllCustomers()
        {
            throw new NotImplementedException();
        }
    }
}
