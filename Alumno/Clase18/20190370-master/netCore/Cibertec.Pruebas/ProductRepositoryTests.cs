using Cibertec.Repositories.Dapper.Northwind;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Cibertec.Pruebas
{
    [TestClass]
    public class ProductRepositoryTests
    {
        // indicar la cadena de conexión
        private readonly string _connectionString = "Server=.;database=northwind_lite;trusted_connection=true;";

        [TestMethod]
        public void ProductListNotNull()
        {            
            // instanciar el unitofwork
            var unitOfWork = new NorthwindUnitOfWork(_connectionString);
            // obtener la lista de productos
            var listaProductos = unitOfWork.Products.GetList();
            // hacer la comprobación
            Assert.IsNotNull(listaProductos);
        }

        [TestMethod]
        public void ProductListLengthGreaterThan0()
        {
            // instanciar el unitofwork
            var unitOfWork = new NorthwindUnitOfWork(_connectionString);
            // obtener la lista de productos
            var listaProductos = unitOfWork.Products.GetList();
            // hacer la comprobación
            Assert.AreNotEqual(0, listaProductos.Count());
        }
    }
}
