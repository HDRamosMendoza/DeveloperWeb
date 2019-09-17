using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cibertec.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;

namespace Cibertec.Repositories.Dapper
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly string _connectionString;

        public Repository(string connectionString)
        {
            // deshabilitar pluralización de tablas
            SqlMapperExtensions.TableNameMapper = (type) =>
            {
                return $"[{type.Name}]";
            };
            _connectionString = connectionString;
        }

        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Delete(entity);
            }
        }

        public T GetById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>(id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert(entity);
            }
        }

        public bool Update(T entity)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    return connection.Update(entity);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
