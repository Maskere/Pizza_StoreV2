using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Catalogs;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class EditPizzaModel : PageModel
    {
        private FakePizzaRepository repo;
        [BindProperty]
        public Pizza Pizza { get; set; }
        public EditPizzaModel() 
        {
            repo = FakePizzaRepository.Instance;
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
