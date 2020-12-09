using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using AplicacionComercial.Common.Interfaces;

namespace AplicacionComercial.Common.Entities
{
    public class Bodega:IEntity
    {
        public int Id  {get; set;}

        [Display(Name = "Almacén")]
        [Required]
        public string Descripcion {get; set;}

        [Required]
        [DefaultValue(true)]
        public bool Activo {get;set;}
    }
}
