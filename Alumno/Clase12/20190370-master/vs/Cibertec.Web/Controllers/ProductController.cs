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
    // Le decimos que el usuario deben de estar previamente logueado
    [Authorize]
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork unit) : base(unit)
        {
        }

        // GET: Product
        public ActionResult Index()
        {
            // obtener la lista de productos de la BD
            var products = unitOfWork.Products.GetListWithDetails();

            // enviar el listado a la vista
            return View(products);
        }

        private IEnumerable<SelectListItem> ObtenerDesplegableProveedores()
        {
            // obtener la lista de proveedores de la BD
            var proveedores = unitOfWork.Suppliers.GetList();
            var lista = proveedores.Select(p => new SelectListItem { Text = $"{p.CompanyName} - {p.ContactName}", Value = p.Id.ToString() });

            return lista;
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            // obtener la lista de items para el desplegable
            var lista = ObtenerDesplegableProveedores();

            // enviar una lista de elemento SelectListItem a la vista
            ViewBag.SupplierList = lista;
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            // validamos el modelo (validacón en el servidor)
            if (ModelState.IsValid)
            {
                // insertamos el producto en BD
                var nuevoId = unitOfWork.Products.Insert(product);

                // si no hay errores, redireccionar al index
                return RedirectToAction("Index");
            }

            // si hay errores de validación, mostrar el formulario nuevamente con dichos errores
            return View(product);
        }
        // GET: Product/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Product producto)
        {
            if(ModelState.IsValid)
            {
                var resultado = unitOfWork.Products.Update(producto);
                if (resultado) return RedirectToAction("Index");
                ModelState.AddModelError("", "Ocurrio un error al tratar de guardar en la BD");
            }

            var listaProveedores = ObtenerDesplegableProveedores();
            ViewBag.SupplierList = listaProveedores;

            return View(producto);
        }


        // POST: Product/Delete/{id}
        public ActionResult Delete(int id)
        {
            var producto = unitOfWork.Products.GetById(id);
            return View(producto);
        }

        // Post: Product/Delete/{id}
        /*public ActionResult DeletePost (int id)
        {
            var productoEliminar un unitOfWork.Productos.GetById(id);
            var resultado = unitOfWork.Products.Delete
        }
        */

    }
}