using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository : IRepository<Product>
    {
        // podrían ir métodos particulares sobre el modelo de Producto
        IEnumerable<Product> ObtenerConPrecioMayorA(decimal precio);
    }
}
