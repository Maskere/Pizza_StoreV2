using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Pizza_StoreV2.Pages.Orders
{
    public class CreateOrderModel : PageModel
    {
        //private FakeOrderRepository repo;
        //private FakePizzaRepository pizzaRepo;
        //private FakeCustomerRepository customerRepo;
        private IPizzaRepository pizzaRepo;
        private IOrderRepository orderRepo;
        private ICustomerRepository customerRepo;
        public SelectList PizzaList { get; set; }
        public SelectList CustomerList { get; set; }
        [BindProperty] 
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public CreateOrderModel(IOrderRepository OrderRepo, IPizzaRepository pizzaRepo, ICustomerRepository customerRepo) 
        {
            //repo = FakeOrderRepository.Instance;
            //pizzaRepo = FakePizzaRepository.Instance;
            //customerRepo = FakeCustomerRepository.Instance;
            OrderRepo = orderRepo;
            PizzaList = new SelectList(pizzaRepo.GetAllPizzas());
            CustomerList = new SelectList(customerRepo.GetAllCustomers());
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (orderRepo.GetOrders().Count < Order.OrderID)
            {
                orderRepo.AddOrder(Order);
            }
            return RedirectToPage("GetAllOrders");
        }
        public IActionResult OnGet(int id)
        {
            return Page();
        }
    }
}
