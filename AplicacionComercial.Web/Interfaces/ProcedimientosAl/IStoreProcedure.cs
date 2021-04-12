using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces.ProcedimientosAl
{
    public interface IStoreProcedure<T> where T :class
    {
        Task<List<T>> Listar(bool activo, string nombre);
        Task Agregar(string nombre,T entity);
        Task Agregar(T entity);
        Task Actualizar(string nombre, int id);
        Task Actualizar(T entity);
        Task Eliminar(T entity);
        Task Eliminar(string nombre, int id);
    }
}
