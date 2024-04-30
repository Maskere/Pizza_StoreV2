using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;
using System.Collections.Generic;
namespace Pizza_StoreV2.Pages.Orders
{
    public class GetAllOrdersModel : PageModel
    {
        //private FakeOrderRepository repo;
        private IOrderRepository repo;
        [BindProperty(SupportsGet =true)]
        public string FilterCriteria { get; set; }
        public GetAllOrdersModel(IOrderRepository Repo) 
        {
            repo = Repo;
        }
        public List<Order> Orders { get; private set; }
        public IActionResult OnGet()
        {
            Orders = repo.GetOrders();
            if (!string.IsNullOrEmpty(FilterCriteria)) { /*Orders = repo.FilterOrder(FilterCriteria);*/ }
            return Page();
        }
        public IActionResult OnPost() 
        {
            return Page();
        }
    }
}
