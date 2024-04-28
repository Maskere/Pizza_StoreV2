using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pizza_StoreV2.Interface;
using Pizza_StoreV2.Models;

namespace Pizza_StoreV2.Pages.Orders
{
    public class EditOrderModel : PageModel
    {
        //private FakeOrderRepository repo;
        //private FakeCustomerRepository customerRepo;
        //private FakePizzaRepository pizzaRepo;
        private IOrderRepository orderRepo;
        private ICustomerRepository customerRepo;
        private IPizzaRepository pizzaRepo;
        [BindProperty]
        public Order Order { get; set; }
        public Customer Customer { get; set; }
        public Pizza Pizza { get; set; }
        public EditOrderModel(IOrderRepository OrderRepo, ICustomerRepository CustomerRepo, IPizzaRepository PizzaRepo) 
        {
            repo = FakeOrderRepository.Instance;
            customerRepo = FakeCustomerRepository.Instance;
            pizzaRepo = FakePizzaRepository.Instance;
        }
        public IActionResult OnGet(int id)
        {
            Order = orderRepo.SearchForOrderById(id);
            return Page();
        }
        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            orderRepo.UpdateOrder(Order);
            return RedirectToPage("GetAllOrders");
        }
    }
}
