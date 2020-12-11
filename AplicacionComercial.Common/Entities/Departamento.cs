using AplicacionComercial.Common.Interfaces;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Departamento:IEntity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }

        public virtual ICollection<Producto> Producto { get; set; }
    }
}
