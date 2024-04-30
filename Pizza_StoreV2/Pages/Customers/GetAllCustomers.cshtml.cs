using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;
namespace Pizza_StoreV2.Pages.Customers
{
    public class GetAllCustomersModel : PageModel
    {
        private ICustomerRepository repo;
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }
        public GetAllCustomersModel(ICustomerRepository Repo) 
        {
            repo = Repo;
        }
        public List<Customer> Customers { get; private set; }
        public IActionResult OnGet()
        {
            Customers = repo.GetAllCustomers();
            if (!string.IsNullOrEmpty(FilterCriteria)) { Customers = repo.FilterCustomers(FilterCriteria); }
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
