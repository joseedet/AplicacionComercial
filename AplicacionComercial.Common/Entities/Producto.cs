using AplicacionComercial.Common.Interfaces;

using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Producto:IEntity
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public int Iddepartamento { get; set; }

        [Required]
        [Display(Name = "IVA")]
        public int Idiva { get; set; }

        [Required]
        public decimal Precio { get; set; }
        public string Notas { get; set; }
        public string Imagen { get; set; }

        [Required]
        [Display(Name = "Medida")]
        public string Idmedida { get; set; }

        [Required]
        [Display(Name = "Unidades")]
        public double Medida { get; set; }

        public bool Activo { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        public virtual Departamento IddepartamentoNavigation { get; set; }

        [Required]
        [Display(Name = "IVA")]
        public virtual Iva IdivaNavigation { get; set; }

        [Required]
        [Display(Name = "Medida")]
        public virtual Medida IdmedidaNavigation { get; set; }

    }
}
