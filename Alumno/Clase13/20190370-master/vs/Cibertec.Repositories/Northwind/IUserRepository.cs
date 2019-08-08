using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Models;

namespace Cibertec.Repositories.Northwind
{
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        /// Este método va a servir para invocar el SP ValidateUser
        /// </summary>
        /// <param name="email">heber.daniel.ramos.mendoza@gmail.com</param>
        /// <param name="password">HDRamosMendoza</param>
        /// <returns>Un objeto del tipo User. Si no encuentra ningún registro retorna null</returns>
        User ValidateUser(string email, string password);
    }
}
