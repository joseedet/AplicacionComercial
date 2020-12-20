using AplicacionComercial.Common.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Models
{
    public class ProductoAlmacenViewModel:Producto
    {

        public BodegaProducto Almacen { get; set; }
        public int IdAlmacen { get; set; }
    }
}
