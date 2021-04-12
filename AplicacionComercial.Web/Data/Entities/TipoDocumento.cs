using AplicacionComercial.Common.Interfaces;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Data.Entities
{
    public class TipoDocumento : IEntity
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }

        //public virtual ICollection<User> Clientes { get; set; }
        //public virtual ICollection<User> Proveedores { get; set; }
    }
}
