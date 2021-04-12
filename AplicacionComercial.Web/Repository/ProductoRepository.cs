using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Repository
{
    public class ProductoRepository : GenericRepository<Producto>, IProductoRepository
    {
        private readonly DataContext _dataContext;
        public ProductoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Producto> GetProductoAlmacen(int idProducto)
        {
            //throw new System.NotImplementedException();
            return await _dataContext.Productos
                .Include(p => p.BodegaProductos)
                .FirstOrDefaultAsync(p => p.Id == idProducto);
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _dataContext.Productos
                 .Include(p => p.Iddepartamento)
                 .Include(p => p.Idiva)
                 .Include(p => p.Idmedida)
                 .FirstOrDefaultAsync(m => m.Id == id);
        }


        public async Task<Producto> GetProductoCodBarraAsync(int idProducto)
        {
            return await _dataContext.Productos
                .Include(p => p.Barras)
                .FirstOrDefaultAsync(p => p.Id == idProducto);
            //throw new System.Exception();
        }

        public async Task<List<Producto>> GetIndexResult()
        {
            return await _dataContext.Productos.Include(p => p.Departamento)
                 .Include(p => p.Iva)
                 .Include(p => p.Medida)
                 .ToListAsync();
        }

        public async Task<List<Producto>> GetImagenProductoById(int idP)
        {
            //return await _dataContext.Productos.Include(p => p.Departamento)
            //    .Include(p => p.Iva)
            //    .Include(p => p.Medida)
            //    .Include(i=>i.ImagenesProducto)               
            //    .ToListAsync();

            //var query = from ps in _dataContext.Productos
            //            from im in _dataContext.ImagenesProducto
            //            where ps.Id == idProducto && ps.Id==im.idProducto
            //            select ps.IdProducto.ToListAsync;


            return await _dataContext.Productos
                        .Include(i => i.ImagenesProducto)
                        .ToListAsync();


            //throw new System.NotImplementedException();
        }

        public async Task<Producto> GetProductoDetallesImagenProducto(int id)
        {

            return await _dataContext.Productos
                .Include(p => p.ImagenesProducto)
                .FirstOrDefaultAsync(p => p.Id == id);
            //throw new System.NotImplementedException();
        }

        //public async Task<List<Producto>> GetProductoDetallesImagenProducto(int id)
        //{

        //    return await _dataContext.Productos
        //                   .Include(i=> i.ImagenesProducto)
        //                   .ToListAsync();

        //    //throw new System.NotImplementedException();
        //}

        //public Task<List<Producto>> GetImagenProductoById(int id)
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
