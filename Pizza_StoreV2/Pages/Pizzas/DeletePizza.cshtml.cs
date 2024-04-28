using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class DeletePizzaModel : PageModel
    {
        //private FakePizzaRepository repo;
        private IPizzaRepository repo;
        [BindProperty]
        public Pizza Pizza { get; set; }
        public DeletePizzaModel(IPizzaRepository Repo) 
        {
            repo = Repo;
        }
        public IActionResult OnGet(int id)
        {
            Pizza = repo.SearchForPizzaById(id);
            return Page();
        }
        public IActionResult OnPost(int id) 
        {
            repo.DeletePizzaById(id);
            return RedirectToPage("GetAllPizzas");
        }
    }
}
