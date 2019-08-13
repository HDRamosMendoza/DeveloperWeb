using Cibertec.Repositories.Dapper.Northwind;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cibertec.Pruebas
{
    [TestClass]
    public class ProductRepositoryTests
    {
        // Indicar la cadena de cconexion
        private readonly string _connectionString = "Server=.;database=northwind_lite;trusted_connection=true;";

        [TestMethod]
        public void ProductListNotNull()
        {
            // Instanciar el unitOfWork
            var unitOfWork = new NorthwindUnitOfWork(_connectionString);
            // Obtener la lista de productos
            var listaProductos = unitOfWork.Products.GetList();
            // Hacer la comprobacion
            Assert.IsNotNull(listaProductos);

        }

        [TestMethod]
        public void ProductListLengthGreaterThan0()
        {
            // Instanciar el unitOfWork
            var unitOfWork = new NorthwindUnitOfWork(_connectionString);
            // Obtener la lista de productos
            var listaProductos = unitOfWork.Products.GetList();
            // Hacer la comparacion
            Assert.AreNotEqual(0, listaProductos.Count());
        }

    }
}
