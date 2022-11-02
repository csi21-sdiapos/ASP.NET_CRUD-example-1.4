using System;
using System.Collections.Generic;
using ASP.NET_CRUD_example_1._4_DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ASP.NET_CRUD_example_1._4_DAL.DataContexts
{
    public partial class aspnetcrudexample13Context : DbContext
    {
        public aspnetcrudexample13Context()
        {
        }

        public aspnetcrudexample13Context(DbContextOptions<aspnetcrudexample13Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; } = null!;
        public virtual DbSet<Asignatura> Asignaturas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=asp.net-crud-example-1.3;UserId=postgres;Password=12345;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasMany(d => d.ListaAsignaturas)
                    .WithMany(p => p.ListaAlumnos)
                    .UsingEntity<Dictionary<string, object>>(
                        "AlumnoAsignatura",
                        l => l.HasOne<Asignatura>().WithMany().HasForeignKey("ListaAsignaturasId"),
                        r => r.HasOne<Alumno>().WithMany().HasForeignKey("ListaAlumnosId"),
                        j =>
                        {
                            j.HasKey("ListaAlumnosId", "ListaAsignaturasId");

                            j.ToTable("AlumnoAsignatura");

                            j.HasIndex(new[] { "ListaAsignaturasId" }, "IX_AlumnoAsignatura_ListaAsignaturasId");
                        });
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
