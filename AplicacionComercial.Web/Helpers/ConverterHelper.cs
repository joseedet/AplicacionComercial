using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

using System.Threading.Tasks;

namespace AplicacionComercial.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public async Task<Producto> ToProductAsync(ProductoViewModel model, bool isNew)
        {

            return new Producto
            {
                Id = isNew ? 0 : model.Id,
                Activo = model.Activo,
                Descripcion=model.Descripcion,
                Iddepartamento = model.Iddepartamento,
                Idiva = model.Idiva,
                Idmedida = model.Idmedida,
                Cantidad = model.Cantidad,
                Nombre = model.Nombre,
                Notas = model.Notas,
                Precio = model.Precio,
                ImagenesProducto = model.ImagenesProducto


            };

        }
        public ProductoViewModel ToProductViewModel(Producto producto)
        {
            return new ProductoViewModel
            {
                Id = producto.Id,
                Activo = producto.Activo,
                Descripcion=producto.Descripcion,
                Iddepartamento = producto.Iddepartamento,
                Idiva = producto.Idiva,
                Idmedida = producto.Idmedida,
                Cantidad = producto.Cantidad,
                Nombre = producto.Nombre,
                Notas = producto.Notas,
                Precio = producto.Precio,
                ImagenesProducto = producto.ImagenesProducto

            };
        }
    }
}
