using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Customers
{
    public class EditCustomerModel : PageModel
    {
        private FakeCustomerRepository repo;
        [BindProperty]
        public Customer Customer { get; set; }
        public EditCustomerModel()
        {
            repo = FakeCustomerRepository.Instance;
        }
        public IActionResult OnGet(int id)
        {
            Customer = repo.SearchForCustomerById(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateCustomer(Customer);
            return RedirectToPage("GetAllCustomers");
        }
    }
}
