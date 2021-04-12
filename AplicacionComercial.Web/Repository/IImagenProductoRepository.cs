using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Data;
using AplicacionComercial.Web.Interfaces;


using System;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Repository
{
    public class IImagenProductoRepository : GenericRepository<ImagenProducto>, IImagenProducto
    {
        private readonly DataContext _dataContext;
        public IImagenProductoRepository(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;

        }

        public async Task<ImagenProducto> GetImagenProductoById(int id)
        {
            //return await _dataContext.ImagenesProducto.
            throw new NotImplementedException();
            

        }

        public ImagenProducto InsertarImagenProducto(ImagenProducto imagenProducto)
        {
            
            throw new NotImplementedException();
        }

    }
}
