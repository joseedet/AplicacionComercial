﻿using AplicacionComercial.Common.Entities;

using Microsoft.AspNetCore.Http;

namespace AplicacionComercial.Web.Models
{
    public class ProductoViewModel : Producto
    {
        public IFormFile Image { get; set; } = null;
    }
}
