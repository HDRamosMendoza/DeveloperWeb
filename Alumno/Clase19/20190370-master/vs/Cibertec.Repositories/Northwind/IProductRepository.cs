using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.Models.ViewModels;

namespace Cibertec.Repositories.Northwind
{
    public interface IProductRepository : IRepository<Product>
    {
        // podrían ir métodos particulares sobre el modelo de Producto
        IEnumerable<Product> ObtenerConPrecioMayorA(decimal precio);

        /// <summary>
        /// Este método servirá para obtener la lista de todos los productos incluyendo el nombre de cada proveedor
        /// </summary>
        /// <returns></returns>
        IEnumerable<ProductViewModel> GetListWithDetails();
    }
}
