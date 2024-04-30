using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Pizza_StoreV2.Interface;
namespace Pizza_StoreV2.Pages.Customers
{
    public class CreateCustomerModel : PageModel
    {
        //private FakeCustomerRepository repo;
        private ICustomerRepository repo;
        [BindProperty]
        public Customer Customer { get; set; }
        public CreateCustomerModel(ICustomerRepository repository)
        {
            //repo = FakeCustomerRepository.Instance;
            repo = repository;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if(repo.GetAllCustomers().Count<Customer.CustomerId)
            {
                repo.AddCustomer(Customer);
            }
            return RedirectToPage("GetAllCustomers");
        }
        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
