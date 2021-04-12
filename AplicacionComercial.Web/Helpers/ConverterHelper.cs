using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

using System.Threading.Tasks;

namespace AplicacionComercial.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public ProductoAlmacenViewModel ToProductoAlmacenViewModel(BodegaProducto model)
        {
            return new ProductoAlmacenViewModel
            {
                //Idbodega = model.Idbodega,
                //Idbodega=model.
                Idbodega=model.Idbodega,
                Idproducto=model.Idproducto,
                CantidadMinima=model.CantidadMinima,
                DiasReposicion = model.DiasReposicion,
                Maximo = model.Maximo,
                Minimo = model.Minimo,
                Stock = model.Stock
            };
        }

        public BodegaProducto ToAlmacenProducto(ProductoAlmacenViewModel model, bool isNew)
        {
            return new BodegaProducto
            {
                //Id = isNew ? 0 : model.Id,
                Idbodega = model.Idbodega,
                Idproducto=model.Idproducto,
                CantidadMinima=model.CantidadMinima,
                DiasReposicion=model.DiasReposicion,
                Maximo=model.Maximo,
                Minimo=model.Minimo,
                Stock=model.Stock


            };
        }

        public Producto ToProductAsync(ProductoViewModel model, bool isNew)
        {

            return new Producto
            {
                //Id = (Product)isNew ? 0 : model.Id,
                Activo = model.Activo,
                Descripcion=model.Descripcion,
                Iddepartamento = model.Iddepartamento,
                Idiva = model.Idiva,
                Idmedida = model.Idmedida,               
                Nombre = model.Nombre,
                Notas = model.Notas,
                Precio = model.Precio,
                //ImagenesProducto = model.ImagenesProducto


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
                Nombre = producto.Nombre,
                Notas = producto.Notas,
                Precio = producto.Precio,
                //ImageFullPath=producto.ImageFullPath,
                //ImagenesProducto = producto.ImagenesProducto

            };
        }
        public ImagenProductoViewModel ToImagenProductViewModel(Producto producto)
        {
            return new ImagenProductoViewModel
            {

                Descripcion = producto.Descripcion,
                Nombre = producto.Nombre,
                ImagenesProducto = producto.ImagenesProducto,
                Id = producto.Id,
                //Activo = imagenProducto.Activo,
                //Iddepartamento = imagenProducto.Iddepartamento,
                //Idiva = imagenProducto.Idiva,
                //Idmedida = imagenProducto.Idmedida,
                //Notas = imagenProducto.Notas,
                //Precio = imagenProducto.Precio,


            };
            //throw new System.NotImplementedException();
        }
        public  ImagenProducto ToImagenProducto(AddImagenProducto ImagenProductoViewModel)
        {

            return new ImagenProducto
            {
                 ProductoId= ImagenProductoViewModel.Id,
                 ImageId= ImagenProductoViewModel.ImageId

            };
        }

        //public ImagenProducto ToImagenProducto(Producto producto)
        //{
        //    return new ImagenProducto
        //    {
        //        ProductoId = producto.Id,
        //        ImageId = producto.

        //    };
            
        //}

        public ImagenProducto ToImagenProducto(int id)
        {
            throw new System.NotImplementedException();
        }

        //public Task<Producto> IConverterHelper.ToProductAsync(ProductoViewModel model, bool isNew)
        //{
        //    throw new System.NotImplementedException();
        //}
        Task<ImagenProducto>ToImagenProductoAsync(Producto producto)
        {
            //return new ImagenProducto
            //{
            //    Id=producto.
            //}
            throw new System.NotImplementedException();
        }

       
    }
}
