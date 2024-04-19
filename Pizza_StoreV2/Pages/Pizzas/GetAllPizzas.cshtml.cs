using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages
{
    public class GetAllPizzasModel : PageModel
    {
        private FakePizzaRepository repo;
        private PizzaCatalog PizzaCatalog;
        public GetAllPizzasModel()
        {
            PizzaCatalog = new PizzaCatalog();
            repo = FakePizzaRepository.Instance;
        }
        public List<Pizza> Pizzas { get; private set; }
        public IActionResult OnGet()
        {
            Pizzas = repo.GetAllPizzas();
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
