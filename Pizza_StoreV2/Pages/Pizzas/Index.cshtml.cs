using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;
using System.Collections.Generic;

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class IndexModel : PageModel
    {
        private FakePizzaRepository repo;
        public List<Pizza> Pizzas { get; private set; }
        public IndexModel() 
        {
            repo = new FakePizzaRepository();
        }
        public void OnGet()
        {
            Pizzas = repo.GetAllPizzas();
        }
    }
}
