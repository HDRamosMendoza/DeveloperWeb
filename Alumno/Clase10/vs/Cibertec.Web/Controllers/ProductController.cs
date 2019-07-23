using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;

namespace Cibertec.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ProductController ()
        {
            // Instanciar el unit of work con la cadena de conexion.
            unitOfWork = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindLite"].ConnectionString);
        }

        // GET: Product
        public ActionResult Index()
        {
            // Obtener la lista de productos de la BD
            var products = unitOfWork.Products.GetList();

            // Enviar el listado a la vista.
            return View(products);
        }
    }
}