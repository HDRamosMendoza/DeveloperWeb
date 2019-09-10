using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Cibertec.DemoBackend.Models
{
    public class ColegioDbContextInitializer : DropCreateDatabaseAlways<ColegioDbContext>
    {
        protected override void Seed(ColegioDbContext context)
        {
            IList<Alumno> defaultAlumnos = new List<Alumno>
            {
                new Alumno
                {
                    Id = 1,
                    Nombre = "Juan Pérez",
                    Edad = 11,
                    Foto = "",
                    Grado = "Sexto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 2,
                    Nombre = "Sandra Gómez",
                    Edad = 11,
                    Foto = "",
                    Grado = "Sexto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 3,
                    Nombre = "Jorge Ramírez",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 4,
                    Nombre = "José Robles",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "B"
                },
                new Alumno
                {
                    Id = 5,
                    Nombre = "María Paredes",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 6,
                    Nombre = "Roberto Guzmán",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 7,
                    Nombre = "Adriana Ramos",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "B"
                }
            };

            context.Alumnos.AddRange(defaultAlumnos);

            base.Seed(context);
        }
    }
    public class ColegioDbContext : DbContext
    {
        public ColegioDbContext() : base()
        {
            Database.SetInitializer(new ColegioDbContextInitializer());
        }

        public DbSet<Alumno> Alumnos { get; set; }
    }
}