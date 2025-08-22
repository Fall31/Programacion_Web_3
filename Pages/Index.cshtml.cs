using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
namespace RazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly int pageSize = 5;

        public List<Tarea> Tareas { get; set; } = new();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? FiltroEstado { get; set; }

        public void OnGet(int pageNumber = 1)
        {
            var todasLasTareas = new List<Tarea>
            {
                new Tarea { Id=1, Nombre="Estudiar C#", FechaVencimiento=DateTime.Now.AddDays(2), Estado="Pendiente" },
                new Tarea { Id=2, Nombre="Preparar reunión", FechaVencimiento=DateTime.Now.AddDays(5), Estado="Finalizada" },
                new Tarea { Id=3, Nombre="Enviar informe", FechaVencimiento=DateTime.Now.AddDays(1), Estado="Pendiente" },
                new Tarea { Id=4, Nombre="Hacer ejercicio", FechaVencimiento=DateTime.Now.AddDays(7), Estado="Cancelada" },
                new Tarea { Id=5, Nombre="Pagar servicios", FechaVencimiento=DateTime.Now.AddDays(3), Estado="Pendiente" },
                new Tarea { Id=6, Nombre="Leer libro", FechaVencimiento=DateTime.Now.AddDays(10), Estado="Pendiente" },
                new Tarea { Id=7, Nombre="Organizar escritorio", FechaVencimiento=DateTime.Now.AddDays(4), Estado="Finalizada" },
                new Tarea { Id=8, Nombre="Escribir reportes", FechaVencimiento=DateTime.Now.AddDays(8), Estado="En curso" }
            };
            if(!string.IsNullOrEmpty(FiltroEstado)&& FiltroEstado != "Todos")
            {
                todasLasTareas = todasLasTareas
                    .Where(t=>t.Estado == FiltroEstado)
                    .ToList();
            }
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(todasLasTareas.Count / (double)pageSize);

            Tareas = todasLasTareas
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
        }
    }
}
