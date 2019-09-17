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
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {

        }
    }
}
