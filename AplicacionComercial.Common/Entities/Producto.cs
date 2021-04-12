using AplicacionComercial.Common.Interfaces;

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AplicacionComercial.Common.Entities
{
    public class Producto : IEntity
    {
        public int Id { get; set; }

        //[Required]
        //[DefaultValue(true)]
        public bool Activo { get; set; }

        //[Required]
        public string Descripcion { get; set; }

        //[Required]
        [MaxLength(50, ErrorMessage = "El {0} no puede contener más de 50 carácteres")]
        public string Nombre { get; set; }

        //[Required]
        [Display(Name = "Departamento")]
        public int Iddepartamento { get; set; }

        //[Required]
        [Display(Name = "IVA")]
        public int Idiva { get; set; }

        //[Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Precio { get; set; }


        public string Notas { get; set; }
        public string Imagen { get; set; } 

        //[Required]
        [Display(Name = "Medida")]
        public int Idmedida { get; set; }



        [DisplayName("Núm. Imágenes")]
        public int NumeroImagenesProducto => ImagenesProducto == null ? 0 : ImagenesProducto.Count;



        [DisplayName("Is Starred")]
        public bool IsStarred { get; set; }

        public virtual Departamento Departamento { get; set; }



        public virtual Iva Iva { get; set; }


        public virtual Medida Medida { get; set; }

      

        public ICollection<ImagenProducto> ImagenesProducto { get; set; }
        public ICollection<BodegaProducto> BodegaProductos { get; set; }
        public ICollection<Barra> Barras { get; set; }
        //public ICollection<Barra> Barras { get; set; }


        [Display(Name = "Image")]
        public string ImageFullPath => ImagenesProducto == null || ImagenesProducto.Count == 0
        ? $"https://localhost:44334/image/noimage/noimage.png"
        : ImagenesProducto.FirstOrDefault().ToString();
    }
}
