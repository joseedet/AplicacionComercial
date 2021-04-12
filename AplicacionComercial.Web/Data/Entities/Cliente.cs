using AplicacionComercial.Common.Enum;
using AplicacionComercial.Common.Interfaces;

using Microsoft.AspNetCore.Identity;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Data.Entities
{
    public class Cliente :User
    {
        public int ClienteId { get; set; }
        //public int TipoDocumentoId { get; set; }

        //[Required]
        //public string Documento { get; set; }

        //[Required]
        //[Display(Name = "Razón Social")]
        //public string NombreComercial { get; set; }

        //[Required]
        //[Display(Name = "Nombre Contacto")]
        //public string NombresContacto { get; set; }

        //[Required]
        //[Display(Name = "Apellidos")]
        //public string ApellidosContacto { get; set; }

        //[Required]
        //[Display(Name = "Dirección")]
        //[MaxLength(50, ErrorMessage = "50 carácteres máximo")]
        //public string Direccion { get; set; }

        //[Required]
        //[Display(Name = "Código Postal")]
        //[MaxLength(5, ErrorMessage = "Máximo 5 cáracteres")]
        //public string CodPostal { get; set; }

        //[Required]
        //[Display(Name = "Población")]
        //[MaxLength(50, ErrorMessage = "50 carácteres como máximo")]
        //public string Poblacion { get; set; }

        //[Required]
        //[MaxLength(50, ErrorMessage = "50 carácteres como máximo")]
        //public string Provincia { get; set; }

        //[Required]
        //[MaxLength(9, ErrorMessage = "9 carácteres como máximo")]
        //[DataType(DataType.PhoneNumber)]
        //public string Movil { get; set; }


        //[MaxLength(9, ErrorMessage = "9 carácteres como máximo")]
        //[DataType(DataType.PhoneNumber)]
        //public string Telefono { get; set; }

        //[Required]
        //[DataType(DataType.EmailAddress)]
        //public string Correo { get; set; }
        //public string Foto { get; set; }
        //public string Notas { get; set; }
        //public DateTime? Aniversario { get; set; }


        //[Required]
        //[DefaultValue(true)]
        //public bool Activo { get; set; }

        //public  UserType UserType{get;set;}

        //[Display(Name = "Tipo Documento")]
        public virtual TipoDocumento IdtipoDocumentoNavigation { get; set; }
    }
}
