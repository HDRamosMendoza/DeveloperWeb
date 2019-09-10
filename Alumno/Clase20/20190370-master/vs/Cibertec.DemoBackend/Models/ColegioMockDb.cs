using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.DemoBackend.Models
{
    public class ColegioMockDb
    {
        public List<Alumno> Alumnos { get; set; }
        public ColegioMockDb()
        {
            Alumnos = new List<Alumno>
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
                    Id = 1,
                    Nombre = "María Paredes",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 1,
                    Nombre = "Roberto Guzmán",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "A"
                },
                new Alumno
                {
                    Id = 1,
                    Nombre = "Adriana Ramos",
                    Edad = 10,
                    Foto = "",
                    Grado = "Quinto",
                    Seccion = "B"
                }
            };
        }
    }
}