using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;
using Cibertec.Repositories.Northwind;
using System.Data.SqlClient;
using Dapper;

namespace Cibertec.Repositories.Dapper.Northwind
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(string connectionString): base(connectionString)
        {

        }
        public User ValidateUser(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            { 
                return connection.QueryFirstOrDefault<User>("ValidateUser", new { email, password }, commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
