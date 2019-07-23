using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Dapper;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(string connectionString) : base(connectionString)
        {

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
