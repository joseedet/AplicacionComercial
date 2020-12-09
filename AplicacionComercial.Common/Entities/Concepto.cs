﻿using AplicacionComercial.Common.Interfaces;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionComercial.Common.Entities
{
    public class Concepto:IEntity
    {
        public int Id { get; set; }

        [MaxLength(75)]
        [Required]

        public string Descripcion { get; set; }

        [Required]
        [DefaultValue(true)]
        public bool Activo { get; set; }
    }
}
