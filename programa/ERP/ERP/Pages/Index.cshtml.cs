using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ERP.Pages
{
    public class IndexModel : PageModel
    {

        [BindProperty]
        public string Usuario { get; set; } = "";

        [BindProperty]
        public string Contrasenia { get; set; } = "";

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public IActionResult OnPost()
        {
            // Guardar el usuario en la sesión
            HttpContext.Session.SetString("Usuario", Usuario);
            if (Usuario == "V" | Usuario == "v")
            {
                return RedirectToPage("Ventas/PaginaPrincipalVentas");
            }
            else if (Usuario == "R" | Usuario == "r")
            {
                return RedirectToPage("RRHH/Empleados");
            }
            else if (Usuario == "A" | Usuario == "a"){

                return RedirectToPage("Administrador/PaginaPrincipal");
            }

            else
            {
                return RedirectToPage("Produccion/PaginaPrincipalProduccion");
            }

                


            // Redirigir a la página principal (por ejemplo, un dashboard)




        }
    }
}
