using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Pizzas
{
    public class DeletePizzaModel : PageModel
    {
        private FakePizzaRepository repo;
        [BindProperty]
        public Pizza Pizza { get; set; }
        public DeletePizzaModel() 
        {
            repo = FakePizzaRepository.Instance;
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
