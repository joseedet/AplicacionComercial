using AplicacionComercial.Common.Entities;

using Microsoft.AspNetCore.Http;

using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Models
{
    public class ImagenProductoViewModel : Producto
    {

        public int IdProducto { get; set; }        

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        [Display(Name = "Image")]
        public new string  ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44305/images/noimage.png"
            : $"https://localhost:44305/images/producto";

        
    }
}
