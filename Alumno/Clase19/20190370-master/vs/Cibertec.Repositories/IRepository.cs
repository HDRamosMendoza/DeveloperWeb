using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Repositories
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Para eliminar un registro
        /// </summary>
        /// <returns>
        /// Devuelve verdadero si es que se eliminó correctamente
        /// </returns>
        bool Delete(T entity);

        /// <summary>
        /// Para actualizar un registro
        /// </summary>
        /// <returns>
        /// Devuelve verdadero si es que se actualizó correctamente. Falso si no actualizó ninguno
        /// </returns>
        bool Update(T entity);

        /// <summary>
        /// Para insertar un nuevo registro
        /// </summary>
        /// <returns>
        /// Devuelve el id del nuevo registro
        /// </returns>
        int Insert(T entity);

        /// <summary>
        /// Obtener la lista de todos los registros de la tabla
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetList();

        /// <summary>
        /// Obtener un registro en base a su ID
        /// </summary>
        /// <returns>
        /// Un solo registro tipo T
        /// </returns>
        T GetById(int id);
    }
}
