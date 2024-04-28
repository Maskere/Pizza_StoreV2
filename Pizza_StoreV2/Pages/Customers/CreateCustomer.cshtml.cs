using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using Pizza_StoreV2.Catalogs;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Pizza_StoreV2.Pages.Customers
{
    public class CreateCustomerModel : PageModel
    {
        private FakeCustomerRepository Repo;
        [BindProperty]
        public Customer Customer { get; set; }
        public CreateCustomerModel()
        {
            Repo = FakeCustomerRepository.Instance;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(Repo.GetAllCustomers().Count()<Customer.CustomerId)
            {
                Repo.AddCustomer(Customer);
            }
            return RedirectToPage("GetAllCustomers");
        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
