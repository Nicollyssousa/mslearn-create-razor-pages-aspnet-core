using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; } = default!;
        private readonly PizzaService _Service;
        public IList<Pizza> PizzaList { get; set; }= default!;

        public PizzaListModel(PizzaService service)
        {
            _Service = service;
        }
        public void OnGet()
        {
            PizzaList = _Service.GetPizzas();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || NewPizza == null)
            {
                return Page();
            }

            _Service.AddPizza(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            _Service.DeletePizza(id);
            return RedirectToAction("Get");
        }
    }
}
