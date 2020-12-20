using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Models;

using System.Threading.Tasks;

namespace AplicacionComercial.Web.Interfaces
{
    public interface IConverterHelper
    {
        Task<Producto> ToProductAsync(ProductoViewModel model, bool isNew);
        ProductoViewModel ToProductViewModel(Producto _producto);
        BodegaProducto ToAlmacenProducto(ProductoAlmacenViewModel model);
        ProductoAlmacenViewModel ProductoAlmacenViewModel(BodegaProducto _bodegaProducto);
    }
}
