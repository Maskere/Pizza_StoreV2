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

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class CreatePizzaModel : PageModel
    {
        private FakePizzaRepository repo;
        [BindProperty]
        public Pizza Pizza { get; set; }
        public CreatePizzaModel()
        {
            repo = FakePizzaRepository.Instance;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }
            if (repo.GetAllPizzas().Count<Pizza.PizzaId)
            {
                repo.AddPizza(Pizza);
            }
            return RedirectToPage("GetAllPizzas");
        }
        public IActionResult OnGet() 
        {
            return Page();
        }
    }
}
