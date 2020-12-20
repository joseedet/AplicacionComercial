using AplicacionComercial.Common.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IProductoRepository:IGenericRepository<Producto>
    {
        Task<List<Producto>> GetIndexResult();
        Task<Producto> GetProductoById(int id);
        Task<Producto> GetProductoAlmacen(int id);
    }
}
