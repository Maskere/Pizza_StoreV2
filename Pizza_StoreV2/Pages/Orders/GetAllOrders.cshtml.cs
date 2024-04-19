using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;
using System.Collections.Generic;
namespace Pizza_StoreV2.Pages.Orders
{
    public class GetAllOrdersModel : PageModel
    {
        private FakeOrderRepository repo;
        public GetAllOrdersModel() 
        {
            repo =FakeOrderRepository.Instance;
        }
        public List<Order> Orders { get; private set; }
        public IActionResult OnGet()
        {
            Orders = repo.GetAllOrders();
            return Page();
        }
        public IActionResult OnPost() 
        {
            return Page();
        }
    }
}
