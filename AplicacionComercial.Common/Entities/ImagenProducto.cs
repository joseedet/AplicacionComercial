using AplicacionComercial.Common.Interfaces;

using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class ImagenProducto : IEntity
    {
        public int Id { get; set; }

        public int IdProducto { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths
        [Display(Name = "Image")]
        public string ImageFullPath => ImageId == Guid.Empty
            ? $"https://localhost:44305/images/noimage.png"
            : $"https://onsale.blob.core.windows.net/products/{ImageId}";

        public virtual Producto IdproductoNavigation { get; set; }
    }
}
