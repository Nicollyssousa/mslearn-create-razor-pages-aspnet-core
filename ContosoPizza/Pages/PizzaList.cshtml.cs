using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoPizza.Models;
using ContosoPizza.Services;

namespace ContosoPizza.Pages
{
    public class PizzaListModel : PageModel
    {
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
    }
}
