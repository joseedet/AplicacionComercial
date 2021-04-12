using AplicacionComercial.Common.Interfaces;

using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class ImagenProducto :IEntity
    {
        public int  Id { get; set; }
        public int ProductoId { get; set; }        

        [Display(Name = "Image")]
        [MaxLength(50)]
        public string ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == string.Empty
            ? $"https://localhost:44305/image/noimage.png"
            : $"https://localhosot:44305/image/produto/";

       
        public virtual Producto IdproductoNavigation { get; set; }
    }
}
