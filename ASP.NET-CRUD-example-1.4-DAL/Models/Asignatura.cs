using System;
using System.Collections.Generic;

namespace ASP.NET_CRUD_example_1._4_DAL.Models
{
    public partial class Asignatura
    {
        public Asignatura()
        {
            ListaAlumnos = new HashSet<Alumno>();
        }

        public int Id { get; set; }
        public string AsignaturaNombre { get; set; } = null!;

        public virtual ICollection<Alumno> ListaAlumnos { get; set; }
    }
}
