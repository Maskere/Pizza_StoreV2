using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pizza_StoreV2.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<Order> Orders { get; set; }
        public FakeOrderRepository repo;
        public FakePizzaRepository pizzaRepo;
        public FakeCustomerRepository customerRepo;
        public CreateOrderModel() 
        {
            Order = new Order();
            Customer = new Customer();
            Pizza = new Pizza();
            Orders = new List<Order>();
            Pizzas = new List<Pizza>();
            Customers = new List<Customer>();
            repo = FakeOrderRepository.Instance;
            pizzaRepo = FakePizzaRepository.Instance;
            customerRepo = FakeCustomerRepository.Instance;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (repo.Orders.Count < Order.OrderID)
            {
                repo.AddOrder(Order);
            }
            return RedirectToPage("GetAllOrders");
        }
        public IActionResult OnGet()
        {

            return Page();
        }
    }
}
