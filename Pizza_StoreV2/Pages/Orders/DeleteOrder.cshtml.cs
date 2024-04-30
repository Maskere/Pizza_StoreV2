using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Orders
{
    public class DeleteOrderModel : PageModel
    {
        private IOrderRepository repo;
        [BindProperty]
        public Order Order { get; set; }
        public Pizza pizza {  get; set; }
        public DeleteOrderModel(IOrderRepository Repo) 
        {
            repo = Repo;
        }
        public IActionResult OnGet(int id)
        {
            Order = repo.SearchForOrderById(id);
            return Page();
        }
        public IActionResult OnPost(int id) 
        {
            repo.DeleteOrderById(id);
            return RedirectToPage("GetAllOrders");
        }
    }
}
