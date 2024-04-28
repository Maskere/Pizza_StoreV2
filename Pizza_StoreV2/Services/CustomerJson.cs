﻿using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Pages;
using Pizza_StoreV2.Helpers;
namespace Pizza_StoreV2.Services
{
    public class CustomerJson : ICustomerRepository
    {
        string fileName = @"C:\Users\mstac\Documents\Pizza_StoreV2 - kopi\Pizza_StoreV2\Data\jsonCustomer.json";
        private List<Customer> Customers;
        public int Count
        {
            get { return Customers.Count; }
        }
        public void AddCustomer(Customer customer)
        {
            Customers = jsonFileReaderCustomer.ReadJson(fileName);
            Customers.Add(customer);
            Helpers.jsonFileWriterCustomer.WriteToJson(Customers,fileName);
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
        public Customer GetNewCustomer(string customerName, int customerId)
        {
            Customer customer = new Customer();
            customer.CustomerName = customerName;
            customer.CustomerId = customerId;
            if (Customers[customerId] != null) { return null; }
            return customer;
        }
        public void AddCustomer1(Customer customer)
        {
            Customers.Add(customer);
        }
        public void AddCustomer11(Customer customer)
        {
            
        }

        public List<Customer> GetAllCustomers()
        {
            throw new System.NotImplementedException();
        }

        public Customer GetCustomer()
        {
            throw new System.NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}