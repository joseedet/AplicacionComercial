using AplicacionComercial.Common.Enum;
using AplicacionComercial.Common.Interfaces;
using AplicacionComercial.Web.Data.Entities;

using Microsoft.AspNetCore.Identity;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Data.Entities
{
    public class Proveedor : IEntity
    {
        public int Id { get; set; }

        public int TipoDocumentoId { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }

        [Display(Name = "Apellidos")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string ApellidosContacto { get; set; }


        [Display(Name = "C. Postal")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string CodPostal { get; set; }


        [Required(ErrorMessage = "Correo es obligatorio")]
        public string Correo { get; set; }


        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Direccion { get; set; }


        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Documento { get; set; }


        [Display(Name = "Razón Social")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Nombre { get; set; }


        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string NombresContacto { get; set; }


        [Display(Name = "T. Movil")]
        [Required(ErrorMessage = "Teléfono móvil es obligatorio")]
        public string Movil { get; set; }


        public string Notas { get; set; }


        [Display(Name = "Población")]
        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Poblacion { get; set; }

        [Required(ErrorMessage = "El {0} es obligatorio")]
        public string Provincia { get; set; }


        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Tipo de Usuario")]

        public UserType UserType { get; set; }
        
       
        public virtual TipoDocumento IdtipoDocumentoNavigation { get; set; }
    }
}
