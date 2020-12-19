using AplicacionComercial.Common.Entities;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Models
{
    public class ProductoViewModel : Producto
    {

        [Display(Name = "Departamento")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un departamento.")]
        [Required]
        public int IdDepartamento { get; set; }
        public IEnumerable<SelectListItem> Departamentos { get; set; }


        [Display(Name = "IVA")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione un tipo de IVA.")]
        [Required]
        public int IdIva { get; set; }
        public IEnumerable<SelectListItem> IVAs { get; set; }


        [Display(Name = "Medida")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de medida.")]
        [Required]
        public int IdMedida { get; set; }
        public IEnumerable<SelectListItem> Medidas { get; set; }


        //[Display(Name = "Unidades")]
        //[Range(1, int.MaxValue, ErrorMessage = "Seleccione tipo de unidad.")]
        //[Required]
        //public int Id { get; set; }
        //public IEnumerable<SelectListItem> Unidades { get; set; }
    }
}
