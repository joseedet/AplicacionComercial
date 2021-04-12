using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Barra
    {
        public int Idproducto { get; set; }

        [Display(Name = "Cod.Barras")]
        public long Barra1 { get; set; }

        public bool Activo { get; set; }


        public virtual Producto IdproductoNavigation { get; set; }
    }
}
