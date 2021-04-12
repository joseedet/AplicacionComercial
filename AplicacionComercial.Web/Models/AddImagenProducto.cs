using AplicacionComercial.Common.Entities;

using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplicacionComercial.Web.Models
{
    public class AddImagenProducto:ImagenProducto
    {
        public IFormFile Image { get; set; }
    }
}
