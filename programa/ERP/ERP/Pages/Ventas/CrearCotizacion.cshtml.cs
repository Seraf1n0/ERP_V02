using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP.Pages.Objetos;

namespace ERP.Pages.Ventas
{
    public class CrearCotizacionModel : PageModel
    {
        [BindProperty]
        public Cotizacion Cotizacion { get; set; }

        public List<int> Probabilidades { get; set; }
        public List<string> Zonas { get; set; }
        public List<string> Sectores { get; set; }

        public void OnGet()
        {
            // Inicializa la propiedad Cotizacion para evitar null reference exception
            Cotizacion = new Cotizacion(0,"0", "0", 12.1f, DateTime.MinValue, DateTime.Now, 0, "nada", "este", "comercial", null);

            // Llenamos las listas con valores simulados o desde la base de datos
            Probabilidades = new List<int> { 0, 25, 50, 75, 100 };
            Zonas = new List<string> { "Norte", "Sur", "Este", "Oeste" };
            Sectores = new List<string> { "Comercial", "Residencial", "Industrial" };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) // Luego de validar errores
            {
                OnGet();
                return Page();
            }

            // Aquí el insert para Ventas.Cotizacion

            return RedirectToPage("Cotizacion");
        }

        // Métodos para obtener valores de tablas catálogo
        private List<int> ObtenerProbabilidades()
        {
            // Consulta para obtener la lista de probabilidades
            return new List<int>();
        }

        private List<string> ObtenerZonas()
        {
            // Consulta para obtener la lista de zonas
            return new List<string>();
        }

        private List<string> ObtenerSectores()
        {
            // Consulta para obtener la lista de sectores
            return new List<string>();
        }
    }
}
