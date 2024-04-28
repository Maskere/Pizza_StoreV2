using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class EditPizzaModel : PageModel
    {
        //private FakePizzaRepository repo;
        private IPizzaRepository repo;
        [BindProperty]
        public Pizza Pizza { get; set; }
        public EditPizzaModel(IPizzaRepository Repo) 
        {
            repo = Repo;
        }
        public IActionResult OnGet(int id)
        {
            Pizza = repo.SearchForPizzaById(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdatePizza(Pizza);
            return RedirectToPage("GetAllPizzas");
        }
    }
}
