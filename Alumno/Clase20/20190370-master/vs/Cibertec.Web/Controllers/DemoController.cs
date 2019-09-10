using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Web.Controllers
{
    public class DemoController : Controller
    {
        // /Demo
        public string Index()
        {
            return "Esta es la <b>acción</b> principal del controlador Demo";
        }

        public ActionResult IndexAlterno(int repeticiones = 0)
        {
            // pasar variables a la vista
            ViewBag.DataDinamica = "Data dinámica";
            ViewBag.Repeticiones = repeticiones;
            return View();
        }

        public string Bienvenido(string nombre, int visitas)
        {
            return $"Hola {nombre}. Tus visitas son: {visitas}";
        }

        public ActionResult ShowPartial()
        {
            return PartialView("_LoginPartial");
        }
    }
}