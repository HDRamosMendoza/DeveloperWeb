using System;
using Cibertec.Repositories.Northwind;
using Cibertec.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;
using System.Linq;
using Cibertec.UnitOfWork;

namespace Cibertec.Pruebas
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IUnitOfWork unitOfWork;

        public UnitTest1()
        {
            unitOfWork = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindLite"].ConnectionString);
        }

        [TestMethod]
        public void CantidadDeRegistrosMayorA0()
        {
            var lista = unitOfWork.Products.GetList();
            Assert.AreEqual(true, lista.Count() > 0);
        }

        [TestMethod]
        public void CantidadDeRegistrosConPrecioMayorA100()
        {
            var lista = unitOfWork.Products.ObtenerConPrecioMayorA(100);
            Assert.AreEqual(2, lista.Count());
        }

        //[TestMethod]
        public void InsertarRegistro()
        {
            // insertar el registro y obtener el nuevo ID
            var id = unitOfWork.Products.Insert(new Product
            {
                ProductName = "Producto Prueba",
                SupplierId = 1,
                IsDiscontinued = false
            });

            // obtener el registro con el nuevo id
            var nuevoProducto = unitOfWork.Products.GetById(id);

            // compruebo
            Assert.AreEqual("Producto Prueba", nuevoProducto.ProductName);
        }

        [TestMethod]
        public void EliminarRegistro()
        {
            // insertar el registro y obtener el nuevo ID
            var id = unitOfWork.Products.Insert(new Product
            {
                ProductName = "Producto Prueba Eliminar",
                SupplierId = 1,
                IsDiscontinued = false
            });

            // obtener el registro con el nuevo id
            var nuevoProducto = unitOfWork.Products.GetById(id);

            // compruebo la inserción
            Assert.AreEqual("Producto Prueba Eliminar", nuevoProducto.ProductName);

            // borrar el producto creado anteriormente
            var resultadoBorrar = unitOfWork.Products.Delete(new Product { Id = id });

            // obtener el registro borrado
            var productoEliminado = unitOfWork.Products.GetById(id); // debería ser nulo

            Assert.AreEqual(null, productoEliminado);
        }

        //public void Prueba()
        //{
        //    var reporte = unitOfWork.Products.GenerarReporte(inicio, fin);
        //}
    }
}
