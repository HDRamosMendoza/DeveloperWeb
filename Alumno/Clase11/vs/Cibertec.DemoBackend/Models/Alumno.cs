using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cibertec.DemoBackend.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Foto { get; set; }
        public int Edad { get; set; }
        public string Seccion { get; set; }
        public string Grado { get; set; }
    }
}