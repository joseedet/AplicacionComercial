using AplicacionComercial.Common.Entities;
using AplicacionComercial.Web.Interfaces;
using AplicacionComercial.Web.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Task<Producto> ToProductAsync(ProductoViewModel model, bool isNew)
        {
            //return new Producto{ Activo=model.Activo,

            throw new NotImplementedException();
            //};

        }

        public ProductoViewModel ToProductViewModel(Producto _producto)
        {
            throw new NotImplementedException();
        }
    }
}
