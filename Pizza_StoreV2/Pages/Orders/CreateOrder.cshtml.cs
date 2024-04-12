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
        private Order order;
        private Customer customer;
        private Pizza pizza;
        public CreateOrderModel() 
        {
            order = new Order();
        }
        [BindProperty]
        public Order Order { get { return order; } }
        public IActionResult OnPost()
        {

            return RedirectToPage("GetAllPizzas");
        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
