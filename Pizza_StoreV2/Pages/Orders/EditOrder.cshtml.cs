using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Orders
{
    public class EditOrderModel : PageModel
    {
        private FakeOrderRepository repo;
        private FakeCustomerRepository CustomerRepo;
        private FakePizzaRepository PizzaRepo;
        [BindProperty]
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public EditOrderModel() 
        {
            repo = FakeOrderRepository.Instance;
            CustomerRepo = FakeCustomerRepository.Instance;
            PizzaRepo = FakePizzaRepository.Instance;
        }
        public IActionResult OnGet(int id)
        {
            Order = repo.SearchForOrderById(id);
            return Page();
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateOrder(Order);
            return RedirectToPage("GetAllOrders");
        }
    }
}
