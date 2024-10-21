using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP.Pages.Objetos;

namespace ERP.Pages.Ventas
{
    public class CrearCotizacionModel : PageModel
    {
        public string nombreCliente;
        public DateTime fechaHoy = DateTime.Now;
        public void OnGet()
        {
            nombreCliente = "";
            fechaHoy = DateTime.Today;
        }

        public void OnPost()
        {
           
        }

    }
}
