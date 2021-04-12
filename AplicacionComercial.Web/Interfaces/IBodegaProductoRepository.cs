using AplicacionComercial.Common.Entities;

using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IBodegaProductoRepository : IGenericRepository<BodegaProducto>
    {
        Task<BodegaProducto> GetBodegaProductoAsync(int idProducto, int idAlmacen);
        Task<bool> ExistAsync(int idBodega, int idProducto);

    }
}
