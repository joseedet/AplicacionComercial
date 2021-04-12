using AplicacionComercial.Common.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IImagenProducto:IGenericRepository<ImagenProducto> 
    {
        
        public Task<ImagenProducto> GetImagenProductoById(int id);
        public ImagenProducto InsertarImagenProducto(ImagenProducto imagenProducto);
        
    }
}
