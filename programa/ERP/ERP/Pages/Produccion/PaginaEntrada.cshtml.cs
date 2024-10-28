using ERP.Pages.Objetos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP.Pages.Produccion
{
    public class PaginaEntradaModel : PageModel
    {
        public List<Entrada> entradas = new List<Entrada>();
        public void OnGet()
        {
        }
    }
}
