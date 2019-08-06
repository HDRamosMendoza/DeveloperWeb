using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Data.SqlClient;
using Cibertec.Models.ViewModels;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {

        }

        public IEnumerable<ProductViewModel> GetListWithDetails()
        {
            // debería ser reemplazado por un SP
            var sql = @"select p.*, s.ContactName + ' - ' + s.CompanyName as                      SupplierName
                        from Product p left join Supplier s
                        on p.SupplierId = s.Id";

            using (var connection = new SqlConnection(_connectionString))
            {
                // hacer la consulta en BD y mapear los resultados con la clase ProductViewModel
                return connection.Query<ProductViewModel>(sql);
            }
        }

        public IEnumerable<Product> ObtenerConPrecioMayorA(decimal precio)
        {
            var sql = @"select * from Product
                        where UnitPrice > @PriceParam";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Product>(sql, new { PriceParam = precio });
            }

        }
    }
}
