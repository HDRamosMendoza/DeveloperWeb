using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using Cibertec.UnitOfWork;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public IProductRepository Products { get; }
        public ISupplierRepository Suppliers { get; }
        public IUserRepository Users { get; }

        public NorthwindUnitOfWork(string connectionString)
        {
            Products = new ProductRepository(connectionString);
            Suppliers = new SupplierRepository(connectionString);
            Users = new UserRepository(connectionString);
            // aquí se deberán inicializar los demás repositorios
        }
    }
}
