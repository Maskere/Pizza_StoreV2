using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;
using System.Collections.Generic;
namespace Pizza_StoreV2.Pages.Orders
{
    public class GetAllOrdersModel : PageModel
    {
        private OrderCatalog catalog;
        public GetAllOrdersModel() 
        {
            catalog = new OrderCatalog();
        }
        public List<Order> Orders { get; private set; }
        public IActionResult OnGet()
        {
            Orders = catalog.AllOrders();
            return Page();
        }
        public IActionResult OnPost() 
        {
            return Page();
        }
    }
}
