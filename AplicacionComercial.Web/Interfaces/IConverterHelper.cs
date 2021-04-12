using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Models;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IConverterHelper
    {
        Producto ToProductAsync(ProductoViewModel model, bool isNew);
        ProductoViewModel ToProductViewModel(Producto _producto);
        BodegaProducto ToAlmacenProducto(ProductoAlmacenViewModel model, bool isNew);
        ProductoAlmacenViewModel ToProductoAlmacenViewModel(BodegaProducto _bodegaProducto);
        ImagenProductoViewModel ToImagenProductViewModel(Producto producto);
        ImagenProducto ToImagenProducto(AddImagenProducto ImagenProductoViewModel);

       

        //ImagenProducto ToImagenProducto(Producto producto);

    }
}
