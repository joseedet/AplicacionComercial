using AplicacionComercial.Common.Enum;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionComercial.Web.Models
{
    public class AddUserViewModel 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public int IdtipoDocumento { get; set; }

        [Required]
        public string Documento { get; set; }

        [Required]
        [Display(Name = "Razón Social")]
        public string NombreComercial { get; set; }

        [Required]
        [Display(Name = "Nombre Contacto")]
        public string NombresContacto { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public string ApellidosContacto { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        [MaxLength(50, ErrorMessage = "50 carácteres máximo")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Código Postal")]
        [MaxLength(5, ErrorMessage = "Máximo 5 cáracteres")]
        public string CodPostal { get; set; }

        [Required]
        [Display(Name = "Población")]
        [MaxLength(50, ErrorMessage = "50 carácteres como máximo")]
        public string Poblacion { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "50 carácteres como máximo")]
        public string Provincia { get; set; }

        public string Foto { get; set; }
        public string Notas { get; set; }
        public DateTime? Aniversario { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }

        [DisplayName(displayName:"Tipo Usuario")]
        public UserType UserType { get; set; }
       
    }
}
