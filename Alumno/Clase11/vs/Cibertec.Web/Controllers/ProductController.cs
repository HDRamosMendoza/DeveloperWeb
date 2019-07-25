using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;
using Cibertec.Models;

namespace Cibertec.Web.Controllers
{
    //public class ProductController : Controller
    public class ProductController : BaseController
    {
        //private readonly IUnitOfWork unitOfWork;
        public ProductController (IUnitOfWork unit):base(unit)
        {
            // Instanciar el unit of work con la cadena de conexion.
            // unitOfWork = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindLite"].ConnectionString);

            // Inyectar la dependencia
            // unitOfWork = unit;


        }

        // GET: Product
        public ActionResult Index()
        {
            // Obtener la lista de productos de la BD
            //var products = unitOfWork.Products.GetList();
            var products = unitOfWork.Products.GetListWithDetails();

            // Enviar el listado a la vista.
            return View(products);
        }

        public ActionResult Create()
        {
            // obtener la lista de proveedores de la bd.
            var proveedores = unitOfWork.Suppliers.GetList();

            ViewBag.SupplierList = proveedores.Select(p => new SelectListItem { Text = $"" });
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Insertamos el producto en BD.
                var nuevoId = unitOfWork.Products.Insert(product);

                // Si no hay errores, redireccionar al index.
                return RedirectToAction("Index");
            }

            // Si hay errores de validacion, mostrar el formulario nuevamente con dichos errores.
            return View(product);
        }
    }
}