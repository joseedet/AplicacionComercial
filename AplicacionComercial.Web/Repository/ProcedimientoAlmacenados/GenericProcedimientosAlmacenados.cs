using AplicacionComercial.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AplicacionComercial.Common.Interfaces;
using AplicacionComercial.Web.Interfaces.ProcedimientosAl;

namespace AplicacionComercial.Web.Repository.ProcedimientoAlmacenados
{
    public class GenericProcedimientosAlmacenados<T> : IStoreProcedure<T> where T : class
    {
        private readonly DataContext _dataContext;
        public GenericProcedimientosAlmacenados(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Task<T> Actualizar(string nombre, T entity)
        {
            throw new NotImplementedException();
        }

        public Task Actualizar(string nombre, int id)
        {
            throw new NotImplementedException();
        }
        
        public async Task Actualizar(T entity)
        {
            _dataContext.Update(entity);
             await _dataContext.SaveChangesAsync();
        }

        /// <summary>
        /// Función no implementada.Agrega registro por procedimiento almacenado. 
        /// </summary>
        /// <param name="nombre">Nombre del procedimiento almacenado.</param>
        /// <param name="entity">Entidad. Aqui recogemos todos los parámetros.</param>
        /// <returns>int</returns>
        public int Agregar(string nombre, T entity)
        {

            throw new NotImplementedException();
        }

        public async Task Agregar(T entity)
        {
            await _dataContext.AddAsync(entity);
        }

        public async Task Eliminar(T entity)
        {
            _dataContext.Remove(entity);
           await _dataContext.SaveChangesAsync();
        }

        public Task Eliminar(string nombre, int id)
        {

            throw new NotImplementedException();
        }

        public Task<List<T>> Listar(bool activo, string nombre,T entity)
        {

            throw new NotImplementedException();
        }

        public Task<List<T>> Listar(bool activo, string nombre)
        {
            throw new NotImplementedException();
        }

        async Task IStoreProcedure<T>.Agregar(string nombre, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
