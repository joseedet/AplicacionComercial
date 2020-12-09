using AplicacionComercial.Common.Interfaces;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Iva:IEntity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Descripcion { get; set; }

        [Required]
        public double Tarifa { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }
    }
}
