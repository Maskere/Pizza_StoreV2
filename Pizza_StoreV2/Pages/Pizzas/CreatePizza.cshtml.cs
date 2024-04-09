using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class CreatePizzaModel : PageModel
    {
        private Pizza pizza;

        public CreatePizzaModel()
        {
            pizza = new Pizza();
            
        }
        [BindProperty]
        public Pizza Pizza { get { return pizza; } }
        
        public IActionResult OnPost()
        {

            return RedirectToPage("GetAllPizzas");
        }
        public void OnGet() 
        {
            
        }
    }
}
