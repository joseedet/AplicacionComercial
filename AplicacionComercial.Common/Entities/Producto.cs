using AplicacionComercial.Common.Interfaces;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Producto:IEntity
    {
        public int Id { get; set; }

        [Required]

        public string Descripcion { get; set; }

        [Required]
        [MaxLength(50,ErrorMessage ="El {0} no puede contener más de 50 carácteres")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public int Iddepartamento { get; set; }

        [Required]
        [Display(Name = "IVA")]
        public int Idiva { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }


        public string Notas { get; set; }
       // public string Imagen { get; set; }

        [Required]
        [Display(Name = "Medida")]
        public int Idmedida { get; set; }

        [Required]
        [Display(Name = "Unidades")]
        public double Medida { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }


        [DisplayName("Número imágenes producto")]
        public int NumeroImagenesProducto => ImagenesProducto == null ? 0 : ImagenesProducto.Count;

        [Required]
        [Display(Name = "Departamento")]
        public virtual Departamento IddepartamentoNavigation { get; set; }

        [Required]
        [Display(Name = "IVA")]
        public virtual Iva IdivaNavigation { get; set; }

        [Required]
        [Display(Name = "Medida")]
        public virtual Medida IdmedidaNavigation { get; set; }

        public ICollection<ImagenProducto> ImagenesProducto { get; set; }

    }
}
