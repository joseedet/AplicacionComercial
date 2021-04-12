using AplicacionComercial.Common.Interfaces;

using System;

namespace AplicacionComercial.Web.Data.Entities
{
    public class Compra : IEntity
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public User Proveedor { get; set; }
        public int BodegaId { get; set; }
    }
}
