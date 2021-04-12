using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Repository
{
    public class BodegaProductoRepository :  IBodegaProductoRepository
    {
        private readonly DataContext _dataContext;
        public BodegaProductoRepository(DataContext dataContext) 
        {
            _dataContext = dataContext;

        }

        public async Task CreateAsync(BodegaProducto entity)
        {
            await _dataContext.AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(BodegaProducto entity)
        {
            _dataContext.Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public  async Task<bool> ExistAsync(int idBodega,int idProducto)
        {
            return await _dataContext.Set<BodegaProducto>().AnyAsync(e => e.Idbodega==idBodega && e.Idproducto==idProducto);
            //return await _dataContext.Set<T>().AnyAsync(e => e.Id == id);
        }

        public async Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<BodegaProducto> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<BodegaProducto> GetAll(int pageNumber)
        {
            throw new NotImplementedException();
        }

        public Task<IAsyncEnumerable<BodegaProducto>> GetAllList()
        {
            throw new NotImplementedException();
        }

        public async Task<BodegaProducto> GetBodegaProductoAsync(int idProducto, int idAlmacen)
        {
            return await _dataContext.BodegaProductos
                    .FirstOrDefaultAsync(p => p.Idproducto == idProducto
                    && p.Idbodega == idAlmacen);
            //throw new Exception();
        }

        public Task<BodegaProducto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(BodegaProducto entity)
        {
            _dataContext.BodegaProductos.Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }
}
