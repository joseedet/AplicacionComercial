using AplicacionComercial.Common.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;

namespace AplicacionComercial.Common.Entities
{
    public class CompraDetalle:IEntity
    {
        public int Id { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public int KardexId { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public float Cantidad { get; set; }
        public float PorcentajeIVA { get; set; }
        public float PorcentajeDescuento { get; set; }


    }
}
