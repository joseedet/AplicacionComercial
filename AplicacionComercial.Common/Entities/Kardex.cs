using AplicacionComercial.Common.Interfaces;

using System;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Kardex : IEntity
    {
        public int Id { get; set; }
        public int BodegaId { get; set; }
        public int ProductoId { get; set; }
        public DateTime Fecha { get; set; }

        [MaxLength(50)]
        public string Documento { get; set; }

        public float Entrada { get; set; }
        public float Salida { get; set; }

        [Display(Name ="Último Costo")]
        public decimal UltimoCosto { get; set; }

        [Display(Name ="Costo Promedio")]
        public decimal CostoPromedio { get; set; }
        public bool Activo { get; set; }
    }
}
