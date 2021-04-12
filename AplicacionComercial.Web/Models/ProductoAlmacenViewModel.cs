using AplicacionComercial.Common.Entities;

using Microsoft.AspNetCore.Mvc.Rendering;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Models
{
    public class ProductoAlmacenViewModel : BodegaProducto
    {
        [Display(Name = "Almacén")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione una almacén.")]
        [Required]
        //public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Almacenes { get; set; }

    }
}
