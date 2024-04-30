using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Customers
{
    public class DeleteCustomerModel : PageModel
    {
        private ICustomerRepository repo;
        [BindProperty]
        public Customer Customer {  get; set; }
        public DeleteCustomerModel(ICustomerRepository Repo) 
        {
            repo = Repo;
        }
        public IActionResult OnGet(int id)
        {
            Customer = repo.SearchForCustomerById(id);
            return Page();
        }
        public IActionResult OnPost(int id) 
        {
            repo.DeleteACustomerById(id);
            return RedirectToPage("GetAllCustomers");
        }
    }
}
