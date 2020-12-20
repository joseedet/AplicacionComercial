using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;

using Microsoft.EntityFrameworkCore;

using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace AplicacionComercial.Web.Repository
{
    public class ProductoRepository : GenericRepository<Producto>,IProductoRepository
    {
        private readonly DataContext _dataContext;
        public ProductoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Producto> GetProductoById(int id)
        {
            return await _dataContext.Productos
                 .Include(p => p.Iddepartamento)
                 .Include(p => p.Idiva)
                 .Include(p => p.Idmedida)
                 .FirstOrDefaultAsync(m => m.Id == id);
        }
       

        async Task<List<Producto>> IProductoRepository.GetIndexResult()
        {
           return await _dataContext.Productos.Include(p => p.Departamento)
                .Include(p => p.Iva)
                .Include(p => p.Medida).ToListAsync();
        }
    }
}
