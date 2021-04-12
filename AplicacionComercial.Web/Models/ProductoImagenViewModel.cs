using AplicacionComercial.Common.Entities;
using AplicacionComercial.Common.Interfaces;

using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Web.Models
{
    public class ProductoImagenViewModel : Producto, IEntity
    {

        public new int Id { get; set; }
        public int ProductoId { get; set; }
        public string Carpeta { get; set; }

        [Display(Name = "Image")]
        public Guid ImageId { get; set; }

        //TODO: Pending to put the correct paths

    }
}
