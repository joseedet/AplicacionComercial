using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class BodegaProducto
    {
        public int Idbodega { get; set; }
        public int Idproducto { get; set; }


        public double Stock { get; set; }

        [Display(Name = "Mínimo")]
        [Required]
        public double Minimo { get; set; }

        [Display(Name = "Máximo")]
        [Required]
        public double Maximo { get; set; }

        [Display(Name = "Días Reposición")]
        [Required]
        public int DiasReposicion { get; set; }

        [Display(Name = "Cantidad Mínima")]
        [Required]
        public double CantidadMinima { get; set; }

        public virtual Bodega IdbodegaNavigation { get; set; }
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
