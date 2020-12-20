using AplicacionComercial.Common.Entities;

using Microsoft.AspNetCore.Http;

namespace AplicacionComercial.Web.Models
{
    public class ImagenProductoViewModel : ImagenProducto
    {
        public IFormFile Image { get; set; } = null;
    }
}
