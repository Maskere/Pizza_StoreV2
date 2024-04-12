using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using Pizza_StoreV2.Catalogs;

namespace Pizza_StoreV2.Pages.Customers
{
    public class CreateCustomerModel : PageModel
    {
        private FakeCustomerRepository repo;
        [BindProperty]
        public Customer customer { get; set; }
        public CreateCustomerModel()
        {
            repo = FakeCustomerRepository.Instance;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {

                return Page();
            }
            else { }
            repo.AddCustomer(customer);
            return RedirectToPage("GetAllCustomers");
        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
