using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;
using System.Collections.Generic;

namespace Pizza_StoreV2.Pages.Customers
{
    public class GetAllCustomersModel : PageModel
    {
        private CustomerCatalog customerCatalog;
        private FakeCustomerRepository repo;
        public GetAllCustomersModel() 
        {
            customerCatalog = new CustomerCatalog();
            repo = FakeCustomerRepository.Instance;
        }
        [BindProperty]
        public List<Customer> Customers { get; set; }
        public IActionResult OnGet()
        {
            Customers = repo.GetAllCustomers();
            return Page();
        }
        public IActionResult OnPost() 
        {
            return Page();
        }
    }
}
