using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages
{
    public class GetAllPizzasModel : PageModel
    {
        //private FakePizzaRepository repo;
        private IPizzaRepository repo;
        [BindProperty(SupportsGet =true)]
        public string FilterCriteria { get; set; }
        public GetAllPizzasModel(IPizzaRepository Repo)
        {
            repo = Repo;
        }
        public List<Pizza> Pizzas { get; private set; }
        public IActionResult OnGet()
        {
            Pizzas = repo.GetAllPizzas();
            if (!string.IsNullOrEmpty(FilterCriteria)) { Pizzas = repo.FilterPizzas(FilterCriteria); }
            return Page();
        }
        public IActionResult OnPost() 
        {
            return Page();
        }
    }
}
