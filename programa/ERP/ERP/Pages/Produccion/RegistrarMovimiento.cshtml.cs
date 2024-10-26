using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ERP.Pages.Produccion
{
    public class RegistrarMovimientoModel : PageModel
    {
        public List<Articulo> articulosDisponibles { get; set; }
        public bool mostrarModal { get; set; }

        public void OnGet()
        {
            articulosDisponibles = obtenerArticulosDisponibles();
        }

        public List<Articulo> obtenerArticulosDisponibles()
        {
            // Aquí iría la consulta SQL para obtener los artículos disponibles
            return new List<Articulo>
            {
                new Articulo ("Papas Zibas", "A001", "Chiverias", 1101, 125.0, "Esa es", "Papas alv alv", 250.0)
            };
        }

        public void OnPostMostrarModal()
        {
            mostrarModal = true;
            articulosDisponibles = obtenerArticulosDisponibles();
        }

        public void OnPostCerrarModal()
        {
            mostrarModal = false;
            articulosDisponibles = obtenerArticulosDisponibles();
        }
    }
}