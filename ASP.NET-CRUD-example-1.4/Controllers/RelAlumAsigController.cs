using ASP.NET_CRUD_example_1._4.Models;
using ASP.NET_CRUD_example_1._4_DAL.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CRUD_example_1._4.Controllers
{
    public class RelAlumAsigController : Controller
    {
        private readonly aspnetcrudexample13Context context;

        public RelAlumAsigController(aspnetcrudexample13Context context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var asignaturas = this.context.Asignaturas.Include(asig => asig.ListaAlumnos).Select(asig => new AsignaturaViewModel
            {
                AsignaturaNombre = asig.AsignaturaNombre,
                ListaAlumnos = String.Join(',', asig.ListaAlumnos.Select(alum => "\n" + alum.Id + ".\t" + alum.AlumnoNombre + " " + alum.AlumnoApellidos + " --> " + alum.AlumnoEmail + "\n")),
            });

            return View(asignaturas);
        }
    }
}
